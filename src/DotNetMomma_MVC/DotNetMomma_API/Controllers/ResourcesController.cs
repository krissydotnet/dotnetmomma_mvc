using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetMomma_API.Controllers
{
    public class ResourcesController : ApiController
    {
        private ResourcesRepository _resourcesRepository = null;

        public ResourcesController(ResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_resourcesRepository.GetList());
        }

        public IHttpActionResult Get(int id)
        {
            var resource = _resourcesRepository.Get(id);
            if (resource == null)
            {
                return NotFound();
            }
            else return Ok(resource);
        }

    }
}
