using BoardingTracker.Application.VacancyTypes.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType
{
    public class UpdateVacancyTypeRequest : IRequest<VacancyTypeModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
