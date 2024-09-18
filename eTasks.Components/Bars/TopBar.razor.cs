using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    /// <summary>
    /// Implementação da barra superior
    /// </summary>
    public class TopBarBase: ComponentBase
    {
        [Parameter]
        public string Height { get; set; } = "60px";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
