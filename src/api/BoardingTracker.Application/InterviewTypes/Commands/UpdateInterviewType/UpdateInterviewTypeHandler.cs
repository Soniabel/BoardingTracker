using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType
{
    public class UpdateInterviewTypeHandler : IRequestHandler<UpdateInterviewTypeRequest, InterviewTypeModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateInterviewTypeHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewTypeModel> Handle(UpdateInterviewTypeRequest request, CancellationToken cancellationToken)
        {
            var interviewType = await _context.InterviewTypes
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interviewType is null)
            {
                throw new NotFoundException(nameof(InterviewType), request.Id);
            }

            interviewType.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InterviewTypeModel>(interviewType);
        }
    }
}
