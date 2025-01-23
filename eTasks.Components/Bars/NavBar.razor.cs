using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class NavBarBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public bool IsMobile { get; set; } = false;
        [Parameter] public NavBarButtonsKind NavBarButtonsKind { get; set; } = NavBarButtonsKind.DeleteCheck;
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public EventCallback OnBackButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnHelpButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnDeleteButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnCheckButtonClick { get; set; }

        protected TopBarPosition BarPosition { get; set; } = TopBarPosition.FixedTop;
        protected List<BarButton> Botoes { get; set; } = new();
        protected string basePath { get; set; } = "assets/UI/toolbar/light/";
        protected string TextColor { get; set; } = "#336699";
        protected string Height { get; set; } = "60px";
        protected string DivHeight { get; set; } = "0px";

        protected override void OnParametersSet()
        {
            DivHeight = IsMobile ? "70px" : "0px";

            TextColor = ColorPallete.GetColor(Cor.Primary, IsDarkMode);

            if (IsDarkMode)
                basePath = "assets/UI/toolbar/dark/";
            else
                basePath = "assets/UI/toolbar/light/";

            if (IsMobile)
                BarPosition = TopBarPosition.FixedTop;
            else
                BarPosition = TopBarPosition.None;

            RebuildNavBar();
        }

        protected override void OnInitialized()
        {
            RebuildNavBar();
        }

        private void RebuildNavBar()
        {
            Botoes.Clear();
            Botoes.Add(new BarButton() { DicaTela = "Ajuda", Imagem = "Help.png", Visible = NavBarButtonsKind == NavBarButtonsKind.OnlyHelp ? true : false, OnClick = OnHelpButtonClick });
            Botoes.Add(new BarButton() { DicaTela = "Apagar", Imagem = "Delete.png", Visible = NavBarButtonsKind == NavBarButtonsKind.DeleteCheck ? true : false, OnClick = OnDeleteButtonClick });
            Botoes.Add(new BarButton() { DicaTela = "Salvar", Imagem = "Accept.png", Visible = NavBarButtonsKind == NavBarButtonsKind.DeleteCheck || NavBarButtonsKind == NavBarButtonsKind.OnlyCheck ? true : false, OnClick = OnCheckButtonClick });
        }
    }

    public enum NavBarButtonsKind
    {
        OnlyCheck,
        OnlyHelp,
        DeleteCheck
    }
}
