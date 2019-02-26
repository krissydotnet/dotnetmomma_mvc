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
        private int pageSize = 10;

        public BlogViewModel(PostRepository postRepository, int page = 1, int catId = 0)
        {
            Posts = postRepository.Posts(page - 1, pageSize, catId).ToList();
            TotalPosts = postRepository.TotalPosts();
        }
        public List<Post> Posts { get; set; } 
        public int TotalPosts { get; set; }
    }
}