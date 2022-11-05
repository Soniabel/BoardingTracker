namespace BoardingTracker.Domain.Entities
{
    public partial class InterviewType
    {
        public InterviewType()
        {
            Interviews = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
