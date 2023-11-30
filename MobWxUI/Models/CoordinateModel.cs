namespace MobWxUI.Models
{
    public class CoordinateModel : ICoordinateModel
    {
        private string Latitude { get; set; }
        private string Longitude { get; set; }

        public CoordinateModel() {
            Latitude = string.Empty;
            Longitude = string.Empty;
        }

        //  test location near Seattle WA
        //    Latitude = "47.67530";
        //    Longitude = "-122.30183";

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
    }
}
