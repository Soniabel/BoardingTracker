using BoardingTracker.Application.Auth.Abstract;
using BoardingTracker.Application.Auth.Models;
using BoardingTracker.Application.Auth.TokenGenerators;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;

namespace BoardingTracker.Application.Auth.Services
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordHasher _passwordHasher;

        public SecurityRepository(DBBoardingTrackerContext context,
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticateResult> Authenticate(User user)
        {
            AccessToken accessToken = _accessTokenGenerator.GenerateToken(user);
            string refreshToken = _refreshTokenGenerator.GenerateToken();
            var refreshTokenDto = new RefreshToken
            {
                Token = refreshToken,
                UserGID = user.Id,
                UserId = user.Id
            };

            await _refreshTokenRepository.Create(refreshTokenDto);
            return new AuthenticateResult
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                RefreshToken = refreshToken,
                Role = user.Role,
                UserGID = user.Id.ToString()
            };
        }

        public async Task<RegisterResult> Registration(User user)
        {
            var emailAlredyExist = await _userRepository.GetByEmailAsync(user.Email);
            if (emailAlredyExist != null)
                throw new System.Exception("Error Email");

            var passwordHash = _passwordHasher.HashPassword(user.Password);

            var newUser = new User
            {
                Email = user.Email,
                Password = passwordHash,
                Role = user.Role
            };

            await _context.Userss.AddAsync(newUser);
            await _context.SaveChangesAsync();

            AccessToken accessToken = _accessTokenGenerator.GenerateToken(newUser);

            return new RegisterResult
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                UserGID = newUser.Id.ToString(),
                Role = newUser.Role
            };
        }
    }
}
