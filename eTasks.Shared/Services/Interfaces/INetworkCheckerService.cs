namespace eTasks.Shared.Services.Interfaces
{
    public enum InternetSpeedStatus
    {
        Fast,
        Regular,
        Slow,
        NotConnected
    }

    public interface INetworkCheckerService
    {
        Task<bool> HasConnectionAsync();
        Task<bool> HasInternetConnectionAsync(string URL = "https://httpbin.org/status/204", int TimeOutInSeconds = 5);
        Task<(bool isConnected, double LatencyMS, InternetSpeedStatus SpeedStatus)> CheckConnectionAndSpeedAsync(string URL = "https://httpbin.org/status/204", int TimeOutInSeconds = 5, string FileUrl = "https://httpbin.org/image", int FileTimeoutInSeconds = 10);
    }
}
