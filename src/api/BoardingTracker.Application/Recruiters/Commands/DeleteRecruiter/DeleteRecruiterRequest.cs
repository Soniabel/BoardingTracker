using MediatR;

namespace BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter
{
    public class DeleteRecruiterRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
