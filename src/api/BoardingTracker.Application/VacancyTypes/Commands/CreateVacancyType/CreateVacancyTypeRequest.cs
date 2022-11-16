using BoardingTracker.Application.VacancyTypes.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType
{
    public class CreateVacancyTypeRequest : IRequest<VacancyTypeModel>
    {
        public string Name { get; set; } = null!;
    }
}
