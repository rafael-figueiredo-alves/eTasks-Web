using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Buttons
{
    public class ActionButtonBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public EventCallback OnClick { get; set; }
    }
}
