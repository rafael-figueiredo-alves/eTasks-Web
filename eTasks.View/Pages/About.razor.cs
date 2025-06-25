using eTasks.Shared.Extensions;

namespace eTasks.View.Pages
{
    public class AboutBase : PageBase
    {   
        protected string Versao { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Versao = "2.0.0";
        }

        protected void Voltar()
        {
            NavigationManager?.GoHome();
        }
    }
}
