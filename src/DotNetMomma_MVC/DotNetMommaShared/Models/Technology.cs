using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetMommaShared.Models
{
    public class Technology
    {

        public Technology()
        {
            Resources = new List<ResourceTechnologies>();
        }

        public int Id { get; set; }
        /// <summary>
        /// The name of the technology.
        /// </summary>
        [Display(Name="Technology")]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<ResourceTechnologies> Resources { get; set; }
    }
}