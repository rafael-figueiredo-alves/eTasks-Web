using eTasks.Components.Dialog;
using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Services.Interfaces
{
    public interface IDialogService
    {
        event Func<DialogOptions, Task>? OnShow;
        event Func<Task>? OnHide;

        Task ConfirmDelete(string Title, string Message, EventCallback? OnConfirm = null, EventCallback? OnCancel = null);
        Task Confirm(string Title, string Message, EventCallback? OnConfirm = null, EventCallback? OnCancel = null);
        Task ShowInfo(string Title, string Message, EventCallback? OnConfirm = null);
        Task Warn(string Title, string Message, EventCallback? OnConfirm = null);
        Task ShowError(string Title, string Message, EventCallback? OnConfirm = null);
        Task ShowError(string Title, Exception Message, EventCallback? OnConfirm = null);

        Task Hide();
    }
}
