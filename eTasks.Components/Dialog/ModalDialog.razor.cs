using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.Dialog
{
    public class ModalDialogBase : ComponentBase, IDisposable
    {
        #region Serviços Injetados
        [Inject] protected IJSRuntime? JSRuntime {  get; set; }
        [Inject] protected IDialogService? DialogService { get; set; }
        #endregion

        #region Parâmetros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        #endregion

        #region Variáveis
        protected string? ModalId { get; set; } = $"modal-{Guid.NewGuid()}";
        protected string basePath { get; set; } = "assets/UI/dialogs/";
        protected string basePathWithMode { get; set; } = "assets/UI/dialogs/light/";
        protected string DialogIcon { get; set; } = "assets/UI/dialogs/light/DeleteIcon.png";

        protected string Titulo { get; set; } = "EXCLUIR TAREFA?";
        protected string Mensagem { get; set; } = "Tem certeza que deseja mesmo excluir a tarefa selecionada ?";
        protected DialogType? DialogType { get; set; } = Enums.DialogType.ConfirmDelete;

        protected EventCallback? OnConfirmClicked { get; set; }
        protected EventCallback? OnCancelClicked { get; set; }
        #endregion

        protected override void OnInitialized()
        {
            if(DialogService != null)
            {
                DialogService.OnShow += ShowDialog;
                DialogService.OnHide += HideModal;
            }
        }

        protected override void OnParametersSet()
        {
            if (IsDarkMode)
                basePathWithMode = basePath + "dark/";
            else
                basePathWithMode = basePath + "light/";
        }

        private void GetDialogIcon()
        {
            switch (DialogType)
            {
                case Enums.DialogType.ConfirmDelete:
                    DialogIcon = $"{basePathWithMode}DeleteIcon.png";
                    break;
                case Enums.DialogType.Confirm:
                    DialogIcon = $"{basePathWithMode}ConfirmIcon.png";
                    break;
                case Enums.DialogType.Information:
                    DialogIcon = $"{basePathWithMode}InfoIcon.png";
                    break;
                case Enums.DialogType.Warning:
                    DialogIcon = $"{basePathWithMode}WarningIcon.png";
                    break;
                case Enums.DialogType.Error:
                    DialogIcon = $"{basePathWithMode}ErrorIcon.png";
                    break;
                default:
                    DialogIcon = $"{basePathWithMode}DeleteIcon.png";
                    break;
            }
        }

        public async Task ShowDialog(DialogOptions dialogOptions)
        {
            DialogType = dialogOptions.TipoDeDialogo;
            GetDialogIcon();

            Titulo = dialogOptions.Titulo;
            Mensagem = dialogOptions.Mensagem;
            OnConfirmClicked = OnConfirmClicked;
            OnCancelClicked = OnCancelClicked;

            StateHasChanged();

            await JSRuntime!.InvokeVoidAsync("mostrarModal", ModalId);
        }

        public async Task HideModal()
        {
            await JSRuntime!.InvokeVoidAsync("fecharModal", ModalId);
        }

        protected async Task EscreveMsg()
        {
            if (OnConfirmClicked.HasValue)
                await OnConfirmClicked.Value.InvokeAsync();
        }

        public void Dispose()
        {
            if (DialogService != null)
            {
                DialogService.OnShow -= ShowDialog;
                DialogService.OnHide -= HideModal;
            }
        }
    }
}
