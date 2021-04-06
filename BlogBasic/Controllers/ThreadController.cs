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

    public class ThreadController : Controller
    {
    
          static private List<Thread> _threadList = null;
    static ThreadController()
        {
            _threadList = new List<Thread>();
            _threadList.Add(new Thread
            {
                Id = 100,
                ThreadName = "My 100 Thread",
                ThreadDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
            _threadList.Add(new Thread
            {
                Id = 101,
                ThreadName = "My 101 Thread",
                ThreadDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
            _threadList.Add(new Thread
            {
                Id = 102,
                ThreadName = "My 102 Thread",
                ThreadDescription = "Post for SDT genious students",
                Content = "this is the new repository post in git",
                TimeStamp = DateTime.UtcNow
            });
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_threadList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Thread thread)
        {
            // create the post in database
            thread.Id = _threadList.Max(x => x.Id) + 1;
            thread.TimeStamp = DateTime.UtcNow;
            _threadList.Add(thread);

            return RedirectToAction("Index");
           
        }

        public IActionResult Edit(int id)
        {
            // code for edit the post
            Thread thread = _threadList.FirstOrDefault(x => x.Id == id);
            return View(thread);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Thread thread)
        {
            // code for edit the post
            Thread threadExisting = _threadList.FirstOrDefault(x => x.Id == id);
            _threadList.Remove(threadExisting);

            thread.TimeStamp = DateTime.UtcNow;
            _threadList.Add(thread);

            return RedirectToAction("Index");
            
        }

        public IActionResult Delete(int id)
        { 
            // delte code
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // delte code
            return View();
        }
    }
}
