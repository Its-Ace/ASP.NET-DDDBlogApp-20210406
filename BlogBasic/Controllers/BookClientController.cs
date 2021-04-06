using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBasic.Context;
using BlogBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogBasic.Controllers
{
    public class BookClientController : Controller
    {

        private BookContext _db = null;
        public BookClientController(BookContext db)
        {
            _db = db;
        }


        public IActionResult Index(string isbn)
        {
            return View(Compare(isbn));
        }

        //Facade --- 
        public List<Book> Compare(string isbn)
        {
            BookAController clientA = new BookAController(_db);
            Book bookA = clientA.Get(isbn);
            BookBController clientB = new BookBController(_db);
            Book bookB = clientB.Get(isbn);
            List<Book> books = new List<Book>();
            books.Add(bookA);
            books.Add(bookB);

            books.Sort(delegate (Book b1, Book b2)
            {
                return b1.Price.CompareTo(b2.Price);
            });
            return books;
        }
    }
}