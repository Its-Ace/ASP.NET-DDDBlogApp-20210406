using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBasic.Context;
using BlogBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogBasic.Controllers
{
    public class BookAController : Controller
    {
        private BookContext _db = null;
        public BookAController(BookContext db)
        {
            _db = db;
        }

        [HttpGet("{isbn}")]
        public Book Get(string isbn)
        {
             
            var query = from b in _db.Books
                        where b.ISBN == isbn && b.Source == "Book Store 1"
                        select b;
            return query.SingleOrDefault();
             
        }
    }
}