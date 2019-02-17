using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Sections.Add(new Section
            {
                Id = 1,
                Name = "Tools"
            });
            context.Sections.Add(new Section
            {
                Id = 2,
                Name = "Training"
            });
            context.Sections.Add(new Section
            {
                Id = 3,
                Name = "Kids"
            });

            context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Design Tools"
            });
            context.Categories.Add(new Category
            {
                Id = 2,
                Name = "Code Editors"
            });
            context.Categories.Add(new Category
            {
                Id = 3,
                Name = "Communities"
            });
            context.Categories.Add(new Category
            {
                Id = 4,
                Name = "Code Validators"
            });
            context.Categories.Add(new Category
            {
                Id = 5,
                Name = "Guides"
            });
            context.Categories.Add(new Category
            {
                Id = 6,
                Name = "Cheat Sheets"
            });
            context.Categories.Add(new Category
            {
                Id = 7,
                Name = "Free Resources"
            });
            context.Categories.Add(new Category
            {
                Id = 8,
                Name = "Paid Resources"
            });
            context.Categories.Add(new Category
            {
                Id = 9,
                Name = "Games"
            });
            context.Categories.Add(new Category
            {
                Id = 10,
                Name = "Tutorials"
            });
            context.Categories.Add(new Category
            {
                Id = 11,
                Name = "Miscellaneous"
            });
        }
    }
}
