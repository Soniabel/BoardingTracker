using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using BoardingTracker.Domain.Entities;

namespace BoardingTracker.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateRequest, CandidateModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateCandidateHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateModel> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(request);

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CandidateModel>(candidate);
        }
    }
}
