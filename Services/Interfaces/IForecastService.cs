using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Services.Interfaces
{
    public interface IForecastService
    {
        Task<List<ForecastReadDTO>> GetAllAsync();
        Task<ForecastReadDTO?> GetByIdAsync(int id);
        Task<ForecastReadDTO> CreateAsync(ForecastCreateDTO dto);
        Task<bool> UpdateAsync(int id, ForecastCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
