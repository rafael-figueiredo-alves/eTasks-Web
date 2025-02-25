using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class AvatarMenuItemBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public AvatarMenuItemType ItemType { get; set; } = AvatarMenuItemType.Conquer;
        [Parameter] public string? ItemName { get; set; } = string.Empty;
        [Parameter] public EventCallback OnClick { get; set; }
        #endregion

        #region Variáveis
        protected string ImageIcon { get; set; } = "assets/UI/avatar/light/menu/conquista.png";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            var ThemePath = "light";
            var Item = "conquista";

            if (IsDarkMode)
            {
                ThemePath = "dark";
            }

            switch(ItemType)
            {
                case AvatarMenuItemType.Conquer:
                    Item = "conquista";
                    break;
                case AvatarMenuItemType.Setup:
                    Item = "config";
                    break;
                case AvatarMenuItemType.Language:
                    Item = "idioma";
                    break;
                case AvatarMenuItemType.Theme:
                    Item = "tema";
                    break;
                case AvatarMenuItemType.About:
                    Item = "sobre";
                    break;
            }

            ImageIcon = $"assets/UI/avatar/{ThemePath}/menu/{Item}.png";
        }
        #endregion
    }

    public enum AvatarMenuItemType
    {
        Conquer,
        Setup,
        Language,
        Theme,
        About
    }
}
