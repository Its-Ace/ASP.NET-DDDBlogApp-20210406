using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBasic.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set; }
        public string PurchaseUrl { get; set; }
    }
}
