using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Timers;
using Android.Database.Sqlite;
using Android.Content.PM;
using Android.Content;
using Android.Bluetooth;
using System;
using Android.Widget;
using Android.Views;
using Acr.UserDialogs;

namespace SATCARGO
{
    [Activity(Label = "SATURNO SISTEMA DE PESAGEM DE PLATAFORMAS",Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        Timer timer = null;
        new const string TAG = "BluetoothChat.MainActivity";
        bool logShown;
        private object bluetoothDeviceReceiver;
        BluetoothAdapter btAdapter;
        static ArrayAdapter<string> newDevicesArrayAdapter;
       
        public string EXTRA_DEVICE_ADDRESS { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            UserDialogs.Init(this);
            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.activity_main);
     
            timer = new Timer();
            timer.Interval = 3000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            // StartScan();
            Validacoes.SenhaCalibracao = false;


        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            timer.Dispose();
            Finish();
            StartActivity(typeof(ActPrincipal));

        }
    }
}