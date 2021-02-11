using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.Database.Sqlite;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using com.xamarin.samples.bluetooth.bluetoothchat;
using SATCARGO.ClassesGerais;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace SATCARGO.Activitys
{
    [Activity(Label = "ActConfiguraComunicacao", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class ActConfiguraComunicacao : AppCompatActivity
    {

        string[] selecao;
        Spinner spinner;
        string firstItem = "";
        public ArrayAdapter adapter { get; private set; }
        BancoDados mdTemp;
        private SQLiteDatabase sqldTemp;
        private string sSQLQuery;
        private string sMessage;
        private bool bDBIsAvailable;
        private object handler;
        const string TAG = "DeviceListActivity";
        public const string EXTRA_DEVICE_ADDRESS = "device_address";

        EditText TextBluetooth;

        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.layoutConfiguraComunicacao);
         

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CONFIGURAÇÃO COMUNICAÇÃO PLATAFORMAS";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock1);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;
            TextView textIpHeard = FindViewById<TextView>(Resource.Id.textIpHeard);
            EditText TextIp = FindViewById<EditText>(Resource.Id.TextIpConfigura);
            TextView textPortaHeard = FindViewById<TextView>(Resource.Id.textPortaHeard);
            EditText TextPorta = FindViewById<EditText>(Resource.Id.TextPortaComunicacao);
            EditText TextSenha = FindViewById<EditText>(Resource.Id.TextSenhaComunicacao);
            TextView TextHeadBlutooth = FindViewById<TextView>(Resource.Id.textHeaderBluetooth);
            TextBluetooth = FindViewById<EditText>(Resource.Id.BluetoothConfigura);
            TextBluetooth.Text = Intent.GetStringExtra("nome");

        
            RadioButton RdnWifi = FindViewById<RadioButton>(Resource.Id.RdnWifi);
            RadioButton RdnBluetooth = FindViewById<RadioButton>(Resource.Id.RdnBluetooth);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairComunicacao);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarComunicacao);
            Android.Support.V7.Widget.AppCompatButton BtnTestarBluetooth = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.btnTestarBluetooth);
            Android.Support.V7.Widget.AppCompatButton BtnPesquisar = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.btnPequisaBluetooth);
            StringBuilder outStringBuffer;
            BluetoothAdapter bluetoothAdapter = null;
            BluetoothChatService ServiceConnection = null;
            spinner = FindViewById<Spinner>(Resource.Id.spinnernrplataformas);
            selecao = new string[6];
            selecao[0] = "01";
            selecao[1] = "02";
            selecao[2] = "03";
            selecao[3] = "04";
            selecao[4] = "05";
            selecao[5] = "06";
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecao);
            spinner.Adapter = adapter;
            //================================================================================//
            //                              VALOR CADASTRADOS                                 //
            //================================================================================//
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = "SELECT NR_PLATAFORMAS," +
                        " DESCRICAO_TIPO_CONEXAO, " +
                        " ENDERECO_IP, " +
                        " PORTA, " +
                        " BLUETOOTH " +
                        " FROM CONEXAO_PLATAFORMA WHERE _id=1";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;
            int nrParcelas = 0;
            if (ValorCursor > 0)
            {
                icursorTemp.MoveToNext();
                if (icursorTemp.GetString(1) == "WIFI")
                    RdnWifi.Checked = true;
                else
                    RdnBluetooth.Checked = true;

                TextIp.Text = icursorTemp.GetString(2);
                TextPorta.Text = icursorTemp.GetString(3);
                if (TextBluetooth.Text == "")
                   TextBluetooth.Text = icursorTemp.GetString(4);
                Validacoes.NrPlataformas = int.Parse(icursorTemp.GetString(0));
            }
            else
            {
                RdnBluetooth.Checked = true;
            }
            if (RdnWifi.Checked == true &&  Validacoes.ConexaoWifiBluetooth != true )
            {
                TextHeadBlutooth.Visibility = ViewStates.Invisible;
                TextBluetooth.Visibility = ViewStates.Invisible;
                BtnPesquisar.Visibility = ViewStates.Invisible;
            }
            if (RdnBluetooth.Checked == true || Validacoes.ConexaoWifiBluetooth == true)
            {
                textIpHeard.Visibility = ViewStates.Invisible;
                TextIp.Visibility = ViewStates.Invisible;
                textPortaHeard.Visibility = ViewStates.Invisible;
                TextPorta.Visibility = ViewStates.Invisible;
                RdnBluetooth.Checked = true;
            }
            TextBluetooth.InputType = 0;
            RdnWifi.Click += RadioButtonBluetooth;
            RdnBluetooth.Click += RadioButtonWifi;
            Window.SetSoftInputMode(SoftInput.StateHidden);

            //==============================================//
            //                  BLUETOOTH                   //
            //==============================================//

            var scanButton = FindViewById<Button>(Resource.Id.btnPequisaBluetooth);

            if (Validacoes.NrPlataformas > 0)
            {
                spinner.SetSelection(Validacoes.NrPlataformas);
            }
            spinner.ItemSelected += (s, e) =>
            {
                firstItem = spinner.SelectedItem.ToString();
                if (firstItem.Equals(spinner.SelectedItem.ToString()))
                {

                    Validacoes.NrPlataformas = int.Parse(spinner.SelectedItem.ToString()) - 1;

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }

            };


           

            scanButton.Click += (sender, e) =>
            {
                StartActivity(typeof(DeviceListActivity));
                RdnBluetooth.Checked = true;
                textIpHeard.Visibility = ViewStates.Invisible;
                TextIp.Visibility = ViewStates.Invisible;
                textPortaHeard.Visibility = ViewStates.Invisible;
                TextPorta.Visibility = ViewStates.Invisible;
                Validacoes.DeviceListPrinter = false;

                Finish();
            };

            // Register for broadcasts when a device is discovered

            BtnSair.Click += delegate
            {
                Finish();
            };

            BtnTestarBluetooth.Click += delegate
            {
                BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
                ICollection<BluetoothDevice> aparelhos = adaptador.BondedDevices;
                BluetoothDevice[] apa = new BluetoothDevice[aparelhos.Count];
                ParcelUuid[] chaves;
                BluetoothSocket[] socket = new BluetoothSocket[1];
                int i = 0;

                string Conectado = "nao";
                foreach (BluetoothDevice aparelho in aparelhos)
                {

                    apa[i] = aparelho;
                    if (aparelho.Name == TextBluetooth.Text)
                    {
                        Conectado = "sim";
                        chaves = aparelho.GetUuids();
                        socket[0] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[0].Uuid);
                        break;
                    }
                    i++;
                }
                if (adaptador?.IsEnabled == false)
                {
                    var enableBtIntent = "ok";
                }
                if (Conectado == "sim")
                {
                    var address = apa[i].Address;
                    conectar(socket[0]);
                }
            };

            BtnSalvar.Click += delegate
            {
                if (RdnWifi.Checked == true)
                {
                    if (TextIp.Text == "")
                    {
                        Toast.MakeText(this, "Deve ser digitado um Endereço de nº IP", ToastLength.Short).Show();
                        return;
                    }
                    if (TextPorta.Text == "")
                    {
                        Toast.MakeText(this, "Deve ser digitado uma Porta de comunicação", ToastLength.Short).Show();
                        return;
                    }
                }
                if (RdnBluetooth.Checked == true)
                {
                    if (TextBluetooth.Text == "")
                    {
                        Toast.MakeText(this, "Deve ser digitado um pareamento BlueTooth", ToastLength.Short).Show();
                        return;
                    }
                }
                //if (TextSenha.Text == "")
                //{
                //    Toast.MakeText(this, "Deve ser digitada uma Senha", ToastLength.Short).Show();
                //    return;
                //}

                string DescricaoComunicao = "";



                //==============================================================================================//
                //                             VERIFICA SE JÁ EXISTE UM ENDEREÇO GRAVADO                        //
                //==============================================================================================//
                sSQLQuery = "";
                sSQLQuery = "SELECT _id,NR_PLATAFORMAS,DESCRICAO_TIPO_CONEXAO " +
                " FROM CONEXAO_PLATAFORMA ";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                ValorCursor = icursorTemp.Count;
                if (RdnWifi.Checked == true)
                    DescricaoComunicao = "WIFI";
                if (RdnBluetooth.Checked == true)
                    DescricaoComunicao = "BLUETOOTH";

                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                    string Valores =  int.Parse(spinner.SelectedItem.ToString())-1  + ",'" +
                            DescricaoComunicao + "','" +
                            TextIp.Text + "','" +
                            TextPorta.Text + "','" +
                            TextBluetooth.Text + "','" +
                            TextSenha.Text + "','" +
                            Data + "','" +
                            Hora + "'";
                    string Campos = "NR_PLATAFORMAS," +
                            "DESCRICAO_TIPO_CONEXAO," +
                            "ENDERECO_IP," +
                            "PORTA," +
                            "BLUETOOTH," +
                            "SENHA," +
                            "DATA_CADASTRO," +
                            "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                            "CONEXAO_PLATAFORMA " + "(" + Campos + ") " +
                            "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update CONEXAO_PLATAFORMA set " +
                                   $" NR_PLATAFORMAS={int.Parse(spinner.SelectedItem.ToString())-1}," +
                                   $" DESCRICAO_TIPO_CONEXAO='{DescricaoComunicao}'," +
                                   $" ENDERECO_IP='{TextIp.Text}'," +
                                   $" PORTA='{TextPorta.Text}', " +
                                   $" BLUETOOTH='{TextBluetooth.Text}', " +
                                   $" SENHA='{TextSenha.Text}', " +
                                   $" DATA_CADASTRO='{Data}', " +
                                   $" HORA_CADASTRO='{Hora}' " +
                                   $" where _id=1  ";

                    sqldTemp.ExecSQL(ComandoSql);
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
            };
            void RadioButtonWifi(object sender, EventArgs e)
            {
                RadioButton rb = (RadioButton)sender;
                TextHeadBlutooth.Visibility = ViewStates.Visible;
                TextBluetooth.Visibility = ViewStates.Visible;
                textIpHeard.Visibility = ViewStates.Invisible;
                TextIp.Visibility = ViewStates.Invisible;
                textPortaHeard.Visibility = ViewStates.Invisible;
                TextPorta.Visibility = ViewStates.Invisible;
                BtnPesquisar.Visibility = ViewStates.Visible;
                Validacoes.ConexaoWifiBluetooth = true;
            }
            void RadioButtonBluetooth(object sender, EventArgs e)
            {
                RadioButton rb = (RadioButton)sender;
                TextHeadBlutooth.Visibility = ViewStates.Invisible;
                TextBluetooth.Visibility = ViewStates.Invisible;
                textIpHeard.Visibility = ViewStates.Visible;
                TextIp.Visibility = ViewStates.Visible;
                textPortaHeard.Visibility = ViewStates.Visible;
                TextPorta.Visibility = ViewStates.Visible;
                BtnPesquisar.Visibility = ViewStates.Invisible;
                Validacoes.ConexaoWifiBluetooth = false;
            }

        
    }
        
        public override bool OnTouchEvent(MotionEvent e)
        {
      
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(TextBluetooth.WindowToken, 0);
            return base.OnTouchEvent(e);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }


        public void conectar(BluetoothSocket socket)
        {
            //loading.Visibility = Android.Views.ViewStates.Visible;

            try
            {
                //  ConnectedThread mConnectedThread = new ConnectedThread(socket);
                //  mConnectedThread.start();
                socket.Connect();
              
            }
            catch (Exception ex)
            {
                // loading.Visibility = Android.Views.ViewStates.Gone;
                Toast.MakeText(this, "Não foi possivel conectar", ToastLength.Long).Show();


            }
            try
            {

                var output = socket.OutputStream;
                var readput = socket.InputStream;
                byte[] buffer = new byte[2];
                buffer[0] = 0x7D;
                buffer[1] = 0x03;

                output.Write(buffer,0,2);

                byte[] rbuffer = new byte[38];

                // Read data from the device
                //int readByte = socket.InputStream.Read(rbuffer, 0, rbuffer.Length);
                System.Threading.Thread.Sleep(300);
                var readByte = readput.Read(rbuffer, 0, rbuffer.Length);
                Toast toast = Toast.MakeText(this, "CONEXÃO REALIZADA COM SUCESSO", ToastLength.Long);
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
               // Toast.MakeText(this, "CONEXÃO REALIZADA COM SUCESSO", ToastLength.Long).Show();


                socket.Close();
            }
            catch (Exception ex)
            {
                //Toast.MakeText(this, "Não foi possivel enviar a mensagem", ToastLength.Long).Show();
                //Toast.MakeText(this, "NÃO FOI POSSIVEL REALIZAR A CONEXÃO", ToastLength.Long).Show();
                Toast toast = Toast.MakeText(this, "NÃO FOI POSSIVEL REALIZAR A CONEXÃO", ToastLength.Long);
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
                // loading.Visibility = Android.Views.ViewStates.Gone;
            }
        }
       
    }

}
