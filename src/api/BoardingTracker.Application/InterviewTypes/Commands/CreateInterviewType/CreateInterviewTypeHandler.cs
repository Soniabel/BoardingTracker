using AutoMapper;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType
{
    public class CreateInterviewTypeHandler : IRequestHandler<CreateInterviewTypeRequest, InterviewTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateInterviewTypeHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewTypeModel> Handle(CreateInterviewTypeRequest request, CancellationToken cancellationToken)
        {
            var interviewType = _mapper.Map<InterviewType>(request);

            _context.InterviewTypes.Add(interviewType);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InterviewTypeModel>(interviewType);
        }
    }
}
