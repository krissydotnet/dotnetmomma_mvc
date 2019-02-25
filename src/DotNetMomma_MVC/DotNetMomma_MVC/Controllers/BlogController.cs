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
        int pageSize = 10;
        public BlogController()
        {
            _postRepository = new PostRepository(Context);
            
        }

        // GET: Blog
        public ActionResult Index(int page = 1)
        {
            var viewModel = new BlogViewModel(_postRepository, page);
            return View(viewModel);
        }

        public ActionResult Details(int? id)
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