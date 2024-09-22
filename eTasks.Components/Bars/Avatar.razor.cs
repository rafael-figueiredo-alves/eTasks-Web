using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class AvatarBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = "assets/UI/Avatar2.png";
        [Parameter] public string OffcanvasMenuID {  get; set; } = string.Empty;
        [Parameter] public EventCallback OnClick { get; set; }
        #endregion
    }
}
