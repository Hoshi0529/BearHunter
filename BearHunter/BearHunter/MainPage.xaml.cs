using System;

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

        int count = 0;
        int hoshi;
        int yamann;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            // サブページへ移動
            await Shell.Current.GoToAsync("//SubPage");
        }

    }

  
}
