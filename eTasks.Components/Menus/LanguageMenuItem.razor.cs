using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class LanguageMenuItemBase : ComponentBase
    {
        #region Parametros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public SupportedLanguages Language { get; set; } = SupportedLanguages.Portugues;
        [Parameter] public bool Selected { get; set; } = false;
        [Parameter] public EventCallback<SupportedLanguages> OnSelectLanguage { get; set; }
        #endregion

        #region Variáveis
        protected string ImageIcon { get; set; } = "assets/UI/languages/pt.svg";
        protected string ItemName { get; set; } = "Português";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            ItemName  = LanguageUtils.GetLanguageName(Language);
            ImageIcon = LanguageUtils.GetLanguageFlag(Language);
        }

        protected async Task OnClick()
        {
            await OnSelectLanguage.InvokeAsync(Language);
        }
        #endregion
    }

    public enum SupportedLanguages
    {
        Portugues,
        English,
        Espanol
    }

    public static class LanguageUtils
    {
        public static string GetLanguageName(SupportedLanguages language)
        {
            return language switch
            {
                SupportedLanguages.Portugues => "Português",
                SupportedLanguages.English => "English",
                SupportedLanguages.Espanol => "Español",
                _ => "Unknown"
            };
        }

        public static string GetLanguageFlag(SupportedLanguages language)
        {
            return language switch
            {
                SupportedLanguages.Portugues => "assets/UI/languages/pt.svg",
                SupportedLanguages.English => "assets/UI/languages/en.svg",
                SupportedLanguages.Espanol => "assets/UI/languages/es.svg",
                _ => "assets/UI/languages/pt.svg"
            };
        }

        public static string GetLanguageCode(SupportedLanguages language)
        {
            return language switch
            {
                SupportedLanguages.Portugues => "pt-BR",
                SupportedLanguages.English => "en-US",
                SupportedLanguages.Espanol => "es-ES",
                _ => "pt-BR"
            };
        }

        public static SupportedLanguages GetLanguageFromCode(string code)
        {
            return code switch
            {
                "pt-BR" => SupportedLanguages.Portugues,
                "en-US" => SupportedLanguages.English,
                "es-ES" => SupportedLanguages.Espanol,
                _ => SupportedLanguages.Portugues
            };
        }
    }
}
