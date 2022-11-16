using AutoMapper;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateRequest, CandidateModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateCandidateHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateModel> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (candidate is null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            candidate.FirstName = request.FirstName;
            candidate.LastName = request.LastName;
            candidate.PhoneNumber = request.PhoneNumber;
            candidate.Biography = request.Biography;
            candidate.ResumeUrl = request.ResumeUrl;
            candidate.UserId = request.UserId;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CandidateModel>(candidate);
        }
    }
}
