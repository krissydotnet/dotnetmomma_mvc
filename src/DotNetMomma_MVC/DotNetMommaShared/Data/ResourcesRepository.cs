using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class ResourcesRepository : BaseRepository<Resource>
    {
        public ResourcesRepository(Context context) : base(context)
        {
        }

        public override Resource Get(int id, bool includeRelatedEntities = true)
        {
            var resources = Context.Resources.AsQueryable();
            if (includeRelatedEntities)
            {
                resources = resources
                    .Include(r => r.Section)
                    .Include(r => r.Category)
                    .Include(r => r.Technologies);
            }
            return resources
                .Where(r => r.Id == id)
                .SingleOrDefault();
        }

        public override IList<Resource> GetList(bool includeRelatedEntities = true)
        {
            var resources = Context.Resources.AsQueryable();
            if (includeRelatedEntities)
            {
                resources = resources
                    .Include(r => r.Section)
                    .Include(r => r.Category);
            }
            return resources
                .OrderBy(s => s.Name)
                .ToList();
        }
        public bool LinkAlreadyExists(int resourceId, string resourceUrl, int sectionId)
        {
            return Context.Resources
                .Any(r => r.Id != resourceId &&
                r.URL == resourceUrl && 
                r.SectionId == sectionId);
        }
    }
}
