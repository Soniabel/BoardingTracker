using MediatR;

namespace BoardingTracker.Application.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
