using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class Post
    {
        public Post()
        {
            Tags = new List<PostTags>();
            PostedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public int PostCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Location { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        public PostCategory PostCategory { get; set; }
        public ICollection<PostTags> Tags { get; set; }

    }
}
