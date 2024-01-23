using MobWxUI.ViewModels;

namespace MobWxUI.Views;

public partial class CurrentConditionsView : BaseView<CurrentConditionsViewModel>
{
    readonly IDispatcher dispatcher;

    public CurrentConditionsView(
        IDispatcher dispatcher, 
        CurrentConditionsViewModel currentForecastViewModel
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
        // NOTE: Code cannot get here if the POINTS or FORECAST responses were null
        if (BindingContext.DownloadWxImageCommand.CanExecute(null))
        {
            BindingContext.DownloadWxImageCommand.Execute(BindingContext.ConditionIcon);
        }
    }
}