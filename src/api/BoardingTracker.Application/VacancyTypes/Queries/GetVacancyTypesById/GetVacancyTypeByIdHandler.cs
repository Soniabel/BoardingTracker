using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById
{
    public class GetVacancyTypeByIdHandler : IRequestHandler<GetVacancyTypeByIdRequest, VacancyTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetVacancyTypeByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyTypeModel> Handle(GetVacancyTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var vacancyType = await _context.VacancyTypes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyType is null)
            {
                throw new NotFoundException(nameof(VacancyType), request.Id);
            }

            return _mapper.Map<VacancyTypeModel>(vacancyType);
        }
    }
}
