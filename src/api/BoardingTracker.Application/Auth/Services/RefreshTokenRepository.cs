using BoardingTracker.Application.Auth.Abstract;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Auth.Services
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DBBoardingTrackerContext _context;

        public RefreshTokenRepository(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task Create(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Guid userGID)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens
                .Where(t => t.UserGID == userGID)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid refreshTokenGID)
        {
            var result = await _context.RefreshTokens.FindAsync(refreshTokenGID);
            _context.RefreshTokens.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstAsync(t => t.Token == token);
        }
    }
}
