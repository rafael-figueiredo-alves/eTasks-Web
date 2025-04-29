using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.Dialog
{
    public class ModalDialogBase : ComponentBase
    {
        [Inject] protected IJSRuntime? JSRuntime {  get; set; }

        protected string? ModalId { get; set; } = $"modal-{Guid.NewGuid()}"; 

        public async Task OpenDialog()
        {
            await JSRuntime!.InvokeVoidAsync("mostrarModal", ModalId);
        }

        public async Task CloseModal()
        {
            await JSRuntime!.InvokeVoidAsync("fecharModal", ModalId);
        }

        protected void EscreveMsg()
        {
            Console.WriteLine("Clicou em SALVAR");
        }
    }
}
