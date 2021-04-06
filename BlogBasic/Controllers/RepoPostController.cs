using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using BlogBasic.Core.Models;
using BlogBasic.InfrastrutureCore.Context;
using BlogBasic.InfrastrutureCore.Repo;
using BlogBasic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogBasic.Controllers
{
    public class RepoPostController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Thread> _threadRepository;

        public RepoPostController(
            IRepository<Post> postRepository,   //injected by the core framework
            IRepository<Thread> threadRepository
            )
        {
            _postRepository = postRepository;
            _threadRepository = threadRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_postRepository.GetAll().Result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            post.Id = _postRepository.Max().Result;
            post.TimeStamp = DateTime.UtcNow;
            _postRepository.Add(post);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // code for edit the post
            Post post = _postRepository.Get(id).Result;

            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            _postRepository.Update(id, post);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // code for edit the post
            Post post = _postRepository.Get(id).Result;

            // delte code
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _postRepository.Remove(_postRepository.Get(id).Result);
            return RedirectToAction("Index");
        }
    }
}
