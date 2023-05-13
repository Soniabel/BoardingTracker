using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Users.Queries.GetAllUsers
{
    public class GetUsers : IRequest<UsersList>
    {
        public class GetUsersHandler : IRequestHandler<GetUsers, UsersList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetUsersHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UsersList> Handle(GetUsers request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.AsNoTracking()
                    .Select(user => _mapper.Map<UserModel>(user))
                    .ToListAsync(cancellationToken);

                if (users is null)
                {
                    throw new NotFoundException("Users is empty!");
                }

                return new UsersList { Items = users };
            }
        }
    }
}
