using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    /// <summary>
    /// Implementação da barra superior
    /// </summary>
    public class TopBarBase: ComponentBase
    {
        [Parameter] public string Height { get; set; } = "60px";

        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public bool isDarkMode { get; set; } = false;

        protected string CorFundo { get; set; } = "white";
        protected string Sombra { get; set; } = "0 4px 8px rgba(0, 0, 0, 0.2)";

        protected override void OnParametersSet()
        {
            CorFundo = ColorPallete.GetColor(Cor.Background, isDarkMode);
            Sombra = ColorPallete.GetColor(Cor.Shadow, isDarkMode);
        }
    }
}
