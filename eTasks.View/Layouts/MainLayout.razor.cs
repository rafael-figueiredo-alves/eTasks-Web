using eTasks.Components.Menus;
using eTasks.Shared.Extensions;
using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.View.Layouts
{
    public class MainLayoutBase : LayoutsBase
    {
        #region Serviços
        [Inject] public MenuTeste? menuTeste { get; set; }
        #endregion

        #region Variáveis
        protected string Title { get; set; } = "Minhas Tarefas";
        protected string Dica { get; set; } = "Tema escuro";
        protected string Idioma { get; set; } = "en-US";
        protected MainMenuItemType SelectedMainMenuItem { get; set; }
        #endregion

        #region Métodos
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                menuTeste?.SetSelected((int)MainMenuItemType.Tasks);
                Idioma = "pt-BR";
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
            Idioma = languageCode;
            Console.WriteLine(languageCode);
        }

        protected void TesteClick()
        {
            ThemeService?.ChangeTheme();
            ThemeChange = ThemeService?.IsDarkTheme() ?? false;
            ChangeTheme();
        }

        protected void GoGoogle()
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
            menuTeste?.SetSelected((int)mainMenuItemType);
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
                    TesteClick();
                    break;
                default:
                    NavigationManager?.NavigateTo("/");
                    break;
            }
        }
        #endregion
    }
}
