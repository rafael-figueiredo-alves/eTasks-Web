using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class LanguageMenuBase : ComponentBase
    {
        #region Parâmetros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public string LanguageMenuTitle { get; set; } = "Idioma";
        [Parameter] public string SelectedLanguage { get; set; } = "en";
        [Parameter] public EventCallback<string> OnSelectLanguage { get; set; }
        #endregion

        #region Variáveis
        protected string CloseButton { get; set; } = "assets/UI/offcanvas/light/Close.png";
        protected SupportedLanguages SelectedLanguageEnum { get; set; } = SupportedLanguages.Portugues;
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                CloseButton = "assets/UI/offcanvas/dark/Close.png";
            else
                CloseButton = "assets/UI/offcanvas/light/Close.png";

            SelectedLanguageEnum = LanguageUtils.GetLanguageFromCode(SelectedLanguage);
        }

        protected async Task OnSelectLanguageClick(SupportedLanguages language)
        {
            SelectedLanguageEnum = language;
            SelectedLanguage = LanguageUtils.GetLanguageCode(language);
            await OnSelectLanguage.InvokeAsync(SelectedLanguage);
        }
        #endregion
    }
}
