using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBasic.Core.Models;
using BlogBasic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogBasic.Controllers
{
    public class PostController : Controller
    {
        static private List<Post> _postList = null;
        static PostController()
        {
            _postList = new List<Post>();
            _postList.Add(new Post
            {
                Id = 100,
                PostName = "My 100 Post",
                PostDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
            _postList.Add(new Post
            {
                Id = 101,
                PostName = "My 101 Post",
                PostDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
            _postList.Add(new Post
            {
                Id = 102,
                PostName = "My 102 Post",
                PostDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            

            return View(_postList.OrderBy(x=>x.Id).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            post.Id = _postList.Max(x => x.Id) + 1;
            post.TimeStamp = DateTime.UtcNow;
            _postList.Add(post);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // code for edit the post
            Post post = _postList.FirstOrDefault(x => x.Id == id);
            
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            // code for edit the post
            Post postExisting = _postList.FirstOrDefault(x => x.Id == id);
            _postList.Remove(postExisting);

            post.TimeStamp = DateTime.UtcNow;
            _postList.Add(post);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // code for edit the post
            Post post = _postList.FirstOrDefault(x => x.Id == id);

            // delte code
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // code for edit the post
            Post postExisting = _postList.FirstOrDefault(x => x.Id == id);
            _postList.Remove(postExisting);

            return RedirectToAction("Index");
        }
    }
}
