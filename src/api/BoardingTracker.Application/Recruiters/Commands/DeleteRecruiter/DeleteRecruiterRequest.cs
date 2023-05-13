using MediatR;

namespace BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter
{
    public class DeleteRecruiterRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
