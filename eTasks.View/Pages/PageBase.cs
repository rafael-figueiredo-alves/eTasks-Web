using eTasks.Components;
using eTasks.Shared.Services;
using eTasks.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    /// <summary>
    /// Classe base para Páginas
    /// </summary>
    public class PageBase : ComponentBase
    {
        #region Serviços injetados necessários às páginas
        [Inject] public LayoutService? LayoutService { get; set; }
        [Inject] protected NavigationManager? NavigationManager { get; set; }
        [Inject] protected IThemeService? ThemeService { get; set; }
        #endregion

        #region Variáveis públicas compartilhadas entre telas
        public Type TipoLayout { get; set; } = typeof(Layouts.MainLayout);
        public bool IsMobile { get; set; } = false;
        public string CorFundo { get; set; } = string.Empty;
        public string CorTexto { get; set; } = string.Empty;
        public string BackButtonHint { get; set; } = "Voltar";
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

            ChangeTheme();

            base.OnInitialized();
        }

        public virtual void ChangeTheme()
        {
            CorFundo = ColorPallete.GetColor(Cor.Background, ThemeService?.IsDarkTheme() ?? false);
            CorTexto = ColorPallete.GetColor(Cor.Text, ThemeService?.IsDarkTheme() ?? false);
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
        #endregion
    }
}
