using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMommaAdmin.ViewModels
{
    public class PostTagsAddViewModel
    {
        public int PostId
        {
            get { return Post.Id; }
            set { Post.Id = value; }
        }

        public Post Post { get; set; } = new Post();
        [Display(Name = "Tag")]
        public int TagId {get; set; }

        public SelectList TagSelectListItems { get; set; }

        public void Init(TagRepository tagRepository)
        {
            TagSelectListItems = new SelectList(
                tagRepository.GetList(includeRelatedEntities: false),
                "Id", "Name");

        }
    }
}