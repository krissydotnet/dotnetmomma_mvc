using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Models
{
    public class PostTechnologies
    {
        public int Id { get; set; }
        [Display(Name = "Post")]
        public int PostId { get; set; }
        [Display(Name = "Technology")]
        public int TechnologyId { get; set; }

        public Post Post { get; set; }
        public Technology Technology { get; set; }
    }
}
