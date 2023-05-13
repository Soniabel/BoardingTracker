using BoardingTracker.Application.Interviews.Models;
using MediatR;

namespace BoardingTracker.Application.Interviews.Queries.GetInterviewsById
{
    public class GetInterviewByIdRequest : IRequest<InterviewModel>
    {
        public int Id { get; set; }
    }
}
