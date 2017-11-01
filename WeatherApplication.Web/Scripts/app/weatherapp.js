$(document).ready(function () {
    var country = "";

    var weather = {
        location: "",
        Time: "",
        wind: "",
        visibility: "",
        skyConditions: "",
        temperature: "",
        dewPoint: "",
        relativeHumidity: "",
        pressure: "",
        iconUrl: ""
    };

    //to Get the Weather for a City in a Country
    $('#getweather').click(function () {
        var city = $('#cities').val();
        if (!Utils.isEmpty(city) && !Utils.isEmpty(country)) {
            //var url = "/api/weather/" + country + "/" + city;
            var url = "/api/weather/" + city;
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: url,
                dataType: "Json",
                success: function (response) {
                    //var data = $.parseJSON(response);
                    var data = response;
                    if (data.cod.toString() === "200") {
                        var weather = {
                            location: data.coord.lat + "," + data.coord.lon,
                            time: Utils.getTime(data.dt),
                            wind: data.wind.speed + " m/s",
                            visibility: data.visibility,
                            skyConditions: data.weather.length > 0 ? data.weather[0].description : "",
                            temperature: data.main.temp,
                            dewPoint: "",
                            relativeHumidity: Utils.isEmpty(data.main.humidity) ? "" : data.main.humidity + " %",
                            pressure: data.main.pressure + " hpa",
                            iconUrl: data.weather.length > 0 ? "http://openweathermap.org/img/w/" + data.weather[0].icon + ".png" : ""
                        };

                        var weathertmpl = $.templates("#weatherinfotemplate");
                        var weatherhtml = weathertmpl.render(weather);
                        $("#weatherinfo").html(weatherhtml);
                    }

                },
                error: function ajaxError(response) {
                    console.log(response.status + ' ' + response.statusText);
                }
            });
        };
    });

    //To Get the Cities for the selected Country
    $('#countries').change(function () {
        var item = $(this);
        country = item.val();
        if (!Utils.isEmpty(country)) {
            var url = "/api/countries/" + country + "/cities";
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: url,
                dataType: "Json",
                success: function (data) {
                    var cities = $("#cities");
                    cities.empty();
                    cities.append($("<option></option>").val("").html("SELECT CITY..."));
                    $.each(data, function (i, item) {
                        cities.append($("<option></option>").val(item.id).html(item.name));
                    });
                },
                error: function ajaxError(response) {
                    alert(response.status + ' ' + response.statusText);
                }
            });
        };
    });

    //Load all the countries
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/api/countries",
        dataType: "Json",
        success: function (data) {
            var countries = $("#countries");
            countries.empty();
            countries.append($("<option></option>").val("").html("SELECT COUNTRY..."));
            $.each(data, function (i, item) {
                countries.append($("<option></option>").val(item.isO_3166_code).html(item.name));
            });
        },
        error: function ajaxError(response) {
            alert(response.status + ' ' + response.statusText);
        }
    });
});