using eTasks.Controller.Interfaces;
using eTasks.Model;
using eTasks.Shared.Constants;
using eTasks.Shared.Services.Interfaces;
using System.Net.Http.Json;

namespace eTasks.Controller
{
    public class VersionController : IVersion
    {
        private HttpClient httpClient;
        private INetworkCheckerService _networkCheckerService;
        private const string Endpoint = "version.json";
        public VersionController(IAppConfig appConfig, INetworkCheckerService networkCheckerService) 
        {
            httpClient = new HttpClient { BaseAddress = new Uri(appConfig.BaseUrl + '/') };
            _networkCheckerService = networkCheckerService;
        }

        public async Task<(bool, string)> IsUpdateAvailable()
        {
            var isConnectedToNetwork = await _networkCheckerService.HasConnectionAsync();

            if (isConnectedToNetwork)
            {
                var hasInternet = await _networkCheckerService.HasInternetConnectionAsync();

                if (hasInternet)
                {
                    VersionInfo info = await httpClient.GetFromJsonAsync<VersionInfo>(Endpoint) ?? new VersionInfo();

                    return (info.AppVersion > SystemConstants.Version, info.DisplayVersion);
                }
                else
                {
                    return (false, string.Empty);
                }
            }
            else
            {
                return (false, string.Empty);
            }
        }
    }
}
