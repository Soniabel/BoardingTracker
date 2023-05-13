using BoardingTracker.Application.VacancyStatuses.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus
{
    public class UpdateVacancyStatusRequest : IRequest<VacancyStatusModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
