using Microsoft.EntityFrameworkCore;
using SkyVibe_Webapplikation1.Models;

namespace SkyVibe_Webapplikation1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<CurrentWeather> CurrentWeathers => Set<CurrentWeather>();
        public DbSet<Forecast> Forecasts => Set<Forecast>();
    }
}
