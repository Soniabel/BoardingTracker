using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Interviews.Queries.GetAllInterviews
{
    public class GetInterviews : IRequest<InterviewsList>
    {
        public class GetInterviewsHandler : IRequestHandler<GetInterviews, InterviewsList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetInterviewsHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InterviewsList> Handle(GetInterviews request, CancellationToken cancellationToken)
            {
                var interviews = await _context.Interviews.AsNoTracking()
                    .Include(interview => interview.Candidate)
                    .Include(interview => interview.InterviewType)
                    .Include(interview => interview.Recruiter)
                    .Include(interview => interview.Vacancy.SeniorityLevel)
                    .Include(interview => interview.Vacancy.VacancyType)
                    .Include(interview => interview.Vacancy.VacancyStatus)
                    .Select(interview => _mapper.Map<InterviewModel>(interview))
                    .ToListAsync(cancellationToken);

                if (interviews is null)
                {
                    throw new NotFoundException("Interviews is empty!");
                }

                return new InterviewsList { Items = interviews };
            }
        }
    }
}
