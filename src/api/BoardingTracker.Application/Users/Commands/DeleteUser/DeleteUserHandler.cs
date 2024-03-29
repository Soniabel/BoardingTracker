﻿using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Guid>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteUserHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Userss.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _context.Userss.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
