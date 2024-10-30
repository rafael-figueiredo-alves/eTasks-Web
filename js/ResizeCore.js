function isMobileResolution() {
    return window.innerWidth <= 768;
}

function subscribeToResize(dotNetHelper) {
    window.addEventListener("resize", () => {
        dotNetHelper.invokeMethodAsync("UpdateLayout", isMobileResolution());
    });
}

function unsubscribeFromResize(dotNetHelper) {
    window.removeEventListener("resize", () => {
        dotNetHelper.invokeMethodAsync("UpdateLayout", isMobileResolution());
    });
}