using DateTimeInSQLAndDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeInSQLAndDotNet
{
    public class TestDataInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            IList<Blog> Blogs = new List<Blog>();

            Blogs.Add(new Blog()
            {
                CreatedDate = DateTime.Now,
                ModifedDate = DateTime.Now,
                Name = "Majid Placement",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Content = "This is my first post!",
                        CreatedDate = DateTime.Now,
                        ModifedDate = DateTime.Now,
                    },
                    new Post()
                    {
                        Content = "This is my second post!",
                        CreatedDate = DateTime.Now,
                        ModifedDate = DateTime.Now,
                    },
                    new Post()
                    {
                        Content = "This is my third post!",
                        CreatedDate = DateTime.Now,
                        ModifedDate = DateTime.Now,
                    }
                }
            });

            Blogs.Add(new Blog()
            {
                CreatedDate = DateTime.Now,
                ModifedDate = DateTime.Now,
                Name = "FooBar Blog",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Content = "This is my first post wooah!",
                        CreatedDate = DateTime.Now,
                        ModifedDate = DateTime.Now,
                    }
                }
            });

            context.Blogs.AddRange(Blogs);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
