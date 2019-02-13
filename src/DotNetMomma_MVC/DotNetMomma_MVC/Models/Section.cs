using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_MVC.Models
{
    public class Section
    {
        /// <summary>
        /// The list of Section.
        /// </summary>
        public enum SectionType
        {
            Tools = 1,
            Training = 2,
            Kids = 3
        }

        /// <summary>
        /// Constructors an section for the provided section type and name.
        /// </summary>
        /// <param name="sectionType">The section type for the section.</param>
        /// <param name="name">The name for the section.</param>
        public Section(SectionType sectionType, string name = null)
        {
            Id = (int)sectionType;

            // If we don't have a name argument, 
            // then use the string representation of the section type for the name.
            Name = name ?? sectionType.ToString();
        }

        /// <summary>
        /// The ID of the section.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the section.
        /// </summary>
        public string Name { get; set; }
    }
}
