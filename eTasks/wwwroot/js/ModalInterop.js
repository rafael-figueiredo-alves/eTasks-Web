window.modalInterop = {
    _dotnetRef: null,
    _popListener: null,

    pushStateForModal(dotnetRef) {
        this._dotnetRef = dotnetRef;
        window.location.hash = "#modal";
        this._popListener = () => {
            if (location.hash !== "#modal" && this._dotnetRef) {
                this._dotnetRef.invokeMethodAsync("OnBrowserBack");
            }
        };
        window.addEventListener("hashchange", this._popListener);
    },

    popState() {
        if (location.hash === "#modal") {
            history.back();
        }
    },

    clear() {
        window.removeEventListener("hashchange", this._popListener);
        this._popListener = null;
        this._dotnetRef = null;
    }
};
