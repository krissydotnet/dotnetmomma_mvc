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
    public class SectionController : BaseController
    {
        private SectionsRepository _sectionsRepository = null;

        public SectionController()
        {
            _sectionsRepository = new SectionsRepository(Context);
        }
        // GET: Section
        public ActionResult Index()
        {
            var sections = _sectionsRepository.GetList(includeRelatedEntities: false);
            return View(sections);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var section = _sectionsRepository.Get((int)id);
            if (section == null)
            {
                return HttpNotFound();
            }
            

            return View(section);
        }

        public ActionResult Add()
        {
            var section = new Section();
            return View(section);
        }

        [HttpPost]
        public ActionResult Add(Section section)
        {
            ValidateSection(section);

            if (ModelState.IsValid)
            {
                _sectionsRepository.Add(section);

                TempData["Message"] = "Your section has been added.";

                return RedirectToAction("Details", new { id = section.Id });

            }

            return View(section);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var section = _sectionsRepository.Get((int)id);
            if (section == null)
            {
                return HttpNotFound();
            }


            return View(section);
        }

        [HttpPost]
        public ActionResult Edit(Section section)
        {
            ValidateSection(section);
            if (ModelState.IsValid)
            {
                _sectionsRepository.Update(section);
                return RedirectToAction("Details", new { Id = section.Id});
            }
            return View(section);
        }

        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var section = _sectionsRepository.Get((int)id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }
        [HttpPost]
        public ActionResult Delete (Section section)
        {
            _sectionsRepository.Delete(section.Id);

            TempData["Message"] = "The section has been deleted successfully";

            return RedirectToAction("Index");
        }

        private void ValidateSection(Section section)
        {
            if (ModelState.IsValidField("Section.Name"))
            {
                if (_sectionsRepository.SectionAlreadyExists(section.Id, section.Name))
                {
                    ModelState.AddModelError("Section.Name",
                       "The section has already been added.");
                }
            }
        }
    }
}