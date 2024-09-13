using eTasks.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTasks.Shared.Services
{
    public class LocalStorage : ILocalStorage
    {
        [Inject] public IJSRuntime? JS { get; set; }

        public LocalStorage(IJSRuntime jsservice)
        {
            JS = jsservice;
        }
        public async Task DeleteValue(string key)
        {
            await JS!.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task<string> GetValue(string key)
        {
            return await JS!.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task SetValue(string key, string value)
        {
            await JS!.InvokeVoidAsync("localStorage.setItem", key, value);
        }
    }
}
