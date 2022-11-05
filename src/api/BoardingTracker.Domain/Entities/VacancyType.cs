namespace BoardingTracker.Domain.Entities
{
    public partial class VacancyType
    {
        public VacancyType()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
