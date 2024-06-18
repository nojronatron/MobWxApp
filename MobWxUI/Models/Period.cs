namespace MobWxUI.Models
{
    public class Period
    {
        public int? Number { get; set; } // ordinal 1-14 for a 7 day forecast split into 12hr periods
        public string? Name { get; set; } // will be null for hourly
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public bool IsDaytime { get; set; } = true;
        public int Temperature { get; set; } = int.MinValue;
        public string? TemperatureUnit { get; set; }
        public string? TemperatureTrend { get; set; } // rising, falling
        public Pop? ProbabilityOfPrecipitation { get; set; } = new();
        public Dewpoint? Dewpoint { get; set; } = new();
        public Rh? RelativeHumidity { get; set; } = new();
        public string? WindSpeed { get; set; }
        public string? WindDirection { get; set; } // [ N, NNE, NE, ENE, E, ESE, SE, SSE, S, SSW, SW, WSW, W, WNW, NW, NNW ]
        public string Icon { get; set; } = "wxicon_placeholder_86x86.png"; // this is a URL string, NOT the actual icon itself
        public string? ShortForecast { get; set; }
        public string? DetailedForecast { get; set; }
        public string Winds
        {
            get
            {
                return string.IsNullOrEmpty(WindDirection) 
                    ? $"{WindSpeed}" 
                    : $"{WindDirection} at {WindSpeed}";
            }
        }
        public string Temp
        {
            get
            {
                char degreeSymbol = '°';
                return string.IsNullOrEmpty(TemperatureTrend) 
                    ? $"{Temperature}{degreeSymbol}F" 
                    : $"{Temperature}{degreeSymbol}F and {TemperatureTrend}";
            }
        }
        public byte[]? WxImageByteArray { get; set; } // this will store actual image data once it is fetched
    }
}
