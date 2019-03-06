using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetMommaShared.Data
{
    public class SectionsRepository
        : BaseRepository<Section>
    {
        const string SectionsListKey = "SectionsList";

        public SectionsRepository(Context context) : base(context)
        {
        }

        public override Section Get(int id, bool includeRelatedEntities = true)
        {
            var sections = Context.Sections.AsQueryable();
            if (includeRelatedEntities)
            {
                sections = sections
                    .Include(s => s.Resources);
            }
            return sections
                .Where(s => s.Id == id)
                .SingleOrDefault();
        }

        public override IList<Section> GetList(bool includeRelatedEntities = true)
        {
            var sectionsList = EntityCache.Get<List<Section>>(SectionsListKey);

            if (sectionsList == null)
            {
                var sections = Context.Sections.AsQueryable();
                if (includeRelatedEntities)
                {
                    sections = sections
                        .Include(s => s.Resources);
                }
                sectionsList =  sections
                    .OrderBy(s => s.Name)
                    .ToList();
                EntityCache.Add(SectionsListKey, sectionsList);

            }
            return sectionsList;

         
        }
        public override void Add(Section entity)
        {
            base.Add(entity);
            EntityCache.Remove(SectionsListKey);
        }
        public override void Update(Section entity)
        {
            base.Update(entity);
            EntityCache.Remove(SectionsListKey);
        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(SectionsListKey);
        }

        public bool SectionAlreadyExists(int sectionId, string sectionName)
        {
            return Context.Sections
                .Any(s => s.Id != sectionId && s.Name == sectionName);
        }
    }
}
