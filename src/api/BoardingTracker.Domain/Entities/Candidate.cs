namespace BoardingTracker.Domain.Entities
{
    public partial class Candidate
    {
        public Candidate()
        {
            Interviews = new HashSet<Interview>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Biography { get; set; }
        public string ResumeUrl { get; set; } = null!;
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
