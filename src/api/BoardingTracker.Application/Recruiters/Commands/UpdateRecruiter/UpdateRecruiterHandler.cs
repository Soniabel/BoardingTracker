using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter
{
    public class UpdateRecruiterHandler : IRequestHandler<UpdateRecruiterRequest, RecruiterModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateRecruiterHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecruiterModel> Handle(UpdateRecruiterRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (recruiter is null)
            {
                throw new NotFoundException(nameof(Recruiter), request.Id);
            }

            recruiter.FirstName = request.FirstName;
            recruiter.LastName = request.LastName;
            recruiter.ProfileImageUrl = request.ProfileImageUrl;
            recruiter.UserId = request.UserId;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RecruiterModel>(recruiter);
        }
    }
}
