using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class ButtonBarBase : ComponentBase
    {
        #region Dependency injections
        [Inject] protected NavigationManager? navigationManager { get; set; }
        #endregion

        #region Parameters
        [Parameter] public string AvatarPath { get; set; } = string.Empty;
        [Parameter] public List<BarButton>? Botoes { get; set; } = null;
        [Parameter] public string AvatarOffcanvasMenuID { get; set; } = string.Empty;
        [Parameter] public EventCallback AvatarOnClick { get; set; }
        [Parameter] public bool isDarkMode { get; set; } = false;
        [Parameter] public bool ShowAvatar { get; set; } = true;
        [Parameter] public string AvatarHint { get; set; } = "Menu do usuário";
        #endregion

        #region Variables
        protected string basePath { get; set; } = "assets/UI/toolbar/light/";
        #endregion

        #region Methods
        protected override void OnParametersSet()
        {
            if (isDarkMode)
                basePath = "assets/UI/toolbar/dark/";
            else
                basePath = "assets/UI/toolbar/light/";

        }
        #endregion
    }

    public class BarButton
    {
        public string Imagem {  get; set; } = string.Empty;
        public string DicaTela { get; set; } = string.Empty;
        public EventCallback<Task> OnClick { get; set; }
        public string OffcanvasMenuID { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
    }
}
