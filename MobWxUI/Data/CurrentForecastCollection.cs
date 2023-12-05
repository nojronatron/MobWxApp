using MobWxUI.Models;
using System.Collections.ObjectModel;

namespace MobWxUI.Data
{
    public class CurrentForecastCollection : Collection<IForecastResponseModel>
    {
        //public event EventHandler<ForecastResponseModelEventArgs> Changed;
        //protected override void InsertItem(int index, IForecastResponseModel newItem)
        //{
        //    base.InsertItem(index, newItem);
        //    EventHandler<ForecastResponseModelEventArgs> temp = Changed;
        //    if (temp != null)
        //    {
        //        temp(this, new ForecastResponseModelEventArgs(ChangeType.Added, newItem, null));
        //    }
        //}
        //protected override void SetItem(int index, IForecastResponseModel newItem)
        //{
        //    IForecastResponseModel replaced = Items[index];
        //    base.SetItem(index, newItem);
        //    EventHandler<ForecastResponseModelEventArgs> temp = Changed;
        //    if (temp != null)
        //    {
        //        temp(this, new ForecastResponseModelEventArgs(ChangeType.Replaced, replaced, newItem));
        //    }
        //}
        //protected override void RemoveItem(int index)
        //{
        //    IForecastResponseModel removedItem = Items[index];
        //    base.RemoveItem(index);
        //    EventHandler<ForecastResponseModelEventArgs> temp = Changed;
        //    if (temp != null)
        //    {
        //        temp(this, new ForecastResponseModelEventArgs(ChangeType.Removed, removedItem, null));
        //    }
        //}
        //protected override void ClearItems()
        //{
        //    base.ClearItems();
        //    EventHandler<ForecastResponseModelEventArgs> temp = Changed;
        //    if (temp != null)
        //    {
        //        temp(this, new ForecastResponseModelEventArgs(ChangeType.Cleared, null, null));
        //    }
        //}
        public int GetIndexOfLatestForecastData()
        {
            // todo: determine if a Collection is really necessary
            // todo: enture calling methods handle an empty collection
            int index = 0;
            foreach (IForecastResponseModel forecastResponseModel in Items)
            {
                if (forecastResponseModel.GeneratedAt > Items[index].GeneratedAt)
                {
                    index = Items.IndexOf(forecastResponseModel);
                }
            }
            return index;
        }
        public Period GetLatestForecast()
        {
            int index = GetIndexOfLatestForecastData();
            return Items[index].Periods[0];
        }
    }
}
