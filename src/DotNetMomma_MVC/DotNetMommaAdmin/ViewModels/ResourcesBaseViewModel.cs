using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMommaAdmin.ViewModels
{
    public abstract class ResourcesBaseViewModel
    {
        public Resource Resource { get; set; } = new Resource();

        public SelectList SectionSelectListItems { get; set; }
        public SelectList CategorySelectListItems { get; set; }

        /// <summary>
        ///  Initializes the view model.
        /// </summary>
        
        public virtual void Init(Repository repository, SectionsRepository sectionsRepository)
        {
            SectionSelectListItems = new SelectList(
                sectionsRepository.GetList(includeRelatedEntities: false), 
                "Id", "Name");

            CategorySelectListItems = new SelectList(
                repository.GetCategories(),
                "Id", "Name");

        }

    }
}