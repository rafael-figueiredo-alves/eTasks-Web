using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Components.Menus;
using eTasks.Components.Services.Interfaces;
using eTasks.Shared.Constants;
using eTasks.Shared.Services;
using eTasks.Shared.Services.Interfaces;
using eTranslate.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.View.Layouts
{
    public class LayoutsBase : LayoutComponentBase
    {
        #region Injeções de Serviços Compartilhados
        [Inject] public NavigationManager? NavigationManager { get; set; }
        [Inject] public LayoutService? LayoutService { get; set; }
        [Inject] public IThemeService? ThemeService { get; set; }
        [Inject] public ILanguageService? LanguageService { get; set; }
        [Inject] public IDialogService? DialogService { get; set; }
        [Inject] public IJSRuntime? IJSRuntime { get; set; }
        [Inject] public IeTranslate? ETranslate { get; set; }
        #endregion

        #region Variáveis compartilhadas
        public bool IsMobile { get; set; } = false;
        public bool ThemeChange { get; set; } = false;
        public string CorFundo { get; set; } = string.Empty;
        public string CorTexto { get; set; } = string.Empty;
        public string CurrentLanguage { get; set; } = "pt-BR";
        public Dictionary<MainMenuTextsEnum, string>? MenuTexts { get; set; }
        public Dictionary<AvatarMenuTextsEnum, string>? AvatarMenuTexts { get; set; }
        public Dictionary<DialogTextsEnum, string>? DialogTexts { get; set; }
        public string? ActionButtonHint { get; set; } = "Adicionar";
        public string LangageMenuTitle { get; set; } = "Idioma";
        public string DicaTrocarIdiomaMainNavBar { get; set; } = "Trocar tema";
        #endregion

        #region Métodos
        protected override async Task OnInitializedAsync()
        {
            IsMobile = false;

            // Define o layout inicial
            if (LayoutService != null)
                IsMobile = await (LayoutService?.IsMobileLayout() ?? Task.FromResult<bool?>(false)) ?? false;

            HandleLayoutChanged(IsMobile);

            // Inscreve-se para ouvir mudanças no layout
            if (LayoutService != null)
                LayoutService.OnLayoutChanged += HandleLayoutChanged;

            LanguageService!.OnLanguageChanged += SetCurrentLanguage;
            await LanguageService.SetLanguage(await LanguageService!.GetLanguage());

            await ChangeTheme();
        }

        protected virtual async Task SetCurrentLanguage(string language)
        {
            CurrentLanguage = language;
            ETranslate!.SetLanguage(CurrentLanguage);

            MenuTexts = new Dictionary<MainMenuTextsEnum, string>
            {
                { MainMenuTextsEnum.Home, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Home, "Inicio") },
                { MainMenuTextsEnum.Tasks, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Tasks, "Tarefas") },
                { MainMenuTextsEnum.Goals, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Goals, "Metas") },
                { MainMenuTextsEnum.Readings, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Readings, "Leituras") },
                { MainMenuTextsEnum.Shopping, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Shopping, "Compras") },
                { MainMenuTextsEnum.Notes, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Notes, "Anotações") },
                { MainMenuTextsEnum.Finance, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Finances, "Finanças") },
                { MainMenuTextsEnum.Title, await ETranslate!.Translate(TranslateKeyConsts.MainMenu_Title, "Menu") },
            };
 
            AvatarMenuTexts = new Dictionary<AvatarMenuTextsEnum, string>
            {
                { AvatarMenuTextsEnum.EditProfile, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_EditProfile, "Editar Perfil") },
                { AvatarMenuTextsEnum.ChangePassword, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_ChangePassword, "Alterar senha") },
                { AvatarMenuTextsEnum.About, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_About, "Sobre o eTasks") },
                { AvatarMenuTextsEnum.Settings, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_Settings, "Configurações") },
                { AvatarMenuTextsEnum.Conquers, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_Conquers, "Conquistas") },
                { AvatarMenuTextsEnum.ChangeLanguage, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_ChangeLanguage, "Trocar idioma") },
                { AvatarMenuTextsEnum.ChangeTheme, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_ChangeTheme, "Trocar tema") },
                { AvatarMenuTextsEnum.Logout, await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_Logout, "Sair") },
            };

            DialogTexts = new Dictionary<DialogTextsEnum, string>
            {
                { DialogTextsEnum.CopyErrorMsg, await ETranslate!.Translate(TranslateKeyConsts.Dialog_CopyErrorMsg, "Não foi possível copiar erro!") },
                { DialogTextsEnum.CopySuccessMsg, await ETranslate!.Translate(TranslateKeyConsts.Dialog_CopySuccessMsg, "Msg. de Erro copiada com sucesso!") },
                { DialogTextsEnum.CopyButton, await ETranslate!.Translate(TranslateKeyConsts.Dialog_CopyButton, "Copiar") },
                { DialogTextsEnum.OkButton, await ETranslate!.Translate(TranslateKeyConsts.Dialog_OkButton, "Confirmar") },
                { DialogTextsEnum.CancelButton, await ETranslate!.Translate(TranslateKeyConsts.Dialog_CancelButton, "Cancelar") },
                { DialogTextsEnum.MoreDetails, await ETranslate!.Translate(TranslateKeyConsts.Dialog_MoreDetails, "Mais detalhes") }
            };

            ActionButtonHint = await ETranslate!.Translate(TranslateKeyConsts.ActionButton_Hint, "Adicionar");

            LangageMenuTitle = await ETranslate!.Translate(TranslateKeyConsts.LanguageMenu_Title, "Idioma");
            DicaTrocarIdiomaMainNavBar = await ETranslate!.Translate(TranslateKeyConsts.AvatarMenu_ChangeTheme, "Trocar tema");
        }

        protected virtual async Task ChangeTheme()
        {
            CorFundo = ColorPallete.GetColor(Cor.Background, await ThemeService!.IsDarkTheme());
            CorTexto = ColorPallete.GetColor(Cor.Text, await ThemeService!.IsDarkTheme());

            await InvokeAsync(StateHasChanged);
        }

        private void HandleLayoutChanged(bool isMobileLayout)
        {
            IsMobile = isMobileLayout;
            InvokeAsync(StateHasChanged);
        }

        protected void Dispose()
        {
            if (LayoutService != null)
                LayoutService.OnLayoutChanged -= HandleLayoutChanged;

            if(LanguageService != null)
                LanguageService.OnLanguageChanged -= SetCurrentLanguage;
        }
        #endregion
    }
}
