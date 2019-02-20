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
    public class ResourceTechnologiesAddViewModel
    {
        public int ResourceId
        {
            get { return Resource.Id; }
            set { Resource.Id = value; }
        }

        public Resource Resource { get; set; } = new Resource();
        [Display(Name = "Technology")]
        public int TechnologyId {get; set; }

        public SelectList TechnologySelectListItems { get; set; }

        public void Init(TechnologyRepository technologyRepository)
        {
            TechnologySelectListItems = new SelectList(
                technologyRepository.GetList(includeRelatedEntities: false),
                "Id", "Name");

        }
    }
}