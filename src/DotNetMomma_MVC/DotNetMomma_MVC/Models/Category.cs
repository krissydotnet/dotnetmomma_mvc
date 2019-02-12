using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Models
{
    public class Category
    {

        /// <summary>
        /// The list of Categories.
        /// </summary>
        public enum CategoryType
        {
            Tools = 1,
            Training = 2,
            Kids = 3,
        }

        /// <summary>
        /// Constructors an activity for the provided activity type and name.
        /// </summary>
        /// <param name="activityType">The activity type for the activity.</param>
        /// <param name="name">The name for the activity.</param>
        public Category(CategoryType categoryType, string name = null)
        {
            Id = (int)categoryType;

            // If we don't have a name argument, 
            // then use the string representation of the activity type for the name.
            Name = name ?? categoryType.ToString();
        }

        /// <summary>
        /// The ID of the activity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the activity.
        /// </summary>
        public string Name { get; set; }
    }
}