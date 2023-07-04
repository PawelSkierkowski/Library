namespace Library.Data.Models
{
    public class UserSummaryView
    {
        public long UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int TotalBooks { get; set; }

        public int TotalDays { get; set; }
    }
}
