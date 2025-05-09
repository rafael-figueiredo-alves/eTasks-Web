using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Containers
{
    public class AccordionItemBase : ComponentBase
    {
        [CascadingParameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public bool Expanded { get; set; } = false;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string ID { get; set; } = $"AccordionItem_{Guid.NewGuid().ToString()}";
        [Parameter] public string? BodyHeight { get; set; } = null;
        [Parameter] public string Title { get; set; } = string.Empty;

        protected string imagemSeta { get; set; } = "/assets/UI/dialogs/light/DetailsBtn.png";

        protected override void OnParametersSet()
        {
            imagemSeta = $"assets/UI/dialogs/{(IsDarkMode ? "dark" : "light")}/DetailsBtn.png";
        }
    }
}
