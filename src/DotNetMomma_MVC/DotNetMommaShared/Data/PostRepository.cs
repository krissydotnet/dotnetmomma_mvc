using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class PostRepository : BaseRepository<Post>
    {
        const string PostListKey = "PostList";

        public PostRepository(Context context) : base(context)
        {
        }

        public override Post Get(int id, bool includeRelatedEntities = true)
        {
            var posts = Context.Posts.AsQueryable();
            if (includeRelatedEntities)
            {
                posts = posts
                        .Include(p => p.PostCategory)
                        .Include(r => r.Tags.Select(t => t.Tag));
            }
            return posts
                .Where(r => r.Id == id)
                .SingleOrDefault();

        }

        public override IList<Post> GetList(bool includeRelatedEntities = true)
        {
            var postList = EntityCache.Get<List<Post>>(PostListKey);

            if (postList == null)
            {
                var posts = Context.Posts.AsQueryable();
                if (includeRelatedEntities)
                {
                    posts = posts
                        .Include(p => p.PostCategory)
                        .Include(p => p.Tags.Select(t => t.Tag));
                }
                postList = posts
                    .OrderBy(p => p.PostedOn)
                    .ToList();
            }
            return postList;

        }
        public override void Add(Post entity)
        {
            base.Add(entity);
            EntityCache.Remove(PostListKey);
        }
        public override void Update(Post entity)
        {
            base.Update(entity);
            EntityCache.Remove(PostListKey);

        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(PostListKey);
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {

            var posts = Context.Posts
                        .Where(p => p.Published)
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .ToList();


            var postIds = posts.Select(p => p.Id).ToList();

            return Context.Posts
                .Where(p => postIds.Contains(p.Id))
              .OrderByDescending(p => p.PostedOn)
              .Include(p => p.PostCategory)
              .Include(p => p.Tags.Select(t => t.Tag))
              .ToList();
        }

        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            var posts = Context.Posts
                                .Where(p => p.Published && p.PostCategory.UrlSlug.Equals(categorySlug))
                                .OrderByDescending(p => p.PostedOn)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Include(p => p.PostCategory)
                                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return Context.Posts
                          .Where(p => postIds.Contains(p.Id))
                          .OrderByDescending(p => p.PostedOn)
                          .Include(r => r.Tags.Select(t => t.Tag))
                          .ToList();
        }


        public PostCategory PostCategory(string categorySlug)
        {
            return Context.PostCategories
                        .FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            var posts = Context.Posts
                              .Where(p => p.Published && p.Tags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)))
                              .OrderByDescending(p => p.PostedOn)
                              .Skip(pageNo * pageSize)
                              .Take(pageSize)
                              .Include(p => p.PostCategory)
                              .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return Context.Posts
                          .Where(p => postIds.Contains(p.Id))
                          .OrderByDescending(p => p.PostedOn)
                          .Include(r => r.Tags.Select(t => t.Tag))
                          .ToList();
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return Context.Posts
                        .Where(p => p.Published && p.Tags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)))
                        .Count();
        }

        public Tag Tag(string tagSlug)
        {
            return Context.Tags
                .FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }


        public int TotalPosts() {
                return Context.Posts
                        .Where(p => p.Published).Count();
        }

        public int TotalPostsForCategory(string categorySlug)
        {

            return Context.Posts
                        .Where(p => p.Published && p.PostCategory.UrlSlug.Equals(categorySlug))
                        .Count();
        }
        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = Context.Posts
                                  .Where(p => p.Published && (p.Title.Contains(search) || p.PostCategory.Name.Equals(search) || p.Tags.Any(t => t.Tag.Name.Equals(search))))
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNo * pageSize)
                                  .Take(pageSize)
                                  .Include(p => p.PostCategory)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return Context.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .Include(r => r.Tags.Select(t => t.Tag))
                  .ToList();
        }

        public int TotalPostsForSearch(string search)
        {
            return Context.Posts
                    .Where(p => p.Published && (p.Title.Contains(search) || p.PostCategory.Name.Equals(search) || p.Tags.Any(t => t.Tag.Name.Equals(search))))
                    .Count();
        }

        public Post Post(int year, int month, string titleSlug)
        {
         
            return Context.Posts
                    .Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Equals(titleSlug))
                    .Include(p => p.PostCategory)
                    .Include(r => r.Tags.Select(t => t.Tag))
                    .SingleOrDefault();
        }
    }
}
