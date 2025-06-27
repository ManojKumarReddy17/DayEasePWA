window.mapInterop = {
    getCurrentLocationAndInitMap: function (dotNetRef) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                const lat = position.coords.latitude;
                const lng = position.coords.longitude;

                dotNetRef.invokeMethodAsync('UpdateCoordinates', lat, lng);

                var mapCenter = new google.maps.LatLng(lat, lng);
                var map = new google.maps.Map(document.getElementById("googleMap"), {
                    center: mapCenter,
                    zoom: 15
                });

                var marker = new google.maps.Marker({
                    position: mapCenter,
                    map: map,
                    draggable: true
                });

                marker.addListener('dragend', function () {
                    var newLat = marker.getPosition().lat();
                    var newLng = marker.getPosition().lng();
                    dotNetRef.invokeMethodAsync('UpdateCoordinates', newLat, newLng);
                });
            });
        } else {
            alert("Geolocation is not supported by this browser.");
        }
    }
};
