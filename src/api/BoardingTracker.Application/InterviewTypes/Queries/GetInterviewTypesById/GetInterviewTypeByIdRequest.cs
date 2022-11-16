using BoardingTracker.Application.InterviewTypes.Models;
using MediatR;

namespace BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById
{
    public class GetInterviewTypeByIdRequest : IRequest<InterviewTypeModel>
    {
        public int Id { get; set; }
    }
}
