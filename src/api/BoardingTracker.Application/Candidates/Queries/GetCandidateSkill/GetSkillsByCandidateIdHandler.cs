using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Candidates.Queries.GetCandidateSkill
{
    public class GetSkillsByCandidateIdHandler : IRequestHandler<GetSkillsByCandidateIdRequest, SkillList>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetSkillsByCandidateIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillList> Handle(GetSkillsByCandidateIdRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (candidate is null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            var skills = await _context.CandidateSkills.Where(candidateSkills => candidateSkills.CandidateId == request.Id)
                .Join(_context.Skills,
                candidateSkills => candidateSkills.SkillId,
                skill => skill.Id,
                (candidateSkills, skill) => _mapper.Map<SkillModel>(skill)).ToListAsync();

            if (skills is null)
            {
                throw new NotFoundException("Skills is empty!");
            }

            return new SkillList { Items = skills };
        }
    }
}
