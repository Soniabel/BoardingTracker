using AutoMapper;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.Recruiters.Commands.CreateRecruiter
{
    public class CreateRecruiterHandler : IRequestHandler<CreateRecruiterRequest, RecruiterModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateRecruiterHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecruiterModel> Handle(CreateRecruiterRequest request, CancellationToken cancellationToken)
        {
            var recruiter = _mapper.Map<Recruiter>(request);

            _context.Recruiters.Add(recruiter);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RecruiterModel>(recruiter);
        }
    }
}
