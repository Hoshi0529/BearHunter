﻿using Android;
using Android.App;
using Android.Runtime;
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesFeature("android.hardware.location", Required = false)]
[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
[assembly: UsesFeature("android.hardware.location.network", Required = false)]
[assembly: UsesPermission(Manifest.Permission.AccessBackgroundLocation)]

namespace BearHunter
{
    [Application]
    //下記を追記
    [MetaData("com.google.android.maps.v2.API_KEY",
             Value = "AIzaSyB7ihdAHiq3osky-8D-r6iNNmB5GtdPhYk")] // ここに先ほど取得したAPIキーを入れる
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
