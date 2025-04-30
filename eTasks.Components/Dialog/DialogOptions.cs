using eTasks.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Dialog
{
    public class DialogOptions
    {
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DialogType TipoDeDialogo { get; set; } = DialogType.ConfirmDelete;
        public EventCallback? ConfirmarClick { get; set; }
        public EventCallback? CancelarClick { get; set; }
        public string? Stacktrace { get; set; }

    }
}
