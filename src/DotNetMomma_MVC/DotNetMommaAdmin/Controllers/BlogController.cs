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
    public class BlogController : BaseController
    {
        private PostRepository _postRepository = null;

        public BlogController()
        {
            _postRepository = new PostRepository(Context);
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
            post.Technologies = post.Technologies.OrderBy(t => t.Technology.Name).ToList();

            return View(post);
        }

        public ActionResult Add()
        {
            var post = new Post();
            return View(post);
        }

        [HttpPost]
        public ActionResult Add(Post post)
        {
            ValidatePost(post);

            if (ModelState.IsValid)
            {

                _postRepository.Add(post);

                TempData["Message"] = "Your post was successfully added.";

                return RedirectToAction("Details", new { id = post.Id });
            }


            return View(post);

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


            return View(post);

        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            ValidatePost(post);

            if (ModelState.IsValid)
            {
                _postRepository.Update(post);

                TempData["Message"] = "Your resource was successfully added.";

                return RedirectToAction("Details", new { id = post.Id });
            }

            return View(post);

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