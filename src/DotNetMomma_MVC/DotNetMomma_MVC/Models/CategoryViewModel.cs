using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Models
{
    public class CategoryViewModel
    {
        /// <summary>
        /// The ID of the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; }

        public List<Resource> Links { get; set; } 

    }
}