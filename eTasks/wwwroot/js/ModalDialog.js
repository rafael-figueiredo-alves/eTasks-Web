window.modalInstance = null;

window.mostrarModal = function (modalId) {
    var modalElement = document.getElementById(modalId);
    if (!modalElement) {
        console.error('Elemento do modal não encontrado.');
        return;
    }

    // Se já existe uma instância, reutilize-a
    if (!window.modalInstance) {
        window.modalInstance = new bootstrap.Modal(modalElement, {
            backdrop: 'static' // Garante apenas um backdrop
        });
    }

    // Mostrar o modal
    window.modalInstance.show();
};

window.fecharModal = function (modalId) {
    var modalElement = document.getElementById(modalId);
    if (window.modalInstance && modalElement) {
        window.modalInstance.hide();
        // Limpa a instância após fechar para evitar problemas
        window.modalInstance = null;

        // Remove qualquer backdrop residual
        var backdrops = document.querySelectorAll('.modal-backdrop');
        backdrops.forEach(function (backdrop) {
            backdrop.remove();
        });
    }
};

window.copyToClipboard = async function (text) {
    try {
        await navigator.clipboard.writeText(text);
        return true;
    } catch (err) {
        console.error("Erro ao copiar para a área de transferência: ", err);
        return false;
    }
};
