namespace BoardingTracker.Application.Recruiters.Models
{
    public class RecruiterModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ProfileImageUrl { get; set; }

        public Guid UserId { get; set; }

        public string Email { get; set; }
    }
}
