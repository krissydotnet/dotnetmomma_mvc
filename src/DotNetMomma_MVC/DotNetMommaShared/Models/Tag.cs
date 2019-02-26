﻿using System;
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
            Posts = new List<PostTags>();
        }
        public int Id { get; set; }
        [Display(Name ="Tag")]
        public string Name { get; set; }
        public string UrlSlug
        {
            get
            {
                return Name.Replace(" ", "_").ToLower();
            }
        }
        public string Description { get; set; }

        public ICollection<PostTags> Posts { get; set; }
    }
}
