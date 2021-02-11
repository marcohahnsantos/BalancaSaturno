using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.PM;
using SATCARGO.Activitys;
using SATCARGO.ClassesGerais;
using Android.Database.Sqlite;
using System.IO;
using com.xamarin.samples.bluetooth.bluetoothchat;
using Android.Bluetooth;
using Android.Database.Sqlite;
using Android.Runtime;
using Android.Views.InputMethods;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActConfiguraPrinter", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class ActConfiguraPrinter : AppCompatActivity
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
        string ImpressoraAtivada="";


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layoutConfiguraPrinter);
            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CONFIGURAÇÃO COMUNICAÇÃO IMPRESSORAS";
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
            EditText TextBluetooth = FindViewById<EditText>(Resource.Id.BluetoothConfigura);
            TextBluetooth.Text = Intent.GetStringExtra("nome");
            RadioButton RdnWifi = FindViewById<RadioButton>(Resource.Id.RdnWifi);
            RadioButton RdnBluetooth = FindViewById<RadioButton>(Resource.Id.RdnBluetooth);

            RadioButton RdnImpressoraAtivada = FindViewById<RadioButton>(Resource.Id.RdnImpressoraAtivada);
            RadioButton RdnImpressoraDesativada = FindViewById<RadioButton>(Resource.Id.RdnImpressoraDesativada);



            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairComunicacao);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarComunicacao);
            Android.Support.V7.Widget.AppCompatButton BtnTestarBluetooth = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.btnTestarBluetooth);
            Android.Support.V7.Widget.AppCompatButton BtnPesquisar = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.btnPequisaBluetooth);
            StringBuilder outStringBuffer;
            BluetoothAdapter bluetoothAdapter = null;
            BluetoothChatService ServiceConnection = null;
            
            //================================================================================//
            //                              VALOR CADASTRADOS                                 //
            //================================================================================//
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;

        

            sSQLQuery = "SELECT " +
                        " DESCRICAO_TIPO_CONEXAO, " +
                        " ENDERECO_IP, " +
                        " PORTA, " +
                        " BLUETOOTH, " +
                        " ATIVA " +
                        " FROM CONEXAO_PRINTERS WHERE _id=1";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;
            int nrParcelas = 0;
            if (ValorCursor > 0)
            {
                icursorTemp.MoveToNext();
                if (icursorTemp.GetString(0) == "WIFI")
                    RdnWifi.Checked = true;
                else
                    RdnBluetooth.Checked = true;

                TextIp.Text = icursorTemp.GetString(1);
                TextPorta.Text = icursorTemp.GetString(3);
                if (TextBluetooth.Text == "")
                    TextBluetooth.Text = icursorTemp.GetString(3);

                if (icursorTemp.GetString(4) == "S")
                    RdnImpressoraAtivada.Checked = true;
                else
                    RdnImpressoraDesativada.Checked = true;
                // Validacoes.NrPlataformas = int.Parse(icursorTemp.GetString(0));
            }
            else
            {
                RdnBluetooth.Checked = true;
                RdnImpressoraDesativada.Checked = true;
            }



            if (RdnWifi.Checked == true && Validacoes.ConexaoWifiBluetooth != true)
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

           

           

            RdnBluetooth.Click += RadioButtonWifi;
            RdnWifi.Click += RadioButtonBluetooth;
            TextBluetooth.InputType = 0;
            //==============================================//
            //                  BLUETOOTH                   //
            //==============================================//

            var scanButton = FindViewById<Button>(Resource.Id.btnPequisaBluetooth);

            scanButton.Click += (sender, e) =>
            {
                StartActivity(typeof(DeviceListActivity));
                RdnBluetooth.Checked = true;
                textIpHeard.Visibility = ViewStates.Invisible;
                TextIp.Visibility = ViewStates.Invisible;
                textPortaHeard.Visibility = ViewStates.Invisible;
                TextPorta.Visibility = ViewStates.Invisible;
                Validacoes.DeviceListPrinter = true;
                Finish();
            };
            Window.SetSoftInputMode(SoftInput.StateHidden);
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
                if (RdnImpressoraAtivada.Checked == true)
                {
                    ImpressoraAtivada = "S";
                }
                if (RdnImpressoraDesativada.Checked == true)
                {
                    ImpressoraAtivada = "N";
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
                sSQLQuery = "SELECT _id,DESCRICAO_TIPO_CONEXAO " +
                " FROM CONEXAO_PRINTERS ";
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

                    string Valores = "'" +
                            DescricaoComunicao + "','" +
                            TextIp.Text + "','" +
                            TextPorta.Text + "','" +
                            TextBluetooth.Text + "','" +
                            TextSenha.Text + "','" +
                            Data + "','" +
                            Hora + "','"+
                            ImpressoraAtivada+"'";
                    string Campos = "DESCRICAO_TIPO_CONEXAO," +
                            "ENDERECO_IP," +
                            "PORTA," +
                            "BLUETOOTH," +
                            "SENHA," +
                            "DATA_CADASTRO," +
                            "HORA_CADASTRO," +
                            "ATIVA";

                    sSQLQuery = "INSERT INTO " +
                            "CONEXAO_PRINTERS " + "(" + Campos + ") " +
                            "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update CONEXAO_PRINTERS set " +
                                   $" DESCRICAO_TIPO_CONEXAO='{DescricaoComunicao}'," +
                                   $" ENDERECO_IP='{TextIp.Text}'," +
                                   $" PORTA='{TextPorta.Text}', " +
                                   $" BLUETOOTH='{TextBluetooth.Text}', " +
                                   $" SENHA='{TextSenha.Text}', " +
                                   $" DATA_CADASTRO='{Data}', " +
                                   $" HORA_CADASTRO='{Hora}', " +
                                   $" ATIVA='{ImpressoraAtivada}' " +
                                   $" where _id=1  ";


                    sqldTemp.ExecSQL(ComandoSql);
                    Validacoes.ImpressoraAtiva = ImpressoraAtivada;
                
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();

            
                }
                sSQLQuery = "SELECT BLUETOOTH " +
                     " FROM CONEXAO_PRINTERS WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.ImpressoraAtiva = ImpressoraAtivada;
                    Validacoes.NomeImpressora = icursorTemp.GetString(0);
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
            catch (Exception erro)
            {
                // loading.Visibility = Android.Views.ViewStates.Gone;
                Toast.MakeText(this, "Não foi possivel conectar", ToastLength.Long).Show();


            }
            try
            {


                var output = socket.OutputStream;
                var readput = socket.InputStream;
                byte[] buffer1 = new byte[3];
                //buffer1[0] = 0x1B;
                //buffer1[1] = 0x21;
                //buffer1[2] = 0x01;
                //output.Write(buffer1, 0, buffer1.Count());
                buffer1[0] = 0x1B;
                buffer1[1] = 0x21;
                buffer1[2] = 0x08;
                output.Write(buffer1, 0, buffer1.Count());


                byte[] buffer = new byte[35];
                //======================================//
                //          CABEÇARIO                   //
                //======================================//
                buffer = Validacoes.Imprime_linha(); 
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"EMPRESA : {Validacoes.EmpresaNome}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"CNPJ : {Validacoes.EmpresaCnpj} "); 
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"IE : {Validacoes.EmpresaIe}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"END :{Validacoes.EmpresaEndereco}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"BAIRRO : {Validacoes.EmpresaBairro}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"CIDADE : {Validacoes.EmpresaCidade}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"UF : {Validacoes.EmpresaUf}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());
                System.Threading.Thread.Sleep(300);
                Toast.MakeText(this, "CONEXÃO REALIZADA COM SUCESSO", ToastLength.Long).Show();
                socket.Close();
            }
            catch (Exception ex)
            {
                //Toast.MakeText(this, "Não foi possivel enviar a mensagem", ToastLength.Long).Show();
                Toast.MakeText(this, "NÃO FOI POSSIVEL REALIZAR A CONEXÃO", ToastLength.Long).Show();
                // loading.Visibility = Android.Views.ViewStates.Gone;
            }
        }

    }
}
