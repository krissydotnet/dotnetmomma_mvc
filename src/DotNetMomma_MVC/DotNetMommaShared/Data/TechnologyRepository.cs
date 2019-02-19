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
            var technologies = Context.Technologies.AsQueryable();
            if (includeRelatedEntities)
            {
                technologies = technologies
                    .Include(t => t.Resources);
            }
            return technologies
                .OrderBy(t => t.Name)
                .ToList();
        }
        public bool TechnologyAlreadyExists(int techId, string techName)
        {
            return Context.Technologies
                .Any(t => t.Id != techId && t.Name == techName);
        }
    }
}
