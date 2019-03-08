using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetMomma_API.Controllers
{
    public class PostsController : ApiController
    {
        private PostRepository _postRepository;
        public PostsController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_postRepository.GetList(includeRelatedEntities: false));
        }

        public IHttpActionResult Get(int id)
        {
            var post = _postRepository.Get(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

    }
}
