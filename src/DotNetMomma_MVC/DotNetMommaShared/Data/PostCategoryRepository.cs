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
            var category = Context.PostCategories.AsQueryable();

            if (includeRelatedEntities)
            {
                category = category
                    .Include(c => c.Posts);

            }
            return category
                .OrderBy(c => c.Name)
                .ToList();
        }
        public bool CategoryAlreadyExists(int categoryId, string categoryName)
        {
            return Context.PostCategories
                .Any(s => s.Id != categoryId && s.Name == categoryName);
        }

    }
}
