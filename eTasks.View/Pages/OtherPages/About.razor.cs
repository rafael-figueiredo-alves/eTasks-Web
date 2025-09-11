using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Shared.Extensions;

namespace eTasks.View.Pages.OtherPages
{
    public class AboutBase : PageBase
    {   
        protected string Versao { get; set; } = string.Empty;
        protected string CorDestaques { get; set; } = string.Empty;
        protected string CorNormal {  get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ChangeTheme();

            Versao = "2.0.0";

            LanguageService.OnLanguageChanged += SetCurrentLanguage;
            ThemeService.OnThemeChanged += ChangeTheme;
        }

        public override async Task ChangeTheme()
        {
            await base.ChangeTheme();
            CorDestaques = ColorPallete.GetColor(Cor.Primary, ThemeChange);
            CorNormal = ColorPallete.GetColor(Cor.Secondary, ThemeChange);
        }

        protected async Task SetCurrentLanguage(string language)
        {
            if (Versao == "2.0.0")
                Versao = language;
            else
                Versao = "2.0.0";
        }

        protected void Voltar()
        {
            NavigationManager?.GoBack();
        }
    }
}
