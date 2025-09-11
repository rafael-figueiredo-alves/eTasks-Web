using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;
using eTasks.Shared.Services;
using eTasks.Shared.Services.Interfaces;
using eTranslate.Interfaces;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    /// <summary>
    /// Classe base para Páginas
    /// </summary>
    public class PageBase : ComponentBase, IDisposable
    {
        #region Serviços injetados necessários às páginas
        [Inject] public LayoutService? LayoutService { get; set; }
        [Inject] protected NavigationManager? NavigationManager { get; set; }
        [Inject] protected IThemeService? ThemeService { get; set; }
        [Inject] protected IDialogService? DialogService { get; set; }
        [Inject] protected IeTranslate? IeTranslate { get; set; }
        [Inject] protected ILanguageService? LanguageService { get; set; }
        #endregion

        #region Variáveis públicas compartilhadas entre telas
        public Type TipoLayout { get; set; } = typeof(Layouts.MainLayout);
        public bool IsMobile { get; set; } = false;
        public string CorFundo { get; set; } = string.Empty;
        public string CorTexto { get; set; } = string.Empty;
        public string BackButtonHint { get; set; } = "Voltar";
        public bool ThemeChange { get; set; } = false;       
        #endregion

        #region Métodos
        protected override async Task OnInitializedAsync()
        {
            IsMobile = false;

            // Define o layout inicial
            if(LayoutService != null)
                IsMobile = await (LayoutService?.IsMobileLayout() ?? Task.FromResult<bool?>(false)) ?? false;

            if (IsMobile)
                TipoLayout = typeof(Layouts.PageLayout);
            else
                TipoLayout = typeof(Layouts.MainLayout);

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;
            
            if(ThemeService != null)
                ThemeService!.OnThemeChanged += ChangeTheme;

            await ChangeTheme();

            base.OnInitialized();
        }

        public virtual async Task ChangeTheme()
        {
            ThemeChange = await ThemeService!.IsDarkTheme();
            CorFundo = ColorPallete.GetColor(Cor.Background, await ThemeService!.IsDarkTheme());
            CorTexto = ColorPallete.GetColor(Cor.Text, await ThemeService!.IsDarkTheme());

            await InvokeAsync(StateHasChanged);
        }

        //Método responsáevl por lidar com os layouts
        private void HandleLayoutChanged(bool isMobileLayout)
        {
            IsMobile = isMobileLayout;

            if (isMobileLayout)
                TipoLayout = typeof(Layouts.PageLayout);
            else
                TipoLayout = typeof(Layouts.MainLayout);

            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            ThemeService!.OnThemeChanged -= ChangeTheme;
        }
        #endregion
    }
}
