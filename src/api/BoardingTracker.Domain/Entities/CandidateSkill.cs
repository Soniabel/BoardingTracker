﻿namespace BoardingTracker.Domain.Entities
{
    public partial class CandidateSkill
    {
        public Guid? CandidateId { get; set; }
        public int? SkillId { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}
