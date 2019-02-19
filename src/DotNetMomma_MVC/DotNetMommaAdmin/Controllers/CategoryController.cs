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
    public class CategoryController : BaseController
    {
        private CategoryRepository _categoryRepository = null;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository(Context);
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryRepository.GetList(includeRelatedEntities: false);

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryRepository.Get((int)id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
            
        }

        // GET: Category/Add
        public ActionResult Add()
        {
            var category = new Category();
            return View(category);
        }

        // POST: Category/Add
        [HttpPost]
        public ActionResult Add(Category category)
        {
            ValidateCategory(category);
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);

                TempData["Message"] = "Your category has been added.";

                return RedirectToAction("Details", new { id = category.Id });

            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryRepository.Get((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ValidateCategory(category);

            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                return RedirectToAction("Details", new { Id = category.Id });
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryRepository.Get((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            _categoryRepository.Delete(category.Id);

            TempData["Message"] = "The category has been deleted successfully";

            return RedirectToAction("Index");

        }
        private void ValidateCategory(Category category)
        {
            if (ModelState.IsValidField("Category.Name"))
            {
                if(_categoryRepository.CategoryAlreadyExists(category.Id, category.Name))
                {
                    ModelState.AddModelError("Category.Name",
                        "The category has already been added.");
                }
            }
        }
    }
}
