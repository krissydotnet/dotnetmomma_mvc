using System;
using System.Collections.Generic;
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
        public string Name { get; set; }

        public ICollection<ResourceTechnologies> Resources { get; set; }
    }
}