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
        public BlogController()
        {
            _postRepository = new PostRepository(Context);
            
        }

        // GET: Blog
        public ActionResult Index(int p = 1)
        {
            int pageSize = 5;
            var viewModel = new BlogViewModel(_postRepository, p, pageSize);
            ViewBag.Title = "Latests Posts";

            return View(viewModel);
        }

        // GET: Category
        public ActionResult Category(string category, int p = 1)
        {
            int pageSize = 5;
            var viewModel = new BlogViewModel(_postRepository, category, "Category", p, pageSize);
            if (viewModel.PostCategory == null)
                throw new HttpException(404, "Category not found");

            ViewBag.Title = String.Format(@"Latest posts in category ""{0}""",
                                viewModel.PostCategory.Name);

            return View("Index", viewModel);
        }

        // GET: Tag
        public ActionResult Tag(string tag, int p = 1)
        {
            int pageSize = 5;
            var viewModel = new BlogViewModel(_postRepository, tag, "Tag", p, pageSize);
            if (viewModel.Tag == null)
                throw new HttpException(404, "Tag not found");
            ViewBag.Title = String.Format(@"Latest posts with tag ""{0}""",
                                viewModel.Tag.Name);

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

        public ActionResult Search(string s, int p = 1)
        {
            int pageSize = 5;

            ViewBag.Title = String.Format(@"Lists of posts found
                        for search text ""{0}""", s);

            var viewModel = new BlogViewModel(_postRepository, s, "Search", p, pageSize);
            return View("Index", viewModel);
        }

    }
}