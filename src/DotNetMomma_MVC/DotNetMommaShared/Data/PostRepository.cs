﻿using DotNetMommaShared.Models;
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

    }
}
