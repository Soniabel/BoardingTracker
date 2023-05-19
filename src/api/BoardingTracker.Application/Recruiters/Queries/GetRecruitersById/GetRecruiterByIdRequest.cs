using BoardingTracker.Application.Recruiters.Models;
using MediatR;

namespace BoardingTracker.Application.Recruiters.Queries.GetRecruitersById
{
    public class GetRecruiterByIdRequest : IRequest<RecruiterModel>
    {
        public Guid Id { get; set; }
    }
}
