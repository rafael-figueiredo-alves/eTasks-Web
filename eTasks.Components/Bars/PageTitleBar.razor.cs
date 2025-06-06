using eTasks.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class PageTitleBarBase : ComponentBase
    {
        #region Parâmetros
        [Parameter] public bool isDarkMode { get; set; }
        [Parameter] public string Title { get; set; } = string.Empty;
        #endregion

        #region Variáveis
        protected string BackgroudColor { get; set; } = "#336699";
        protected string TextColor { get; set; } = "#FFFFFF";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            BackgroudColor = ColorPallete.GetColor(Cor.Primary, isDarkMode);
            TextColor = ColorPallete.GetColor(Cor.Text, !isDarkMode);
        }
        #endregion
    }
}
