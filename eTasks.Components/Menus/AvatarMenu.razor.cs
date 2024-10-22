using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class AvatarMenuBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string? AvatarPath { get; set; } = string.Empty;
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
            if (IsDarkMode)
            {
                CloseButton          = "assets/UI/offcanvas/dark/Close.png";
                ProfileButton        = "assets/UI/avatar/dark/EditProfile.png";
                ChangePasswordButton = "assets/UI/avatar/dark/ChangePassword.png";
                LogoutButton         = "assets/UI/avatar/dark/Logout.png";
            }
            else
            {
                CloseButton          = "assets/UI/offcanvas/light/Close.png";
                ProfileButton        = "assets/UI/avatar/light/EditProfile.png";
                ChangePasswordButton = "assets/UI/avatar/light/ChangePassword.png";
                LogoutButton         = "assets/UI/avatar/light/Logout.png";
            }
        }
        #endregion
    }
}
