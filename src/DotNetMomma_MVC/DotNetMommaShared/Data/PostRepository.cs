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
            var posts = Context.Posts.AsQueryable();
            if (includeRelatedEntities)
            {
                posts = posts
                    .Include(p => p.PostCategory)
                    .Include(p => p.Tags.Select(t => t.Tag));
            }
            return posts
                .OrderBy(p => p.PostedOn)
                .ToList();
        }

        public IList<Post> Posts(int pageNo, int pageSize, int catId)
        {
            var posts = new List<Post>();

            if (catId != 0)
            {
                posts = Context.Posts
                        .Where(p => p.Published && p.PostCategoryId == catId)
                                .OrderByDescending(p => p.PostedOn)
                                 .Skip(pageNo * pageSize)
                                 .Take(pageSize)
                                 .ToList();
            } else
            {
                posts = Context.Posts
                        .Where(p => p.Published)
                                .OrderByDescending(p => p.PostedOn)
                                 .Skip(pageNo * pageSize)
                                 .Take(pageSize)
                                 .ToList();
            }
                
             
            var postIds = posts.Select(p => p.Id).ToList();

            return Context.Posts
                .Where(p => postIds.Contains(p.Id))
              .OrderByDescending(p => p.PostedOn)
              .Include(p => p.PostCategory)
              .Include(p => p.Tags.Select(t => t.Tag))
              .ToList();
        }

        public int TotalPosts()
        {
            return Context.Posts
                .Where(p => p.Published)
                .Count();
        }

    }
}
