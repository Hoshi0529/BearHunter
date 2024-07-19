using Microsoft.Maui.Controls;
using Maui.GoogleMaps;
using Microsoft.Maui;
using System;
using Microsoft.Maui.Devices.Sensors;


namespace BearHunter
{

    public partial class MainPage : ContentPage
    {
        Location location2;
        double nowlatitude;
        double nowlongitude;
        double beforlatitude;
        double beforlongitude;
        //現在の位置情報を取得する
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        List<string> messages = new List<string>
        {
            "炎炎ノ炎ニ帰セ",
            "メッセージ2",
            "メッセージ3"
        };

        int messageIndex = 0;

        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                location2 = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location2 != null)
                {
                    beforlatitude = nowlatitude;
                    beforlongitude = nowlongitude;
                    Console.WriteLine($"Latitude: {location2.Latitude}, Longitude: {location2.Longitude}, Altitude: {location2.Altitude}");
                    nowlatitude = (location2.Latitude);
                    nowlongitude = (location2.Longitude);

                }
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = true;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
          
            await GetCurrentLocation();
        }
        private void kumaClicked(object sender, EventArgs e)
        {
            // Simulate step data
            DisplayNextMessage();
        }

        private void DisplayNextMessage()
        {
            // 現在のメッセージを表示
            messageLabel.Text = messages[messageIndex];

            // 次のメッセージのインデックスを設定
            messageIndex = (messageIndex + 1) % messages.Count;
        }

    }
}
