using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    /// <summary>
    /// Entity Framework context class
    /// </summary>
    public class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DatabaseInitializer());
            //Disable initializer
            Database.SetInitializer<Context>(null);
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ResourceTechnologies> ResourceTechnologies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }

    }
}
