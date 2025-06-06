namespace eTasks.Shared.Services.Interfaces
{
    public interface ILanguageService
    {
        /// <summary>
        /// Retorna a língua/idioma atual
        /// </summary>
        /// <returns>Retorna a língua/idioma atual</returns>
        public Task<string> GetLanguage();

        /// <summary>
        /// Define a língua/idioma a usar
        /// </summary>
        /// <param name="language">língua/idioma</param>
        /// <returns>O próprio serviço</returns>
        public Task<ILanguageService> SetLanguage(string language);

        /// <summary>
        /// Método acionado ao mudar a língua/idioma atual
        /// </summary>
        public event Func<string, Task>? OnLanguageChanged;
    }
}
