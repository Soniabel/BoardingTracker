using MediatR;

namespace BoardingTracker.Application.Interviews.Commands.DeleteInterview
{
    public class DeleteInterviewRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
