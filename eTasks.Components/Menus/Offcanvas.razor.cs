using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Menus
{
    public class OffcanvasBase : ComponentBase
    {
        public enum DirecaoOffCanvas
        {
            Esquerda, direita
        }

        public enum PosicaoOffCanvas
        {
            Esquerda,
            Direita,
            Topo,
            Inferior
        }

        [Parameter] public PosicaoOffCanvas Posicao { get; set; } = PosicaoOffCanvas.Direita;
        [Parameter] public string OffcanvasID { get; set; } = string.Empty;
        [Parameter] public DirecaoOffCanvas direcaoOffCanvas { get; set; } = Offcanvas.DirecaoOffCanvas.direita;
        [Parameter] public bool EOffcanvasPerfil { get; set; } = false;
        [Parameter] public bool isDarkMode { get; set; } = false;
        [Parameter] public RenderFragment? ChildContent { get; set; }


        protected string borderRadius = "0px 25px 25px 0px";
        protected string Position { get; set; } = "offcanvas-end";
        protected string Width { get; set; } = "350px";
        protected string Shadow { get; set; } = "-4px 2px 4px rgba(0, 0, 0, 0.2)"; 

        protected override void OnParametersSet()
        {
            if (direcaoOffCanvas == DirecaoOffCanvas.Esquerda)
            {
                if (EOffcanvasPerfil)
                {
                    borderRadius = "0px 60px 0px 0px";
                }
                else
                {
                    borderRadius = "0px 25px 25px 0px";
                }
            }
            else
            {
                if (EOffcanvasPerfil)
                {
                    borderRadius = "60px 0px 0px 0px";
                }
                else
                {
                    borderRadius = "25px 0px 0px 25px";
                }
            }

            switch (Posicao)
            {
                case PosicaoOffCanvas.Esquerda:
                    Position = "offcanvas-start";
                    Width = "350px";
                    break;
                case PosicaoOffCanvas.Direita:
                    Position = "offcanvas-end";
                    Width = "350px";
                    break;
                case PosicaoOffCanvas.Topo:
                    Position = "offcanvas-top";
                    Width = "100%";
                    break;
                case PosicaoOffCanvas.Inferior:
                    Position = "offcanvas-bottom";
                    Width = "100%";
                    break;
                default:
                    Position = "offcanvas-start";
                    break;
            }

            if (direcaoOffCanvas == DirecaoOffCanvas.Esquerda)
            {
                Shadow = isDarkMode ? "4px 2px 4px rgba(100,100,100,0.1)" : "4px 2px 4px rgba(0, 0, 0, 0.2)";
            }
            else
            {
                Shadow = isDarkMode ? "-4px 2px 4px rgba(100,100,100,0.1)" : "-4px 2px 4px rgba(0, 0, 0, 0.2)";
            }
        }
    }
}
