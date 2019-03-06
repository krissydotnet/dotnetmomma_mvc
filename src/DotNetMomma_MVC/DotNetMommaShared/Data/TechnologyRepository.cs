using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class TechnologyRepository : BaseRepository<Technology>
    {
        const string TechnologyListKey = "TechnologyList";

        public TechnologyRepository(Context context) : base(context)
        {
        }

        public override Technology Get(int id, bool includeRelatedEntities = true)
        {
            var technologies = Context.Technologies.AsQueryable();
            if (includeRelatedEntities)
            {
                technologies = technologies
                    .Include(t => t.Resources);
            }
            return technologies
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public override IList<Technology> GetList(bool includeRelatedEntities = true)
        {
            var technologyList = EntityCache.Get<List<Technology>>(TechnologyListKey);
            if (technologyList == null)
            {
                var technologies = Context.Technologies.AsQueryable();
                if (includeRelatedEntities)
                {
                    technologies = technologies
                        .Include(t => t.Resources);
                }
                technologyList = technologies
                    .OrderBy(t => t.Name)
                    .ToList();
            }
            return technologyList;

        }
        public override void Add(Technology entity)
        {
            base.Add(entity);
            EntityCache.Remove(TechnologyListKey);
        }
        public override void Update(Technology entity)
        {
            base.Update(entity);
            EntityCache.Remove(TechnologyListKey);

        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(TechnologyListKey);
        }

        public bool TechnologyAlreadyExists(int techId, string techName)
        {
            return Context.Technologies
                .Any(t => t.Id != techId && t.Name == techName);
        }
    }
}
