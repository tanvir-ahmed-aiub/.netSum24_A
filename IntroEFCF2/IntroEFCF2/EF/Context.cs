using IntroEFCF2.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroEFCF2.EF
{
    public class Context : DbContext
    {
 
        public DbSet<Department> Deparments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}