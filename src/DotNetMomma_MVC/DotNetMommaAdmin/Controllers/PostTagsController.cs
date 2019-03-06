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
    public class PostTagsController : BaseController
    {
        private PostRepository _postRepository = null;
        private TagRepository _tagRepository = null;
        private PostTagsRepository _postTagsRepository = null;

        public PostTagsController()
        {
            _postRepository = new PostRepository(Context);
            _tagRepository = new TagRepository(Context);
            _postTagsRepository = new PostTagsRepository(Context);
        }


        // GET: PostTags/Create
        public ActionResult Add(int postId)
        {
            var post = _postRepository.Get(postId);

            if (post == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PostTagsAddViewModel()
            {
                Post = post
            };

            viewModel.Init(_tagRepository);

            return View(viewModel);
        }

        // POST: PostTags/Add
        [HttpPost]
        public ActionResult Add(PostTagsAddViewModel viewModel)
        {
            ValidatePostTags(viewModel);

            if (ModelState.IsValid)
            {
                var postTags = new PostTags()
                {
                    PostId = viewModel.PostId,
                    TagId = viewModel.TagId,
                };

                _postTagsRepository.Add(postTags);

                TempData["Message"] = "Your tag was successfully added!";

                return RedirectToAction("Edit", "Post", new { id = viewModel.PostId });

            }


            viewModel.Post = _postRepository.Get(viewModel.PostId);
            viewModel.Init(_tagRepository);

            return View(viewModel);
        }

        public ActionResult Delete(int postId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var postTags = _postTagsRepository.Get((int)id);


            if (postTags == null)
            {
                return HttpNotFound();
            }

            return View(postTags);
        }

        [HttpPost]
        public ActionResult Delete(int postId, int id)
        {
            // TODO Delete the comic book artist.

            _postTagsRepository.Delete(id);

            TempData["Message"] = "Your tag was successfully deleted!";

            return RedirectToAction("Edit", "Post", new { id = postId });
        }

        private void ValidatePostTags(PostTagsAddViewModel viewModel)
        {
            if (ModelState.IsValidField("PostId") &&
                ModelState.IsValidField("TagId"))
            {
                if (_postTagsRepository.PostHasTagAlready(viewModel.PostId, viewModel.TagId))
                {
                    ModelState.AddModelError("TagId",
                        "This tag already exists for this post.");
                }
            }
        }
    }
}
