using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using APIEXAMPLE.Model;
using Newtonsoft.Json;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIEXAMPLE
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView _textView;
        private List<WeatherDetails> wd= new List<WeatherDetails>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _textView = FindViewById<TextView>(Resource.Id.textView1);
            GetDataAsync();
        }

        private async Task GetDataAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://samples.openweathermap.org/data/2.5/forecast?id=524901&appid=b1b15e88fa797225412429c1c50c122a1");
            if (response.IsSuccessStatusCode)
            {
               
                var jasonStringWeather = await response.Content.ReadAsStringAsync();

                //JSONObject jSONObject = new JSONObject(jasonStringWeather);
              
               
                
               
              var weatherDetails = JsonConvert.DeserializeObject<WeatherDetails>(jasonStringWeather);

         
               
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}