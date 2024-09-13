namespace eTasks.Shared.Services.Interfaces
{
    public interface ILocalStorage
    {
        public Task<string> GetValue(string key);
        public Task SetValue(string key, string value);
        public Task DeleteValue(string key);
    }
}
