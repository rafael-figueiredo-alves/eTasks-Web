using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class AvatarMenuBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string? AvatarPath { get; set; } = string.Empty;
        [Parameter] public EventCallback OnShowProfileClick { get; set; }
        [Parameter] public EventCallback OnChangePasswordClick { get; set; }
        [Parameter] public EventCallback OnLogoutClick { get; set; }
        [Parameter] public EventCallback OnChangeThemeClick { get; set; }
        [Parameter] public EventCallback OnConquerClick { get; set; }
        [Parameter] public EventCallback OnSetupClick { get; set; }
        [Parameter] public EventCallback OnChangeLanguageClick { get; set; }
        [Parameter] public EventCallback OnShowAboutClick { get; set; }
        #endregion

        #region Variáveis
        protected string CloseButton { get; set; } = "assets/UI/offcanvas/light/Close.png";
        protected string ProfileButton { get; set; } = "assets/UI/avatar/light/EditProfile.png";
        protected string ChangePasswordButton { get; set; } = "assets/UI/avatar/light/ChangePassword.png";
        protected string LogoutButton { get; set; } = "assets/UI/avatar/light/Logout.png";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            var ThemePath = "light";

            if (IsDarkMode)
            {
                ThemePath = "dark";
            }

            CloseButton          = $"assets/UI/offcanvas/{ThemePath}/Close.png";
            ProfileButton        = $"assets/UI/avatar/{ThemePath}/EditProfile.png";
            ChangePasswordButton = $"assets/UI/avatar/{ThemePath}/ChangePassword.png";
            LogoutButton         = $"assets/UI/avatar/{ThemePath}/Logout.png";
        }

        protected void CloseMenu()
        {
            Console.WriteLine("Menu fechado");
        }
        #endregion
    }
}
