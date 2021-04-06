using Microsoft.EntityFrameworkCore;
using SP2021.BlogPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP2021.BlogPortal.DAL
{
    public class BlogDatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogDatabaseContext(DbContextOptions<BlogDatabaseContext> options) :
            base(options)
        {
        }
    }
}
