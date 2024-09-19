using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class ButtonBarBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = "/assets/UI/Avatar.png";
        [Parameter] public List<BarButton>? Botoes { get; set; } = null;
        #endregion

        public string ImagemAvatar
        {
            get
            {
                var path = "";
                if (AvatarPath.StartsWith("/"))
                    path = navigationManager?.BaseUri.TrimEnd('/') + AvatarPath;
                else
                    if (navigationManager!.BaseUri.EndsWith('/'))
                    path = navigationManager?.BaseUri + AvatarPath;
                else
                    path = navigationManager?.BaseUri + "/" + AvatarPath;
                return path;
            }
        }
    }

    public class BarButton
    {
        public string Imagem {  get; set; } = string.Empty;
        public string DicaTela { get; set; } = string.Empty;
        public EventCallback OnClick { get; set; }
    }
}
