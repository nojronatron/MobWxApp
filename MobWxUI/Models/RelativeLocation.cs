namespace MobWxUI.Models
{
    public class RelativeLocation
    {
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Geometry { get; set; } = string.Empty;
        public Distance Distance { get; set; } = new();
        public Bearing Bearing { get; set; } = new();

        public string GetSafeCityName()
        {
            if (string.IsNullOrEmpty(City) || string.IsNullOrEmpty(State))
            {
                return "No City Info";
            }
            return $"{City.Trim()}, {State.Trim()}";
        }
    }
}
