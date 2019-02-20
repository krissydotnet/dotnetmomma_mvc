using DotNetMommaAdmin.ViewModels;
using DotNetMommaShared.Data;
using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DotNetMommaAdmin.Controllers
{
    public class ResourceTechnologiesController : BaseController
    {
        private ResourcesRepository _resourcesRepository = null;
        private ResourceTechnologiesRepository _resourceTechnologiesRepository = null;
        private TechnologyRepository _technologyRepository = null;

        public ResourceTechnologiesController()
        {
            _resourcesRepository = new ResourcesRepository(Context);
            _resourceTechnologiesRepository = new ResourceTechnologiesRepository(Context);
            _technologyRepository = new TechnologyRepository(Context);
        }

        public ActionResult Add(int resourceId)
        {
            var resource = _resourcesRepository.Get(resourceId);

            if (resource == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ResourceTechnologiesAddViewModel()
            {
                Resource = resource
            };

            viewModel.Init(_technologyRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ResourceTechnologiesAddViewModel viewModel)
        {
            ValidateResourceTechnolgies(viewModel);

            if (ModelState.IsValid)
            {
                var resourceTechnolgies = new ResourceTechnologies()
                {
                    ResourceId = viewModel.ResourceId,
                    TechnologyId = viewModel.TechnologyId,
                };

                _resourceTechnologiesRepository.Add(resourceTechnolgies);

                TempData["Message"] = "Your technology was successfully added!";

                return RedirectToAction("Edit", "Resources", new { id = viewModel.ResourceId });

            }


            viewModel.Resource = _resourcesRepository.Get(viewModel.ResourceId);
            viewModel.Init(_technologyRepository);

            return View(viewModel);
        }

        public ActionResult Delete(int resourceId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the comic book artist.
            // Include the "ComicBook.Series", "Artist", and "Role" navigation properties.
            var resourceTechnologies = _resourceTechnologiesRepository.Get((int)id);


            if (resourceTechnologies == null)
            {
                return HttpNotFound();
            }

            return View(resourceTechnologies);
        }

        [HttpPost]
        public ActionResult Delete(int resourceId, int id)
        {
            // TODO Delete the comic book artist.

            _resourceTechnologiesRepository.Delete(id);

            TempData["Message"] = "Your technology was successfully deleted!";

            return RedirectToAction("Edit", "Resources", new { id = resourceId });
        }

        private void ValidateResourceTechnolgies(ResourceTechnologiesAddViewModel viewModel)
        {
            if (ModelState.IsValidField("ResourceId") &&
                ModelState.IsValidField("TechnologyId"))
            {
                if (_resourcesRepository.ResourceHasTechnologyAlready(viewModel.ResourceId, viewModel.TechnologyId))
                {
                    ModelState.AddModelError("TechnologyId",
                        "This technology already exists for this resource.");
                }
            }
        }

    }
}