using eTasks.Shared.Services.Interfaces;

namespace eTasks.Shared.Services
{
    public class LanguageService : ILanguageService
    {
        #region Constante e Variáveis privadas
        const string LanguageStorageKey = "UILanguage";

        private string? _Language = "pt-BR";

        private LocalStorage LocalStorage { get; set; }
        #endregion

        #region Métodos
        public LanguageService(LocalStorage localStorage)
        {
            LocalStorage = localStorage;
        }

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
            if (!await LocalStorage.KeyExists(LanguageStorageKey))
                await LocalStorage.SetValue(LanguageStorageKey, _Language ?? "pt-BR");

            _Language = await LocalStorage.GetValue<string>(LanguageStorageKey);

            return _Language ?? "pt-BR";
        }

        public async Task<ILanguageService> SetLanguage(string language)
        {
            _Language = language;

            await LocalStorage.SetValue(LanguageStorageKey, _Language);

            await CallOnLanguageChangedEvent();

            return this;
        }
        #endregion
    }
}
