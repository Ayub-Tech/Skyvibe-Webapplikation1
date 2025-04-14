using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationReadDTO>> GetAllAsync();
        Task<LocationReadDTO?> GetByIdAsync(int id);
        Task<LocationReadDTO> CreateAsync(LocationCreateDTO dto);
        Task<bool> UpdateAsync(int id, LocationCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
