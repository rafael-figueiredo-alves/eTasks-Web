using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class TitleBarBase : ComponentBase
    {
        [Parameter] public bool isDarkMode {  get; set; }
        [Parameter] public string Title { get; set; } = string.Empty;

        protected string BackgroudColor { get; set; } = "#336699";
        protected string TextColor { get; set; } = "#FFFFFF";

        protected override void OnParametersSet()
        {
            BackgroudColor = ColorPallete.GetColor(Cor.Primary, isDarkMode);
            TextColor = ColorPallete.GetColor(Cor.Text, !isDarkMode);
        }
    }
}
