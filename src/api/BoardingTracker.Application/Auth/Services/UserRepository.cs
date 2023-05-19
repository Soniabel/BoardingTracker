using BoardingTracker.Application.Auth.Abstract;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Auth.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DBBoardingTrackerContext _context;

        public UserRepository(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Userss.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetByIdAsync(Guid gid)
        {
            return await _context.Userss.FirstOrDefaultAsync(user => user.Id == gid);
        }
    }
}
