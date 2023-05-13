using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.InterviewTypes.Queries.GetAllInterviewTypes
{
    public class GetInterviewTypes : IRequest<InterviewTypeList>
    {
        public class GetInterviewTypesHandler : IRequestHandler<GetInterviewTypes, InterviewTypeList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetInterviewTypesHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InterviewTypeList> Handle(GetInterviewTypes request, CancellationToken cancellationToken)
            {
                var interviewTypes = await _context.InterviewTypes.AsNoTracking()
                    .Select(interviewType => _mapper.Map<InterviewTypeModel>(interviewType))
                    .ToListAsync(cancellationToken);

                if (interviewTypes is null)
                {
                    throw new NotFoundException("InterviewTypes is empty!");
                }

                return new InterviewTypeList { Items = interviewTypes };
            }
        }
    }
}
