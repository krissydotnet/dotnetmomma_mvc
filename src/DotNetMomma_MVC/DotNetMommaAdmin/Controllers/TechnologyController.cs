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
    public class TechnologyController : BaseController
    {
        private TechnologyRepository _technologyRepository = null;

        public TechnologyController()
        {
            _technologyRepository = new TechnologyRepository(Context);
        }

        // GET: Technology
        public ActionResult Index()
        {
            var technology = _technologyRepository.GetList(includeRelatedEntities: false);
            return View(technology);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var technology = _technologyRepository.Get((int)id);
            if (technology == null)
            {
                return HttpNotFound();
            }


            return View(technology);
        }

        public ActionResult Add()
        {
            var technology = new Technology();
            return View(technology);
        }

        [HttpPost]
        public ActionResult Add(Technology technology)
        {
            ValidateTechnology(technology);

            if (ModelState.IsValid)
            {
                _technologyRepository.Add(technology);

                TempData["Message"] = "Your technology has been added.";

                return RedirectToAction("Details", new { id = technology.Id });

            }

            return View(technology);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var technology = _technologyRepository.Get((int)id);
            if (technology == null)
            {
                return HttpNotFound();
            }


            return View(technology);
        }

        [HttpPost]
        public ActionResult Edit(Technology technology)
        {
            ValidateTechnology(technology);
            if (ModelState.IsValid)
            {
                _technologyRepository.Update(technology);
                return RedirectToAction("Details", new { Id = technology.Id });
            }
            return View(technology);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var technology = _technologyRepository.Get((int)id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }
        [HttpPost]
        public ActionResult Delete(Technology technology)
        {
            _technologyRepository.Delete(technology.Id);

            TempData["Message"] = "The technology has been deleted successfully";

            return RedirectToAction("Index");
        }


        private void ValidateTechnology(Technology technology)
        {
            if (ModelState.IsValidField("Technology.Name"))
            {
                if (_technologyRepository.TechnologyAlreadyExists(technology.Id, technology.Name))
                {
                    ModelState.AddModelError("Technology.Name",
                       "The technology has already been added.");
                }
            }
        }

    }
}