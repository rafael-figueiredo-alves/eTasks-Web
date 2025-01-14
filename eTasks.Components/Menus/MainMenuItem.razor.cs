using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class MainMenuItemBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public MainMenuItemType ItemType { get; set; } = MainMenuItemType.Home;
        [Parameter] public string? ItemName { get; set; } = string.Empty;
        [Parameter] public bool Selected { get; set; } = false;
        [Parameter] public EventCallback OnClick { get; set; }
        #endregion

        #region Variáveis
        protected string ImageIcon { get; set; } = "assets/UI/mainmenu/light/inicio.png";
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

            switch (ItemType)
            {
                case MainMenuItemType.Home:
                    Item = "inicio";
                    break;
                case MainMenuItemType.Tasks:
                    Item = "tarefas";
                    break;
                case MainMenuItemType.Goals:
                    Item = "metas";
                    break;
                case MainMenuItemType.Shopping:
                    Item = "compras";
                    break;
                case MainMenuItemType.Readings:
                    Item = "leituras";
                    break;
                case MainMenuItemType.Notes:
                    Item = "anotacoes";
                    break;
                case MainMenuItemType.Finance:
                    Item = "financas";
                    break;
            }

            ImageIcon = $"assets/UI/mainmenu/{ThemePath}/{Item}.png";
        }
        #endregion
    }

    public enum MainMenuItemType
    {
        Home,
        Tasks,
        Goals,
        Shopping,
        Readings,
        Notes,
        Finance
    }
}
