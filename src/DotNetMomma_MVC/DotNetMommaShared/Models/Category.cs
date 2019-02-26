using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetMommaShared.Models
{
    public class Category
    {
        /// <summary>
        /// Represents a Category
        /// </summary>
        public Category()
        {
            Resources = new List<Resource>();
        }

        /// <summary>
        /// The ID of the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        [Display(Name = "Category")]
        public string Name { get; set; }



        public ICollection<Resource> Resources { get; set; }
    }
}