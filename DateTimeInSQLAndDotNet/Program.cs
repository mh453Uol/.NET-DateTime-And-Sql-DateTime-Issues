using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucatingDateTime;

namespace DateTimeInSQLAndDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new DatabaseContext())
            {
                var blog = context.Blogs.First();

                var createdDate = blog.CreatedDate.Truncate(TimeSpan.FromSeconds(1));

                var blogByCreatedDate = context.Blogs
                        .Where(b => b.CreatedDate == createdDate)
                        .ToList();

                var foo = context.Blogs.Where(b =>
                    (b.CreatedDate.Year == createdDate.Year
                    && b.CreatedDate.Month == createdDate.Month
                    && b.CreatedDate.Day == createdDate.Day
                    && b.CreatedDate.Hour == createdDate.Hour
                    && b.CreatedDate.Minute == createdDate.Minute
                    && b.CreatedDate.Second == createdDate.Second))
                    .FirstOrDefault();
            }
        }
    }
}
