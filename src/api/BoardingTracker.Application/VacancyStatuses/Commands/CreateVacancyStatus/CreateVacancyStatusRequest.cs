using BoardingTracker.Application.VacancyStatuses.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus
{
    public class CreateVacancyStatusRequest : IRequest<VacancyStatusModel>
    {
        public string Name { get; set; } = null!;
    }
}
