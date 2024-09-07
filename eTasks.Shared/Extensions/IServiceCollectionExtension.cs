using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTasks.Shared.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void LoadServices(this IServiceCollection Services, string BaseURL)
        {
            Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseURL) });
        }
    }
}
