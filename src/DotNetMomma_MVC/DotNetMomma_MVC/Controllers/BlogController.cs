using DotNetMomma_MVC.ViewModels;
using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DotNetMomma_MVC.Controllers
{
    public class BlogController : BaseController
    {
        PostRepository _postRepository = null;
        int pageSize = 5;
        public BlogController()
        {
            _postRepository = new PostRepository(Context);
            
        }

        // GET: Blog
        public ActionResult Index(int p = 1, int catId = 0)
        {
            int pageSize = 2;
            var viewModel = new BlogViewModel(_postRepository, p, pageSize, catId);
            ViewBag.Title = "Latests Posts";

            return View(viewModel);
        }
        // GET: Category
        public ActionResult Category(int p = 1, int category = 0)
        {
            int pageSize = 2;
            var viewModel = new BlogViewModel(_postRepository, p, pageSize,  category);
            ViewBag.Title = "Latest Posts";

            return View("Index", viewModel);
        }
        // GET: Tag
        public ActionResult Tag(int p = 1, int tag = 0)
        {
            var viewModel = new BlogViewModel(_postRepository, p, 0);
            ViewBag.Title = "Latest Posts";

            return View("Index", viewModel);
        }

        public ActionResult Posts(int? id)
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
            post.Tags = post.Tags.OrderBy(t => t.Tag.Name).ToList();

            return View(post);
        }

    }
}