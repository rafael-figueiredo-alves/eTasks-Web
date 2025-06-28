using Microsoft.AspNetCore.Components;

namespace eTasks.Shared.Extensions
{
    public static class NavigationManagerExtension
    {
        private static string? PreviousURL;

        private static void Go(this NavigationManager navigationManager, string Route)
        {
            PreviousURL = Route;
            navigationManager.NavigateTo(Route, replace: true);
        }

        private static string BaseURL(this NavigationManager navigationManager)
        {
            return navigationManager.BaseUri.ToString();
        }

        public static void GoHome(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("");
        }

        public static void GoFinances(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/finances");
        }

        public static void GoTasks(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/tasks");
        }

        public static void GoNotes(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/notes");
        }

        public static void GoShopping(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/shopping");
        }

        public static void GoGoals(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/goals");
        }

        public static void GoReadings(this NavigationManager navigationManager)
        {
            navigationManager.GoTo("/readings");
        }

        public static void GoTo(this NavigationManager navigationManager, string URL)
        {
            string URI = new Uri(BaseURL(navigationManager)).ToString();

            if(URI.EndsWith('/'))
                URI = URL.StartsWith('/') ? URI + URL.TrimStart('/') : URI + URL;
            else
                URI = URL.StartsWith('/') ? URI + URL : URI + '/' + URL;

            navigationManager.Go(URI);
        }

        public static void GoBack(this NavigationManager navigationManager)
        {
            if(!string.IsNullOrEmpty(PreviousURL))
                navigationManager.Go(PreviousURL);
            else
                navigationManager.Go(BaseURL(navigationManager));
        }
    }
}
