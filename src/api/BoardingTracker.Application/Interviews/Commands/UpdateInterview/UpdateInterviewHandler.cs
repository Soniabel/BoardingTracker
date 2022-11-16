using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Interviews.Commands.UpdateInterview
{
    public class UpdateInterviewHandler : IRequestHandler<UpdateInterviewRequest, InterviewModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateInterviewHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewModel> Handle(UpdateInterviewRequest request, CancellationToken cancellationToken)
        {
            var interview = await _context.Interviews
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interview is null)
            {
                throw new NotFoundException(nameof(Interview), request.Id);
            }

            interview.Title = request.Title;
            interview.StartTime = request.StartTime;
            interview.EndTime = request.EndTime;
            interview.VacancyId = request.VacancyId;
            interview.RecruiterId = request.RecruiterId;
            interview.CandidateId = request.CandidateId;
            interview.InterviewTypeId = request.InterviewTypeId;

            await _context.SaveChangesAsync(cancellationToken);

            var updatedInterview = await _context.Interviews
                .Include(interview => interview.InterviewType)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<InterviewModel>(updatedInterview);
        }
    }
}
