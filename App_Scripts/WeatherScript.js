$("#btnSubmit").click(function () {
    var cityname = $("#txtCity").val();
    var url = "/Weather/GetWeatherInfo/" + cityname;
    $.get(url, function (response) {
        console.log(response);
        if (!response.ErrorText) {
            var data = JSON.parse(response.weatherInformation);
            $("#lblTemp").text(data.temperature);
            $("#lblWindSpeed").text(data.windspeed);
            $("#lblWindDirection").text(data.winddirection);
            $("#lblLat").text(data.latitude);
            $("#lblLon").text(data.longitude);
        }
        else {
            alert(response.ErrorText);
        }
        
    });
});