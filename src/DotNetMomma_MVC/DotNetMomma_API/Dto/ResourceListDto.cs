using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMomma_API.Dto
{
    public class ResourceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public ICollection<ResourceTechnologies> Technologies { get; set; }

    }
}