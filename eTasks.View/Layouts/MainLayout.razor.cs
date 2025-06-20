using eTasks.Components.Menus;
using eTasks.Shared.Constants;
using eTasks.Shared.Extensions;
using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.View.Layouts
{
    public class MainLayoutBase : LayoutsBase
    {
        #region Serviços
        [Inject] public MenuTeste? MenuTeste { get; set; }
        #endregion

        #region Variáveis
        protected string Title { get; set; } = "Minhas Tarefas";
        protected MainMenuItemType SelectedMainMenuItem { get; set; }
        #endregion

        #region Métodos
        protected override async Task SetCurrentLanguage(string language)
        {
            await base.SetCurrentLanguage(language);
            await SetTitleBar();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                MenuTeste?.SetSelected((int)MainMenuItemType.Tasks);
                ThemeChange = await ThemeService!.IsDarkTheme();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected void GoAbout()
        {
            NavigationManager?.GoTo("about");
        }

        protected async Task OnSelectedLanguage(string languageCode)
        {
            await Task.CompletedTask;
            await LanguageService!.SetLanguage(languageCode);
        }

        protected async Task OnChangeTheme()
        {
            ThemeService?.ChangeTheme();
            ThemeChange = await ThemeService!.IsDarkTheme();
            await ChangeTheme();
        }

        protected async Task GoGoogle()
        {
            try
            {
                var num1 = 24;
                var num2 = 0;
                var Teste = num1 / num2;
            }
            catch (Exception ex)
            {
                await DialogService!.ShowError("ERRO", ex);
            }
            //NavigationManager?.NavigateTo("https://github.com/rafael-figueiredo-alves");
        }

        protected void testeIrGoogle()
        {
            NavigationManager?.NavigateTo("https://github.com/rafael-figueiredo-alves");
        }

        private async Task SetTitleBar()
        {
            switch (SelectedMainMenuItem)
            {
                case MainMenuItemType.Home:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_HomePage, "Seja bem vindo ao eTasks");
                    break;
                case MainMenuItemType.Tasks:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_TasksPage, "Minhas Tarefas");
                    break;
                case MainMenuItemType.Goals:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_GoalsPage, "Minhas Metas");
                    break;
                case MainMenuItemType.Shopping:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_ShoppingPage, "Minhas Compras");
                    break;
                case MainMenuItemType.Readings:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_ReadingsPage, "Minhas Leituras");
                    break;
                case MainMenuItemType.Notes:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_NotesPage, "Minhas Anotações");
                    break;
                case MainMenuItemType.Finance:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_FinancePage, "Minhas Finanças");
                    break;
                default:
                    Title = await ETranslate!.Translate(TranslateKeyConsts.Titles_HomePage, "Seja bem vindo ao eTasks");
                    break;
            }
        }

        protected async Task OnMainMenuItemClick(MainMenuItemType mainMenuItemType)
        {
            await Task.CompletedTask;
            switch (mainMenuItemType)
            {
                case MainMenuItemType.Home:
                    NavigationManager?.GoHome();
                    break;
                case MainMenuItemType.Tasks:
                    Console.WriteLine("Tarefas");
                    break;
                case MainMenuItemType.Goals:
                    Console.WriteLine("Metas");
                    break;
                case MainMenuItemType.Shopping:
                    Console.WriteLine("Compras");
                    break;
                case MainMenuItemType.Readings:
                    Console.WriteLine("Leituras");
                    break;
                case MainMenuItemType.Notes:
                    Console.WriteLine("Anotações");
                    break;
                case MainMenuItemType.Finance:
                    Console.WriteLine("Finanças");
                    break;
                default:
                    NavigationManager?.NavigateTo("/");
                    break;
            }

            SelectedMainMenuItem = mainMenuItemType;
            await SetTitleBar();
            MenuTeste?.SetSelected((int)mainMenuItemType);
        }

        protected async Task OnAvatarMenuItemClick(AvatarMenuItemType avatarMenuItemType)
        {
            await Task.CompletedTask;
            switch (avatarMenuItemType)
            {
                case AvatarMenuItemType.Conquer:

                    break;
                case AvatarMenuItemType.About:
                    NavigationManager?.GoTo("about");
                    break;
                case AvatarMenuItemType.Setup:

                    break;
                case AvatarMenuItemType.Language:
                    if (IJSRuntime != null)
                    {
                        await IJSRuntime.InvokeVoidAsync("OpenLanguageMenu", "LanguageMenu");
                    }
                    break;
                case AvatarMenuItemType.Theme:
                    await OnChangeTheme();
                    break;
                default:
                    NavigationManager?.NavigateTo("/");
                    break;
            }
        }
        #endregion
    }
}
