using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
namespace BearHunter;


public partial class NewPage1 : ContentPage
{
    static string id = 2112141.ToString();
   
    public partial class WeatherResult
    {
        [Newtonsoft.Json.JsonProperty("cod")]
        public long Cod { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public long Message { get; set; }

        [Newtonsoft.Json.JsonProperty("cnt")]
        public long Cnt { get; set; }

        [Newtonsoft.Json.JsonProperty("list")]
        public WeatherSummary[] List { get; set; }

        [Newtonsoft.Json.JsonProperty("city")]
        public City City { get; set; }
    }

    public partial class City
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("coord")]
        public Coord Coord { get; set; }

        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("population")]
        public long Population { get; set; }

        [Newtonsoft.Json.JsonProperty("timezone")]
        public long Timezone { get; set; }

        [Newtonsoft.Json.JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [Newtonsoft.Json.JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

    public partial class Coord
    {
        [Newtonsoft.Json.JsonProperty("lat")]
        public double Lat { get; set; }

        [Newtonsoft.Json.JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class WeatherSummary
    {
        [Newtonsoft.Json.JsonProperty("dt")]
        public long Dt { get; set; }

        [Newtonsoft.Json.JsonProperty("main")]
        public MainClass Main { get; set; }

        [Newtonsoft.Json.JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [Newtonsoft.Json.JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        /* [Newtonsoft.Json.JsonProperty("wind")]
         public Wind Wind { get; set; }
        */
        [Newtonsoft.Json.JsonProperty("visibility")]
        public long Visibility { get; set; }

        [Newtonsoft.Json.JsonProperty("pop")]
        public double Pop { get; set; }

        [Newtonsoft.Json.JsonProperty("snow", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Snow Snow { get; set; }

        [Newtonsoft.Json.JsonProperty("sys")]
        public Sys Sys { get; set; }

        [Newtonsoft.Json.JsonProperty("dt_txt")]
        public DateTimeOffset DtTxt { get; set; }
    }

    public partial class Clouds
    {
        [Newtonsoft.Json.JsonProperty("all")]
        public long All { get; set; }
    }

    public partial class MainClass
    {
        [Newtonsoft.Json.JsonProperty("temp")]
        public double Temp { get; set; }

        [Newtonsoft.Json.JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [Newtonsoft.Json.JsonProperty("pressure")]
        public long Pressure { get; set; }

        [Newtonsoft.Json.JsonProperty("sea_level")]
        public long SeaLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("grnd_level")]
        public long GrndLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("humidity")]
        public long Humidity { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }

    public partial class Snow
    {
        [Newtonsoft.Json.JsonProperty("3h")]//éûä‘ÅH
        public double The3H { get; set; }
    }

    public partial class Sys
    {
        [Newtonsoft.Json.JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public partial class Weather
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("main")]
        public string Main { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("icon")]
        public string Icon { get; set; }
    }
    public NewPage1()
    {
        InitializeComponent();
        InitListView();
        WeatherPut();
    }

    System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();

    void InitListView()
    {

    }

    void AddItem(string dateTime, string weather, string temp)
    {
        List.Text = dateTime + "/" + weather + "/" + temp;

    }

    private async void WeatherPut()
    {
        string str = await GetJson();
        WeatherResult result = GetDataFromJson(str);

        foreach (var weatherSummary in result.List)
        {
            string dateTime = weatherSummary.DtTxt.DateTime.AddHours(8).ToString("Måédì˙ HHéûmmï™");
            string weather = GetWeather(weatherSummary.Weather[0].Main);
            string temp = weatherSummary.Main.Temp.ToString() + "Åé";
            AddItem(dateTime, weather, temp);
        }
    }


    public WeatherResult GetDataFromJson(string jsonText)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherResult>(jsonText);
    }

    public string GetWeather(string str)
    {

        if (str == "Clear")
            return "ê∞ÇÍ";
        else if (str == "Clouds")
            return "Ç≠Ç‡ÇË";
        else if (str == "Rain")
            return "âJ";
        else if (str == "Thunderstorm")
            return "óãâJ";
        else if (str == "Snow")
            return "ê·";
        else if (str == "Mist")
            return "ñ∂";
        else if (str == "Drizzle")
            return "ñ∂âJ";
        else
            return "ÅH";
    }
    //aa

    public async Task<string> GetJson()
    {
        string apiKey = "6105f57ac4a3c76d912c3d5205c8e58a";
        //åSéRÅ@2112141Å@ìåãûÅ@1853908
        string url = "https://api.openweathermap.org/data/2.5/forecast?id=" + id + "&units=metric&cnt=12&APPID=" + apiKey;
        return await httpClient.GetStringAsync(url);
    }
}