using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        Task<List<CurrentWeatherReadDTO>> GetAllAsync();
        Task<CurrentWeatherReadDTO?> GetByIdAsync(int id);
        Task<CurrentWeatherReadDTO> CreateAsync(CurrentWeatherCreateDTO dto);
        Task<bool> UpdateAsync(int id, CurrentWeatherCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
