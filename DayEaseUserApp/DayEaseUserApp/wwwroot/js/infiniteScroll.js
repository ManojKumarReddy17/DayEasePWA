window.setupInfiniteScroll = (sentinel, dotNetHelper) => {
    if (!(sentinel instanceof Element)) {
        console.error("Sentinel is not a valid DOM element");
        return;
    }

    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                dotNetHelper.invokeMethodAsync("OnScrollNearBottom");
            }
        });
    }, {
        root: null,
        rootMargin: "200px",
        threshold: 0
    });

    observer.observe(sentinel);
};

window.initInfiniteScroll = (dotNetRef) => {
    const anchor = document.getElementById("scroll-anchor");
    if (!anchor) {
        console.warn("scroll-anchor not found");
        return;
    }

    const observer = new IntersectionObserver(entries => {
        if (entries[0].isIntersecting) {
            dotNetRef.invokeMethodAsync("LoadMoreStores");
        }
    }, {
        root: null,
        rootMargin: "200px",
        threshold: 0
    });

    observer.observe(anchor);
};
