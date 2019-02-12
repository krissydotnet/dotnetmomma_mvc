using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetMomma_MVC.Data;
using DotNetMomma_MVC.Models;

namespace DotNetMomma_MVC.Controllers
{
    public class ResourcesController : Controller
    {
        private ResourcesRepository _resourcesRepository = null;

        public ResourcesController()
        {
            _resourcesRepository = new ResourcesRepository();
        }

        // GET: Resources All
        public ActionResult Index()
        {
            List<Resource> resources = _resourcesRepository.GetResources();

            return View(resources);
        }

        // GET: Resources Tools
        public ActionResult Tools()
        {
            List<Resource> resources = _resourcesRepository.GetResources().Where(x => x.CategoryId == (int)Category.CategoryType.Tools).ToList();
            return View(resources);
        }

        // GET: Resources Training
        public ActionResult Training()
        {
            List<Resource> resources = _resourcesRepository.GetResources().Where(x => x.CategoryId == (int)Category.CategoryType.Training).ToList();
            return View(resources);
        }
        // GET: Resources Kids
        public ActionResult Kids()
        {
            List<Resource> resources = _resourcesRepository.GetResources().Where(x => x.CategoryId == (int)Category.CategoryType.Kids).ToList();
            return View(resources);
        }


        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
