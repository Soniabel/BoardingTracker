﻿namespace BoardingTracker.Application.Candidates.Models
{
    public class CandidateModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Biography { get; set; }

        public string ResumeUrl { get; set; } = null!;

        public string Email { get; set; }

        public Guid UserId { get; set; }
    }
}
