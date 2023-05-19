using AutoMapper;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Candidates.Queries.GetCandidateById
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdRequest, CandidateModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetCandidateByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateModel> Handle(GetCandidateByIdRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.AsNoTracking()
                   .Join(_context.Userss,
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
                    })
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (candidate is null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            return _mapper.Map<CandidateModel>(candidate);
        }
    }
}
