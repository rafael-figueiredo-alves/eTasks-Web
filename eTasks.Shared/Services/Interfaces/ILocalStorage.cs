namespace eTasks.Shared.Services.Interfaces
{
    public interface ILocalStorage
    {
        /// <summary>
        /// Lê valor tipo string contido na chave do localstorage
        /// </summary>
        /// <param name="key">Chave a consultar</param>
        /// <returns>Valor em formato de texto (string)</returns>
        public Task<string?> GetValue(string key);

        /// <summary>
        /// Lê valor tipo T (objeto) contido na chave do localstorage
        /// </summary>
        /// <typeparam name="T">Tipo a retornar (conversão em objeto)</typeparam>
        /// <param name="key">Chave a consultar</param>
        /// <returns>Valor em formato T (objeto)</returns>
        public Task<T?> GetValue<T>(string key);

        /// <summary>
        /// Grave um valor string no local storage
        /// </summary>
        /// <param name="key">Chave que guardará valor</param>
        /// <param name="value">Valor em formato string</param>
        /// <returns>Nenhum retorno</returns>
        public Task SetValue(string key, string value);

        /// <summary>
        /// Grave um valor tipo qualquer (objeto) no local storage
        /// </summary>
        /// <typeparam name="T">Tipo a salvar (objeto)</typeparam>
        /// <param name="key">Chave que guardará valor</param>
        /// <param name="value">Valor em formato T</param>
        /// <returns>Nenhum</returns>
        public Task SetValue<T>(string key, T value);
        
        /// <summary>
        /// Método para apagar um valor baseado na chave informada
        /// </summary>
        /// <param name="key">Chave a buscar e apagar</param>
        /// <returns>Nenhum</returns>
        public Task DeleteValue(string key);

        /// <summary>
        /// Verifica se chave existe no LocalStorage
        /// </summary>
        /// <param name="key">Chave a buscar</param>
        /// <returns>Verdadeiro se chave for encontrada</returns>
        public Task<bool> KeyExists(string key);
    }
}
