using eTasks.Components.Enums;

namespace eTasks.Components.Dialog
{
    public class DialogOptions
    {
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DialogType TipoDeDialogo { get; set; } = DialogType.ConfirmDelete;

    }
}
