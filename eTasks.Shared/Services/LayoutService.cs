using Microsoft.JSInterop;

public class LayoutService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<LayoutService>? _objRef;
    public event Action<bool>? OnLayoutChanged;
    public bool IsMobileLayout { get; private set; }

    public LayoutService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        _objRef = DotNetObjectReference.Create(this);
        IsMobileLayout = await _jsRuntime.InvokeAsync<bool>("isMobileResolution");

        // Subscribing to window resize events
        await _jsRuntime.InvokeVoidAsync("subscribeToResize", _objRef);
    }

    [JSInvokable]
    public void UpdateLayout(bool isMobile)
    {
        if (IsMobileLayout != isMobile)
        {
            IsMobileLayout = isMobile;
            OnLayoutChanged?.Invoke(isMobile); // Notifica as páginas do layout atualizado
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_objRef != null)
        {
            await _jsRuntime.InvokeVoidAsync("unsubscribeFromResize", _objRef);
            _objRef.Dispose();
        }
    }
}
