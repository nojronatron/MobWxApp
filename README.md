# MobWxApp

The purpose of this app is to leverage the NOAA/NWS API to acquire current and forecast weather information using REST API calls.

## Goals

- Build a multi-platform app for Windows and Android
- Learn how to use .NET MAUI 8 w/ .NET 8
- Implement MVVM, DI, and Async programming patterns
- Ensure stable app execution and operation
- Learn how to use the NOAA/NWS API
- Deploy a functional app via the Android Play ecosystem

## Project Status

As of 27-Dec-2023:

- Initial development of TabBar navigation.
- Added placeholder About page.
- Added TabBar icons (more to come).

As of 16-Dec-2023:

- Added contrasting color palettes to UI style resources.
- Platform light/dark modes automatically supported, applied to UI.
- Added custom AppIcon.
- Changed Windows platform App size to something more reasonable. :smiley:

As of 12-Dec-2023:

- In development.
- Android location services utilized to gather device location.

As of 5-Dec-2023:

- The app is currently in development.
- App will return current weather information for a location (Android: detected or input; Windows: user-input only).

## Implemented Features

Latest-to-oldest:

- Move UI to TabBar views paradigm.
- Update UI with color palette.
- Update UI light/dark scheme (follows platform scheme).
- Enable just-in-time downloading the NWS "Icon" image (current conditions image) when current condition page is loaded (right now it is a placeholder).
- Get location by device location (Android only).
- Get location by user input.
- Get weather forecast for location.
- Show current weather conditions.

## Remaining Work To Be Done

In No particular order:

- Fix ObservableObject implementation to simplify code and ensure proper bindings.
- Implement a local database e.g. SqlLite to store data.
- Reconsider if Collections are really necessary for this app.
- Implement NWS/NOAA API cache-friendly code (currently the code ignores caching requests).
- Quick recall of forecast weather data periods (e.g. Tomorrow, Tomorrow night, Thursday, etc).
- Add an about page to show app, developer information.
- Update UI with color palette.
- Update UI light/dark scheme.
- Navigation bar to: Enter location, show current weather, show list of forecasts, and any other pages.
- Exception handling: Catch FeatureNotSupported, FeatureNotEnabled, and Permission Exception types.
- Consider refactoring `MainPage.OnAppearing()` logic to a dedicated function
- Dedicate a class and function to process lattitude and longitude entries (curently this is duplicated code) (MainPage and SetLocation).
- Ensure code installs, operates, and looks correct on at least one actual Android device/phone (not just the emulator).
- Update UI to be responsive to window size, device orientation, and device type.
- Various refactorings to improve code quality and readability.

### Stretch Goals

- Current Warnings and Watches alert on Current Conditions page with click to detailed information.
- Sunset and Sunrise times e.g. Civil Twilight etc.
- Moon phase, current and future significant dates.
- A settings page to allow user to set preferences such as light/dark mode, location(s).

## Credits and References

- Various code snippets from [Microsoft Learn .NET MAUI 8](https://learn.microsoft.com/en-us/dotnet/maui), November and December 2023.
- Various code snippets from [MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui), December 2023.
- Splash screen images screen-snipped from [NOAA GOES Image Viewer](https://www.star.nesdis.noaa.gov/GOES/index.php), 3-Dec-2023.
- Exclamation Mark icon from [Icons8](https://icons8.com/icon/j1rPetruM5Fl/exclamation-mark).
- Custom icons by [me](https://github.com/nojronatron).
