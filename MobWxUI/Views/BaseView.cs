using MobWxUI.ViewModels;
using System.Diagnostics;

namespace MobWxUI.Views
{
    /* Code source: Maui Community Toolkit Sample Pages Base BasePage.cs */
    public abstract class BaseView<TViewModel> : BaseView where TViewModel : BaseViewModel
    {
        protected BaseView(TViewModel viewModel) : base(viewModel) { }

        public new TViewModel BindingContext => (TViewModel)base.BindingContext;
    }

    public abstract class BaseView: ContentPage
    {
        protected BaseView(object? viewModel = null)
        {
            BindingContext = viewModel;
            Padding = 12; // todo: reconsider including this
            if (string.IsNullOrWhiteSpace(Title))
            {
                Title = GetType().Name;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine($"OnAppearing: {Title}");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine($"OnDisappearing: {Title}");
        }
    }
}
