using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class CategoryRepository
        : BaseRepository<Category>
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public override Category Get(int id, bool includeRelatedEntities = true)
        {
            var category = Context.Categories.AsQueryable();

            if (includeRelatedEntities) {
                category = category
                    .Include(c => c.Resources);
             
            }

            return category
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }

        public override IList<Category> GetList(bool includeRelatedEntities = true)
        {
            var category = Context.Categories.AsQueryable();

            if (includeRelatedEntities)
            {
                category = category
                    .Include(c => c.Resources);

            }
            return category
                .OrderBy(c => c.Name)
                .ToList();
        }
        public bool CategoryAlreadyExists(int categoryId, string categoryName)
        {
            return Context.Categories
                .Any(s => s.Id != categoryId && s.Name == categoryName);
        }
    }
}
