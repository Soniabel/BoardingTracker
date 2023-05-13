using AutoMapper;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Candidates.Queries.GetAllCandidates
{
    public class GetCandidates : IRequest<CandidatesList>
    {
        public class GetCandidatesHandler : IRequestHandler<GetCandidates, CandidatesList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetCandidatesHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CandidatesList> Handle(GetCandidates request, CancellationToken cancellationToken)
            {
                var candidates = await _context.Candidates
                    .Join(_context.Users,
                    candidate => candidate.UserId,
                    user => user.Id,
                    (candidate, user) => new CandidateModel
                    {
                        Id = candidate.Id,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        PhoneNumber = candidate.PhoneNumber,
                        Biography = candidate.Biography,
                        ResumeUrl = candidate.ResumeUrl,
                        UserId = user.Id,
                        Email = user.Email
                    }).ToListAsync(cancellationToken);

                if (candidates is null)
                {
                    throw new NotFoundException("Candidates is empty!");
                }

                return new CandidatesList { Items = candidates };
            }
        }
    }
}
