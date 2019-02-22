using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class Post
    {
        public Post()
        {
            Technologies = new List<PostTechnologies>();
        }
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        public ICollection<PostTechnologies> Technologies { get; set; }

    }
}
