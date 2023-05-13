using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus
{
    public class UpdateVacancyStatusHandler : IRequestHandler<UpdateVacancyStatusRequest, VacancyStatusModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateVacancyStatusHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyStatusModel> Handle(UpdateVacancyStatusRequest request, CancellationToken cancellationToken)
        {
            var vacancyStatus = await _context.VacancyStatuses
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyStatus is null)
            {
                throw new NotFoundException(nameof(VacancyStatus), request.Id);
            }

            vacancyStatus.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<VacancyStatusModel>(vacancyStatus);
        }
    }
}
