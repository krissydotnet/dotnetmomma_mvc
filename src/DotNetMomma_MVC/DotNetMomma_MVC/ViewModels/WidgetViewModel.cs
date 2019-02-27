using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.ViewModels
{
    public class WidgetViewModel
    {
        public WidgetViewModel(PostRepository postRepository, PostCategoryRepository categoryRepository, TagRepository tagRepository)
        {
            PostCategories = categoryRepository.GetList();
            Tags = tagRepository.GetList();
            LatestPosts = postRepository.Posts(0, 10);
        }
        public IList<PostCategory> PostCategories { get; private set; }
        public IList<Tag> Tags { get; private set; }
        public IList<Post> LatestPosts { get; private set; }
    }
}