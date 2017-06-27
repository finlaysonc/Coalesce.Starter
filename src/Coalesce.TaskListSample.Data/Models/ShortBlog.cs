using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coalesce.TaskListSample.Data.Models
{
    public class ShortBlog
    {
        [Key]
        public int BlogId { get; set; }

        public string Url { get; set; }

    }

    public class BlogsWithNameFoo
    {
        [Key]
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class BlogAndAuthor
    {
        [Key]
        public int BlogId { get; set; }

        public string Url { get; set; }

        public string LastName { get; set; }

    }

}