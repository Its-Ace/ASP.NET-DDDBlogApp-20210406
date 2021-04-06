using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP2021.BlogPortal.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Blog Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        public Blog()
        {
            TimeStamp = DateTime.Now;
        }
    }
}


 