using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    /// <summary>
    /// Implementação de código da página não encontrada
    /// </summary>
    public class PageNotFoundBase : ComponentBase
    {
        #region Injeções de Dependência
        /// <summary>
        /// Serviço de navegação
        /// </summary>
        [Inject] protected NavigationManager? navigationManager { get; set; }
        #endregion

        #region Váriaveis Para setar cores na página
        /// <summary>
        /// Cor de fundo da imagem e da página
        /// </summary>
        protected string Background { get; set; } = "";
        /// <summary>
        /// Cor das linhas da imagem
        /// </summary>
        protected string LineStroke { get; set; } = "#0E0620";
        /// <summary>
        /// Preenchimento da imagem
        /// </summary>
        protected string ImageFill { get; set; } = "#FFFFFF";
        /// <summary>
        /// Cor do texto da página
        /// </summary>
        protected string TextColor { get; set; } = "black";
        #endregion

        #region Métodos e Eventos
        /// <summary>
        /// Método para ir para a página principal do eTasks
        /// </summary>
        protected void GoHome()
        {
            navigationManager?.NavigateTo((new Uri(navigationManager.BaseUri)).ToString());
        }
        #endregion
    }
}
