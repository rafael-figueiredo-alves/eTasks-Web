using eTasks.Components;
using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Layouts
{
    public class LayoutsBase : LayoutComponentBase
    {
        [Inject] public NavigationManager? navigationManager { get; set; }
        [Inject] public LayoutService? LayoutService { get; set; }

        public bool isMobile { get; set; } = false;
        public string CorFundo { get; set; } = string.Empty;
        public string CorTexto { get; set; } = string.Empty;
        public bool ThemeChange { get; set; } = false;

        protected override void OnInitialized()
        {
            // Define o layout inicial
            isMobile = LayoutService?.IsMobileLayout ?? false;

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;

            ChangeTheme();
        }

        public virtual void ChangeTheme()
        {
            CorFundo = ColorPallete.GetColor(Cor.Background, ThemeChange);
            CorTexto = ColorPallete.GetColor(Cor.Text, ThemeChange);
        }

        private void HandleLayoutChanged(bool isMobileLayout)
        {
            isMobile = isMobileLayout;
            InvokeAsync(StateHasChanged);
        }

        protected void Dispose()
        {
            if (LayoutService != null)
                LayoutService.OnLayoutChanged -= HandleLayoutChanged;
        }
    }
}
