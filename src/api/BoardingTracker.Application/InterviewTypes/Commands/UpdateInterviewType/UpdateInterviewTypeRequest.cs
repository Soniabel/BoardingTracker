using BoardingTracker.Application.InterviewTypes.Models;
using MediatR;

namespace BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType
{
    public class UpdateInterviewTypeRequest : IRequest<InterviewTypeModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
