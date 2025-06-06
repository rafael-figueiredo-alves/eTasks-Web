namespace eTasks.Shared.Services.Interfaces
{
    public interface IThemeService
    {
        /// <summary>
        /// Evento acionado ao mudar o tema da aplicação
        /// </summary>
        public event Func<Task>? OnThemeChanged;

        /// <summary>
        /// Verifica se está usando o tema escuro
        /// </summary>
        /// <returns></returns>
        public Task<bool> IsDarkTheme();

        /// <summary>
        /// Define o tema da aplicação
        /// </summary>
        /// <param name="isDark">Informa se é ou não escuro</param>
        /// <returns>`Próprio serviço</returns>
        public Task<IThemeService> SetTheme(bool isDark);

        /// <summary>
        /// Troca o tema de claro para escuro ou de escuro para claro
        /// </summary>
        /// <returns>Próprio serviço</returns>
        public Task<IThemeService> ChangeTheme();
    }
}
