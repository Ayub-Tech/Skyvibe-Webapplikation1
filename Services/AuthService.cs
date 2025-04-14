using Microsoft.EntityFrameworkCore;
using Skyvibe_Webapplikation1.Services.Interfaces;
using SkyVibe_Webapplikation1.Data;
using SkyVibe_Webapplikation1.DTOs;
using SkyVibe_Webapplikation1.Helpers;
using SkyVibe_Webapplikation1.Models;
using SkyVibe_Webapplikation1.Services.Interfaces;
using System;

namespace SkyVibe_Webapplikation1.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> RegisterAsync(UserRegisterDTO dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                throw new Exception("Användarnamnet är redan taget.");

            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return JwtTokenGenerator.GenerateToken(user, _config);
        }

        public async Task<string> LoginAsync(UserLoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Felaktigt användarnamn eller lösenord.");

            return JwtTokenGenerator.GenerateToken(user, _config);
        }
    }
}
