namespace MobWxUI.Models
{
    public class CoordinateModel : ICoordinateModel
    {
        private string Latitude { get; set; }
        private string Longitude { get; set; }
        private string Altitude { get; set; } // comes with device location info

        public bool IsEmpty
        {
            get => string.IsNullOrWhiteSpace(Latitude)
                && string.IsNullOrWhiteSpace(Longitude);
        }

        public CoordinateModel()
        {
            Latitude = string.Empty;
            Longitude = string.Empty;
            Altitude = string.Empty;
        }

        /// <summary>
        /// Sets the Latitude and Longitude properties. Attempts to set Altitude as well. Null Location ref will result in blank Latitude, Longitude, and Altitude properties.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>true if at least Latitude and Longitude are valid</returns>
        public bool SetCoordinates(Location? location)
        {
            if (location != null)
            {
                var tempLatitude = location.Latitude.ToString();
                Latitude = LimitToFourDecimalPlaces(tempLatitude);
                if (!IsValidLatitude())
                {
                    Latitude = string.Empty;
                    return false;
                }
                var tempLongitude = location.Longitude.ToString();
                Longitude = LimitToFourDecimalPlaces(tempLongitude);
                if (!IsValidLongitude())
                {
                    Longitude = string.Empty;
                    return false;
                }
                Altitude = location.Altitude == null ? "0" : location.Altitude.ToString()!;
                return !IsEmpty && IsValidLatLong();
            }
            else
            {
                Latitude = string.Empty;
                Longitude = string.Empty;
                Altitude = string.Empty;
                return true;
            }
        }

        private static string LimitToFourDecimalPlaces(string coordinate)
        {
            string coord = coordinate.Trim();
            string[] coordinateParts = coord.Split('.');
            if (coordinateParts[1].Length > 4)
            {
                return $"{coordinateParts[0]}.{coordinateParts[1].Substring(0, 4)}";
            }
            else
            {
                return coord;
            }
        }

        public bool SetLatitude(string latitude)
        {
            string lat = latitude.Trim();

            if (string.IsNullOrWhiteSpace(lat))
            {
                return false;
            }

            Latitude = LimitToFourDecimalPlaces(lat);
            return true;
        }

        public bool SetLongitude(string longitude)
        {
            string lon = longitude.Trim();

            if (string.IsNullOrWhiteSpace(lon))
            {
                return false;
            }

            Longitude = LimitToFourDecimalPlaces(lon);
            return true;
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }

        public string LatLonAltitudeToString()
        {
            return $"{this},{Altitude}";
        }

        public bool IsValidAltitude()
        {
            if (!string.IsNullOrWhiteSpace(Altitude) && double.TryParse(Altitude, out double altitude))
            {
                return true;
            }

            return false;
        }

        public bool IsValidLatitude()
        {
            if (Latitude == null)
            {
                return false;
            }

            return (-90.0 <= double.Parse(Latitude) && double.Parse(Latitude) <= 90.0);
        }

        public bool IsValidLongitude()
        {
            if (Longitude == null)
            {
                return false;
            }

            return (-180.0 <= double.Parse(Longitude) && double.Parse(Longitude) <= 180.0);
        }

        public bool IsValidLatLong()
        {
            return IsValidLatitude() && IsValidLongitude();
        }

        public double GetLatitude()
        {
            if (IsValidLatitude() && double.TryParse(Latitude, out double latitude))
            {
                return latitude;
            }

            throw new FormatException($"Unable to parse {Latitude}.");
        }

        public double GetLongitude()
        {
            if (IsValidLongitude() && double.TryParse(Longitude, out double longitude))
            {
                return longitude;
            }

            throw new FormatException($"Unable to parse {Longitude}.");
        }

        public double GetAltitude()
        {
            if (IsValidAltitude() && double.TryParse(Altitude, out double altitude))
            {
                return altitude;
            }

            throw new FormatException($"Unable to parse {Altitude}.");
        }
    }
}
