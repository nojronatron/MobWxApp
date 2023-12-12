namespace MobWxUI.Models
{
    public class Period
    {
        public int? Number { get; set; }
        public string? Name { get; set; } // will be null for hourly
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public bool IsDaytime { get; set; } = true;
        public int Temperature { get; set; } = int.MinValue;
        public string TemperatureUnit { get; set; } = "C";
        public string TemperatureTrend { get; set; } = "unknown"; // rising, falling
        public Pop? ProbabilityOfPrecipitation { get; set; }
        public Dewpoint? Dewpoint { get; set; }
        public Rh? RelativeHumidity { get; set; }
        public string WindSpeed { get; set; } = "0 mph";
        public string WindDirection { get; set; } = "E"; // [ N, NNE, NE, ENE, E, ESE, SE, SSE, S, SSW, SW, WSW, W, WNW, NW, NNW ]
        public string Icon { get; set; } = string.Empty; // this is a URL string, NOT the actual icon itself
        public string ShortForecast { get; set; } = string.Empty;
        public string DetailedForecast { get; set; } = string.Empty;
        public string Winds { get { return $"{WindDirection} at {WindSpeed}"; } }
        public string Temp { get { return $"{Temperature} {TemperatureUnit} and {TemperatureTrend}"; } }
    }
}
