using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using System.Timers;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.PM;
using SATCARGO.Activitys;
using SATCARGO.ClassesGerais;
using Android.Database.Sqlite;
using System.IO;
using com.xamarin.samples.bluetooth.bluetoothchat;
using Android.Bluetooth;
using Android.Runtime;
using Android.Views.InputMethods;
using SATCARGO.Model;
using System.Threading;
using Xamarin.Forms;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActConfigura4Plataformas", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]

    public class ActConfigura4Plataformas : Activity
    {
       
  
        public SQLiteDatabase sqldTemporario;
        /// <summary>
        /// The sSQLquery for query handling.
        /// </summary>

        /// <summary>
        /// The sMessage to hold message.
        /// </summary>
        BancoDados mdTemp;
        private SQLiteDatabase sqldTemp;
        TextView TxtPeso;
        TextView TxtPeso1;
        TextView TxtBat1;
        TextView TxtPeso2;
        TextView TxtBat2;
        TextView TxtPeso3;
        TextView TxtBat3;
        TextView TxtPeso4;
        TextView TxtBat4;
        TextView TxtPeso5;
        TextView TxtBat5;
        TextView TxtPeso6;
        TextView TxtBat6;
        TextView TxtAguarde1;
        TextView TxtAguarde2;
        TextView TxtAguarde3;
        TextView TxtAguarde4;
        TextView TxtAguarde5;
        TextView TxtAguarde6;

        Android.Widget.Button BtnZerarPlataforma1;
        Android.Widget.Button BtnZerarPlataforma2;
        Android.Widget.Button BtnZerarPlataforma3;
        Android.Widget.Button BtnZerarPlataforma4;
        Android.Widget.Button BtnZerarPlataforma5;
        Android.Widget.Button BtnZerarPlataforma6;
        Android.Widget.Button BtnCalibrarPlataforma1;

        string Fecharthread;
        bool BotaoZeraBalanca1Ativo;
        bool BotaoZeraBalanca2Ativo;
        bool BotaoZeraBalanca3Ativo;
        bool BotaoZeraBalanca4Ativo;
        bool BotaoZeraBalanca5Ativo;
        bool BotaoZeraBalanca6Ativo;

        string ZeraBalanca1;
        string ZeraBalanca2;
        string ZeraBalanca3;
        string ZeraBalanca4;
        string ZeraBalanca5;
        string ZeraBalanca6;

        Android.Widget.ProgressBar progressBar;
        Android.Widget.ProgressBar progressBar1;
        Android.Widget.ProgressBar progressBar2;
        Android.Widget.ProgressBar progressBar3;
        Android.Widget.ProgressBar progressBar4;
        Android.Widget.ProgressBar progressBar5;
        Android.Widget.ProgressBar progressBar6;

        System.Timers.Timer _timer;
        int _countSeconds;
        object _lock = new object();
        private Thread threadBalanca;
        protected override void OnCreate(Bundle bundle)
        {
            //EditText TextIp = FindViewById<EditText>(Resource.Id.TextIpConfigura);
            base.OnCreate(bundle);

            Fecharthread = "N";
            
            if (Validacoes.Nrplataformas+1 == 1)
            {
                SetContentView(Resource.Layout.Layout1plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);

                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
            

                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility = Android.Views.ViewStates.Visible;


                ZeraBalanca1 = "N";
    
            }
            if (Validacoes.Nrplataformas+1 == 2)
            {
                SetContentView(Resource.Layout.Layout2plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtPeso2 = FindViewById<TextView>(Resource.Id.TxtPesoPlat2);
                TxtBat2 = FindViewById<TextView>(Resource.Id.BateriaPlat2);
                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);
                TxtAguarde2 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress2);
               
                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                BtnZerarPlataforma2 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat2);
                BotaoZeraBalanca2Ativo = true;
               
                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
                progressBar2 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress2);

                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility = Android.Views.ViewStates.Visible;


                ZeraBalanca1 = "N";
                ZeraBalanca2 = "N";
              
            }
            if (Validacoes.Nrplataformas+1 == 3)
            {
                SetContentView(Resource.Layout.Layout3plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtPeso2 = FindViewById<TextView>(Resource.Id.TxtPesoPlat2);
                TxtBat2 = FindViewById<TextView>(Resource.Id.BateriaPlat2);
                TxtPeso3 = FindViewById<TextView>(Resource.Id.TxtPesoPlat3);
                TxtBat3 = FindViewById<TextView>(Resource.Id.BateriaPlat3);

                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);
                TxtAguarde2 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress2);
                TxtAguarde3 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress3);

                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                BtnZerarPlataforma2 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat2);
                BotaoZeraBalanca2Ativo = true;

                BtnZerarPlataforma3 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat3);
                BotaoZeraBalanca3Ativo = true;

                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
                progressBar2 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress2);
                progressBar3 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress3);

                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility = Android.Views.ViewStates.Visible;


                ZeraBalanca1 = "N";
                ZeraBalanca2 = "N";
                ZeraBalanca3 = "N";


            }
            if (Validacoes.Nrplataformas+1 == 4)
            {
                SetContentView(Resource.Layout.Layout4plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtPeso2 = FindViewById<TextView>(Resource.Id.TxtPesoPlat2);
                TxtBat2 = FindViewById<TextView>(Resource.Id.BateriaPlat2);
                TxtPeso3 = FindViewById<TextView>(Resource.Id.TxtPesoPlat3);
                TxtBat3 = FindViewById<TextView>(Resource.Id.BateriaPlat3);
                TxtPeso4 = FindViewById<TextView>(Resource.Id.TxtPesoPlat4);
                TxtBat4 = FindViewById<TextView>(Resource.Id.BateriaPlat4);

                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);
                TxtAguarde2 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress2);
                TxtAguarde3 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress3);
                TxtAguarde4 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress4);

                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                BtnZerarPlataforma2 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat2);
                BotaoZeraBalanca2Ativo = true;

                BtnZerarPlataforma3 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat3);
                BotaoZeraBalanca3Ativo = true;

                BtnZerarPlataforma4 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat4);
                BotaoZeraBalanca4Ativo = true;

                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
                progressBar2 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress2);
                progressBar3 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress3);
                progressBar4 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress4);

                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility = Android.Views.ViewStates.Visible;


                ZeraBalanca1 = "N";
                ZeraBalanca2 = "N";
                ZeraBalanca3 = "N";
                ZeraBalanca4 = "N";


            }
            if (Validacoes.Nrplataformas+1 == 5)
            {
                SetContentView(Resource.Layout.Layout5plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtPeso2 = FindViewById<TextView>(Resource.Id.TxtPesoPlat2);
                TxtBat2 = FindViewById<TextView>(Resource.Id.BateriaPlat2);
                TxtPeso3 = FindViewById<TextView>(Resource.Id.TxtPesoPlat3);
                TxtBat3 = FindViewById<TextView>(Resource.Id.BateriaPlat3);
                TxtPeso4 = FindViewById<TextView>(Resource.Id.TxtPesoPlat4);
                TxtBat4 = FindViewById<TextView>(Resource.Id.BateriaPlat4);
                TxtPeso5 = FindViewById<TextView>(Resource.Id.TxtPesoPlat5);
                TxtBat5 = FindViewById<TextView>(Resource.Id.BateriaPlat5);
                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);
                TxtAguarde2 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress2);
                TxtAguarde3 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress3);
                TxtAguarde4 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress4);
                TxtAguarde5 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress5);

                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                BtnCalibrarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrarPlataforma1);
                BotaoZeraBalanca1Ativo = true;


                BtnZerarPlataforma2 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat2);
                BotaoZeraBalanca2Ativo = true;

                BtnZerarPlataforma3 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat3);
                BotaoZeraBalanca3Ativo = true;

                BtnZerarPlataforma4 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat4);
                BotaoZeraBalanca4Ativo = true;

                BtnZerarPlataforma5 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat5);
                BotaoZeraBalanca5Ativo = true;

                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
                progressBar2 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress2);
                progressBar3 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress3);
                progressBar4 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress4);
                progressBar5 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress5);

                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility = Android.Views.ViewStates.Visible;

            }
            if (Validacoes.Nrplataformas+1 == 6)
            {
                SetContentView(Resource.Layout.Layout6plataformas);
                TxtPeso = FindViewById<TextView>(Resource.Id.TxtPeso);
                TxtPeso1 = FindViewById<TextView>(Resource.Id.TxtPesoPlat1);
                TxtBat1 = FindViewById<TextView>(Resource.Id.BateriaPlat1);
                TxtPeso2 = FindViewById<TextView>(Resource.Id.TxtPesoPlat2);
                TxtBat2 = FindViewById<TextView>(Resource.Id.BateriaPlat2);
                TxtPeso3 = FindViewById<TextView>(Resource.Id.TxtPesoPlat3);
                TxtBat3 = FindViewById<TextView>(Resource.Id.BateriaPlat3);
                TxtPeso4 = FindViewById<TextView>(Resource.Id.TxtPesoPlat4);
                TxtBat4 = FindViewById<TextView>(Resource.Id.BateriaPlat4);
                TxtPeso5 = FindViewById<TextView>(Resource.Id.TxtPesoPlat5);
                TxtBat5 = FindViewById<TextView>(Resource.Id.BateriaPlat5);
                TxtPeso6 = FindViewById<TextView>(Resource.Id.TxtPesoPlat6);
                TxtBat6 = FindViewById<TextView>(Resource.Id.BateriaPlat6);
                TxtAguarde1 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress1);
                TxtAguarde2 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress2);
                TxtAguarde3 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress3);
                TxtAguarde4 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress4);
                TxtAguarde5 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress5);
                TxtAguarde6 = FindViewById<TextView>(Resource.Id.TxtAguardeProgress6);

                BtnZerarPlataforma1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerarPlataforma1);
                BotaoZeraBalanca1Ativo = true;

                BtnZerarPlataforma2 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat2);
                BotaoZeraBalanca2Ativo = true;

                BtnZerarPlataforma3 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat3);
                BotaoZeraBalanca3Ativo = true;

                BtnZerarPlataforma4 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat4);
                BotaoZeraBalanca4Ativo = true;

                BtnZerarPlataforma5 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat5);
                BotaoZeraBalanca5Ativo = true;

                BtnZerarPlataforma6 = FindViewById<Android.Widget.Button>(Resource.Id.btnPlat6);
                BotaoZeraBalanca6Ativo = true;

                progressBar1 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress1);
                progressBar2 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress2);
                progressBar3 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress3);
                progressBar4 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress4);
                progressBar5 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress5);
                progressBar6 = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress6);


                progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.note_list_progress);
                progressBar.Visibility= Android.Views.ViewStates.Visible;

               
                ZeraBalanca1 = "N";
                ZeraBalanca2 = "N";
                ZeraBalanca3 = "N";
                ZeraBalanca4 = "N";
                ZeraBalanca5 = "N";
                ZeraBalanca6 = "N";
            }
         
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            Android.Widget.ImageButton BtnSair = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnSairPlataforma);
            Android.Widget.ImageButton BtnSalvar = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnSalvarPlataforma);
            
            this.threadBalanca = new Thread(ProcessoBalanca);
            if (this.threadBalanca != null)
            {
                this.threadBalanca.Start();
               Validacoes.EstadoThread = "START";
            }
           

            Validacoes.EstadoThread = "START";
            Window.SetSoftInputMode(SoftInput.StateHidden);
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                Fecharthread = "S";
                threadBalanca.Interrupt();
                Finish();
                this.Dispose();

            };
            if (Validacoes.Nrplataformas+1 >= 1)
            {
                BtnZerarPlataforma1.Click += delegate
                {
                    if (BotaoZeraBalanca1Ativo == true)
                    {
                        progressBar1.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde1.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde1.SetTextColor(Android.Graphics.Color.Blue);
                        TxtPeso1.Visibility = Android.Views.ViewStates.Invisible;
                        BotaoZeraBalanca1Ativo = false;
                        ZeraBalanca1 = "S";
                    }
                };
            }
            if (Validacoes.Nrplataformas+1 >= 2)
            {
                BtnZerarPlataforma2.Click += delegate
                {
                    if (BotaoZeraBalanca2Ativo == true)
                        {
                            progressBar2.Visibility = Android.Views.ViewStates.Visible;
                            TxtAguarde2.Visibility = Android.Views.ViewStates.Visible;
                            TxtAguarde2.SetTextColor(Android.Graphics.Color.Blue);
                            TxtPeso2.Visibility = Android.Views.ViewStates.Invisible;
                            BotaoZeraBalanca2Ativo = false;
                            ZeraBalanca2 = "S";
                        }
                    };
            }
            if (Validacoes.Nrplataformas+1 >= 3)
            {
                 BtnZerarPlataforma3.Click += delegate
                {

                    if (BotaoZeraBalanca3Ativo == true)
                    {
                        progressBar3.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde3.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde3.SetTextColor(Android.Graphics.Color.Blue);
                        TxtPeso3.Visibility = Android.Views.ViewStates.Invisible;
                        BotaoZeraBalanca3Ativo = false;
                        ZeraBalanca3 = "S";
                    }
                };
            }
            if (Validacoes.Nrplataformas+1 >= 4)
            {
                BtnZerarPlataforma4.Click += delegate
                {
                    if (BotaoZeraBalanca4Ativo == true)
                    {
                        progressBar4.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde4.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde4.SetTextColor(Android.Graphics.Color.Blue);
                        TxtPeso4.Visibility = Android.Views.ViewStates.Invisible;
                        BotaoZeraBalanca4Ativo = false;
                        ZeraBalanca4 = "S";
                    }
                };
            }
            if (Validacoes.Nrplataformas+1 >= 5)
            {
                BtnZerarPlataforma5.Click += delegate
                {
                    if (BotaoZeraBalanca5Ativo == true)
                    {
                        progressBar5.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde5.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde5.SetTextColor(Android.Graphics.Color.Blue);
                        TxtPeso5.Visibility = Android.Views.ViewStates.Invisible;
                        BotaoZeraBalanca5Ativo = false;
                        ZeraBalanca5 = "S";
                    }
                };
            }
            if (Validacoes.Nrplataformas+1 >= 6)
            {
                BtnZerarPlataforma6.Click += delegate
                {
                    if (BotaoZeraBalanca6Ativo == true)
                    {
                        progressBar6.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde6.Visibility = Android.Views.ViewStates.Visible;
                        TxtAguarde6.SetTextColor(Android.Graphics.Color.Blue);
                        TxtPeso6.Visibility = Android.Views.ViewStates.Invisible;
                        BotaoZeraBalanca6Ativo = false;
                        ZeraBalanca6 = "S";
                    }
                };
            }
        }

      

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Thread.Sleep(2000);
            BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
            ICollection<BluetoothDevice> aparelhos = adaptador.BondedDevices;
            BluetoothDevice[] apa = new BluetoothDevice[aparelhos.Count];
            ParcelUuid[] chaves;
            BluetoothSocket[] socket = new BluetoothSocket[aparelhos.Count];
            Validacoes.BSocket = socket;


            int i = 0;
            string Conectado = "nao";
            foreach (BluetoothDevice aparelho in aparelhos)
            {
                apa[i] = aparelho;
                if (aparelho.Name == Validacoes.NomeConexaoBluetooth)
                {
                    Conectado = "sim";
                }
                chaves = aparelho.GetUuids();

                Validacoes.BSocket[i] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[i].Uuid);

                if (socket[i].IsConnected == true)
                    socket[i].Close();
                if (Conectado == "sim")
                    break;
                i++;
            }

            var address = apa[0].Address;
            Validacoes.BSocket[0].Close();
            return base.OnOptionsItemSelected(item);
        }
        private void ProcessoBalanca()
        {
            BancoDados banco = new BancoDados();
            banco.PesquisaAparelho();
            Validacoes.Peso1 = 0;
            Validacoes.Peso2 = 0;
            Validacoes.Peso3 = 0;
            Validacoes.Peso4 = 0;
            Validacoes.Peso5 = 0;
            Validacoes.Peso6 = 0;


            try
            {

                if (Validacoes.EstadoThread == "START")
                {
                    Thread.Sleep(500);
                    BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
                    ICollection<BluetoothDevice> aparelhos = adaptador.BondedDevices;
                    BluetoothDevice[] apa = new BluetoothDevice[aparelhos.Count];
                    ParcelUuid[] chaves;
                    BluetoothSocket[] socket = new BluetoothSocket[1];
                    Validacoes.BSocket = socket;


                    int i = 0;
                    string Conectado = "nao";
                    foreach (BluetoothDevice aparelho in aparelhos)
                    {
                        apa[i] = aparelho;
                        if (aparelho.Name == Validacoes.NomeConexaoBluetooth)
                        {
                            Conectado = "sim";
                            chaves = aparelho.GetUuids();
                            Validacoes.BSocket[0] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[0].Uuid);
                            break;
                        }
                        //if (Conectado == "sim")
                        //    break;
                        i++;
                    }
                    //if (adaptador?.IsEnabled == false)
                    //{
                    //    var enableBtIntent = "ok";
                    //}
                    var address = apa[0].Address;

                    


                    this.AtualizaBalanca1(Validacoes.BSocket[0]);
                   // Validacoes.BSocket[0].Close();
                }
            }
            catch
            {
                this.AtualizaBalanca1(Validacoes.BSocket[0]);
            }

        }

        private void AtualizaBalanca1(BluetoothSocket socket1)
        {
            try
            {

                Thread.Sleep(100);
               // socket1 = Validacoes.VerificaDeviceAtivo(socket1);
                if(socket1.IsConnected==false)
                   socket1.Connect();
                
                if (ZeraBalanca1 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket1, 1);
                    progressBar1.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde1.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso1.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca1 = "N";
                    BotaoZeraBalanca1Ativo = true;
                }          
                else
                {
                   Validacoes.VerificaStatusPlafaforma(socket1, 1);
                    
                }
                if (Validacoes.Estabilidade1 == "E")
                {
                    TxtPeso1.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso1.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso1.Text = Convert.ToString(Validacoes.Peso1));
                RunOnUiThread(() => TxtBat1.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao1) + " VDC");
               
                if (Validacoes.Nrplataformas+1 > 1)
                {
                    socket1.Close();
                    AtualizaBalanca2(socket1);
                }
                else
                {
                    int Pesototal = Validacoes.Peso1 +
                          Validacoes.Peso2 +
                          Validacoes.Peso3 +
                          Validacoes.Peso4 +
                          Validacoes.Peso5 +
                          Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    //socket1.Close();
                    AtualizaBalanca1(socket1);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket1.IsConnected == true) socket1.Close();
                    AtualizaBalanca1(socket1);
                }
            }
        }

        private void AtualizaBalanca2(BluetoothSocket socket2)
        {
            try
            {
                socket2.Close();
                socket2.Dispose();
                Thread.Sleep(150);
                socket2 = Validacoes.VerificaDeviceAtivo(socket2);
                socket2.Connect();
                if (ZeraBalanca2 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket2, 2);
                    progressBar2.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde2.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso2.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca2 = "N";
                    BotaoZeraBalanca2Ativo = true;
                }
                else
                {
                    Validacoes.VerificaStatusPlafaforma(socket2, 2);
                }



                if (Validacoes.Estabilidade2 == "E")
                {
                    TxtPeso2.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso2.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso2.Text = Convert.ToString(Validacoes.Peso2));
                RunOnUiThread(() => TxtBat2.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao2) + " VDC");

                if (Validacoes.Nrplataformas+1 > 2)
                {
                    AtualizaBalanca3(socket2);
                }
                else
                {
                    int Pesototal = Validacoes.Peso1 +
                         Validacoes.Peso2 +
                         Validacoes.Peso3 +
                         Validacoes.Peso4 +
                         Validacoes.Peso5 +
                         Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket2.Close();
                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    AtualizaBalanca1(socket2);
                }

            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket2.IsConnected == true) socket2.Close();
                    AtualizaBalanca1(socket2);
                }
            }
        }
        private void AtualizaBalanca3(BluetoothSocket socket3)
        {
            try
            {

                socket3.Close();
                socket3.Dispose();
                Thread.Sleep(150);
                socket3 = Validacoes.VerificaDeviceAtivo(socket3);
                socket3.Connect();
                if (ZeraBalanca3 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket3, 3);
                    progressBar3.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde3.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso3.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca3 = "N";
                    BotaoZeraBalanca3Ativo = true;
                }
                else
                {
                    Validacoes.VerificaStatusPlafaforma(socket3, 3);
                }



                if (Validacoes.Estabilidade3 == "E")
                {
                    TxtPeso3.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso3.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso3.Text = Convert.ToString(Validacoes.Peso3));
                RunOnUiThread(() => TxtBat3.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao3) + " VDC");

                if (Validacoes.Nrplataformas+1 > 3)
                {
                    AtualizaBalanca4(socket3);
                }
                else
                {
                    socket3.Close();
                    int Pesototal = Validacoes.Peso1 +
                   Validacoes.Peso2 +
                   Validacoes.Peso3 +
                   Validacoes.Peso4 +
                   Validacoes.Peso5 +
                   Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    socket3.Close();
                    AtualizaBalanca1(socket3);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket3.IsConnected == true) socket3.Close();
                    AtualizaBalanca1(socket3);
                }
            }
        }
        private void AtualizaBalanca4(BluetoothSocket socket4)
        {
            try
            {

                socket4.Close();
                socket4.Dispose();
                Thread.Sleep(150);
                socket4 = Validacoes.VerificaDeviceAtivo(socket4);
                socket4.Connect();
                if (ZeraBalanca4 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket4, 4);
                    progressBar4.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde4.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso4.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca4 = "N";
                    BotaoZeraBalanca4Ativo = true;
                }
                else
                {
                    Validacoes.VerificaStatusPlafaforma(socket4, 4);
                }



                if (Validacoes.Estabilidade4 == "E")
                {
                    TxtPeso4.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso4.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso4.Text = Convert.ToString(Validacoes.Peso4));
                RunOnUiThread(() => TxtBat4.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao4) + " VDC");


                if (Validacoes.Nrplataformas+1 > 4)
                {
                    AtualizaBalanca5(socket4);
                }
                else
                {
                    socket4.Close();
                    int Pesototal = Validacoes.Peso1 +
                    Validacoes.Peso2 +
                    Validacoes.Peso3 +
                    Validacoes.Peso4 +
                    Validacoes.Peso5 +
                    Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    socket4.Close();
                    AtualizaBalanca1(socket4);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket4.IsConnected == true) socket4.Close();
                    AtualizaBalanca1(socket4);
                }
            }
        }
        private void AtualizaBalanca5(BluetoothSocket socket5)
        {
            try
            {

                socket5.Close();
                socket5.Dispose();
                Thread.Sleep(150);
                socket5 = Validacoes.VerificaDeviceAtivo(socket5);
                socket5.Connect();
                if (ZeraBalanca5 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket5, 5);
                    progressBar5.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde5.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso5.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca5 = "N";
                    BotaoZeraBalanca5Ativo = true;
                }
                else
                {
                    Validacoes.VerificaStatusPlafaforma(socket5, 5);
                }


                if (Validacoes.Estabilidade5 == "E")
                {
                    TxtPeso5.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso5.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso5.Text = Convert.ToString(Validacoes.Peso5));
                RunOnUiThread(() => TxtBat5.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao5) + " VDC");

                if (Validacoes.Nrplataformas+1 > 5)
                {
                    AtualizaBalanca6(socket5);
                }
                else
                {
                    socket5.Close();
                    int Pesototal = Validacoes.Peso1 +
                    Validacoes.Peso2 +
                    Validacoes.Peso3 +
                    Validacoes.Peso4 +
                    Validacoes.Peso5 +
                    Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    socket5.Close();
                    AtualizaBalanca1(socket5);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket5.IsConnected == true) socket5.Close();
                    AtualizaBalanca1(socket5);
                }
            }
        }

        private void AtualizaBalanca6(BluetoothSocket socket6)
        {
            try
            {
                socket6.Close();
                socket6.Dispose();
                Thread.Sleep(150);
                socket6 = Validacoes.VerificaDeviceAtivo(socket6);
                socket6.Connect();
                if (ZeraBalanca6 == "S")
                {
                    Validacoes.ZeraPlafaforma(socket6, 6);
                    progressBar6.Visibility = Android.Views.ViewStates.Invisible;
                    TxtAguarde6.Visibility = Android.Views.ViewStates.Invisible;
                    TxtPeso6.Visibility = Android.Views.ViewStates.Visible;
                    ZeraBalanca6 = "N";
                    BotaoZeraBalanca6Ativo = true;
                }
                else
                {
                    Validacoes.VerificaStatusPlafaforma(socket6, 6);
                }

                if (Validacoes.Estabilidade6 == "E")
                {
                    TxtPeso6.SetTextColor(Android.Graphics.Color.LimeGreen);
                }
                else
                {
                    TxtPeso6.SetTextColor(Android.Graphics.Color.Red);
                }
                RunOnUiThread(() => TxtPeso6.Text = Convert.ToString(Validacoes.Peso6));
                RunOnUiThread(() => TxtBat6.Text = "Tensão Bateria " + Convert.ToString(Validacoes.Tensao6) + " VDC");

                socket6.Close();
                int Pesototal = Validacoes.Peso1 +
                Validacoes.Peso2 +
                Validacoes.Peso3 +
                Validacoes.Peso4 +
                Validacoes.Peso5 +
                Validacoes.Peso6;
                RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                progressBar.Visibility = Android.Views.ViewStates.Invisible;


                AtualizaBalanca1(socket6);



            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalanca.Interrupt();
                }
                else
                {
                    if (socket6.IsConnected == true) socket6.Close();
                    AtualizaBalanca1(socket6);
                }
            }
        }
 

    }
}