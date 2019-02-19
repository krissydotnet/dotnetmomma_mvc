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
    public class ResourcesController : BaseController
    {
        private ResourcesRepository _resourcesRepository = null;
        private SectionsRepository _sectionsRepository = null;

        public ResourcesController()
        {
            _resourcesRepository = new ResourcesRepository(Context);
            _sectionsRepository = new SectionsRepository(Context);
        }

        // GET: Resources
        public ActionResult Index()
        {
            var resources = _resourcesRepository.GetList();
            return View(resources);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = _resourcesRepository.Get((int)id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            resource.Technologies = resource.Technologies.OrderBy(a => a.Technology.Name).ToList();

            return View(resource);
        }
        public ActionResult Add()
        {
            var viewModel = new ResourcesAddViewModel();
            viewModel.Init(Repository, _sectionsRepository);

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Add(ResourcesAddViewModel viewModel)
        {
            ValidateResource(viewModel.Resource);

            if (ModelState.IsValid)
            {
                var resource = viewModel.Resource;

                _resourcesRepository.Add(resource);

                TempData["Message"] = "Your resource was successfully added.";

                return RedirectToAction("Details", new { id = resource.Id });
            }

            viewModel.Init(Repository, _sectionsRepository);

            return View(viewModel);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = _resourcesRepository.Get((int)id);
            if (resource == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ResourcesEditViewModel()
            {
                Resource = resource
            };
            viewModel.Init(Repository, _sectionsRepository);

            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Edit(ResourcesEditViewModel viewModel)
        {
            ValidateResource(viewModel.Resource);

            if (ModelState.IsValid)
            {
                var resource = viewModel.Resource;
                _resourcesRepository.Update(resource);

                TempData["Message"] = "Your resource was successfully added.";

                return RedirectToAction("Details", new { id = resource.Id });
            }

            viewModel.Init(Repository, _sectionsRepository);

            return View(viewModel);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = _resourcesRepository.Get((int)id);

            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _resourcesRepository.Delete(id);

            TempData["Message"] = "Your resource was successfully deleted.";

            return RedirectToAction("Index");
        }


        private void ValidateResource(Resource resource)
        {
            if (ModelState.IsValidField("Resource.URL"))
            {
                if (_resourcesRepository.LinkAlreadyExists(resource.Id, resource.URL, resource.SectionId))
                {
                    ModelState.AddModelError("Resource.URL",
                        "The provided URL has already been added for the selected section.");
                }
            }
        }

    }
}