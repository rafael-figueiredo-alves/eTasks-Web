using eTasks.Controller.Interfaces;
using eTasks.Model;
using eTasks.Shared.Services.Interfaces;
using System.Net.Http.Json;

namespace eTasks.Controller
{
    public class VersionController : IVersion
    {
        private HttpClient httpClient;
        private const string Endpoint = "version.json";
        public VersionController(IAppConfig appConfig) 
        {
            httpClient = new HttpClient { BaseAddress = new Uri(appConfig.BaseUrl + '/') };
        }

        public async Task<(bool, string)> IsUpdateAvailable()
        {
            Console.WriteLine(httpClient.BaseAddress);
            VersionInfo info = await httpClient.GetFromJsonAsync<VersionInfo>(Endpoint) ?? new VersionInfo();

            return (true, info.DisplayVersion);
        }
    }
}
