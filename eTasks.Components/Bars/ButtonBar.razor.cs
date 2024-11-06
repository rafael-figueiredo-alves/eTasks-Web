using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace eTasks.Components.Bars
{
    public class ButtonBarBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = string.Empty;
        [Parameter] public List<BarButton>? Botoes { get; set; } = null;
        [Parameter] public string AvatarOffcanvasMenuID { get; set; } = string.Empty;
        [Parameter] public EventCallback AvatarOnClick { get; set; }
        [Parameter] public bool isDarkMode { get; set; } = false;
        [Parameter] public bool ShowAvatar { get; set; } = true;
        #endregion

        protected string basePath { get; set; } = "assets/UI/toolbar/light/";

        protected override void OnParametersSet()
        {
            if (isDarkMode)
                basePath = "assets/UI/toolbar/dark/";
            else
                basePath = "assets/UI/toolbar/light/";

        }
    }

    public class BarButton
    {
        public string Imagem {  get; set; } = string.Empty;
        public string DicaTela { get; set; } = string.Empty;
        public Action? OnClick { get; set; }
        public string OffcanvasMenuID { get; set; } = string.Empty;
    }
}
