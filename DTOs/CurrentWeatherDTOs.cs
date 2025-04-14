namespace SkyVibe_Webapplikation1.DTOs
{
    public class CurrentWeatherCreateDTO
    {
        public double Temperature { get; set; }
        public string Description { get; set; } = null!;
        public int LocationId { get; set; }
    }

    public class CurrentWeatherReadDTO
    {
        public int Id { get; set; }
        public DateTime RetrievedAt { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; } = null!;
        public int LocationId { get; set; }
    }
}
