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
            // todo: ensure the collection is not empty
            // todo: decide on what will happen if it is
            // todo: update calling methods to handle the empty collection situation
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
    }
}
