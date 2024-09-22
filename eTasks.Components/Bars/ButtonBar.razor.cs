using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace eTasks.Components.Bars
{
    public class ButtonBarBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = "assets/UI/Avatar2.png";
        [Parameter] public List<BarButton>? Botoes { get; set; } = null;
        [Parameter] public string AvatarOffcanvasMenuID { get; set; } = string.Empty;
        [Parameter] public EventCallback AvatarOnClick { get; set; }
        #endregion
    }

    public class BarButton
    {
        public string Imagem {  get; set; } = string.Empty;
        public string DicaTela { get; set; } = string.Empty;
        public Action? OnClick { get; set; }
        public string OffcanvasMenuID { get; set; } = string.Empty;
    }
}
