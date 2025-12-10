window.mapInterop = {
    popupMap: null,
    marker: null,

    getCurrentLocation: function () {
        return new Promise((resolve, reject) => {
            if (!navigator.geolocation) {
                reject("Geolocation not supported");
                return;
            }

            navigator.geolocation.getCurrentPosition(
                (pos) => {
                    resolve({
                        lat: pos.coords.latitude,
                        lng: pos.coords.longitude
                    });
                },
                (err) => {
                    reject("Unable to fetch location");
                }
            );
        });
    },
    openMapPopupChoose: function (lat, lng, dotNetRef) {
        this.loadPopupMap(lat, lng, dotNetRef);
    },

    loadPopupMap: function (lat, lng, dotNetRef) {
        const mapDiv = document.getElementById("popupMap");

        this.popupMap = new google.maps.Map(mapDiv, {
            center: { lat, lng },
            zoom: 16
        });

        this.marker = new google.maps.Marker({
            position: { lat, lng },
            map: this.popupMap,
            draggable: true
        });

        // Send updated coords on drag
        this.marker.addListener("dragend", (e) => {
            dotNetRef.invokeMethodAsync("SetTempLocation",
                e.latLng.lat(), e.latLng.lng());
        });

        // Or click on map
        this.popupMap.addListener("click", (e) => {
            this.marker.setPosition(e.latLng);
            dotNetRef.invokeMethodAsync("SetTempLocation",
                e.latLng.lat(), e.latLng.lng());
        });

        // Send initial values
        dotNetRef.invokeMethodAsync("SetTempLocation", lat, lng);
    }
};





