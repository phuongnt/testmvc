using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC4.data
{
    public class dbContext:DbContext
    {
        public dbContext()
        :base("name=myContext") { }
         
        public DbSet<Airline> Airlines { get; set; }

    }
}