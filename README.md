# MobWxApp

The purpose of this app is to leverage the NOAA/NWS API to acquire current and forecast weather information using REST API calls.

## Goals

- Build a multi-platform app for Windows and Android
- Learn how to use .NET MAUI 8 w/ .NET 8
- Implement MVVM, DI, and Async programming patterns
- Leverage Exception handling to maintain stability while running
- Learn how to use the NOAA/NWS API
- Deploy a function Android App to the Android Play ecosystem
- 
## Project Status

As of 5-Dec-2023:

The app is currently in development.

It will return current weather information for a location (Android: detected or input; Windows: user-input only).

## Implemented Features

- Show current weather conditions.
- Get weather forecast for location.
- Get location by user input.
- Get location by device location (Android only).

## Remaining Work To Be Done

In No particular order:

- Fix ObservableObject implementation to simplify code and ensure proper bindings.
- Implement a local database e.g. SqlLite to store data.
- Reconsider if Collections are really necessary for this app.
- Implement NWS/NOAA API cache-friendly code (currently the code ignores caching requests).
- Quick recall of forecast weather data periods (e.g. Tomorrow, Tomorrow night, Thursday, etc).
- An about page to show app information.
- Update UI with color palette.
- Update UI light/dark scheme.
- Navigation bar to: Enter location, show current weather, show list of forecasts, and any other pages.
- Exception handling: Catch FeatureNotSupported, FeatureNotEnabled, and Permission Exception types.
- Consider refactoring `MainPage.OnAppearing()` logic to a dedicated function
- Dedicate a class and function to process lattitude and longitude entries (curently this is duplicated code) (MainPage and SetLocation).
- Enable just-in-time downloading the NWS "Icon" image when the Current Conditions or a list of forecasts are displayed.

### Stretch Goals

- Current Warnings and Watches alert on Current Conditions page with click to detailed information.
- Sunset and Sunrise times e.g. Civil Twilight etc.
- Moon phase.
- A settings page to allow user to set preferences.

## Credits and References

Splash screen images screen-snipped from [NOAA GOES Image Viewer](https://www.star.nesdis.noaa.gov/GOES/index.php), 3-Dec-2023.

Exclamation Mark icon from [Icons8](https://icons8.com/icon/j1rPetruM5Fl/exclamation-mark).
