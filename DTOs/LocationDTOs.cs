namespace SkyVibe_Webapplikation1.DTOs
{
    public class LocationCreateDTO
    {
        public string CityName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
    }

    public class LocationReadDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
    }
}
