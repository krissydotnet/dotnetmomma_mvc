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
        public ActionResult Tools()
        {
       
            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.Init(_categoryRepository, _resourcesRepository);


            //List<Resource> resources = _resourcesRepository.GetResources().Where(x => x.SectionId == (int)Section.SectionType.Tools).ToList();
           // List<Category> categories = _resourcesRepository.GetCategories().ToList();
            return View(viewModel);
        }

        //// GET: Resources Training
        //public ActionResult Training()
        //{
        //    List<Resource> resources = _resourcesRepository.GetResources().Where(x =>  x.SectionId == (int)Section.SectionType.Training).ToList();
        //    return View(resources);
        //}
        //// GET: Resources Kids
        //public ActionResult Kids()
        //{
        //    List<Resource> resources = _resourcesRepository.GetResources().Where(x => x.SectionId == (int)Section.SectionType.Kids).ToList();
        //    return View(resources);
        //}


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
