using eTasks.Components;
using eTasks.Components.Menus;
using eTasks.Shared.Services;
using eTasks.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.View.Layouts
{
    public class LayoutsBase : LayoutComponentBase
    {
        #region Injeções de Serviços Compartilhados
        [Inject] public NavigationManager? navigationManager { get; set; }
        [Inject] public LayoutService? LayoutService { get; set; }
        [Inject] public IThemeService? ThemeService { get; set; }
        [Inject] public IJSRuntime? iJSRuntime { get; set; }
        #endregion

        #region Variáveis compartilhadas
        public bool isMobile { get; set; } = false;
        public string CorFundo { get; set; } = string.Empty;
        public string CorTexto { get; set; } = string.Empty;
        public bool ThemeChange { get; set; } = false;
        public Dictionary<MainMenuTextsEnum, string>? MenuTexts { get; set; }
        public Dictionary<AvatarMenuTextsEnum, string>? AvatarMenuTexts { get; set; }
        #endregion

        #region Métodos
        protected override async Task OnInitializedAsync()
        {
            // Define o layout inicial
            isMobile = (await LayoutService?.IsMobileLayout()) ?? false;
            HandleLayoutChanged(isMobile);

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;

            ChangeTheme();

            MenuTexts = new Dictionary<MainMenuTextsEnum, string>
            {
                { MainMenuTextsEnum.Home, "Início_1" },
                { MainMenuTextsEnum.Tasks, "Tarefas" },
                { MainMenuTextsEnum.Goals, "Metas" },
                { MainMenuTextsEnum.Readings, "Leituras" },
                { MainMenuTextsEnum.Shopping, "Compras" },
                { MainMenuTextsEnum.Notes, "Anotações" },
                { MainMenuTextsEnum.Finance, "Finanças" },
                { MainMenuTextsEnum.Title, "Opçoes" },
            };

            AvatarMenuTexts = new Dictionary<AvatarMenuTextsEnum, string>
            {
                { AvatarMenuTextsEnum.EditProfile, "Editar Perfil" },
                { AvatarMenuTextsEnum.ChangePassword, "Alterar senha" },
                { AvatarMenuTextsEnum.About, "Sobre o eTasks" },
                { AvatarMenuTextsEnum.Settings, "Configurações" },
                { AvatarMenuTextsEnum.Conquers, "Conquistas" },
                { AvatarMenuTextsEnum.ChangeLanguage, "Trocar idioma" },
                { AvatarMenuTextsEnum.ChangeTheme, "Trocar tema" },
                { AvatarMenuTextsEnum.Logout, "Sair" },
            };
        }

        public virtual void ChangeTheme()
        {
            CorFundo = ColorPallete.GetColor(Cor.Background, ThemeService?.IsDarkTheme() ?? false);
            CorTexto = ColorPallete.GetColor(Cor.Text, ThemeService?.IsDarkTheme() ?? false);

            if(ThemeService?.IsDarkTheme() ?? false)
            {
                MenuTexts = new Dictionary<MainMenuTextsEnum, string>
                {
                { MainMenuTextsEnum.Home, "Home" },
                { MainMenuTextsEnum.Tasks, "Tasks" },
                { MainMenuTextsEnum.Goals, "Goals" },
                { MainMenuTextsEnum.Readings, "Readings" },
                { MainMenuTextsEnum.Shopping, "Shopping" },
                { MainMenuTextsEnum.Notes, "Notes" },
                { MainMenuTextsEnum.Finance, "Finances" },
                { MainMenuTextsEnum.Title, "Menu" },
                };

                AvatarMenuTexts = new Dictionary<AvatarMenuTextsEnum, string>
                {
                { AvatarMenuTextsEnum.EditProfile, "Edit Profile" },
                { AvatarMenuTextsEnum.ChangePassword, "Change Password" },
                { AvatarMenuTextsEnum.About, "About eTasks" },
                { AvatarMenuTextsEnum.Settings, "Settings" },
                { AvatarMenuTextsEnum.Conquers, "Conquers" },
                { AvatarMenuTextsEnum.ChangeLanguage, "Change Language" },
                { AvatarMenuTextsEnum.ChangeTheme, "Change Theme" },
                { AvatarMenuTextsEnum.Logout, "Logout" },
                };
            }
            else
            {
                MenuTexts = new Dictionary<MainMenuTextsEnum, string>
                {
                { MainMenuTextsEnum.Home, "Início_1" },
                { MainMenuTextsEnum.Tasks, "Tarefas" },
                { MainMenuTextsEnum.Goals, "Metas" },
                { MainMenuTextsEnum.Readings, "Leituras" },
                { MainMenuTextsEnum.Shopping, "Compras" },
                { MainMenuTextsEnum.Notes, "Anotações" },
                { MainMenuTextsEnum.Finance, "Finanças" },
                { MainMenuTextsEnum.Title, "Opçoes" },
                };

                AvatarMenuTexts = new Dictionary<AvatarMenuTextsEnum, string>
                {
                { AvatarMenuTextsEnum.EditProfile, "Editar Perfil" },
                { AvatarMenuTextsEnum.ChangePassword, "Alterar senha" },
                { AvatarMenuTextsEnum.About, "Sobre o eTasks" },
                { AvatarMenuTextsEnum.Settings, "Configurações" },
                { AvatarMenuTextsEnum.Conquers, "Conquistas" },
                { AvatarMenuTextsEnum.ChangeLanguage, "Trocar idioma" },
                { AvatarMenuTextsEnum.ChangeTheme, "Trocar tema" },
                { AvatarMenuTextsEnum.Logout, "Sair" },
                };
            }
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
        #endregion
    }
}
