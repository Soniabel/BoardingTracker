using AutoMapper;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateUserHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserModel>(user);
        }
    }
}
