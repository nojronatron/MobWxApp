namespace MobWxUI.Models
{
    public interface ICoordinateModel
    {
        bool IsEmpty { get; }

        double GetAltitude();
        double GetLatitude();
        double GetLongitude();
        bool IsValidAltitude();
        bool IsValidLatitude();
        bool IsValidLatLong();
        bool IsValidLongitude();
        string LatLonAltitudeToString();
        bool SetLatitude(string latitude);
        bool SetLongitude(string longitude);
        bool SetCoordinates(Location? location);
        string ToString();
    }
}
