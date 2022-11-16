using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Email = request.Email;
            user.Password = request.Password;
            user.Role = request.Role;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserModel>(user);
        }
    }
}
