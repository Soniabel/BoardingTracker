using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Recruiters.Queries.GetRecruitersById
{
    public class GetRecruiterByIdHandler : IRequestHandler<GetRecruiterByIdRequest, RecruiterModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetRecruiterByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecruiterModel> Handle(GetRecruiterByIdRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters.AsNoTracking()
                   .FirstOrDefaultAsync(x => x.UserId == request.UserId);

            if (recruiter is null)
            {
                throw new NotFoundException(nameof(Recruiter), request.UserId);
            }

            return _mapper.Map<RecruiterModel>(recruiter);
        }
    }
}
