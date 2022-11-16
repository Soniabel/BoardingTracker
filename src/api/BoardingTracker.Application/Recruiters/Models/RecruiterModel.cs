namespace BoardingTracker.Application.Recruiters.Models
{
    public class RecruiterModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ProfileImageUrl { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }
    }
}
