using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class LanguageMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
    }
}
