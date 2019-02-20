using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetMommaShared.Models
{
    /// <summary>
    /// Represents a Resource
    /// </summary>
    public class Resource
    {
        public Resource()
        {
            Technologies = new List<ResourceTechnologies>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Section Section { get; set; }  
        public Category Category { get; set; }

        public ICollection<ResourceTechnologies> Technologies { get; set; }

    }
}