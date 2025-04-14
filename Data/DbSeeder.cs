using Bogus;
using SkyVibe_Webapplikation1.Models;

namespace SkyVibe_Webapplikation1.Data
{
    public static class DbSeeder
    {
        public static void SeedDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!db.Locations.Any())
            {
                var locations = new Faker<Location>("en")
                    .RuleFor(l => l.CityName, f => f.Address.City())
                    .RuleFor(l => l.CountryCode, f => f.Address.CountryCode())
                    .Generate(5);

                db.Locations.AddRange(locations);
                db.SaveChanges();
            }

            if (!db.CurrentWeathers.Any())
            {
                var weatherFaker = new Faker<CurrentWeather>("en")
                    .RuleFor(w => w.Temperature, f => f.Random.Double(-20, 40))
                    .RuleFor(w => w.Description, f => f.Lorem.Sentence(3))
                    .RuleFor(w => w.RetrievedAt, f => f.Date.Recent())
                    .RuleFor(w => w.LocationId, f => db.Locations.OrderBy(x => Guid.NewGuid()).First().Id);

                db.CurrentWeathers.AddRange(weatherFaker.Generate(10));
                db.SaveChanges();
            }

            if (!db.Forecasts.Any())
            {
                var forecastFaker = new Faker<Forecast>("en")
                    .RuleFor(f => f.ForecastDate, f => f.Date.Soon(7))
                    .RuleFor(f => f.MinTemperature, f => f.Random.Double(-10, 15))
                    .RuleFor(f => f.MaxTemperature, (f, obj) => obj.MinTemperature + f.Random.Double(5, 15))
                    .RuleFor(f => f.Summary, f => f.Lorem.Sentence(3))
                    .RuleFor(f => f.LocationId, f => db.Locations.OrderBy(x => Guid.NewGuid()).First().Id);

                db.Forecasts.AddRange(forecastFaker.Generate(20));
                db.SaveChanges();
            }
        }
    }
}
