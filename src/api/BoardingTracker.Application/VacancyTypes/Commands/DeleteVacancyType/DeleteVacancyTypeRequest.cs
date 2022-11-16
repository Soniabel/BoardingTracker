using MediatR;

namespace BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType
{
    public class DeleteVacancyTypeRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
