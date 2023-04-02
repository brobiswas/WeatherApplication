namespace WeatherApplication.Models
{
    public class CityWeatherData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public weather current_weather { get; set; }
    }

    public class weather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public double weathercode { get; set; }
        public string time { get; set; }
    }

    public class WeatherResult
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }

    }
    public class locationData
    {
        public string city { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string population_proper { get; set; }

    }
    public class result
    {
        public string weatherInformation { get; set; }
        public string ErrorText { get; set; }
    }
}