using BoardingTracker.Application.Auth.Models;
using BoardingTracker.Domain.Entities;

namespace BoardingTracker.Application.Auth.Abstract
{
    public interface ISecurityRepository
    {
        Task<AuthenticateResult> Authenticate(User user);
        Task<RegisterResult> Registration(User user);
    }
}
