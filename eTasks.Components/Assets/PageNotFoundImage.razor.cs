using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Assets
{
    /// <summary>
    /// Classe de implementação do Componente
    /// </summary>
    public class PageNotFoundImageBase : ComponentBase
    {
        /// <summary>
        /// Cor da linha
        /// </summary>
        [Parameter]
        public string LineStroke { get; set; } = "#0E0620";

        /// <summary>
        /// Cor de preenchimento da imagem
        /// </summary>
        [Parameter]
        public string ImageFill { get; set; } = "#FFFFFF";
    }
}
