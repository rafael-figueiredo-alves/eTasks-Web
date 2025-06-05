using eTasks.Components.Services;
using eTasks.Components.Services.Interfaces;
using eTasks.Shared.Extensions;
using eTranslate.Interfaces;
using Microsoft.AspNetCore.Components;

namespace eTasks.View.Pages
{
    public class AboutBase : PageBase
    {
        [Inject] protected IDialogService? DialogService { get; set; }
        [Inject] protected IeTranslate? IeTranslate { get; set; }

        protected string Versao { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Versao = "2.0.0";
        }

        protected void Voltar()
        {
            NavigationManager?.GoHome();
        }

        protected async Task TesteMsg()
        {
            await DialogService!.ShowInfo("Fica a Dica", "Testando caixas de mensagem no sistema inteiro", null);
        }

        protected async Task DelMsg()
        {
            await DialogService!.ConfirmDelete("Deletar", await IeTranslate!.Translate("Teste", "Desejas apagar este arquivo?"));
        }
    }
}
