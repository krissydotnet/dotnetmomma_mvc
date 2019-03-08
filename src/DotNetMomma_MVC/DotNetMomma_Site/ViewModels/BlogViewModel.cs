using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_Site.ViewModels
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

        public BlogViewModel(PostRepository postRepository, string text, string type, int p, int pageSize)
   
        {
            PageSize = pageSize;
            switch (type)
            {
                case "Tag":
                    Posts = postRepository.PostsForTag(text, p - 1, 10);
                    TotalPosts = postRepository.TotalPostsForTag(text);
                    Tag = postRepository.Tag(text);
                    break;
                case "Category":
                    Posts = postRepository.PostsForCategory(text, p - 1, pageSize);
                    TotalPosts = postRepository.TotalPostsForCategory(text);
                    PostCategory = postRepository.PostCategory(text);
                    break;
                default:
                    Posts = postRepository.PostsForSearch(text, p - 1, 10);
                    TotalPosts = postRepository.TotalPostsForSearch(text);
                    Search = text;
                    break;
            }

 
        }

        public BlogViewModel(PostRepository postRepository, int page = 1, int pageSize = 1, string urlSlug = null)
        {
            //PageSize = pageSize;
            //Posts = postRepository.Posts(page - 1, PageSize, urlSlug).ToList();
            //TotalPosts = postRepository.TotalPosts;

        }
        
        public IList<Post> Posts { get; private set; }
        public PostCategory PostCategory { get; private set; }
        public Tag Tag { get; private set; }
        public int TotalPosts { get; private set; }
        public int PageSize { get; set; }
        public string Search { get; private set; }
    }
}