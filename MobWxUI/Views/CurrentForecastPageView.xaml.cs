using MobWxUI.ViewModels;

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
        await dispatcher.DispatchAsync(() => DisplayAlert("Unable to Display Image.", "Unavailable or took too long.", "OK"));
    }

    protected override void OnAppearing()
    {
        if (BindingContext.DownloadWxImageCommand.CanExecute(null))
        {
            BindingContext.DownloadWxImageCommand.Execute(BindingContext.ConditionIcon);
        }
    }
}