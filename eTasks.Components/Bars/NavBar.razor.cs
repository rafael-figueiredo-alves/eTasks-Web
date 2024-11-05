using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class NavBarBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
    }
}
