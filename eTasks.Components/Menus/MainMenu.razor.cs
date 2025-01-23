using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class MainMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        

        protected string CloseButton { get; set; } = "assets/UI/offcanvas/light/Close.png";
        protected bool InicioSelected { get; set; } = false;
        protected bool TarefasSelected { get; set; } = false;
        protected bool MetasSelected { get; set; } = false;
        protected bool ComprasSelected { get; set; } = false;
        protected bool LeiturasSelected { get; set; } = false;
        protected bool AnotacoesSelected { get; set; } = false;
        protected bool FinancasSelected { get; set; } = false;

        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                CloseButton = "assets/UI/offcanvas/dark/Close.png";
            else
                CloseButton = "assets/UI/offcanvas/light/Close.png";
        }
    }
}
