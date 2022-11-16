using BoardingTracker.Application.Vacancies.Models;
using MediatR;

namespace BoardingTracker.Application.Vacancies.Queries.GetVacanciesById
{
    public class GetVacancyByIdRequest : IRequest<VacancyModel>
    {
        public int Id { get; set; }
    }
}
