using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MobWxUI.ViewModels
{
    public class AboutPageViewModel : BaseViewModel, IDisposable
    {
        public string AppVersion { get; set; }
        public string DeveloperName { get; set; }
        public string GitHubLabel { get; set; }
        public string GitHubUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string LinkedInLabel { get; set; }
        public string LinkedInUrl { get; set; }
        public string LinkedInShortUrl { get; set;}

        public IAsyncRelayCommand<string> TapCommand => 
            new AsyncRelayCommand<string>(
                async (url) => await BrowserOpen(url)
                );

        public AboutPageViewModel() {
            AppVersion = "Version: 1.1.0 Beta";
            DeveloperName = "Developer: Jon Rumsey (Nojronatron)";
            GitHubLabel = "Project Home: ";
            ProjectUrl = "github.com/nojronatron";
            GitHubUrl = "https://github.com/nojronatron/MobWxApp";
            LinkedInLabel = "LinkedIn Profile: ";
            LinkedInShortUrl = "in/jonathan-rumsey-wa";
            LinkedInUrl = "https://www.linkedin.com/in/jonathan-rumsey-wa";
        }

        private async Task BrowserOpen(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }
            try
            {
                Debug.WriteLine("Entered BrowserOpen!");
                Uri uri = new Uri(url);
                var browserLaunchSucceeded = await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                Debug.WriteLine($"Browser launch succeeded? {browserLaunchSucceeded}");
            }
            catch (Exception ex)
            {
                // todo: handle this error and notify the user
                Debug.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            // todo: dispose of resources
        }
    }
}
