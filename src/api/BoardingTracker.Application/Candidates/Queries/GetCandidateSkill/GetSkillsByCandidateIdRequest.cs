﻿using BoardingTracker.Application.Skills.Models;
using MediatR;

namespace BoardingTracker.Application.Candidates.Queries.GetCandidateSkill
{
    public class GetSkillsByCandidateIdRequest : IRequest<SkillList>
    {
        public Guid UserId { get; set; }
    }
}
