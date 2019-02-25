using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetMommaShared.Data;

namespace DotNetMommaAdmin.ViewModels
{
    public class PostAddViewModel 
        : PostBaseViewModel
    {

        public PostAddViewModel()
        {

        }
        public override void Init(TagRepository tagRepository, PostCategoryRepository categoryRepository)
        {
            base.Init(tagRepository, categoryRepository);
            
        }
    }
}