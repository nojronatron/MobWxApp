using MobWxUI.Models;

namespace MobWxUI.Data
{
    public class ForecastResponseModelEventArgs : EventArgs
    {
        public readonly IForecastResponseModel ChangedItem;
        public readonly ChangeType ChangeType;
        public readonly IForecastResponseModel ReplacedWith;
        public ForecastResponseModelEventArgs(ChangeType change, IForecastResponseModel item, IForecastResponseModel replacement)
        {
            ChangeType = change;
            ChangedItem = item;
            ReplacedWith = replacement;
        }
    }
    public enum ChangeType
    {
        Added,
        Removed,
        Replaced,
        Cleared
    }
}
