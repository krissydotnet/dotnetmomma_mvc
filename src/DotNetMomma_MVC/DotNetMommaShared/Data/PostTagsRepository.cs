using DotNetMommaShared.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class PostTagsRepository : BaseRepository<PostTags>
    {
        public PostTagsRepository(Context context) : base(context)
        {
        }

        public override PostTags Get(int id, bool includeRelatedEntities = true)
        {
            var postTags = Context.PostTags.AsQueryable();
            if (includeRelatedEntities)
            {
                postTags = postTags
                    .Include(rt => rt.Post.PostCategory);
            }
            return postTags
                .Where(rt => rt.Id == id)
                .SingleOrDefault();

        }

        public override IList<PostTags> GetList(bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }

        public bool PostHasTagAlready(int postId, int tagId)
        {
            return Context.PostTags
                .Any(r => r.PostId == postId &&
                r.TagId == tagId);
        }
    }
}
