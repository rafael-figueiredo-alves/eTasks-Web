using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class MainMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
    }
}
