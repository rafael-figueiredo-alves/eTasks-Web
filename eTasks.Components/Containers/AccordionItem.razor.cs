﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.Containers
{
    public class AccordionItemBase : ComponentBase
    {
        #region Injeção de serviços
        [Inject] public IJSRuntime? JSRuntime { get; set; }
        #endregion

        #region Parâmetros
        [CascadingParameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public bool Expanded { get; set; } = false;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string ID { get; set; } = $"AccordionItem_{Guid.NewGuid().ToString()}";
        [Parameter] public string? BodyHeight { get; set; } = null;
        [Parameter] public string Title { get; set; } = string.Empty;
        #endregion

        #region Variáveis
        protected string imagemSeta { get; set; } = "/assets/UI/dialogs/light/DetailsBtn.png";
        #endregion

        #region Métodos
        protected override void OnParametersSet()
        {
            imagemSeta = $"assets/UI/dialogs/{(IsDarkMode ? "dark" : "light")}/DetailsBtn.png";
        }

        public async Task CloseAccordionItem()
        {
            if(JSRuntime != null)
                await JSRuntime.InvokeVoidAsync("CloseAccordionItem", ID);
        }
        #endregion
    }
}
