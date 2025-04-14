namespace SkyVibe_Webapplikation1.Models
{
    public class CurrentWeather
    {
        public int Id { get; set; }
        public DateTime RetrievedAt { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; } = null!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
    }
}
