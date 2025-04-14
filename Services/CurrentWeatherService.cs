using Microsoft.EntityFrameworkCore;
using SkyVibe_Webapplikation1.Data;
using SkyVibe_Webapplikation1.DTOs;
using SkyVibe_Webapplikation1.Models;
using SkyVibe_Webapplikation1.Services.Interfaces;

namespace SkyVibe_Webapplikation1.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly AppDbContext _context;

        public CurrentWeatherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CurrentWeatherReadDTO>> GetAllAsync()
        {
            return await _context.CurrentWeathers
                .Select(c => new CurrentWeatherReadDTO
                {
                    Id = c.Id,
                    RetrievedAt = c.RetrievedAt,
                    Temperature = c.Temperature,
                    Description = c.Description,
                    LocationId = c.LocationId
                })
                .ToListAsync();
        }

        public async Task<CurrentWeatherReadDTO?> GetByIdAsync(int id)
        {
            var data = await _context.CurrentWeathers.FindAsync(id);
            return data == null ? null : new CurrentWeatherReadDTO
            {
                Id = data.Id,
                RetrievedAt = data.RetrievedAt,
                Temperature = data.Temperature,
                Description = data.Description,
                LocationId = data.LocationId
            };
        }

        public async Task<CurrentWeatherReadDTO> CreateAsync(CurrentWeatherCreateDTO dto)
        {
            var entry = new CurrentWeather
            {
                Temperature = dto.Temperature,
                Description = dto.Description,
                LocationId = dto.LocationId,
                RetrievedAt = DateTime.UtcNow
            };
            _context.CurrentWeathers.Add(entry);
            await _context.SaveChangesAsync();

            return new CurrentWeatherReadDTO
            {
                Id = entry.Id,
                RetrievedAt = entry.RetrievedAt,
                Temperature = entry.Temperature,
                Description = entry.Description,
                LocationId = entry.LocationId
            };
        }

        public async Task<bool> UpdateAsync(int id, CurrentWeatherCreateDTO dto)
        {
            var existing = await _context.CurrentWeathers.FindAsync(id);
            if (existing == null) return false;

            existing.Temperature = dto.Temperature;
            existing.Description = dto.Description;
            existing.LocationId = dto.LocationId;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.CurrentWeathers.FindAsync(id);
            if (existing == null) return false;

            _context.CurrentWeathers.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
