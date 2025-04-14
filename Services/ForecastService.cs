using Microsoft.EntityFrameworkCore;
using SkyVibe_Webapplikation1.Data;
using SkyVibe_Webapplikation1.DTOs;
using SkyVibe_Webapplikation1.Models;
using SkyVibe_Webapplikation1.Services.Interfaces;

namespace SkyVibe_Webapplikation1.Services
{
    public class ForecastService : IForecastService
    {
        private readonly AppDbContext _context;

        public ForecastService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForecastReadDTO>> GetAllAsync()
        {
            return await _context.Forecasts
                .Select(f => new ForecastReadDTO
                {
                    Id = f.Id,
                    ForecastDate = f.ForecastDate,
                    MinTemperature = f.MinTemperature,
                    MaxTemperature = f.MaxTemperature,
                    Summary = f.Summary,
                    LocationId = f.LocationId
                })
                .ToListAsync();
        }

        public async Task<ForecastReadDTO?> GetByIdAsync(int id)
        {
            var forecast = await _context.Forecasts.FindAsync(id);
            return forecast == null ? null : new ForecastReadDTO
            {
                Id = forecast.Id,
                ForecastDate = forecast.ForecastDate,
                MinTemperature = forecast.MinTemperature,
                MaxTemperature = forecast.MaxTemperature,
                Summary = forecast.Summary,
                LocationId = forecast.LocationId
            };
        }

        public async Task<ForecastReadDTO> CreateAsync(ForecastCreateDTO dto)
        {
            var forecast = new Forecast
            {
                ForecastDate = dto.ForecastDate,
                MinTemperature = dto.MinTemperature,
                MaxTemperature = dto.MaxTemperature,
                Summary = dto.Summary,
                LocationId = dto.LocationId
            };
            _context.Forecasts.Add(forecast);
            await _context.SaveChangesAsync();

            return new ForecastReadDTO
            {
                Id = forecast.Id,
                ForecastDate = forecast.ForecastDate,
                MinTemperature = forecast.MinTemperature,
                MaxTemperature = forecast.MaxTemperature,
                Summary = forecast.Summary,
                LocationId = forecast.LocationId
            };
        }

        public async Task<bool> UpdateAsync(int id, ForecastCreateDTO dto)
        {
            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast == null) return false;

            forecast.ForecastDate = dto.ForecastDate;
            forecast.MinTemperature = dto.MinTemperature;
            forecast.MaxTemperature = dto.MaxTemperature;
            forecast.Summary = dto.Summary;
            forecast.LocationId = dto.LocationId;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast == null) return false;

            _context.Forecasts.Remove(forecast);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
