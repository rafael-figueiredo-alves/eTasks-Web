using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class LanguageMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string LanguageMenuTitle { get; set; } = "Idioma";

        protected string CloseButton { get; set; } = "assets/UI/offcanvas/light/Close.png";

        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                CloseButton = "assets/UI/offcanvas/dark/Close.png";
            else
                CloseButton = "assets/UI/offcanvas/light/Close.png";
        }
    }
}
