using DotNetMommaShared.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class ResourceTechnologiesRepository : BaseRepository<ResourceTechnologies>
    {
        public ResourceTechnologiesRepository(Context context) : base(context)
        {
        }

        public override ResourceTechnologies Get(int id, bool includeRelatedEntities = true)
        {
            var resourceTechnologies = Context.ResourceTechnologies.AsQueryable();
            if (includeRelatedEntities)
            {
                resourceTechnologies = resourceTechnologies
                    .Include(rt => rt.Resource.Category)
                    .Include(rt => rt.Resource.Section);
            }
            return resourceTechnologies
                .Where(rt => rt.Id == id)
                .SingleOrDefault();

        }

        public override IList<ResourceTechnologies> GetList(bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }
    }
}
