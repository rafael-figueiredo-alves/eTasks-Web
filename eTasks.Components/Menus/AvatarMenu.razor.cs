using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class AvatarMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
    }
}
