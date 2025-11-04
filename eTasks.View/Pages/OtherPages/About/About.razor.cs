using eTasks.Components;
using eTasks.Components.Enums;
using eTasks.Controller.Interfaces;
using eTasks.Shared.Constants;
using eTasks.Shared.Extensions;
using eTasks.View.Pages.OtherPages.About.Components;
using eTranslate.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace eTasks.View.Pages.OtherPages.About
{
    public class AboutBase : PageBase
    {
        #region Serviços injetados
        [Inject] protected HttpClient? Http { get; set; }
        [Inject] public IeTranslate? ETranslate { get; set; }
        [Inject] public IVersion? versionController { get; set; }
        #endregion

        #region Variáveis
        protected string Versao { get; set; } = string.Empty;
        protected string Titulo { get; set; } = "Sobre o eTasks";
        protected string CorDestaques { get; set; } = string.Empty;
        protected string CorNormal {  get; set; } = string.Empty;
        protected string Language { get; set; } = string.Empty;
        protected List<Changelog> Changelogs { get; set; } = new List<Changelog>();
        private List<ChangelogsByLanguage> ChangelogClasses { get; set; } = new List<ChangelogsByLanguage>();
        #endregion

        #region Métodos
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Titulo = $"{await ETranslate!.Translate(TranslateKeyConsts.About_Title)}";

            ChangelogClasses = await Http!.GetFromJsonAsync<List<ChangelogsByLanguage>>("Changelog.json") ?? new List<ChangelogsByLanguage>();

            Changelogs = GetChangeLog(await LanguageService!.GetLanguage());

            await ChangeTheme();

            Versao = SystemConstants.AppVersion;

            LanguageService!.OnLanguageChanged += SetCurrentLanguage;
            ThemeService!.OnThemeChanged += ChangeTheme;
        }

        public async Task UpdateClickAsync()
        {
            var Teste = await versionController?.IsUpdateAvailable()!;

            if(Teste.Item1)
            {
                await DialogService!.Confirm("Atualização disponível", $"Há uma nova versão {Teste.Item2}. Deseja atualizar o sistema?");
            }
            //await DialogService!.Confirm("Atualização disponível", "Há uma nova versão. Deseja atualizar o sistema?");
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
            Titulo = $"{await ETranslate!.Translate(TranslateKeyConsts.About_Title)}";
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
        #endregion
    }
}
