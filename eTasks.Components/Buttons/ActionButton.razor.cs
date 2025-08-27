using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Buttons
{
    public class ActionButtonBase : ComponentBase
    {
        #region Parâmetros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public string Hint { get; set; } = "Adicionar";
        [Parameter] public bool Visible { get; set; } = true;
        #endregion
    }
}
