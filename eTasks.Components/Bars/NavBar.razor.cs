using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class NavBarBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public bool IsMobile { get; set; } = false;

        protected TopBarPosition BarPosition { get; set; } = TopBarPosition.FixedTop;
        protected List<BarButton> Botoes { get; set; } = new();
        protected string basePath { get; set; } = "assets/UI/toolbar/light/";
        protected string TextColor { get; set; } = "#336699";
        protected string Height { get; set; } = "60px";

        protected override void OnParametersSet()
        {
            Height = IsMobile ? "70px" : "40px";

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
            Botoes.Add(new BarButton() { DicaTela = "Apagar", Imagem = "Delete.png" });
            Botoes.Add(new BarButton() { DicaTela = "Salvar", Imagem = "Accept.png" });
        }
    }
}
