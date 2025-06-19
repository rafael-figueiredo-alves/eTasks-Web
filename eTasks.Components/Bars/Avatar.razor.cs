using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class AvatarBase : ComponentBase
    {
        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = string.Empty;
        [Parameter] public string OffcanvasMenuID {  get; set; } = string.Empty;
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public bool isDarkMode { get; set; } = false;
        [Parameter] public int AvatarHeight { get; set; } = 40;
        [Parameter] public int AvatarWidth { get; set; } = 40;
        [Parameter] public string AvatarExtraStyle { get; set; } = string.Empty;
        [Parameter] public string AvatarMarginStyles { get; set; } = "margin-top: 2px;margin-right: 10px;";
        [Parameter] public bool IsAbleToClick { get; set; } = true;
        [Parameter] public string AvatarHint {  get; set; } = "Menu do Usuário";
        #endregion

        #region Variáveis
        protected string AvatarImagePath { get; set; } = string.Empty;
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            if(AvatarPath != string.Empty)
            {
                AvatarImagePath = AvatarPath;
            }
            else
            {
                if (isDarkMode)
                    AvatarImagePath = "assets/UI/avatar/dark/Avatar.png";
                else
                    AvatarImagePath = "assets/UI/avatar/light/Avatar.png";
            }
        }
        #endregion
    }
}
