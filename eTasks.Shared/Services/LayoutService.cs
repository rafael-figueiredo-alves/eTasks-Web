using Microsoft.JSInterop;

namespace eTasks.Shared.Services
{
    public class LayoutService(IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime = jsRuntime;
        private DotNetObjectReference<LayoutService>? _objRef;
        public event Action<bool>? OnLayoutChanged;
        private bool _IsMobileLayout { get; set; }

        public async Task InitializeAsync()
        {
            _objRef = DotNetObjectReference.Create(this);
            _IsMobileLayout = await _jsRuntime.InvokeAsync<bool>("isMobileResolution");

            // Subscribing to window resize events
            await _jsRuntime.InvokeVoidAsync("subscribeToResize", _objRef);
        }

        public async Task<bool?> IsMobileLayout()
        {
            _IsMobileLayout = await _jsRuntime.InvokeAsync<bool>("isMobileResolution");
            return _IsMobileLayout;
        }

        [JSInvokable]
        public void UpdateLayout(bool isMobile)
        {
            if (_IsMobileLayout != isMobile)
            {
                _IsMobileLayout = isMobile;
                OnLayoutChanged?.Invoke(isMobile); // Notifica as páginas do layout atualizado
            }
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (_objRef != null)
            {
                await _jsRuntime.InvokeVoidAsync("unsubscribeFromResize", _objRef);
                _objRef.Dispose();
            }
        }
    }
}