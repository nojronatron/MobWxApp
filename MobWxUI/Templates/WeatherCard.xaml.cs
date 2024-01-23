namespace MobWxUI.Templates;

public partial class WeatherCard : ContentView
{
	public static readonly BindableProperty NameProperty = 
		BindableProperty.Create(nameof(Name), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string Name
	{
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

	public static readonly BindableProperty ShortForecastProperty =
		BindableProperty.Create(nameof(ShortForecast), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string ShortForecast
	{
        get => (string)GetValue(ShortForecastProperty);
        set => SetValue(ShortForecastProperty, value);
    }

	public static readonly BindableProperty TempProperty =
		BindableProperty.Create(nameof(Temp), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string Temp
	{
        get => (string)GetValue(TempProperty);
        set => SetValue(TempProperty, value);
    }

	public static readonly BindableProperty ProbabilityOfPrecipitationProperty =
		BindableProperty.Create(nameof(ProbabilityOfPrecipitation), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string ProbabilityOfPrecipitation
	{
        get => (string)GetValue(ProbabilityOfPrecipitationProperty);
        set => SetValue(ProbabilityOfPrecipitationProperty, value);
    }

	public static readonly BindableProperty DewpointProperty =
		BindableProperty.Create(nameof(Dewpoint), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string Dewpoint
	{
        get => (string)GetValue(DewpointProperty);
        set => SetValue(DewpointProperty, value);
    }

	public static readonly BindableProperty RelativeHumidityProperty =
        BindableProperty.Create(nameof(RelativeHumidity), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string RelativeHumidity
	{
        get => (string)GetValue(RelativeHumidityProperty);
        set => SetValue(RelativeHumidityProperty, value);
    }

	public static readonly BindableProperty WindsProperty =
		BindableProperty.Create(nameof(Winds), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string Winds
	{
        get => (string)GetValue(WindsProperty);
        set => SetValue(WindsProperty, value);
    }

	public static readonly BindableProperty IconProperty =
		BindableProperty.Create(nameof(Icon), typeof(string), typeof(WeatherCard), default(string), BindingMode.OneWay);
	public string Icon
	{
		get => (string)GetValue(IconProperty);
		set =>SetValue(IconProperty, value);
	}

	public WeatherCard()
	{
		InitializeComponent();
	}
}