using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class MainMenuBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public MainMenuItemType SelectedItem { get; set; }
        [Parameter] public EventCallback<MainMenuItemType> OnMainMenuItemClick { get; set; }
        [Parameter] public Dictionary<MainMenuTextsEnum, string>? MenuTexts { get; set; }


        protected string CloseButton { get; set; }    = "assets/UI/offcanvas/light/Close.png";
        protected bool InicioSelected { get; set; }   = true;
        protected bool TarefasSelected { get; set; }  = false;
        protected bool MetasSelected { get; set; }    = false;
        protected bool ComprasSelected { get; set; }   = false;
        protected bool LeiturasSelected { get; set; }  = false;
        protected bool AnotacoesSelected { get; set; } = false;
        protected bool FinancasSelected { get; set; }  = false;

        protected string GetMenuText(MainMenuTextsEnum text)
        {
            if (MenuTexts == null)
                return DefaultMenuText(text);
            return MenuTexts[text];
        }

        protected string DefaultMenuText(MainMenuTextsEnum text)
        {
            var TextToReturn = string.Empty;

            switch(text)
            {
                case MainMenuTextsEnum.Title:
                    TextToReturn = "Menu";
                    break;
                case MainMenuTextsEnum.Home:
                    TextToReturn = "Início";
                    break;
                case MainMenuTextsEnum.Tasks:
                    TextToReturn = "Tarefas";
                    break;
                case MainMenuTextsEnum.Goals:
                    TextToReturn = "Metas";
                    break;
                case MainMenuTextsEnum.Shopping:
                    TextToReturn = "Compras";
                    break;
                case MainMenuTextsEnum.Readings:
                    TextToReturn = "Leituras";
                    break;
                case MainMenuTextsEnum.Notes:
                    TextToReturn = "Anotações";
                    break;
                case MainMenuTextsEnum.Finance:
                    TextToReturn = "Finanças";
                    break;
            }

            return TextToReturn;
        }


        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                CloseButton = "assets/UI/offcanvas/dark/Close.png";
            else
                CloseButton = "assets/UI/offcanvas/light/Close.png";

            Task.Run(async () => await SetSelected(SelectedItem));
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
