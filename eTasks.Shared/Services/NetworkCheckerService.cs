using eTasks.Shared.Extensions;
using eTasks.Shared.Services.Interfaces;
using Microsoft.JSInterop;

namespace eTasks.Shared.Services
{
    public class NetworkCheckerService : INetworkCheckerService
    {
        private HttpClient _httpClient;
        private readonly IJSRuntime _jsruntime;

        public NetworkCheckerService(IJSRuntime JS)
        {
            _jsruntime = JS;
            _httpClient = new HttpClient();
        }

        public async Task<(bool isConnected, double LatencyMS, InternetSpeedStatus SpeedStatus)> CheckConnectionAndSpeedAsync(string URL = "https://httpbin.org/status/204", int TimeOutInSeconds = 5, string FileUrl = "https://httpbin.org/image", int FileTimeoutInSeconds = 10)
        {
            try
            {
                // Passo 1: Medir latência (RTT simples com HEAD)
                var start = DateTime.UtcNow;
                _httpClient.DefaultRequestHeaders.Add("Accept", "Image/jpeg");
                var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, URL)).TimeoutAfter(TimeSpan.FromSeconds(TimeOutInSeconds));               
                var latencyMs = (DateTime.UtcNow - start).TotalMilliseconds;

                if (!response.IsSuccessStatusCode) return (false, 0, InternetSpeedStatus.NotConnected);

                // Passo 2: Medir velocidade (baixe um arquivo pequeno)
                start = DateTime.UtcNow;
                var fileBytes = await _httpClient.GetByteArrayAsync(FileUrl).TimeoutAfter(TimeSpan.FromSeconds(FileTimeoutInSeconds)); // ~100KB
                var durationSeconds = (DateTime.UtcNow - start).TotalSeconds;
                var fileSizeKB = fileBytes.Length / 1024.0;
                var speedMbps = (fileSizeKB * 8) / durationSeconds / 1024; // Converta para Mbps

                InternetSpeedStatus speedStatus = speedMbps > 5 ? InternetSpeedStatus.Fast : (speedMbps > 1 ? InternetSpeedStatus.Regular : InternetSpeedStatus.Slow);

                return (true, latencyMs, speedStatus);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (false, 0, InternetSpeedStatus.NotConnected);
            }
        }

        public async Task<bool> HasConnectionAsync()
        {
            return await _jsruntime.InvokeAsync<bool>("isConnected");
        }

        public async Task<bool> HasInternetConnectionAsync(string URL = "https://httpbin.org/status/204", int TimeOutInSeconds = 5)
        {
            try
            {
                // Use HEAD para requisição leve (sem baixar corpo)
                var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, URL)).TimeoutAfter(TimeSpan.FromSeconds(TimeOutInSeconds));
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
