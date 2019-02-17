using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class ResourceTechnologies
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int TechnologyId { get; set; }

        public Resource Resource { get; set; }
        public Technology Technology { get; set; }
    }
}
