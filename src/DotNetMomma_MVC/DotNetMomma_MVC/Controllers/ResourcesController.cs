using DotNetMomma_MVC.ViewModels;
using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DotNetMomma_MVC.Controllers
{
    public class ResourcesController : BaseController
    {
        private ResourcesRepository _resourcesRepository = null;
        private CategoryRepository _categoryRepository = null;

        public ResourcesController()
        {
            _resourcesRepository = new ResourcesRepository(Context);
            _categoryRepository = new CategoryRepository(Context);
        }

        // GET: Resources All
        public ActionResult Index()
        {
            var resources = _resourcesRepository.GetList();

            return View(resources);
        }

        // GET: Resources Tools
        public ActionResult Tools(int? id)
        {
       
            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.Init(1, _categoryRepository, _resourcesRepository);

            ViewBag.Title = "Tools";
            if (id != null)
            {
                ViewBag.CategoryId = id;
            }

            return View(viewModel);
        }

        //// GET: Resources Training
        public ActionResult Training(int? id)
        {
            //ResourcesViewModel viewModel = new ResourcesViewModel();
            //viewModel.Init(2, _categoryRepository, _resourcesRepository);

            //ViewBag.Title = "Training";
            //return View(viewModel);

            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.Init(2, _categoryRepository, _resourcesRepository);

            ViewBag.Title = "Training";
            if (id != null)
            {
                ViewBag.CategoryId = id;
            }

            return View(viewModel);
        }
        //// GET: Resources Kids
        public ActionResult Kids(int? id)
        {
            //ResourcesViewModel viewModel = new ResourcesViewModel();
            //viewModel.Init(3,  _categoryRepository, _resourcesRepository);

            //ViewBag.Title = "Kids";
            //return View(viewModel);
            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.Init(3, _categoryRepository, _resourcesRepository);

            ViewBag.Title = "Kids";
            if (id != null)
            {
                ViewBag.CategoryId = id;
            }

            return View(viewModel);
        }


        //// GET: Resources/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Resources/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Resources/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Resources/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Resources/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Resources/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Resources/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
