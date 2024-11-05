using eTasks.Shared.Extensions;
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
        /// <summary>
        /// Define o título a exibir
        /// </summary>
        protected string Titulo { get; set; } = "UH OH! Você se perdeu.";
        /// <summary>
        /// Define o texto explicativo a mostrar.
        /// </summary>
        protected string TextoExplicativo { get; set; } = "Sentimos muito, mas a página que está buscando não existe. Como você chegou aqui é um mistério. Mas para voltar basta apertar o botão abaixo.";
        /// <summary>
        /// Texto do botão para voltar a página inicial
        /// </summary>
        protected string TextoBotao { get; set; } = "VOLTAR PARA PÁGINA INICIAL";
        #endregion

        #region Métodos e Eventos
        /// <summary>
        /// Método para ir para a página principal do eTasks
        /// </summary>
        protected void GoHome()
        {
            //navigationManager?.NavigateTo((new Uri(navigationManager.BaseUri)).ToString());
            //navigationManager?.NavigateTo(Constants.BaseURL());
            navigationManager?.GoHome();
        }
        #endregion
    }
}
