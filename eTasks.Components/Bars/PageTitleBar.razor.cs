using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTasks.Components.Bars
{
    public class PageTitleBarBase : ComponentBase
    {
        [Parameter] public bool isDarkMode { get; set; }
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
