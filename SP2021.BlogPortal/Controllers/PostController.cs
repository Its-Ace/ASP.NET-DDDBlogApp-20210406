using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP2021.BlogPortal.DAL;
using SP2021.BlogPortal.Models;

namespace SP2021.BlogPortal.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDatabaseContext _context = null;
        public PostController(BlogDatabaseContext context)
        {
            _context = context;
        }
        // GET: Portal
        public ActionResult Index()
        {
            // get list from database table 
            var posts = _context.Posts.ToList();
            return View(posts);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post input)
        {
            // add a record in database
            _context.Posts.Add(input);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            // read a record form database to edite
            var post = _context.Posts.FirstOrDefault(t => t.Id == id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post input)
        {
            // save this record into database that came from Page
            _context.Posts.Update(input);
            _context.SaveChanges();
            return RedirectToAction("Blog");
        }
        public ActionResult DeleteBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // delete in database the record
            var post = _context.Posts.FirstOrDefault(t => t.Id == id);
            _context.Posts.Remove(post);
            _context.SaveChanges();

            return View();
        }

    }
}