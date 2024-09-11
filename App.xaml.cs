using System.Diagnostics;
using ApplicationFundamentals.View;
using Microsoft.Maui.ApplicationModel;
using System.Threading.Tasks;
using System.Net.Http;
using ApplicationFundamentals.Resources.Styles;
using ApplicationFundamentals.Services;

namespace ApplicationFundamentals
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        private const string TestUrl = "https://www.google.com";
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;


            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                this.Resources.MergedDictionaries.Add(new WindowsResources());
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                this.Resources.MergedDictionaries.Add(new AndroidResources());
            }

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if(current == NetworkAccess.Internet && isWebsiteReachable)
            {
                //MainPage = new StartPage();

                MainPage = _serviceProvider.GetRequiredService<StartPage>();
                
                Debug.WriteLine("Application Started");
            }
            else
            {
                MainPage = new OfflinePage();
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
