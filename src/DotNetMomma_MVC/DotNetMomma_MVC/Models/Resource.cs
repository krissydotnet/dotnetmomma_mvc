using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Models
{
    public class Resource
    {
        /// <summary>
        /// Constructor for easily creating resources.
        /// </summary>
        /// <param name="id">The ID for the resource.</param>
        /// <param name="name">The display name of the resource.</param>
        /// <param name="url">The url for the resource.</param>
        /// <param name="sectionType">The section type for the entry.</param>
        /// <param name="categoryType">The category type for the entry.</param>
        /// <param name="description">The description for the resource.</param>
        /// <param name="subCategories">The technologies apply to.</param>

        public Resource(int id, string name, string url, string description, Section.SectionType sectionType, Category.CategoryType categoryType,  List<SubCategory.SubCategoryType> subCategories)
        {
            Id = id;
            Name = name;
            SectionId = (int)sectionType;
            CategoryId = (int)categoryType;
            Description = description;
            URL = url;
            SubCategories = subCategories;
        }

        // Default constructor
        public Resource()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SubCategory.SubCategoryType> SubCategories { get; set; }

    }
}