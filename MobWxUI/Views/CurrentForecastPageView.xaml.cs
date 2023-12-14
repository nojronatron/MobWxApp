using MobWxUI.ViewModels;
using Microsoft.Maui.Dispatching;

namespace MobWxUI.Views;

public partial class CurrentForecastPageView : BaseView<CurrentForecastViewModel>
{
    readonly IDispatcher dispatcher;

    public CurrentForecastPageView(
        IDispatcher dispatcher, 
        CurrentForecastViewModel currentForecastViewModel
        ) : base(currentForecastViewModel)
	{
        InitializeComponent();
        BindingContext.ImageDownloadFailed += HandleImageDownloadFailed;
        this.dispatcher = dispatcher;
    }

    async void HandleImageDownloadFailed(object? sender, string e)
    {
        ArgumentNullException.ThrowIfNull(sender);
        await dispatcher.DispatchAsync(() => DisplayAlert("Image Download Failed!", e, "OK"));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext.DownloadWxImageCommand.CanExecute(null))
        {
            BindingContext.DownloadWxImageCommand.Execute(BindingContext.ConditionIcon);
        }
    }
}