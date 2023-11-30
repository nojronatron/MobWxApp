namespace MobWxUI.Models
{
    public class RelativeLocation
    {
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Geometry { get; set; }
        public Distance? Distance { get; set; }
        public Bearing? Bearing { get; set; }
        public string GetSafeCityName()
        {
            if (City is null)
            {
                return "null";
            }
            return City.Trim();
        }
    }
}
