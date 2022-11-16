using MediatR;

namespace BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType
{
    public class DeleteInterviewTypeRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
