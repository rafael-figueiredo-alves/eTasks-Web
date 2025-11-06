using eFirebase4CSharp.Classes;
using eFirebase4CSharp.Interfaces;
using eTasks.Components.Services;
using eTasks.Components.Services.Interfaces;
using eTasks.Controller;
using eTasks.Controller.Interfaces;
using eTasks.Shared.Services;
using eTasks.Shared.Services.Interfaces;
using eTranslate;

namespace eTasks
{
    public static class ControllersRegistration
    {
        public static void LoadControllerServices(this IServiceCollection Services)
        {
            Services.AddScoppedServices();
            Services.AddSingletonServices();
        }

        private static void AddScoppedServices(this IServiceCollection Services)
        {
            Services.AddScoped<IVersion, VersionController>();
        }

        private static void AddSingletonServices(this IServiceCollection Services)
        {

        }
    }
}
