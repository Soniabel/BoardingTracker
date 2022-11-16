using AutoMapper;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Interviews.Commands.CreateInterview
{
    public class CreateInterviewHandler : IRequestHandler<CreateInterviewRequest, InterviewModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;
        //private readonly IEmailSender _emailSender;

        public CreateInterviewHandler(DBBoardingTrackerContext context, IMapper mapper) //IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            //_emailSender = emailSender;
        }

        public async Task<InterviewModel> Handle(CreateInterviewRequest request, CancellationToken cancellationToken)
        {
            var interview = _mapper.Map<Interview>(request);

            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync(cancellationToken);

            var createdInterview = await _context.Interviews
                .Include(interview => interview.InterviewType)
                .Include(interview => interview.Recruiter).ThenInclude(x => x.User)
                .Include(interview => interview.Candidate).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == interview.Id);

            var emails = new List<string>() { createdInterview.Recruiter.User.Email, createdInterview.Candidate.User.Email };

            //await _emailSender.SendEmailAsync(emails);

            return _mapper.Map<InterviewModel>(createdInterview);
        }
    }
}
