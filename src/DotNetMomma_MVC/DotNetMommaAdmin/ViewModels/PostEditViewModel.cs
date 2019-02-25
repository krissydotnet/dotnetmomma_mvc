using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMommaAdmin.ViewModels
{
    public class PostEditViewModel
        : PostBaseViewModel
    {

        public int Id
        {
            get { return Post.Id; }
            set { Post.Id = value; }
        }

    }
}