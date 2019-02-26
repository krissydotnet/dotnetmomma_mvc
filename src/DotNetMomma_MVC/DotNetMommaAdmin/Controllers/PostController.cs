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
    public class PostController : BaseController
    {
        private PostRepository _postRepository = null;
        private TagRepository _tagRepository = null;
        private PostCategoryRepository _categoryRepository = null;

        public PostController()
        {
            _postRepository = new PostRepository(Context);
            _tagRepository = new TagRepository(Context);
            _categoryRepository = new PostCategoryRepository(Context);
        }

        // GET: Blog
        public ActionResult Index()
        {
            var posts = _postRepository.GetList();
           
            return View(posts);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = _postRepository.Get((int)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Tags = post.Tags.OrderBy(t => t.Tag.Name).ToList();

            return View(post);
        }

        //public ActionResult Add()
        public ActionResult Add()
        {
            var viewModel = new PostAddViewModel();
            viewModel.Init(_tagRepository,_categoryRepository);

            return View(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(PostAddViewModel viewModel)
        {
            ValidatePost(viewModel.Post);

            if (ModelState.IsValid)
            {

                var post = viewModel.Post;
                _postRepository.Add(post);

                TempData["Message"] = "Your post was successfully added.";

                return RedirectToAction("Details", new { id = post.Id });


            }


            viewModel.Init(_tagRepository, _categoryRepository);

            return View(viewModel);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = _postRepository.Get((int)id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PostEditViewModel()
            {
                Post = post
            };

            viewModel.Init(_tagRepository, _categoryRepository);

            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Edit(PostEditViewModel viewModel)
        {
            ValidatePost(viewModel.Post);

            if (ModelState.IsValid)
            {
                var post = viewModel.Post;

                _postRepository.Update(post);

                TempData["Message"] = "Your resource was successfully added.";

                return RedirectToAction("Details", new { id = post.Id });
            }

            viewModel.Init(_tagRepository, _categoryRepository);

            return View(viewModel);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = _postRepository.Get((int)id);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _postRepository.Delete(id);

            TempData["Message"] = "Your post was successfully deleted.";

            return RedirectToAction("Index");
        }



        private void ValidatePost(Post post)
        {
            //TODO: ValidatePost

        }

    }
}