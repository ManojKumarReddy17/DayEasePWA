window.setupInfiniteScroll = (sentinel, dotNetHelper) => {
    if (!(sentinel instanceof Element)) {
        console.error("Sentinel is not a valid DOM element");
        return;
    }

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                dotNetHelper.invokeMethodAsync("OnScrollNearBottom");
            }
        });
    });

    observer.observe(sentinel);
};
