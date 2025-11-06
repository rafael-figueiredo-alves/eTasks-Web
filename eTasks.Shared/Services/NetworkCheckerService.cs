using eTasks.Shared.Extensions;
using eTasks.Shared.Services.Interfaces;
using Microsoft.JSInterop;

namespace eTasks.Shared.Services
{
    public class NetworkCheckerService : INetworkCheckerService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsruntime;

        public NetworkCheckerService(HttpClient httpClient, IJSRuntime JS)
        {
            _httpClient = httpClient;
            _jsruntime = JS;
        }

        public async Task<(bool isConnected, double LatencyMS, InternetSpeedStatus SpeedStatus)> CheckConnectionAndSpeedAsync(string URL = "https://www.google.com/generate_204", int TimeOutInSeconds = 5, string FileUrl = "https://fast.com/app/assets/speedtest/random1000x1000.jpg", int FileTimeoutInSeconds = 10)
        {
            try
            {
                // Passo 1: Medir latência (RTT simples com HEAD)
                var start = DateTime.UtcNow;
                var request = new HttpRequestMessage(HttpMethod.Head, URL);
                var response = await _httpClient.SendAsync(request).TimeoutAfter(TimeSpan.FromSeconds(TimeOutInSeconds));
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
            catch
            {
                return (false, 0, InternetSpeedStatus.NotConnected);
            }
        }

        public async Task<bool> HasConnectionAsync()
        {
            return await _jsruntime.InvokeAsync<bool>("isConnected");
        }

        public async Task<bool> HasInternetConnectionAsync(string URL = "https://www.google.com", int TimeOutInSeconds = 5)
        {
            try
            {
                // Use HEAD para requisição leve (sem baixar corpo)
                var request = new HttpRequestMessage(HttpMethod.Head, URL);
                Console.WriteLine(URL);
                var response = await _httpClient.SendAsync(request).TimeoutAfter(TimeSpan.FromSeconds(TimeOutInSeconds)); 
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
