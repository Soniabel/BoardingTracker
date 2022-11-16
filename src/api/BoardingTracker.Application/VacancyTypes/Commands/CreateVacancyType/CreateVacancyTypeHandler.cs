using AutoMapper;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType
{
    public class CreateVacancyTypeHandler : IRequestHandler<CreateVacancyTypeRequest, VacancyTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateVacancyTypeHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyTypeModel> Handle(CreateVacancyTypeRequest request, CancellationToken cancellationToken)
        {
            var vacancyType = _mapper.Map<VacancyType>(request);

            _context.VacancyTypes.Add(vacancyType);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<VacancyTypeModel>(vacancyType);
        }
    }
}
