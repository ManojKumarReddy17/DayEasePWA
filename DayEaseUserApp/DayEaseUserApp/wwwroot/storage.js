window.sessionStore = {
    set: function (key, value) {
        sessionStorage.setItem(key, JSON.stringify(value));
    },
    get: function (key) {
        const data = sessionStorage.getItem(key);
        return data ? JSON.parse(data) : null;
    },
    remove: function (key) {
        sessionStorage.removeItem(key);
    },
    clear: function () {
        sessionStorage.clear();
    }
};

window.geoLocation = {
    getCurrentLocation: async function () {
        return new Promise((resolve, reject) => {
            if (!navigator.geolocation) {
                reject("Geolocation not supported.");
            }

            navigator.geolocation.getCurrentPosition(
                position => {
                    resolve({
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    });
                },
                error => reject(error.message),
                { enableHighAccuracy: true }
            );
        });
    }
};
