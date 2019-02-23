namespace DotNetMommaShared.Migrations
{
    using DotNetMommaShared.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetMommaShared.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DotNetMommaShared.Data.Context";
        }

        protected override void Seed(DotNetMommaShared.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Sections.AddOrUpdate(new Section
            {
                Id = 1,
                Name = "Tools"
            });
            context.Sections.AddOrUpdate(new Section
            {
                Id = 2,
                Name = "Training"
            });
            context.Sections.AddOrUpdate(new Section
            {
                Id = 3,
                Name = "Kids"
            });

            context.Categories.AddOrUpdate(new Category
            {
                Id = 1,
                Name = "Design Tools"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 2,
                Name = "Code Editors"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 3,
                Name = "Communities"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 4,
                Name = "Code Validators"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 5,
                Name = "Guides"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 6,
                Name = "Cheat Sheets"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 7,
                Name = "Free Resources"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 8,
                Name = "Paid Resources"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 9,
                Name = "Games"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 10,
                Name = "Tutorials"
            });
            context.Categories.AddOrUpdate(new Category
            {
                Id = 11,
                Name = "Miscellaneous"
            });
            context.SaveChanges();
        }
    
    }
}
