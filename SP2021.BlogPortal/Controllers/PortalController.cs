using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP2021.BlogPortal.Models;

namespace SP2021.BlogPortal.Controllers
{
    public class PortalController : Controller
    {
        private static List<Blog> _blogs = null;
        public PortalController()
        {
            if (_blogs == null)
            {
                _blogs = new List<Blog>();
                for (int i = 0; i < 25; i++)
                {
                    _blogs.Add(new Blog { Id = i, Name = $"Real Estate Blog - <span style='color:red'>{i}</span>", Description = "Blog related to real estate" });
                }
            }
        }
        // GET: Portal
        public ActionResult Blog()
        {
            return View(_blogs);
        }
        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(Blog input)
        {
            // add this input object
            input.Id = _blogs.Count() + 1;
            _blogs.Add(input);

            return RedirectToAction("Blog");
        }
        public ActionResult EditBlog(int id)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult EditBlog(Blog input)
        {
            var blog = _blogs.FirstOrDefault(t => t.Id == input.Id);
            if(blog != null)
            {
                blog.Name = input.Name;
                blog.Description = input.Description;
            }

            return RedirectToAction("Blog");
        }
        public ActionResult DeleteBlog()
        {
            return View();
        }

    }
}