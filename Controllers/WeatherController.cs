using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Weather()
        {
            return View();
        }

        public JsonResult GetWeatherInfo(string City)
        {
            var locationData = new locationData();
            var output = new result();
            locationData = getLocationData(City);
            if (locationData != null)
            {
                string url = string.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true", locationData.lat, locationData.lng);
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    CityWeatherData weatherInfo = (new JavaScriptSerializer()).Deserialize<CityWeatherData>(json);
                    WeatherResult rslt = new WeatherResult();
                    rslt.latitude = weatherInfo.latitude;
                    rslt.longitude = weatherInfo.longitude;
                    rslt.temperature = weatherInfo.current_weather.temperature;
                    rslt.windspeed = weatherInfo.current_weather.windspeed;
                    rslt.winddirection = weatherInfo.current_weather.winddirection;
                    output.weatherInformation = new JavaScriptSerializer().Serialize(rslt);
                }
            }
            else
            {
                output.ErrorText = "No data found in the database for this input!!!";
            }
            return Json(output, JsonRequestBehavior.AllowGet);
        }

        public locationData getLocationData(string CityName)
        {
            List<locationData> locationList;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/in.json")))
            {
                locationList = JsonConvert.DeserializeObject<List<locationData>>(sr.ReadToEnd());
            }
            var vLocationData = locationList.FirstOrDefault(l => l.city == CityName);
            return vLocationData;
        }
    }
}