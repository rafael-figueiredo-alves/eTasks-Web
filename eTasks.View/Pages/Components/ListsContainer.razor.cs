using eTasks.Components.Menus;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages.Components
{
    public class ListsContainerBase : ComponentBase
    {
        [Parameter] public MainMenuItemType SelectedMenuItem { get; set; } = MainMenuItemType.Home;
    }
}
