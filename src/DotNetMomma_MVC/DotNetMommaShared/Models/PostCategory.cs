using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class PostCategory
    {
        public PostCategory()
        {
            PostCategories = new List<PostCategory>();
        }
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
        public string UrlSlug { get; set; }

        public ICollection<PostCategory> PostCategories{ get; set; }

    }
}
