using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP2021.BlogPortal.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        //public int BlogId { get; set; }

        [Required]
        [Display(Name = "Post Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        public Post()
        {
            TimeStamp = DateTime.Now;
        }
    }
}


 