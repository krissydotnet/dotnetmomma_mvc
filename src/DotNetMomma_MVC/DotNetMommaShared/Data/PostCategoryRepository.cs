using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class PostCategoryRepository
        : BaseRepository<PostCategory>
    {
        const string PostCategoryListKey = "PostCategoryList";

        public PostCategoryRepository(Context context) : base(context)
        {
        }

        public override PostCategory Get(int id, bool includeRelatedEntities = true)
        {
            var category = Context.PostCategories.AsQueryable();

            if (includeRelatedEntities) {
                category = category
                    .Include(c => c.Posts);
             
            }

            return category
                    .Where(c => c.Id == id)
                    .SingleOrDefault();
        }
        public PostCategory Get(string categoryName)
        {
            var category = Context.PostCategories.AsQueryable();

            return category
                    .Where(c => c.Name == categoryName)
                    .SingleOrDefault();
        }
        public override IList<PostCategory> GetList(bool includeRelatedEntities = true)
        {
            var categoryList = EntityCache.Get<List<PostCategory>>(PostCategoryListKey);
            if (categoryList == null)
            {
                var category = Context.PostCategories.AsQueryable();

                if (includeRelatedEntities)
                {
                    category = category
                        .Include(c => c.Posts);

                }
                categoryList = category
                    .OrderBy(c => c.Name)
                    .ToList();
                EntityCache.Add(PostCategoryListKey, categoryList);
            }
            return categoryList;
        }

        public override void Add(PostCategory entity)
        {
            base.Add(entity);
            EntityCache.Remove(PostCategoryListKey);
        }

        public override void Update(PostCategory entity)
        {
            base.Update(entity);
            EntityCache.Remove(PostCategoryListKey);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(PostCategoryListKey);
        }

        public bool CategoryAlreadyExists(int categoryId, string categoryName)
        {
            return Context.PostCategories
                .Any(s => s.Id != categoryId && s.Name == categoryName);
        }

    }
}
