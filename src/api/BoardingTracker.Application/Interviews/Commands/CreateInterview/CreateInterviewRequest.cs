using BoardingTracker.Application.Interviews.Models;
using MediatR;

namespace BoardingTracker.Application.Interviews.Commands.CreateInterview
{
    public class CreateInterviewRequest : IRequest<InterviewModel>
    {
        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VacancyId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid CandidateId { get; set; }

        public int InterviewTypeId { get; set; }
    }
}
