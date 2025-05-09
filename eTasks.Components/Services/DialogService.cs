using eTasks.Components.Dialog;
using eTasks.Components.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Services
{
    public class DialogService : IDialogService
    {
        public event Func<DialogOptions, Task>? OnShow;
        public event Func<Task>? OnHide;

        private async Task ShowDialog(DialogOptions dialogOptions)
        {
            if (OnShow != null)
            {
                await OnShow.Invoke(dialogOptions);
            }
        }

        public async Task ConfirmDelete(string Title, string Message, EventCallback? OnConfirm, EventCallback? OnCancel)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message,
                TipoDeDialogo = Enums.DialogType.ConfirmDelete,
                ConfirmarClick = OnConfirm,
                CancelarClick = OnCancel
            });
        }
        public async Task Confirm(string Title, string Message, EventCallback? OnConfirm, EventCallback? OnCancel)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message,
                TipoDeDialogo = Enums.DialogType.Confirm,
                ConfirmarClick = OnConfirm,
                CancelarClick = OnCancel
            });
        }
        public async Task ShowInfo(string Title, string Message, EventCallback? OnConfirm)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message,
                TipoDeDialogo = Enums.DialogType.Information,
                ConfirmarClick = OnConfirm
            });
        }
        public async Task Warn(string Title, string Message, EventCallback? OnConfirm)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message,
                TipoDeDialogo = Enums.DialogType.Warning,
                ConfirmarClick = OnConfirm
            });
        }
        public async Task ShowError(string Title, string Message, EventCallback? OnConfirm)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message,
                TipoDeDialogo = Enums.DialogType.Error,
                ConfirmarClick = OnConfirm
            });
        }
        public async Task ShowError(string Title, Exception Message, EventCallback? OnConfirm)
        {
            await ShowDialog(new DialogOptions
            {
                Titulo = Title,
                Mensagem = Message.Message,
                TipoDeDialogo = Enums.DialogType.Error,
                ConfirmarClick = OnConfirm,
                Stacktrace = Message.StackTrace
            });
        }

        public async Task Hide()
        {
            if(OnHide != null) 
                await OnHide.Invoke();
        }
    }
}
