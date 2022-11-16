using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Interviews.Queries.GetInterviewsById
{
    public class GetInterviewByIdHandler : IRequestHandler<GetInterviewByIdRequest, InterviewModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetInterviewByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewModel> Handle(GetInterviewByIdRequest request, CancellationToken cancellationToken)
        {
            var interview = await _context.Interviews.AsNoTracking()
                .Include(interview => interview.Candidate)
                .Include(interview => interview.InterviewType)
                .Include(interview => interview.Recruiter)
                .Include(interview => interview.Vacancy.SeniorityLevel)
                .Include(interview => interview.Vacancy.VacancyType)
                .Include(interview => interview.Vacancy.VacancyStatus)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interview is null)
            {
                throw new NotFoundException(nameof(Interview), request.Id);
            }

            return _mapper.Map<InterviewModel>(interview);
        }

    }
}
