using BoardingTracker.Domain.Entities;

namespace BoardingTracker.Application.Auth.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid gid);
    }
}
