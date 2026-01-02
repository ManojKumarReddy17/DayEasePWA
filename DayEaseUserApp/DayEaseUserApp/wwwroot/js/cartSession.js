window.cartSession = {
    save: function (items) {
        sessionStorage.setItem("cart", JSON.stringify(items));
    },

    load: function () {
        return sessionStorage.getItem("cart");
    },

    clear: function () {
        sessionStorage.removeItem("cart");
    }
   
};
window.addEventListener("beforeunload", function () {
    DotNet.invokeMethodAsync(
        "DayEaseUserApp",
        "OnSessionEnd"
    );
});