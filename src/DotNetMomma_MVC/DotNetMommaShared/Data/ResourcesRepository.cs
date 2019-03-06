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
        const string ResourceListKey = "ResourceList";

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
                    .Include(r => r.Technologies.Select(t => t.Technology));
            }
            return resources
                .Where(r => r.Id == id)
                .SingleOrDefault();
        }

        public override IList<Resource> GetList(bool includeRelatedEntities = true)
        {
            var resourceList = EntityCache.Get<List<Resource>>(ResourceListKey);
            if (resourceList == null)
            {
                var resources = Context.Resources.AsQueryable();
                if (includeRelatedEntities)
                {
                    resources = resources
                        .Include(r => r.Section)
                        .Include(r => r.Category);
                }
                resourceList = resources
                    .OrderBy(s => s.Name)
                    .ToList();
            }
            return resourceList;

        }

        public override void Add(Resource entity)
        {
            base.Add(entity);
            EntityCache.Remove(ResourceListKey);
        }
        public override void Update(Resource entity)
        {
            base.Update(entity);
            EntityCache.Remove(ResourceListKey);
        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(ResourceListKey);
        }

        public bool LinkAlreadyExists(int resourceId, string resourceUrl, int sectionId)
        {
            return Context.Resources
                .Any(r => r.Id != resourceId &&
                r.URL == resourceUrl && 
                r.SectionId == sectionId);
        }

        public bool ResourceHasTechnologyAlready(int resourceId, int technologyId)
        {
            return Context.ResourceTechnologies
                .Any(r => r.ResourceId == resourceId &&
                r.TechnologyId == technologyId);
        }
    }
}
