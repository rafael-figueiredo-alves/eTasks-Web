using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Shared.Extensions;
using eTasks.View.Pages.OtherPages.About.Components;

namespace eTasks.View.Pages.OtherPages.About
{
    public class AboutBase : PageBase
    {   
        protected string Versao { get; set; } = string.Empty;
        protected string CorDestaques { get; set; } = string.Empty;
        protected string CorNormal {  get; set; } = string.Empty;
        protected string Language { get; set; } = string.Empty;
        protected List<Changelog> Changelogs { get; set; } = new List<Changelog>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Changelogs.Add(new Changelog() { VersionTitle = "14/07/2025 - versão 2.0.1", Features = ["- Implementado recurso Minha Leitura", "- Realizados ajustes gráficos na interface", "- Solucionados bugs no login"] });
            Changelogs.Add(new Changelog() { VersionTitle = "25/12/2024 - versão 2.0.0", Features = ["- Lançamento da versão 2."] });

            await ChangeTheme();

            Versao = "2.0.0";

            LanguageService!.OnLanguageChanged += SetCurrentLanguage;
            ThemeService!.OnThemeChanged += ChangeTheme;
        }

        public override async Task ChangeTheme()
        {
            await base.ChangeTheme();
            CorDestaques = ColorPallete.GetColor(Cor.Primary, ThemeChange);
            CorNormal = ColorPallete.GetColor(Cor.Secondary, ThemeChange);
        }

        protected async Task SetCurrentLanguage(string language)
        {
            await Task.CompletedTask;
            Language = language;
        }

        protected void Voltar()
        {
            NavigationManager?.GoBack();
        }
    }
}
