using eTasks.Components.Enums;

namespace eTasks.Components.Services.Interfaces
{
    public interface IToastService
    {
        event Action<string, ToastType>? OnShow;
        event Func<Task>? OnHide;
        void ShowSuccess(string message);
        void ShowError(string message);
        Task Hide();
    }
}
