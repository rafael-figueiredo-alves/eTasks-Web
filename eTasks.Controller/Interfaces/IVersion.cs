namespace eTasks.Controller.Interfaces
{
    public interface IVersion
    {
        /// <summary>
        /// Verifica se existe uma versão nova disponível e retorna verdadeiro se existir e o DisplayVersion
        /// </summary>
        /// <returns>Tupla - se tem update e qual é a versão</returns>
        public Task<(bool, string)> IsUpdateAvailable();
    }
}
