using Microsoft.AspNetCore.Components;

namespace eTasks.Shared.Extensions
{
    public static class NavigationManagerExtension
    {
        private static void Go(this NavigationManager navigationManager, string Route)
        {
            navigationManager.NavigateTo(Route, replace: true);
        }

        private static string BaseURL(this NavigationManager navigationManager)
        {
            return navigationManager.BaseUri.ToString();
        }

        public static void GoHome(this NavigationManager navigationManager)
        {
            navigationManager.Go(BaseURL(navigationManager));
        }

        public static void GoFinances(this NavigationManager navigationManager)
        {
            navigationManager.Go("/finances");
        }

        public static void GoTasks(this NavigationManager navigationManager)
        {
            navigationManager.Go("/tasks");
        }

        public static void GoNotes(this NavigationManager navigationManager)
        {
            navigationManager.Go("/notes");
        }

        public static void GoShopping(this NavigationManager navigationManager)
        {
            navigationManager.Go("/shopping");
        }

        public static void GoGoals(this NavigationManager navigationManager)
        {
            navigationManager.Go("/goals");
        }

        public static void GoReadings(this NavigationManager navigationManager)
        {
            navigationManager.Go("/readings");
        }

        public static void GoTo(this NavigationManager navigationManager, string URL)
        {
            string URI = new Uri(BaseURL(navigationManager)).ToString();

            if(URI.EndsWith("/"))
                URI = URL.StartsWith("/") ? URI + URL.Remove(1) : URI + URL;
            else
                URI = URL.StartsWith("/") ? URI + URL : URI + "/" + URL;

            navigationManager.Go(URI);
        }
    }
}
