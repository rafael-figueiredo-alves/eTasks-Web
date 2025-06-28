using eTasks.Shared.Extensions;

namespace eTasks.View.Pages
{
    public class ConquersBase : PageBase
    {   
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
