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
        const string CategoryListKey = "CategoryList";

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
            var categoryList = EntityCache.Get<List<Category>>(CategoryListKey);
            if (categoryList == null)
            {
                var category = Context.Categories.AsQueryable();

                if (includeRelatedEntities)
                {
                    category = category
                        .Include(c => c.Resources);

                }
                categoryList = category
                    .OrderBy(c => c.Name)
                    .ToList();
                
            }
            return categoryList;            
        }
        public override void Add(Category entity)
        {
            base.Add(entity);
            EntityCache.Remove(CategoryListKey);
        }
        public override void Update(Category entity)
        {
            base.Update(entity);
            EntityCache.Remove(CategoryListKey);
        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(CategoryListKey);
        }


        public bool CategoryAlreadyExists(int categoryId, string categoryName)
        {
            return Context.Categories
                .Any(s => s.Id != categoryId && s.Name == categoryName);
        }
    }
}
