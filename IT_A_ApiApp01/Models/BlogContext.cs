using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Models
{
    public class BlogContext:DbContext
    {
       public DbSet<Blog> blogs { get; set; }
    }
}