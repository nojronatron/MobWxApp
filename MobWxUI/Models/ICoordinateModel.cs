namespace MobWxUI.Models
{
    public interface ICoordinateModel
    {
        double GetLatitude();
        double GetLongitude();
        bool IsValidLatitude();
        bool IsValidLatLong();
        bool IsValidLongitude();
        bool SetLatitude(string latitude);
        bool SetLongitude(string longitude);
        string ToString();
    }

}
