using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBasic.Core.Models
{
    public class Thread : Entity
    {
            public int Id { get; set; }

            [Display(Name = "Thread Title")]
            public string ThreadName { get; set; }

            [Display(Name = "Thread Description")]
            public string ThreadDescription { get; set; }

            [Display(Name = "Thread Content")]
            public string Content { get; set; }

            public DateTime TimeStamp { get; set; }

            public Thread()
            {
                TimeStamp = DateTime.Now;
            }
    }
}
