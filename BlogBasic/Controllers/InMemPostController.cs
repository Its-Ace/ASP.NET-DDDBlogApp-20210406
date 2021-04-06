using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using BlogBasic.Core.Models;
using BlogBasic.InfrastrutureCore.Context;
using BlogBasic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogBasic.Controllers
{
    public class InMemPostController : Controller
    {
        private readonly BlogContext _blogContext;

        public InMemPostController(
            BlogContext blogContext   //injected by the core framework
            )
        {
            _blogContext = blogContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            

            return View(_blogContext.Posts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            //post.Id = _blogContext.Posts.Max(x => x.Id) + 1;
            //post.Id = 1000;
            post.TimeStamp = DateTime.UtcNow;
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // code for edit the post
            Post post = _blogContext.Posts.FirstOrDefault(x => x.Id == id);
            
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            // code for edit the post
            Post postExisting = _blogContext.Posts.FirstOrDefault(x => x.Id == id);
            if(postExisting != null)
            {
                _blogContext.Entry(postExisting).CurrentValues.SetValues(post);
            }

            _blogContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // code for edit the post
            Post post = _blogContext.Posts.FirstOrDefault(x => x.Id == id);

            // delte code
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // code for edit the post
            Post postExisting = _blogContext.Posts.FirstOrDefault(x => x.Id == id);
            _blogContext.Posts.Remove(postExisting);
            _blogContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
