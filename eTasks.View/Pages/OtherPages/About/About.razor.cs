using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Shared.Enums;
using eTasks.Shared.Extensions;
using eTasks.View.Pages.OtherPages.About.Components;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace eTasks.View.Pages.OtherPages.About
{
    public class AboutBase : PageBase
    {
        [Inject]
        protected HttpClient? Http { get; set; }

        protected string Versao { get; set; } = string.Empty;
        protected string CorDestaques { get; set; } = string.Empty;
        protected string CorNormal {  get; set; } = string.Empty;
        protected string Language { get; set; } = string.Empty;
        protected List<Changelog> Changelogs { get; set; } = new List<Changelog>();
        private List<ChangelogsByLanguage> ChangelogClasses { get; set; } = new List<ChangelogsByLanguage>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ChangelogClasses = await Http!.GetFromJsonAsync<List<ChangelogsByLanguage>>("Changelog.json") ?? new List<ChangelogsByLanguage>();

            Changelogs = GetChangeLog(await LanguageService!.GetLanguage());

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
            Changelogs = GetChangeLog(language);
        }

        protected void Voltar()
        {
            NavigationManager?.GoBack();
        }

        private List<Changelog> GetChangeLog(string Language)
        {
            var Result = ChangelogClasses.FirstOrDefault(x => x.Language == Language);

            if (Result == null)
                return new List<Changelog>();

            return Result.Changelog;
        }
    }
}
