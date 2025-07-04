﻿using eTasks.Components.Containers;
using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.Dialog
{
    public class ModalDialogBase : ComponentBase, IAsyncDisposable
    {
        #region Serviços Injetados
        [Inject] protected IJSRuntime? JSRuntime {  get; set; }
        [Inject] protected IDialogService? DialogService { get; set; }
        [Inject] protected IToastService? ToastService { get; set; }
        #endregion

        #region Parâmetros
        [Parameter] public bool IsDarkMode { get; set; } = false;
        [Parameter] public Dictionary<DialogTextsEnum, string>? DialogTextsDict { get; set; }
        #endregion

        #region Variáveis
        protected string? ModalId { get; set; } = $"modal-{Guid.NewGuid()}";
        protected string basePath { get; set; } = "assets/UI/dialogs/";
        protected string basePathWithMode { get; set; } = "assets/UI/dialogs/light/";
        protected string DialogIcon { get; set; } = "assets/UI/dialogs/light/DeleteIcon.png";

        protected string Titulo { get; set; } = "EXCLUIR TAREFA?";
        protected string Mensagem { get; set; } = "Tem certeza que deseja mesmo excluir a tarefa selecionada ?";
        protected string? MaisDetalhes { get; set; } = null;
        protected bool DetalhesExpanded { get; set; } = false;
        protected DialogType? DialogType { get; set; } = Enums.DialogType.ConfirmDelete;

        protected EventCallback? OnConfirmClicked { get; set; }
        protected EventCallback? OnCancelClicked { get; set; }
        protected DotNetObjectReference<ModalDialogBase>? objRef;
        protected AccordionItem? ErrorDetailItem { get; set; }
        #endregion

        #region Métodos
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
            DetalhesExpanded = false;
            DialogType = dialogOptions.TipoDeDialogo;
            GetDialogIcon();

            Titulo = dialogOptions.Titulo;
            Mensagem = dialogOptions.Mensagem;
            OnConfirmClicked = dialogOptions.ConfirmarClick;
            OnCancelClicked = dialogOptions.CancelarClick;
            MaisDetalhes = dialogOptions.Stacktrace;

            if(ErrorDetailItem != null)
                await ErrorDetailItem.CloseAccordionItem();

            StateHasChanged();

            await JSRuntime!.InvokeVoidAsync("mostrarModal", ModalId);

            objRef = DotNetObjectReference.Create(this);
            await JSRuntime!.InvokeVoidAsync("modalInterop.pushStateForModal", objRef);
        }

        public async Task HideModal()
        {
            await JSRuntime!.InvokeVoidAsync("fecharModal", ModalId);

            await JSRuntime!.InvokeVoidAsync("modalInterop.popState");
        }

        protected async Task OnConfirmButtonClick()
        {
            if (OnConfirmClicked.HasValue)
                await OnConfirmClicked.Value.InvokeAsync();

            await HideModal();
        }

        protected async Task OnCancelButtonClick()
        {
            if (OnCancelClicked.HasValue)
                await OnCancelClicked.Value.InvokeAsync();

            await HideModal();
        }

        protected async Task OnCopyButtonClick()
        {
            var TextoACopiar = $"{Mensagem}\n{MaisDetalhes}";
            var retorno = await JSRuntime!.InvokeAsync<bool>("copyToClipboard", TextoACopiar);
            if (retorno == true)
                ToastService!.ShowSuccess(GetDialogText(DialogTextsEnum.CopySuccessMsg));
            else
                ToastService!.ShowError(GetDialogText(DialogTextsEnum.CopyErrorMsg));
        }

        protected string GetDialogText(DialogTextsEnum text)
        {
            if (DialogTextsDict == null)
                return DefaultDialogText(text);
            return DialogTextsDict[text];
        }

        protected string DefaultDialogText(DialogTextsEnum text)
        {
            var TextToReturn = string.Empty;

            switch (text)
            {
                case DialogTextsEnum.MoreDetails:
                    TextToReturn = "Mais Detalhes";
                    break;
                case DialogTextsEnum.CopyErrorMsg:
                    TextToReturn = "Não foi possível copiar erro!";
                    break;
                case DialogTextsEnum.CopySuccessMsg:
                    TextToReturn = "Msg. de Erro copiada com sucesso!";
                    break;
                case DialogTextsEnum.CancelButton:
                    TextToReturn = "Cancelar";
                    break;
                case DialogTextsEnum.OkButton:
                    TextToReturn = "Confirmar";
                    break;
                case DialogTextsEnum.CopyButton:
                    TextToReturn = "Copiar";
                    break;
            }

            return TextToReturn;
        }

        [JSInvokable]
        public async Task OnBrowserBack()
        {
            if (DialogType == Enums.DialogType.Error)
                await OnConfirmButtonClick();
            else
                await OnCancelButtonClick(); // Fechar como se tivesse clicado em "cancelar"
        }

        public async ValueTask DisposeAsync()
        {
            if (DialogService != null)
            {
                DialogService.OnShow -= ShowDialog;
                DialogService.OnHide -= HideModal;
            }

            if (objRef != null)
            {
                objRef.Dispose();
                await JSRuntime!.InvokeVoidAsync("modalInterop.clear");
            }
        }
        #endregion
    }
}
