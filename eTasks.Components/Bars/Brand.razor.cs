using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class BrandBase : ComponentBase
    {
        #region Injeções de Dependência
        /// <summary>
        /// Serviço de navegação
        /// </summary>
        [Inject] protected NavigationManager? navigationManager { get; set; }
        #endregion

        #region Parâmetros
        [Parameter] public string AppName { get; set; } = "eTasks";
        [Parameter] public string ColorAppName { get; set; } = "#336699";
        [Parameter] public string LogoPath { get; set; } = "/assets/favicon.png";
        #endregion

        #region Variáveis
        public string ImagemLogo
        {
            get
            {
                var path = "";
                if (LogoPath.StartsWith("/"))
                    path = navigationManager?.BaseUri.TrimEnd('/') + LogoPath;
                else
                    if(navigationManager!.BaseUri.EndsWith('/'))
                        path = navigationManager?.BaseUri + LogoPath;
                    else
                        path = navigationManager?.BaseUri + "/" + LogoPath;
                return  path;
            }
        }
        #endregion
    }
}
