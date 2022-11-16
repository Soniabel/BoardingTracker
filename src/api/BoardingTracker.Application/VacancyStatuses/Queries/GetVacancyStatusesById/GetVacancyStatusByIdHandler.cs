using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById
{
    public class GetVacancyStatusByIdHandler : IRequestHandler<GetVacancyStatusByIdRequest, VacancyStatusModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetVacancyStatusByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyStatusModel> Handle(GetVacancyStatusByIdRequest request, CancellationToken cancellationToken)
        {
            var vacancyStatus = await _context.VacancyStatuses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyStatus is null)
            {
                throw new NotFoundException(nameof(VacancyStatus), request.Id);
            }

            return _mapper.Map<VacancyStatusModel>(vacancyStatus);
        }
    }
}
