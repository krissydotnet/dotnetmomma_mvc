using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DotNetMommaShared.Models
{
    /// <summary>
    /// Represents a Section of DotNetMomma
    /// </summary>
    public class Section
    {
        public Section()
        {
            Resources = new List<Resource>();
        }


        /// <summary>
        /// The ID of the section.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the section.
        /// </summary>
        [Display(Name = "Section")]
        [Required, StringLength(25)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Resource> Resources { get; set; }
    }
}
