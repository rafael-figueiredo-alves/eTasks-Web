﻿using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class AppBarBase : ComponentBase
    {
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string AppName { get; set; } = string.Empty;
        [Parameter] public string PageTitle { get; set; } = string.Empty;
        [Parameter] public Action? OnChangeThemeButtonClick { get; set; }
        [Parameter] public string ChangeThemeButtonTip { get; set; } = "Tema escuro";
        [Parameter] public string MenuButtonTip { get; set; } = "Menu";

        protected List<BarButton> Botoes { get; set; } = new();

        protected override void OnInitialized()
        {
            RebuildAppBar();
        }

        protected override void OnParametersSet()
        {
            RebuildAppBar();
        }

        private void RebuildAppBar()
        {
            Botoes.Clear();
            Botoes.Add(new BarButton() { DicaTela = ChangeThemeButtonTip, Imagem = "ThemeChanger.png", OnClick = OnChangeThemeButtonClick });
            Botoes.Add(new BarButton() { DicaTela = MenuButtonTip, Imagem = "MainMenu.png", OffcanvasMenuID = "#TesteMenu" });
        }
    }
}