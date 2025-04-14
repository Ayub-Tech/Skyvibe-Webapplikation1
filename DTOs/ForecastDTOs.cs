namespace SkyVibe_Webapplikation1.DTOs
{
    public class ForecastCreateDTO
    {
        public DateTime ForecastDate { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string Summary { get; set; } = null!;
        public int LocationId { get; set; }
    }

    public class ForecastReadDTO
    {
        public int Id { get; set; }
        public DateTime ForecastDate { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string Summary { get; set; } = null!;
        public int LocationId { get; set; }
    }
}
