using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, UserModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Userss.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserModel>(user);
        }
    }
}
