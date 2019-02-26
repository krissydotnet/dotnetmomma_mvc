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
        private int length = 100;

        public Post()
        {
            Tags = new List<PostTags>();
            PostedOn = DateTime.Now;
            Modified = DateTime.Now;
        }
        public int Id { get; set; }
        public int PostCategoryId { get; set; }
        [Required]
        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public string Meta { get; set; }

        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        public PostCategory PostCategory { get; set; }
        public ICollection<PostTags> Tags { get; set; }

        public string ShortDescription
        {
            get
            {
                return (Description.Length >= length) ?
                        Description.Substring(0,length) :
                        Description;
            }
        }

        public string UrlSlug {
            get {
                return Title.Replace(" ", "_").ToLower();
            }
        }




    }
}
