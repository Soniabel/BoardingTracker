using BoardingTracker.Application.VacancyStatuses.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById
{
    public class GetVacancyStatusByIdRequest : IRequest<VacancyStatusModel>
    {
        public int Id { get; set; }
    }
}
