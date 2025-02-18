using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class AvatarMenuBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string? AvatarPath { get; set; } = string.Empty;
        [Parameter] public string? UserName { get; set; } = string.Empty;
        [Parameter] public EventCallback OnShowProfileClick { get; set; }
        [Parameter] public EventCallback OnChangePasswordClick { get; set; }
        [Parameter] public EventCallback OnLogoutClick { get; set; }
        [Parameter] public EventCallback<AvatarMenuItemType> OnAvatarMenuClick { get; set; }
        [Parameter] public Dictionary<AvatarMenuTextsEnum, string>? AvatarMenuTexts { get; set; }
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

        protected string GetAvatarMenuText(AvatarMenuTextsEnum text)
        {
            if (AvatarMenuTexts == null)
                return DefaultAvatarMenuText(text);
            return AvatarMenuTexts[text];
        }

        protected string DefaultAvatarMenuText(AvatarMenuTextsEnum text)
        {
            var TextToReturn = string.Empty;

            switch (text)
            {
                case AvatarMenuTextsEnum.EditProfile:
                    TextToReturn = "Editar Perfil";
                    break;
                case AvatarMenuTextsEnum.About:
                    TextToReturn = "Sobre o eTasks";
                    break;
                case AvatarMenuTextsEnum.Logout:
                    TextToReturn = "Sair";
                    break;
                case AvatarMenuTextsEnum.Settings:
                    TextToReturn = "Configurações";
                    break;
                case AvatarMenuTextsEnum.Conquers:
                    TextToReturn = "Conquistas";
                    break;
                case AvatarMenuTextsEnum.ChangeLanguage:
                    TextToReturn = "Trocar idioma";
                    break;
                case AvatarMenuTextsEnum.ChangePassword:
                    TextToReturn = "Trocar senha";
                    break;
                case AvatarMenuTextsEnum.ChangeTheme:
                    TextToReturn = "Trocar tema";
                    break;
            }

            return TextToReturn;
        }

        protected async Task AvatarMenuItemClick(AvatarMenuItemType avatarMenuItemType)
        {
            if(OnAvatarMenuClick.HasDelegate)
                await OnAvatarMenuClick.InvokeAsync(avatarMenuItemType);
        }
        #endregion
    }
}
