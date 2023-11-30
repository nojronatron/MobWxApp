using MobWxUI.Helpers;

namespace TestMobWxApp
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test_FileDownloadHelper()
        {
            string _userAgent = "(Exploring,jonrumsey.dev@gmail.com)";
            string imageUrl = "https://www.weather.gov/images/mobwx/Icons/medium/sct.png";
            ApiHelper httpClient = new ApiHelper();
            httpClient.Apihelper.DefaultRequestHeaders.Clear();
            httpClient.Apihelper.DefaultRequestHeaders.Add("User-Agent", _userAgent);
            httpClient.Apihelper.DefaultRequestHeaders.Add("Accept", "image/png");
            HttpResponseMessage response = await httpClient.Apihelper.GetAsync(imageUrl);

            if (response.IsSuccessStatusCode)
            {
                Stream result = await response.Content.ReadAsStreamAsync();
                string pngFilePath = await FileDownloadHelper.StoreFileAsync(result, imageUrl);
                Console.WriteLine($"pngFilePath was returned: {pngFilePath} ");
            }
        }
    }
}
