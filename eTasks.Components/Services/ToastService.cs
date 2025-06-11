using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;

namespace eTasks.Components.Services
{
    public class ToastService : IToastService
    {
        public event Action<string, ToastType>? OnShow;
        public event Func<Task>? OnHide;

        #region Métodos
        public void ShowSuccess(string message)
        {
            OnShow?.Invoke(message, ToastType.Success);
        }

        public void ShowError(string message)
        {
            OnShow?.Invoke(message, ToastType.Error);
        }

        public async Task Hide()
        {
            await OnHide?.Invoke()!;
        }
        #endregion
    }
}
