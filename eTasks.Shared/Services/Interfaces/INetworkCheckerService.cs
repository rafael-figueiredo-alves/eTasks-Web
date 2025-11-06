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
        Task<bool> HasInternetConnectionAsync(string URL = "https://www.google.com", int TimeOutInSeconds = 5);
        Task<(bool isConnected, double LatencyMS, InternetSpeedStatus SpeedStatus)> CheckConnectionAndSpeedAsync(string URL = "https://www.google.com/generate_204", int TimeOutInSeconds = 5, string FileUrl = "https://fast.com/app/assets/speedtest/random1000x1000.jpg", int FileTimeoutInSeconds = 10);
    }
}
