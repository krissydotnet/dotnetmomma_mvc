
using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_Site.ViewModels
{
    public class ResourcesViewModel
    {

        public List<Category> Categories { get; set; } = new List<Category>();

        public virtual void Init(int sectionId,  CategoryRepository categoryRepository, ResourcesRepository resourcesRepository)
        {
            Categories = categoryRepository.GetList()
                         .ToList();         

            foreach(var category in Categories)
            {
                category.Resources = resourcesRepository.GetList()
                                        .Where(r => r.CategoryId == category.Id && r.SectionId == sectionId)
                                        .ToList();
            }
        }
    }
}