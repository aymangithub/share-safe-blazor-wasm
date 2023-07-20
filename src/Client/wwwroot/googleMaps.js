window.initializeMap = (mapDivId, latitude, longitude, zoom) => {
    var location = { lat: latitude, lng: longitude };

    const mapOptions = {
        center: new google.maps.LatLng(latitude, longitude),
        zoom: zoom,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoomControl: false, // disables zoom controls
        draggable: false, // disables map navigation
        scrollwheel: false, // disables map navigation when scrolling
        disableDoubleClickZoom: true // disables zoom on double click
    };
    var map = new google.maps.Map(document.getElementById(mapDivId), mapOptions);

    var marker = new google.maps.Marker({ // adds a marker
        position: location,
        map: map
    });
};
