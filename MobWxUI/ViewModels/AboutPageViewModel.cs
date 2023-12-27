using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MobWxUI.ViewModels
{
    public class AboutPageViewModel : BaseViewModel, IDisposable
    {
        public string AppVersion { get; set; }
        public string DeveloperName {get;set;}
        public string GitHubUrl { get; set; }
        public string LinkedInUrl { get; set; }

        public AboutPageViewModel()
        {
            AppVersion = "Version: 1.0.0 alpha";
            DeveloperName = "Developer: Jon Rumsey (Nojronatron)";
            GitHubUrl = "GitHub: https://github.com/nojronatron/MobWxApp";
            LinkedInUrl = "LinkedIn: https://www.linkedin.com/in/jonathan-rumsey-wa";
        }

        public void Dispose()
        {
            // todo: dispose of resources
        }
    }
}
