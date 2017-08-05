/* DATA TABLES */
$(document).ready(function() {

    init_skycons();

});

function init_skycons(){

    if( typeof (Skycons) === 'undefined'){ return; }
    console.log('init_skycons');

    var icons = new Skycons({
            "color": "#73879C"
        }),
        list = [
            "clear-day", "clear-night", "partly-cloudy-day",
            "partly-cloudy-night", "cloudy", "rain", "sleet", "snow", "wind",
            "fog"
        ],
        i;

    for (i = list.length; i--;)
        icons.set(list[i], list[i]);

    icons.play();

}
	   
	   

	

