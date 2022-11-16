using BoardingTracker.Application.InterviewTypes.Models;
using MediatR;

namespace BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType
{
    public class CreateInterviewTypeRequest : IRequest<InterviewTypeModel>
    {
        public string Name { get; set; } = null!;
    }
}
