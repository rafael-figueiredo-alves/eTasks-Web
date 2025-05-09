using eTasks.Components.Menus;
using eTasks.Components.Services.Interfaces;
using eTasks.Shared.Extensions;
using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace eTasks.View.Layouts
{
    public class MainLayoutBase : LayoutsBase
    {
        #region Serviços
        [Inject] public MenuTeste? MenuTeste { get; set; }
        [Inject] public IDialogService? DialogService { get; set; }
        #endregion

        #region Variáveis
        protected string Title { get; set; } = "Minhas Tarefas";
        protected string Dica { get; set; } = "Tema escuro";
        protected MainMenuItemType SelectedMainMenuItem { get; set; }
        #endregion

        #region Métodos
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
            Console.WriteLine(languageCode);
        }

        protected async Task TesteClick()
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

        protected async Task OnMainMenuItemClick(MainMenuItemType mainMenuItemType)
        {
            await Task.CompletedTask;
            switch (mainMenuItemType)
            {
                case MainMenuItemType.Home:
                    Title = "Visão geral";
                    NavigationManager?.GoHome();
                    break;
                case MainMenuItemType.Tasks:
                    Title = "Minhas Tarefas";
                    Console.WriteLine("Tarefas");
                    break;
                case MainMenuItemType.Goals:
                    Title = "Minhas metas";
                    Console.WriteLine("Metas");
                    break;
                case MainMenuItemType.Shopping:
                    Title = "Listas de Compras";
                    Console.WriteLine("Compras");
                    break;
                case MainMenuItemType.Readings:
                    Title = "Minhas Leituras";
                    Console.WriteLine("Leituras");
                    break;
                case MainMenuItemType.Notes:
                    Title = "Minhas anotações";
                    Console.WriteLine("Anotações");
                    break;
                case MainMenuItemType.Finance:
                    Title = "Gerenciamento de Finanças";
                    Console.WriteLine("Finanças");
                    break;
                default:
                    Title = "Visão geral";
                    NavigationManager?.NavigateTo("/");
                    break;
            }

            //SelectedMainMenuItem = mainMenuItemType;
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
                    await TesteClick();
                    break;
                default:
                    NavigationManager?.NavigateTo("/");
                    break;
            }
        }
        #endregion
    }
}
