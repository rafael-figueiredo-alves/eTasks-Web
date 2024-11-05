using Microsoft.AspNetCore.Components;

namespace eTasks.Shared.Extensions
{
    public static class NavigationManagerExtension
    {
        private static string BaseURL(this NavigationManager navigationManager)
        {
            return navigationManager.BaseUri.ToString();
        }

        public static void GoHome(this NavigationManager navigationManager)
        {
            navigationManager.NavigateTo(BaseURL(navigationManager));
        }

        public static void GoTo(this NavigationManager navigationManager, string URL)
        {
            string URI = new Uri(BaseURL(navigationManager)).ToString();

            if(URI.EndsWith("/"))
                URI = URL.StartsWith("/") ? URI + URL.Remove(1) : URI + URL;
            else
                URI = URL.StartsWith("/") ? URI + URL : URI + "/" + URL;

            navigationManager.NavigateTo(URI);
        }
    }
}
