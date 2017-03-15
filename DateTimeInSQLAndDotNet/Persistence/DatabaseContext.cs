using DateTimeInSQLAndDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeInSQLAndDotNet
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Server=.;Database=DateTimeInSQLAndDotNet;Trusted_Connection=True;")
        {
            Database.SetInitializer(new TestDataInitializer());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

