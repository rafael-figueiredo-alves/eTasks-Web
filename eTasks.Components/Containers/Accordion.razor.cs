using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Containers
{
    public class AccordionBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string AccordionID { get; set; } = $"Accordion_{Guid.NewGuid().ToString()}";
        [Parameter] public string Style { get; set; } = string.Empty;
    }
}
