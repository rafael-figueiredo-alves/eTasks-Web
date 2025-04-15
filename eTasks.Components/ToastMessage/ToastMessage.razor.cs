using eTasks.Components.Enums;
using eTasks.Components.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Components.ToastMessage
{
    public class ToastMessageBase : ComponentBase, IDisposable
    {
        [Inject] protected IToastService? ToastService { get; set; }
        [Inject] protected IJSRuntime? JSRuntime { get; set; }

        protected string Message { get; set; } = string.Empty;
        protected ToastType Type { get; set; } = ToastType.Success;
        protected bool IsVisible { get; set; } = false;
        protected bool _isFadingOut { get; set; } = false;
        protected System.Timers.Timer? _timer;

        protected override void OnInitialized()
        {
            if(ToastService != null)
            {
                ToastService.OnShow += ShowToast;
                ToastService.OnHide += HideToast;

                _timer = new Timer(5000); // 5 seconds
                _timer.Elapsed += async (sender, e) => await OnTimerElapsed();
                _timer.AutoReset = false;
            }
        }

        protected void ShowToast(string message, ToastType type)
        {
            Message = message;
            Type = type;
            _isFadingOut = false;
            IsVisible = true;
            StateHasChanged();

            // Start the timer for auto-hide
            _timer?.Stop();
            _timer?.Start();
        }

        protected async Task HideToast()
        {
            _timer?.Stop();
            _isFadingOut = true;
            IsVisible = false;
            StateHasChanged();

            // Wait for the fade-out animation to complete (300ms)
            await Task.Delay(300);
            _isFadingOut = false;
            StateHasChanged();
        }

        private async Task OnTimerElapsed()
        {
            await HideToast();
        }

        public void Dispose()
        {
            if(ToastService != null)
            {
                ToastService.OnShow -= ShowToast;
                ToastService.OnHide -= HideToast;
                _timer?.Dispose();
            }
        }
    }
}
