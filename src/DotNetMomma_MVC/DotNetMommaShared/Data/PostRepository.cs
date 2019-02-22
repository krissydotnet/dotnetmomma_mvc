using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(Context context) : base(context)
        {
        }

        public override Post Get(int id, bool includeRelatedEntities = true)
        {
            var posts = Context.Posts.AsQueryable();
            if (includeRelatedEntities)
            {
                posts = posts
                    .Include(r => r.Technologies.Select(t => t.Technology));
            }
            return posts
                .Where(r => r.Id == id)
                .SingleOrDefault();

        }

        public override IList<Post> GetList(bool includeRelatedEntities = true)
        {
            var posts = Context.Posts.AsQueryable();
            if (includeRelatedEntities)
            {
                posts = posts
                    .Include(r => r.Technologies.Select(t => t.Technology));
            }
            return posts
                .OrderBy(s => s.PostedOn)
                .ToList();
        }

    }
}
