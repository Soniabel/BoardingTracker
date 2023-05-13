using MediatR;

namespace BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus
{
    public class DeleteVacancyStatusRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
