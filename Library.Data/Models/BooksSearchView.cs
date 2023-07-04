namespace Library.Data.Models
{
    public class BooksSearchView
    {
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public long AuthorId { get; set; }

        public string? AuthorFirstName { get; set; }

        public string? AuthorMiddleName { get; set; }

        public string? AuthorLastName { get; set; }

        public long? UserId { get; set; }

        public string? UserFirstName { get; set; }

        public string? UserLastName { get; set; }

        public string? UserEmail { get; set; }
    }
}
