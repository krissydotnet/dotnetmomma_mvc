using DotNetMomma_Site.ViewModels;
using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DotNetMomma_Site.Controllers
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

            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.Init(3, _categoryRepository, _resourcesRepository);

            ViewBag.Title = "Kids";
            if (id != null)
            {
                ViewBag.CategoryId = id;
            }

            return View(viewModel);
        }


    }
}
