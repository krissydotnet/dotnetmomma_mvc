using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class PostTags
    {
        public int Id { get; set; }
        [Display(Name = "Post")]
        public int PostId { get; set; }
        [Display(Name = "Tag")]
        public int TagId { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
