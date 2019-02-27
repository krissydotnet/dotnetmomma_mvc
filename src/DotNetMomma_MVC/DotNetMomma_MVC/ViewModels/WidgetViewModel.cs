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
        public WidgetViewModel(PostCategoryRepository categoryRepository)
        {
            PostCategories = categoryRepository.GetList();
        }
        public IList<PostCategory> PostCategories { get; set; }
    }
}