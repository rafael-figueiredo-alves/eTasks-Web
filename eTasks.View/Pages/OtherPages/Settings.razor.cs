using eTasks.Shared.Extensions;

namespace eTasks.View.Pages
{
    public class SettingsBase : PageBase
    {   
        protected string Versao { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected void Voltar()
        {
            NavigationManager?.GoBack();
        }
    }
}
