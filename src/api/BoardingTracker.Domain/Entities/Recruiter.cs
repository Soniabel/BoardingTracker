namespace BoardingTracker.Domain.Entities
{
    public partial class Recruiter
    {
        public Recruiter()
        {
            Interviews = new HashSet<Interview>();
            Vacancies = new HashSet<Vacancy>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
