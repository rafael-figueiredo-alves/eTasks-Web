using eTasks.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class NavBarBase : ComponentBase
    {
        #region Parâmetros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public bool IsMobile { get; set; } = false;
        [Parameter] public NavBarButtonsKind NavBarButtonsKind { get; set; } = NavBarButtonsKind.DeleteCheck;
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public EventCallback OnBackButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnHelpButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnDeleteButtonClick { get; set; }
        [Parameter] public EventCallback<Task> OnCheckButtonClick { get; set; }
        [Parameter] public string BackButtonText { get; set; } = "Voltar";
        [Parameter] public Dictionary<NavBarHintTextsEnum, string>? HintTexts { get; set; }
        #endregion

        #region Variáveis
        protected TopBarPosition BarPosition { get; set; } = TopBarPosition.FixedTop;
        protected List<BarButton> Botoes { get; set; } = [];
        protected string BasePath { get; set; } = "assets/UI/toolbar/light/";
        protected string TextColor { get; set; } = "#336699";
        protected string Height { get; set; } = "60px";
        protected string DivHeight { get; set; } = "0px";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            DivHeight = IsMobile ? "70px" : "0px";

            TextColor = ColorPallete.GetColor(Cor.Primary, IsDarkMode);

            if (IsDarkMode)
                BasePath = "assets/UI/toolbar/dark/";
            else
                BasePath = "assets/UI/toolbar/light/";

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

        private void SetHintValues()
        {
            if(HintTexts == null || HintTexts.Count == 0)
            {
                HintTexts = new()
                {
                    { NavBarHintTextsEnum.Save, "Salvar" },
                    { NavBarHintTextsEnum.Delete, "Apagar" },
                    { NavBarHintTextsEnum.Help, "Ajuda" }
                };
            }

            if (!HintTexts.ContainsKey(NavBarHintTextsEnum.Save))
                HintTexts.Add(NavBarHintTextsEnum.Save, "Salvar");

            if (!HintTexts.ContainsKey(NavBarHintTextsEnum.Help))
                HintTexts.Add(NavBarHintTextsEnum.Help, "Ajuda");

            if (!HintTexts.ContainsKey(NavBarHintTextsEnum.Delete))
                HintTexts.Add(NavBarHintTextsEnum.Delete, "Apagar");
        }

        private void RebuildNavBar()
        {
            SetHintValues();
            Botoes.Clear();
            Botoes.Add(new BarButton() { DicaTela = HintTexts![NavBarHintTextsEnum.Help], Imagem = "Help.png", Visible = NavBarButtonsKind == NavBarButtonsKind.OnlyHelp, OnClick = OnHelpButtonClick });
            Botoes.Add(new BarButton() { DicaTela = HintTexts![NavBarHintTextsEnum.Delete], Imagem = "Delete.png", Visible = NavBarButtonsKind == NavBarButtonsKind.DeleteCheck, OnClick = OnDeleteButtonClick });
            Botoes.Add(new BarButton() { DicaTela = HintTexts![NavBarHintTextsEnum.Save], Imagem = "Accept.png", Visible = NavBarButtonsKind == NavBarButtonsKind.DeleteCheck || NavBarButtonsKind == NavBarButtonsKind.OnlyCheck, OnClick = OnCheckButtonClick });
        }
        #endregion
    }

    public enum NavBarButtonsKind
    {
        OnlyCheck,
        OnlyHelp,
        DeleteCheck
    }
}
