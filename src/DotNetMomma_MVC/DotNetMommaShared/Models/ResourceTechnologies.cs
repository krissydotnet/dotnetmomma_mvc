using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class ResourceTechnologies
    {
        public int Id { get; set; }
        [Display(Name = "Resource")]
        public int ResourceId { get; set; }
        [Display(Name = "Technology")]
        public int TechnologyId { get; set; }

        public Resource Resource { get; set; }
        public Technology Technology { get; set; }
    }
}
