using eTasks.Shared.Services.Interfaces;

namespace eTasks.Shared.Services
{
    public class LanguageService(LocalStorage localStorage) : ILanguageService
    {
        #region Constante e Variáveis privadas
        const string LanguageStorageKey = "UILanguage";

        private string? _Language = "pt-BR";
        #endregion
        
        #region Métodos
        private async Task CallOnLanguageChangedEvent()
        {
            if (OnLanguageChanged != null)
            {
                await OnLanguageChanged.Invoke(_Language ?? "pt-BR");
            }
        }

        public event Func<string, Task>? OnLanguageChanged = null;

        public async Task<string> GetLanguage()
        {
            if (!await localStorage.KeyExists(LanguageStorageKey))
                await localStorage.SetValue(LanguageStorageKey, _Language ?? "pt-BR");

            _Language = await localStorage.GetValue<string>(LanguageStorageKey);

            return _Language ?? "pt-BR";
        }

        public async Task<ILanguageService> SetLanguage(string language)
        {
            _Language = language;

            await localStorage.SetValue(LanguageStorageKey, _Language);

            await CallOnLanguageChangedEvent();

            return this;
        }
        #endregion
    }
}
