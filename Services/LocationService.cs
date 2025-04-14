using Microsoft.EntityFrameworkCore;
using SkyVibe_Webapplikation1.Data;
using SkyVibe_Webapplikation1.DTOs;
using SkyVibe_Webapplikation1.Models;
using SkyVibe_Webapplikation1.Services.Interfaces;

namespace SkyVibe_Webapplikation1.Services
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocationReadDTO>> GetAllAsync()
        {
            return await _context.Locations
                .Select(l => new LocationReadDTO
                {
                    Id = l.Id,
                    CityName = l.CityName,
                    CountryCode = l.CountryCode
                })
                .ToListAsync();
        }

        public async Task<LocationReadDTO?> GetByIdAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            return location == null ? null : new LocationReadDTO
            {
                Id = location.Id,
                CityName = location.CityName,
                CountryCode = location.CountryCode
            };
        }

        public async Task<LocationReadDTO> CreateAsync(LocationCreateDTO dto)
        {
            var location = new Location
            {
                CityName = dto.CityName,
                CountryCode = dto.CountryCode
            };
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return new LocationReadDTO
            {
                Id = location.Id,
                CityName = location.CityName,
                CountryCode = location.CountryCode
            };
        }

        public async Task<bool> UpdateAsync(int id, LocationCreateDTO dto)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null) return false;

            location.CityName = dto.CityName;
            location.CountryCode = dto.CountryCode;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null) return false;

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
