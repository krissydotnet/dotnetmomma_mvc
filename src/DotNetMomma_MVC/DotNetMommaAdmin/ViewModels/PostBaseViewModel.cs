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
    public abstract class PostBaseViewModel
    {
        public Post Post { get; set; } = new Post();
        public SelectList TagSelectListItems { get; set; }
        public SelectList CategorySelectListItems { get; set; }
        [Display(Name ="Tags")]
        public int TagId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        /// <summary>
        ///  Initializes the view model.
        /// </summary>

        public virtual void Init(TagRepository tagRepository, PostCategoryRepository categoryRepository)
        {

            TagSelectListItems = new SelectList(
                tagRepository.GetList(includeRelatedEntities: false), 
                "Id", "Name");


            CategorySelectListItems = new SelectList(
                categoryRepository.GetList(includeRelatedEntities: false),
                "Id", "Name");

        }

    }
}