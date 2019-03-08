using DotNetMomma_API.Dto;
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
            var resources = _resourcesRepository.GetList();
            var resourceDto = resources.Select(e => new ResourceListDto()
            {
                Id = e.Id,
                Name = e.Name,
                URL = e.URL,
                Description = e.Description,
                Section = e.Section.Name,
                Category = e.Category.Name,
                Technologies = e.Technologies
            }).ToList();

            return Ok(resourceDto);
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
