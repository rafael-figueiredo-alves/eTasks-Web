using eTasks.Shared.Services;
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
        #endregion

        #region Variáveis públicas compartilhadas entre telas
        public Type TipoLayout { get; set; } = typeof(Layouts.MainLayout);
        public bool isMobile { get; set; } = false;
        #endregion

        #region Métodos
        protected override void OnInitialized()
        {         
            // Define o layout inicial
            isMobile = LayoutService?.IsMobileLayout ?? false;

            if (isMobile)
                TipoLayout = typeof(Layouts.PageLayout);
            else
                TipoLayout = typeof(Layouts.MainLayout);

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;

            base.OnInitialized();
        }

        //Método responsáevl por lidar com os layouts
        private void HandleLayoutChanged(bool isMobileLayout)
        {
            isMobile = isMobileLayout;

            if (isMobileLayout)
                TipoLayout = typeof(Layouts.PageLayout);
            else
                TipoLayout = typeof(Layouts.MainLayout);

            InvokeAsync(StateHasChanged);
        }
        #endregion
    }
}
