﻿using BoardingTracker.Application.Interviews.Models;
using MediatR;

namespace BoardingTracker.Application.Interviews.Commands.UpdateInterview
{
    public class UpdateInterviewRequest : IRequest<InterviewModel>
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VacancyId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid CandidateId { get; set; }

        public int InterviewTypeId { get; set; }
    }
}
