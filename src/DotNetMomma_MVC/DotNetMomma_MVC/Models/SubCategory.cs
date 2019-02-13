using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Models
{
    public class SubCategory
    {

        /// <summary>
        /// The list of SubCategory.
        /// </summary>
        public enum SubCategoryType
        {
            HTML = 1,
            CSS = 2,
            JavaScript = 3,
            React = 4,
            JQuery = 5,
            AJAX = 6,
            SASS = 7,
            C_Sharp = 8,
            ASP_MVC = 9,
            ASP_Web_Forms = 10,
            ASP_Core = 11,
            Web_Design = 12,
            Coding = 13,
            Games = 14
        }

        /// <summary>
        /// Constructors an activity for the provided activity type and name.
        /// </summary>
        /// <param name="subCategoryType">The activity type for the activity.</param>
        /// <param name="name">The name for the activity.</param>
        public SubCategory(SubCategoryType subCategoryType)
        {
            Name = subCategoryType.ToString().Replace("_", " ").Replace("Sharp", "#");
        }



        /// <summary>
        /// The name of the technology.
        /// </summary>
        public string Name { get; set; }
    }
}