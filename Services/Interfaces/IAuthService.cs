using SkyVibe_Webapplikation1.DTOs;

namespace Skyvibe_Webapplikation1.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserRegisterDTO dto);
        Task<string> LoginAsync(UserLoginDTO dto);
    }
}
