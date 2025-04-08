using eTasks.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace eTasks.Shared.Services
{
    /// <summary>
    /// Classe de implementação do Serviço de LocalStorage
    /// </summary>
    /// <param name="JsService">Injeção de serviço de JavaScript</param>
    public class LocalStorage(IJSRuntime JsService) : ILocalStorage
    {
        #region Injeções de Dependência
        [Inject] public IJSRuntime? JS { get; set; } = JsService;
        #endregion

        #region Métodos
        /// <summary>
        /// Método para apagar um valor baseado na chave informada
        /// </summary>
        /// <param name="key">Chave a buscar e apagar</param>
        /// <returns>Nenhum</returns>
        public async Task DeleteValue(string key)
        {
            await JS!.InvokeVoidAsync("localStorage.removeItem", key);
        }

        /// <summary>
        /// Verifica se chave existe no LocalStorage
        /// </summary>
        /// <param name="key">Chave a buscar</param>
        /// <returns>Verdadeiro se chave for encontrada</returns>
        public async Task<bool> KeyExists(string key)
        {
            string? Value = await GetValue(key);
            return !string.IsNullOrEmpty(Value);
        }

        #region Métodos para ler valores salvos
        /// <summary>
        /// Lê valor tipo string contido na chave do localstorage
        /// </summary>
        /// <param name="key">Chave a consultar</param>
        /// <returns>Valor em formato de texto (string)</returns>
        public async Task<string?> GetValue(string key)
        {
            return await JS!.InvokeAsync<string?>("localStorage.getItem", key);
        }

        /// <summary>
        /// Lê valor tipo T (objeto) contido na chave do localstorage
        /// </summary>
        /// <typeparam name="T">Tipo a retornar (conversão em objeto)</typeparam>
        /// <param name="key">Chave a consultar</param>
        /// <returns>Valor em formato T (objeto)</returns>
        public async Task<T?> GetValue<T>(string key)
        {
            string? value = await GetValue(key);

            if (string.IsNullOrEmpty(value))
                return default(T?);

            // Se T é string, retorna o valor diretamente como T
            if (typeof(T) == typeof(string))
                return (T)(object)value;

            // Para outros tipos, usa a desserialização JSON
            return JsonSerializer.Deserialize<T>(value);
        }
        #endregion

        #region Métodos para Guardar dados
        /// <summary>
        /// Grave um valor string no local storage
        /// </summary>
        /// <param name="key">Chave que guardará valor</param>
        /// <param name="value">Valor em formato string</param>
        /// <returns>Nenhum retorno</returns>
        public async Task SetValue(string key, string value)
        {
            await JS!.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        /// <summary>
        /// Grave um valor tipo qualquer (objeto) no local storage
        /// </summary>
        /// <typeparam name="T">Tipo a salvar (objeto)</typeparam>
        /// <param name="key">Chave que guardará valor</param>
        /// <param name="value">Valor em formato T</param>
        /// <returns>Nenhum</returns>
        public async Task SetValue<T>(string key, T value)
        {
            string StringValue = JsonSerializer.Serialize<T>(value);
            await SetValue(key, StringValue);
        }
        #endregion
        #endregion
    }
}
