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
        [Inject] public MainMenuService? MainMenuService { get; set; }
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
                SelectedMainMenuItem = (MainMenuItemType)MainMenuService?.GetSelected()!;
                //await OnMainMenuItemClick(SelectedMainMenuItem);
                ThemeChange = await ThemeService!.IsDarkTheme();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected void GoAbout()
        {
            NavigationManager?.NavigateTo("about");
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

        private async Task SetTitleBar()
        {
            Title = SelectedMainMenuItem switch
            {
                MainMenuItemType.Home => await ETranslate!.Translate(TranslateKeyConsts.Titles_HomePage, "Seja bem vindo ao eTasks"),
                MainMenuItemType.Tasks => await ETranslate!.Translate(TranslateKeyConsts.Titles_TasksPage, "Minhas Tarefas"),
                MainMenuItemType.Goals => await ETranslate!.Translate(TranslateKeyConsts.Titles_GoalsPage, "Minhas Metas"),
                MainMenuItemType.Shopping => await ETranslate!.Translate(TranslateKeyConsts.Titles_ShoppingPage, "Minhas Compras"),
                MainMenuItemType.Readings => await ETranslate!.Translate(TranslateKeyConsts.Titles_ReadingsPage, "Minhas Leituras"),
                MainMenuItemType.Notes => await ETranslate!.Translate(TranslateKeyConsts.Titles_NotesPage, "Minhas Anotações"),
                MainMenuItemType.Finance => await ETranslate!.Translate(TranslateKeyConsts.Titles_FinancePage, "Minhas Finanças"),
                _ => await ETranslate!.Translate(TranslateKeyConsts.Titles_HomePage, "Seja bem vindo ao eTasks"),
            };
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
                    NavigationManager?.GoTasks();
                    break;

                case MainMenuItemType.Goals:
                    NavigationManager?.GoGoals();
                    break;

                case MainMenuItemType.Shopping:
                    NavigationManager?.GoShopping();
                    break;

                case MainMenuItemType.Readings:
                    NavigationManager?.GoReadings();
                    break;

                case MainMenuItemType.Notes:
                    NavigationManager?.GoNotes();
                    break;

                case MainMenuItemType.Finance:
                    NavigationManager?.GoFinances();
                    break;

                default:
                    NavigationManager?.NavigateTo("/");
                    break;
            }

            SelectedMainMenuItem = mainMenuItemType;
            await SetTitleBar();
            MainMenuService?.SetSelected(mainMenuItemType);
        }

        protected async Task OnAvatarMenuItemClick(AvatarMenuItemType avatarMenuItemType)
        {
            await Task.CompletedTask;
            switch (avatarMenuItemType)
            {
                case AvatarMenuItemType.Conquer:

                    break;
                case AvatarMenuItemType.About:
                    GoAbout();
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
