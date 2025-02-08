using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class MainMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public EventCallback<MainMenuItemType> OnMainMenuItemClick { get; set; }


        protected string CloseButton { get; set; }    = "assets/UI/offcanvas/light/Close.png";
        protected bool InicioSelected { get; set; }   = true;
        protected bool TarefasSelected { get; set; }  = false;
        protected bool MetasSelected { get; set; }    = false;
        protected bool ComprasSelected { get; set; }   = false;
        protected bool LeiturasSelected { get; set; }  = false;
        protected bool AnotacoesSelected { get; set; } = false;
        protected bool FinancasSelected { get; set; }  = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //if(firstRender)
            //{
            //    await SetSelected(MainMenuItemType.Home);
            //}
        }

        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                CloseButton = "assets/UI/offcanvas/dark/Close.png";
            else
                CloseButton = "assets/UI/offcanvas/light/Close.png";
        }

        private async Task SetSelected(MainMenuItemType itemType)
        {
            InicioSelected = false;
            TarefasSelected = false;
            MetasSelected = false;
            ComprasSelected = false;
            LeiturasSelected = false;
            AnotacoesSelected = false;
            FinancasSelected = false;
            switch (itemType)
            {
                case MainMenuItemType.Home:
                    InicioSelected = true;
                    break;
                case MainMenuItemType.Tasks:
                    TarefasSelected = true;
                    break;
                case MainMenuItemType.Goals:
                    MetasSelected = true;
                    break;
                case MainMenuItemType.Shopping:
                    ComprasSelected = true;
                    break;
                case MainMenuItemType.Readings:
                    LeiturasSelected = true;
                    break;
                case MainMenuItemType.Notes:
                    AnotacoesSelected = true;
                    break;
                case MainMenuItemType.Finance:
                    FinancasSelected = true;
                    break;
            }
            await InvokeAsync(StateHasChanged);
        }

        protected async Task MainMenuItemClick(MainMenuItemType itemType)
        {
            await SetSelected(itemType);

            if(OnMainMenuItemClick.HasDelegate)
                await OnMainMenuItemClick.InvokeAsync(itemType);
        }
    }
}
