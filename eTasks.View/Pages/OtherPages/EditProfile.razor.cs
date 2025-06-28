using eTasks.Shared.Extensions;

namespace eTasks.View.Pages
{
    public class EditProfileBase : PageBase
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
