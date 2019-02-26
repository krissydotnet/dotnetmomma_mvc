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
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 1,
                Name = "Introduction"
            });
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 2,
                Name = "Travel"
            });
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 3,
                Name = "Parenting"
            });
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 4,
                Name = "Products"
            });
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 5,
                Name = "Learning"
            });
            context.PostCategories.AddOrUpdate(new PostCategory
            {
                Id = 6,
                Name = "Coding"
            });
            context.Tags.AddOrUpdate(new Tag
            {
                Id = 1,
                Name = "ASPNET"
            });
            context.Tags.AddOrUpdate(new Tag
            {
                Id = 2,
                Name = "CSharp"
            });
            context.Tags.AddOrUpdate(new Tag
            {
                Id = 3,
                Name = "HTML"
            });
            context.Tags.AddOrUpdate(new Tag
            {
                Id = 4,
                Name = "JavaScript"
            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 1,
                Title = "Console.WriteLine('Hello World');",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 1,
                Published = true,
                PostedOn = DateTime.Now
                
            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 2,
                Title = "I'd rather be at Disney",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 2,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 3,
                Title = "Teaching Kids to Code",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 3,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 4,
                Title = "Have you seen this?",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 4,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 5,
                Title = "I'm too old to learn something new",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 5,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 6,
                Title = "ASP.Net why I like it",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 6,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 7,
                Title = "Planning a trip to Disney",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 2,
                Published = true,
                PostedOn = DateTime.Now

            });
            context.Posts.AddOrUpdate(new Post
            {
                Id = 8,
                Title = "Kids and their devices",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PostCategoryId = 3,
                Published = true,
                PostedOn = DateTime.Now

            });

        }
    
    }
}
