using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById
{
    public class GetInterviewTypeByIdHandler : IRequestHandler<GetInterviewTypeByIdRequest, InterviewTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetInterviewTypeByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewTypeModel> Handle(GetInterviewTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var interviewType = await _context.InterviewTypes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interviewType is null)
            {
                throw new NotFoundException(nameof(InterviewType), request.Id);
            }

            return _mapper.Map<InterviewTypeModel>(interviewType);
        }
    }
}
