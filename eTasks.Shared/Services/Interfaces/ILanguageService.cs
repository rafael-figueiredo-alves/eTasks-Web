namespace eTasks.Shared.Services.Interfaces
{
    public interface ILanguageService
    {
        public Task<string> GetLanguage();
        public Task<ILanguageService> SetLanguage(string language);
        public event Func<string, Task>? OnLanguageChanged;
    }
}
