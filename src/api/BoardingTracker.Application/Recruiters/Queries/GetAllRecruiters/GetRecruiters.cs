using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Recruiters.Queries.GetAllRecruiters
{
    public class GetRecruiters : IRequest<RecruitersList>
    {
        public class GetRecruitersHandler : IRequestHandler<GetRecruiters, RecruitersList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetRecruitersHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RecruitersList> Handle(GetRecruiters request, CancellationToken cancellationToken)
            {
                var recruiters = await _context.Recruiters
                    .Join(_context.Users,
                    recruiter => recruiter.UserId,
                    user => user.Id,
                    (recruiter, user) => new RecruiterModel
                    {
                        Id = recruiter.Id,
                        FirstName = recruiter.FirstName,
                        LastName = recruiter.LastName,
                        ProfileImageUrl = recruiter.ProfileImageUrl,
                        UserId = user.Id,
                        Email = user.Email
                    })
                    .ToListAsync(cancellationToken);

                if (recruiters is null)
                {
                    throw new NotFoundException("Recruiters is empty!");
                }

                return new RecruitersList { Items = recruiters };
            }
        }
    }
}
