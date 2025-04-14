namespace SkyVibe_Webapplikation1.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public ICollection<CurrentWeather> CurrentWeathers { get; set; } = new List<CurrentWeather>();
        public ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();
    }
}
