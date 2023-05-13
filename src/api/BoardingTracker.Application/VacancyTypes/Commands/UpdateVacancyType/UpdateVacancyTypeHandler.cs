using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType
{
    public class UpdateVacancyTypeHandler : IRequestHandler<UpdateVacancyTypeRequest, VacancyTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateVacancyTypeHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyTypeModel> Handle(UpdateVacancyTypeRequest request, CancellationToken cancellationToken)
        {
            var vacancyType = await _context.VacancyTypes
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyType is null)
            {
                throw new NotFoundException(nameof(VacancyType), request.Id);
            }

            vacancyType.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<VacancyTypeModel>(vacancyType);
        }
    }
}
