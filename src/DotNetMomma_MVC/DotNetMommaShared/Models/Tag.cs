using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class Tag
    {
        public Tag()
        {
            Tags = new List<PostTags>();
        }
        public int Id { get; set; }
        [Display(Name ="Tag")]
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public ICollection<PostTags> Tags { get; set; }
    }
}
