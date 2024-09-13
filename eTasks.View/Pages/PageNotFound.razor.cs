using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    /// <summary>
    /// Implementação de código da página não encontrada
    /// </summary>
    public class PageNotFoundBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        protected string Background { get; set; } = "";
        protected string LineStroke { get; set; } = "#0E0620";
        protected string ImageFill { get; set; } = "#FFFFFF";
        protected string TextColor { get; set; } = "black";

        protected void GoHome()
        {
            navigationManager?.NavigateTo((new Uri(navigationManager.BaseUri)).ToString());
        }
    }
}
