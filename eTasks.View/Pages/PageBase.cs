using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject] public LayoutService? LayoutService { get; set; }
        [Inject] protected NavigationManager? NavigationManager { get; set; }

        public Type TipoLayout { get; set; } = typeof(eTasks.View.Layouts.MainLayout);
        public bool isMobile { get; set; } = false;

        protected override void OnInitialized()
        {         
            // Define o layout inicial
            isMobile = LayoutService?.IsMobileLayout ?? false;

            if (isMobile)
                TipoLayout = typeof(eTasks.View.Layouts.PageLayout);
            else
                TipoLayout = typeof(eTasks.View.Layouts.MainLayout);

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;

            base.OnInitialized();
        }

        private void HandleLayoutChanged(bool isMobileLayout)
        {
            isMobile = isMobileLayout;
            if (isMobileLayout)
                TipoLayout = typeof(eTasks.View.Layouts.PageLayout);
            else
                TipoLayout = typeof(eTasks.View.Layouts.MainLayout);
            InvokeAsync(StateHasChanged);
        }
    }
}
