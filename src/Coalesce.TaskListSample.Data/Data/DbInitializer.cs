using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Coalesce.TaskListSample.Data.Models;

namespace Coalesce.TaskListSample.Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext db)
        {
            db.Database.ExecuteSqlCommand(
                    "CREATE FUNCTION [dbo].[SearchBlogs] (@term nvarchar(200)) RETURNS TABLE AS RETURN (SELECT * FROM dbo.Blogs WHERE Url LIKE '%' + @term + '%')");

            Author author = new Author() { LastName = "Michaelis" };
            db.Blogs.Add(new Blog { Name = "Foo  Blog", Url = "http://sample.com/blogs/horses", Author = author });
            db.Blogs.Add(new Blog { Name = "The Horse Blog", Url = "http://sample.com/blogs/horses", Author = author });
            db.Blogs.Add(new Blog { Name = "The Snake Blog", Url = "http://sample.com/blogs/snakes", Author = author });
            db.Blogs.Add(new Blog { Name = "The Fish Blog", Url = "http://sample.com/blogs/fish", Author = author });
            db.Blogs.Add(new Blog { Name = "The Koala Blog", Url = "http://sample.com/blogs/koalas", Author = author });
            db.Blogs.Add(new Blog { Name = "The Parrot Blog", Url = "http://sample.com/blogs/parrots", Author = author });
            db.Blogs.Add(new Blog { Name = "The Kangaroo Blog", Url = "http://sample.com/blogs/kangaroos", Author = author });
            db.SaveChanges();
        }
    }
}