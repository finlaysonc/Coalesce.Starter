namespace Coalesce.TaskListSample.Data.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set;}

        public string LastName { get; set; }
    }

}