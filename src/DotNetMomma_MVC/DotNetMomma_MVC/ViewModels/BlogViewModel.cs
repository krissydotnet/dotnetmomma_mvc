using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.ViewModels
{
    public class BlogViewModel
    {

        public BlogViewModel(PostRepository postRepository, int p, int pageSize)
        {
            Posts = postRepository.Posts(p - 1, pageSize);
            TotalPosts = postRepository.TotalPosts();
            PageSize = pageSize;
            //Posts = postRepository.GetList();
        }

        public BlogViewModel(PostRepository postRepository, string categorySlug, int p, int pageSize)
        {

            Posts = postRepository.PostsForCategory(categorySlug, p - 1, pageSize);
            TotalPosts = postRepository.TotalPostsForCategory(categorySlug);
            PostCategory = postRepository.PostCategory(categorySlug);
            PageSize = pageSize;
        }

        public BlogViewModel(PostRepository postRepository, int page = 1, int pageSize = 1, string urlSlug = null)
        {
            //PageSize = pageSize;
            //Posts = postRepository.Posts(page - 1, PageSize, urlSlug).ToList();
            //TotalPosts = postRepository.TotalPosts;

        }
        
        public IList<Post> Posts { get; private set; }
        public PostCategory PostCategory { get; private set; }
        public int TotalPosts { get; private set; }
        public int PageSize { get; set; }
    }
}