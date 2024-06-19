using IT_A_ApiApp01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_A_ApiApp01.Data
{
    public class ProgrammingContext : DbContext
    {
        public DbSet<Programming> Programming { get; set; }

    }
}