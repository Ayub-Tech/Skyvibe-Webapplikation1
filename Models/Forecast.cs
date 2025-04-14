namespace SkyVibe_Webapplikation1.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public DateTime ForecastDate { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string Summary { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
    }
}
