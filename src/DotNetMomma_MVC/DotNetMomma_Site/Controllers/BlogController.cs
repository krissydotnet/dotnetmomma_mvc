using DotNetMomma_Site.ViewModels;
using DotNetMommaShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DotNetMomma_Site.Controllers
{
    public class BlogController : BaseController
    {
        PostRepository _postRepository = null;
        PostCategoryRepository _categoryRepository = null;
        TagRepository _tagRepository = null;

        public BlogController()
        {
            _postRepository = new PostRepository(Context);
            _categoryRepository = new PostCategoryRepository(Context);
            _tagRepository = new TagRepository(Context);
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

        //public ActionResult Posts(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var post = _postRepository.Get((int)id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    post.Tags = post.Tags.OrderBy(t => t.Tag.Name).ToList();

        //    return View(post);
        //}

        public ViewResult Post(int year, int month, string title)
        {
            var post = _postRepository.Post(year, month, title);

            if (post == null)
                throw new HttpException(404, "Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

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
        [ChildActionOnly]
        public PartialViewResult Sidebar()
        {
            var widgetViewModel = new WidgetViewModel(_postRepository, _categoryRepository, _tagRepository);
            return PartialView("_Sidebars", widgetViewModel);
        }

    }
}