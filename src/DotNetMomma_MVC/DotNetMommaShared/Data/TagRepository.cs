﻿using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class TagRepository : BaseRepository<Tag>
    {
        public TagRepository(Context context) : base(context)
        {
        }

        public override Tag Get(int id, bool includeRelatedEntities = true)
        {
            var tags = Context.Tags.AsQueryable();
            if (includeRelatedEntities)
            {
                tags = tags
                    .Include(t => t.Posts);
            }
            return tags
                .Where(t => t.Id == id)
                .SingleOrDefault();
        }

        public override IList<Tag> GetList(bool includeRelatedEntities = true)
        {
            var tags = Context.Tags.AsQueryable();
            if (includeRelatedEntities)
            {
                tags = tags
                    .Include(t => t.Posts);
            }
            return tags
                .OrderBy(t => t.Name)
                .ToList();
        }
        public bool TagAlreadyExists(int tagId, string tagName)
        {
            return Context.Technologies
                .Any(t => t.Id != tagId && t.Name == tagName);
        }
    }
}
