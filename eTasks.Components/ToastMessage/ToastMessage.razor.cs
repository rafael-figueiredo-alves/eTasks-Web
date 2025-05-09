using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.ToastMessage
{
    public class ToastMessageBase : ComponentBase, IDisposable
    {
        #region Serviços
        [Inject] protected IToastService? ToastService { get; set; }
        [Inject] protected IJSRuntime? JSRuntime { get; set; }
        #endregion

        #region Parâmetros
        [Parameter]
        public int ShowingTime { get; set; } = 3000;
        #endregion

        #region Variáveis
        protected string Message { get; set; } = string.Empty;
        protected ToastType Type { get; set; } = ToastType.Success;
        protected bool IsVisible { get; set; } = false;
        protected bool _isTimerRunning { get; set; } = false;
        #endregion

        #region Métodos
        protected override void OnInitialized()
        {
            if(ToastService != null)
            {
                ToastService.OnShow += ShowToast;
                ToastService.OnHide += HideToast;
            }
        }

        protected async void ShowToast(string message, ToastType type)
        {
            Message = message;
            Type = type;
            IsVisible = true; 
            StateHasChanged();

            // Start the timer for auto-hide
            if (!_isTimerRunning)
            {
                _isTimerRunning = true;
                await Task.Delay(ShowingTime); // 5 seconds
                if (_isTimerRunning)
                {
                    await HideToast();
                }
            }
        }

        protected async Task HideToast()
        {
            _isTimerRunning = false;
            IsVisible = false; // This triggers the fade-out
            StateHasChanged();

            // Wait for the fade-out animation to complete (300ms)
            await Task.Delay(300);
        }

        public void Dispose()
        {
            if(ToastService != null)
            {
                ToastService.OnShow -= ShowToast;
                ToastService.OnHide -= HideToast;
            }
        }
        #endregion
    }
}
