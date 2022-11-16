using BoardingTracker.Application.VacancyTypes.Models;
using MediatR;

namespace BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById
{
    public class GetVacancyTypeByIdRequest : IRequest<VacancyTypeModel>
    {
        public int Id { get; set; }
    }
}
