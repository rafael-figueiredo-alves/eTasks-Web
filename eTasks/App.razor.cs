using eTasks.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace eTasks
{
    public class AppBase : ComponentBase
    {
        [Inject] protected LayoutService? LayoutService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(LayoutService != null)
                await LayoutService.InitializeAsync();
        }
    }
}
