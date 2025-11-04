using eTasks.Model;
using eTasks.Shared.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace eTasks.Shared.Services
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration) //HttpClient httpClient) 
        {
            _configuration = configuration;
        }

        public string BaseUrl { get { return _configuration["BASE_URL"] ?? "default-url"; } } 

        public string API_Key { get { return _configuration["API_KEY"] ?? "default-key"; } }
    }
}
