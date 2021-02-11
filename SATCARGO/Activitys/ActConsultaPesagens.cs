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
using Android.Runtime;
using Android.Views.InputMethods;
using SATCARGO.Model;
using System.Threading;
using Xamarin.Forms;
using Acr.UserDialogs;
using Android;
using SATCARGO.Funcoes;
using System.Drawing;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActcadastroPesagens", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActConsultaPesagens : AppCompatActivity
    {



        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;

        private Pesagens.CarreDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        TextView _dateDisplay;
        TextView _dateDisplayFim;
        EditText _cliente;
        BluetoothSocket[] socketImpressora = new BluetoothSocket[1];
        private string requestLegacyExternalStorage;
     
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string sSQLQuery = "";
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            SetContentView(Resource.Layout.LayoutConsultaPesagem);

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CONSULTA DE PESAGENS";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock2);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;

            _dateDisplay = FindViewById<TextView>(Resource.Id.TextSelConsultaIninical);
            _dateDisplayFim = FindViewById<TextView>(Resource.Id.TextSelConsultaFim);
            _cliente = FindViewById<EditText>(Resource.Id.AutoCompleteTextViewCliente);
            Android.Widget.ImageButton BtnSelecionarData = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnDataConsulta);
            Android.Widget.ImageButton BtnSelecionarDataFinal = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnDataConsultaFinal);
            Android.Widget.ImageButton BtnReimprimir = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnReimprimirTicket);

            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnVoltar);
            Android.Support.V7.Widget.AppCompatImageButton BtnPesquisar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnPesquisarPesagem);
            Android.Support.V7.Widget.AppCompatImageButton BtnGerarCsv = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnGerarCsv);

            Android.Widget.ListView Lista = FindViewById<Android.Widget.ListView>(Resource.Id.ListaPesagens);

            

            BtnSelecionarData.Click += DateSelect_OnClick;
            {
                Android.Widget.ImageButton BtnSelAbates = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnDataConsulta);
            };
            BtnSelecionarDataFinal.Click += DateSelect1_OnClick;
            {
                Android.Widget.ImageButton BtnSelAbates1 = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnDataConsultaFinal);
            };


            BtnGerarCsv.Click += delegate
            {
                GerarCsv();
            };


            BtnReimprimir.Click += delegate
            {
                if (Lista.Count > 0)
                {
                    if (Validacoes.ValorTicket != "")
                    {
                        Android.App.AlertDialog.Builder alerta = new Android.App.AlertDialog.Builder(this);
                        alerta.SetTitle(" SATCARGO - IMPRESSÃO ");
                        alerta.SetIcon(Android.Resource.Drawable.IcInputAdd);
                        //define a mensagem
                        alerta.SetMessage($"Deseja imprimir o Ticket nº {Validacoes.ValorTicket} ?");
                        //define o botão positivo
                        alerta.SetPositiveButton("SIM", (senderAlert, args) =>
                        {
                            Imprimir(Validacoes.ValorTicket);
                            
                        });
                        //define o botão negativo
                        alerta.SetNegativeButton("Não", (senderAlert, args) =>
                        {
                            Validacoes.ValorTicket = "";
                            return;
                        });
                        Dialog dialog = alerta.Create();
                        dialog.Show();
                       
                    }
                }
            };
            Window.SetSoftInputMode(SoftInput.StateHidden);
            Lista.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e)
            {
                Validacoes.ValorTicket= nomes[e.Id].Substring(0,6);
               
            };


            BtnSair.Click += delegate
            {
                Finish();
            };
            BtnPesquisar.Click += delegate
            {
                if (_dateDisplay.Text == "Selecionar Data")
                {
                    Toast.MakeText(this, "Deve ser selecionado a data inicial", ToastLength.Short).Show();
                    return;
                }
                if (_dateDisplayFim.Text == "Selecionar Data")
                {
                    Toast.MakeText(this, "Deve ser selecionado a data final", ToastLength.Short).Show();
                    return;
                }

                DateTime DataInicial = Convert.ToDateTime(_dateDisplay.Text);
                DateTime DataFinal = Convert.ToDateTime(_dateDisplayFim.Text);

                if (DataInicial > DataFinal)
                {
                    Toast.MakeText(this, "Data Inicial deve ser maior que a data final", ToastLength.Short).Show();
                    return;
                }


                ////==============================================================================================//
                ////                             VERIFICA SE JÁ EXISTE UM ENDEREÇO GRAVADO                        //
                ////==============================================================================================//
                CarregaListaPesagens();



            };
            void CarregaListaPesagens()
            {
                
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);
                string Data = System.DateTime.Now.ToShortDateString();
                string Data1 = Convert.ToDateTime(_dateDisplay.Text).ToShortDateString();
                string Data2 = Convert.ToDateTime(_dateDisplayFim.Text).ToShortDateString();
                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT _id, " +
                " VEICULO, " +
                " PESO_TOTAL, " +
                " DATA_CADASTRO, " +
                " HORA_CADASTRO, " +
                " CLIENTE "+
                " FROM PESAGEMS_REALIZADAS " +
                $" where DATA_CADASTRO  BETWEEN '{Data1}' and '{Data2}'";

                if (_cliente.Text != "")
                {
                    sSQLQuery = "SELECT _id, " +
                    " VEICULO, " +
                    " PESO_TOTAL, " +
                    " DATA_CADASTRO, " +
                    " HORA_CADASTRO, " +
                     " CLIENTE " +
                    " FROM PESAGEMS_REALIZADAS " +
                    $" where DATA_CADASTRO  BETWEEN '{Data1}' and '{Data2}' AND CLIENTE LIKE '%{_cliente.Text}%'";
                    
                }
                
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    nomes = new string[icursorTemp.Count];
                    string NomeCliente;
                    for (int i = 0; i < icursorTemp.Count; i++)
                    {
                        icursorTemp.MoveToNext();
                        itemPesagem = new Pesagens.CarreDadosPesagem();
                        itemPesagem.Id = icursorTemp.GetString(0).PadLeft(6, '0');
                        itemPesagem.Data = icursorTemp.GetString(3).PadLeft(6, '0') + " " + icursorTemp.GetString(4);
                        itemPesagem.Veiculo = icursorTemp.GetString(1);
                        itemPesagem.Peso_total = icursorTemp.GetString(2);
                        NomeCliente = icursorTemp.GetString(5);
                        nomes[i] = itemPesagem.Id + " " + itemPesagem.Veiculo + "                                       " +
                            itemPesagem.Peso_total.PadLeft(6, ' ') + "";

                    }
                    ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSelectableListItem, nomes);
                    Lista.SetAdapter(itemsAdapter);
                    Lista.Adapter = itemsAdapter;
                }
                else
                {

                    Toast.MakeText(this, "Nenhum movimento encontrado !", ToastLength.Short).Show();


                    nomes = new string[1];
                    for (int i = 0; i < 1; i++)
                    {
                        nomes[i] = " ".ToString();
                    }


                    ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSelectableListItem, nomes);

                    Lista = FindViewById<Android.Widget.ListView>(Resource.Id.ListaPesagens);
                    Lista.SetAdapter(itemsAdapter);

                    Lista.Adapter = itemsAdapter;
                }
            }
            

            void DateSelect_OnClick(object sender, EventArgs eventArgs)
            {
                DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    _dateDisplay.Text = time.ToLongDateString();
                });
                frag.Show(FragmentManager, DatePickerFragment.TAG);
            }

            void DateSelect1_OnClick(object sender, EventArgs eventArgs)
            {
                DatePickerFragment frag1 = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    _dateDisplayFim.Text = time.ToLongDateString();
                });
                frag1.Show(FragmentManager, DatePickerFragment.TAG);
            }
            void GerarCsv()
            {
                if(Lista.Count==0)
                {
                    MensagemToast("Deve ser realizada uma pesquisa");
                    return;
                }


                string pasta = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string localizacao = Path.Combine(pasta, $"TicketCSV{System.DateTime.Now.ToShortDateString().Replace("/","_")}.csv");
                // gravar no arquivo
                StreamWriter arquivo = new StreamWriter(localizacao, false);
                string Cabecario = "DATA;HORA;CLIENTE;PLACA;PRODUTO;MOTORISTA;PESO_PLAT1;PESO_PLAT2;PESO_EIXO1;PESO_PLAT3;PESO_PLAT4;PESO_EIXO2;PESO_PLAT5;PESO_PLAT6;PESO_EIXO3;PESO_TOTAL";
                arquivo.WriteLine(Cabecario);


                for (int i = 0; i < Lista.Count; i++)
                {
                    Validacoes.ValorTicket = nomes[i].Substring(0, 6);
                    string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string sDB = Path.Combine(sLocation, "PRINCIPAL");
                    sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                    bool bIsExists = File.Exists(sDB);
                    string Data = System.DateTime.Now.ToShortDateString();
                    string Data1 = Convert.ToDateTime(_dateDisplay.Text).ToShortDateString();
                    string Data2 = Convert.ToDateTime(_dateDisplayFim.Text).ToShortDateString();
                    Android.Database.ICursor icursorTemp = null;
                    sSQLQuery = "SELECT  " +
                                "ID_CLIENTE," +
                                "CLIENTE," +
                                "ID_VEICULO," +
                                "VEICULO," +
                                "ID_PRODUTO," +
                                "PRODUTO," +
                                "MOTORISTA," +
                                "NR_PLATAFORMAS," +
                                "PESO_PLAT1," +
                                "PESO_PLAT2," +
                                "PESO_PLAT3," +
                                "PESO_PLAT4," +
                                "PESO_PLAT5," +
                                "PESO_PLAT6," +
                                "PESO_TOTAL," +
                                "DATA_CADASTRO," +
                                "HORA_CADASTRO, " +
                                "_id " +
                                $"FROM PESAGEMS_REALIZADAS WHERE _id={Convert.ToInt32(Validacoes.ValorTicket)}";



                    icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                    int ValorCursor = icursorTemp.Count;



                    if (ValorCursor > 0)
                    {
                        icursorTemp.MoveToNext();
                        Validacoes.PesagemRealizadaIdCliente = icursorTemp.GetString(0);
                        Validacoes.PesagemRealizadaCliente = icursorTemp.GetString(1);
                        Validacoes.PesagemRealizadaIdVeiculo = icursorTemp.GetString(2);
                        Validacoes.PesagemRealizadaVeiculo = icursorTemp.GetString(3);
                        Validacoes.PesagemRealizadaIdProduto = icursorTemp.GetString(4);
                        Validacoes.PesagemRealizadaProduto = icursorTemp.GetString(5);
                        Validacoes.PesagemRealizadaMotorista = icursorTemp.GetString(6);
                        Validacoes.PesagemRealizadaNrPlataformas = icursorTemp.GetString(7);
                        Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(icursorTemp.GetString(8));
                        Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(icursorTemp.GetString(9));
                        Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(icursorTemp.GetString(10));
                        Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(icursorTemp.GetString(11));
                        Validacoes.PesagemRealizadaPlat5 = Convert.ToDouble(icursorTemp.GetString(12));
                        Validacoes.PesagemRealizadaPlat6 = Convert.ToDouble(icursorTemp.GetString(13));
                        Validacoes.PesagemRealizadaTotal = Convert.ToDouble(icursorTemp.GetString(14));
                        Validacoes.PesagemRealizadaData = icursorTemp.GetString(15);
                        Validacoes.PesagemRealizadaHora = icursorTemp.GetString(16);
                        Validacoes.PesagemRealizadaId = icursorTemp.GetString(17);
                        Validacoes.NrPlataformas = Convert.ToInt32(Validacoes.PesagemRealizadaNrPlataformas);
                    }


                    System.Threading.Thread.Sleep(300);
                    //GRAVANDO ARQUIVO
                    string LinhaDados =   $"{Validacoes.PesagemRealizadaData};" +
                                          $"{Validacoes.PesagemRealizadaHora};" +
                                          $"{Validacoes.PesagemRealizadaCliente};" +
                                          $"{Validacoes.PesagemRealizadaVeiculo};" +
                                          $"{Validacoes.PesagemRealizadaProduto};" +
                                          $"{Validacoes.PesagemRealizadaMotorista};" +
                                          $"{Validacoes.PesagemRealizadaPlat1};" +
                                          $"{Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat3};" +
                                          $"{Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat5};" +
                                          $"{Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaTotal};";
                    arquivo.WriteLine(LinhaDados);
                }
                MensagemToast("ARQUIVO CSV GERADO");
                arquivo.Dispose();
            }

            void MensagemToast(string Mensagem)
            {
                Toast toast = Toast.MakeText(this, Mensagem, ToastLength.Long);
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
            }

            void Imprimir(string Tciket)
            {

                try
                {
                    Thread.Sleep(3000);
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
                        if (aparelho.Name == Validacoes.NomeImpressora)
                        {
                            Conectado = "sim";
                            chaves = aparelho.GetUuids();
                            socket[0] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[0].Uuid);
                            break;
                        }
                        i++;
                    }
                    socket[0].Connect();

                    string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string sDB = Path.Combine(sLocation, "PRINCIPAL");
                    sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                    bool bIsExists = File.Exists(sDB);
                    string Data = System.DateTime.Now.ToShortDateString();
                    string Data1 = Convert.ToDateTime(_dateDisplay.Text).ToShortDateString();
                    string Data2 = Convert.ToDateTime(_dateDisplayFim.Text).ToShortDateString();
                    Android.Database.ICursor icursorTemp = null;
                    sSQLQuery = "SELECT  " +
                                "ID_CLIENTE," +
                                "CLIENTE," +
                                "ID_VEICULO," +
                                "VEICULO," +
                                "ID_PRODUTO," +
                                "PRODUTO," +
                                "MOTORISTA," +
                                "NR_PLATAFORMAS," +
                                "PESO_PLAT1," +
                                "PESO_PLAT2," +
                                "PESO_PLAT3," +
                                "PESO_PLAT4," +
                                "PESO_PLAT5," +
                                "PESO_PLAT6," +
                                "PESO_TOTAL," +
                                "DATA_CADASTRO," +
                                "HORA_CADASTRO, " +
                                "_id " +
                                $"FROM PESAGEMS_REALIZADAS WHERE _id={Convert.ToInt32(Validacoes.ValorTicket)}";

                    Thread.Sleep(1000);

                    icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                    int ValorCursor = icursorTemp.Count;



                    if (ValorCursor > 0)
                    {
                        icursorTemp.MoveToNext();
                        Validacoes.PesagemRealizadaIdCliente = icursorTemp.GetString(0);
                        Validacoes.PesagemRealizadaCliente = icursorTemp.GetString(1);
                        Validacoes.PesagemRealizadaIdVeiculo = icursorTemp.GetString(2);
                        Validacoes.PesagemRealizadaVeiculo = icursorTemp.GetString(3);
                        Validacoes.PesagemRealizadaIdProduto = icursorTemp.GetString(4);
                        Validacoes.PesagemRealizadaProduto = icursorTemp.GetString(5);
                        Validacoes.PesagemRealizadaMotorista = icursorTemp.GetString(6);
                        Validacoes.PesagemRealizadaNrPlataformas = icursorTemp.GetString(7);
                        Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(icursorTemp.GetString(8));
                        Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(icursorTemp.GetString(9));
                        Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(icursorTemp.GetString(10));
                        Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(icursorTemp.GetString(11));
                        Validacoes.PesagemRealizadaPlat5 = Convert.ToDouble(icursorTemp.GetString(12));
                        Validacoes.PesagemRealizadaPlat6 = Convert.ToDouble(icursorTemp.GetString(13));
                        Validacoes.PesagemRealizadaTotal = Convert.ToDouble(icursorTemp.GetString(14));
                        Validacoes.PesagemRealizadaData = icursorTemp.GetString(15);
                        Validacoes.PesagemRealizadaHora = icursorTemp.GetString(16);
                        Validacoes.PesagemRealizadaId = icursorTemp.GetString(17);
                        Validacoes.NrPlataformas = Convert.ToInt32(Validacoes.PesagemRealizadaNrPlataformas);
                    }


                    var output = socket[0].OutputStream;
                    var readput = socket[0].InputStream;
                    byte[] buffer1 = new byte[3];
                    buffer1[0] = 0x1B;
                    buffer1[1] = 0x21;
                    buffer1[2] = 0x08;
                    output.Write(buffer1, 0, buffer1.Count());
                    String Cnpj = $"CNPJ : {Validacoes.EmpresaCnpj}";
                    String Ie = $"IE :{Validacoes.EmpresaIe}";
                    String CidaeUf = $"{Validacoes.EmpresaCidade } - { Validacoes.EmpresaUf}";
                    byte[] buffer = new byte[35];
                    //======================================//
                    //          CABEÇARIO                   //
                    //======================================//

                    buffer = Validacoes.Configure_linha_Centro();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaNome}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"{Cnpj}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"{Ie}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaEndereco}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaCidade} - {Validacoes.EmpresaUf}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Configure_linha_Esquerda();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"DATA/HORA : {Validacoes.PesagemRealizadaData} {Validacoes.PesagemRealizadaHora}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PLACA     :{Validacoes.PesagemRealizadaVeiculo}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PRODUTO   : {Validacoes.PesagemRealizadaProduto}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"MOTORISTA : {Validacoes.PesagemRealizadaMotorista}");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"CLIENTE   : {Validacoes.PesagemRealizadaCliente}");
                    output.Write(buffer, 0, buffer.Count());
                    //  buffer = Validacoes.Imprime_linha_Empresa($"UF            : {Validacoes.EmpresaUf}");
                    //  output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());

                    if (Validacoes.NrPlataformas == 1)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLATAFORMA 1  :  {Validacoes.PesagemRealizadaTotal.ToString()} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }
                    if (Validacoes.NrPlataformas == 2)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.PesagemRealizadaPlat1.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.PesagemRealizadaPlat2.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        double PesoEixo = Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }
                    if (Validacoes.NrPlataformas == 3)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.PesagemRealizadaPlat1.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.PesagemRealizadaPlat2.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        double PesoEixo = Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.PesagemRealizadaPlat3.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }
                    if (Validacoes.NrPlataformas == 4)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.PesagemRealizadaPlat1.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.PesagemRealizadaPlat2.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        double PesoEixo = Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.PesagemRealizadaPlat3.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.PesagemRealizadaPlat4.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        PesoEixo = Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4;
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }
                    if (Validacoes.NrPlataformas == 5)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.PesagemRealizadaPlat1.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.PesagemRealizadaPlat2.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.PesagemRealizadaPlat3.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.PesagemRealizadaPlat4.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        PesoEixo = Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4;
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.5  : {Validacoes.PesagemRealizadaPlat5.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }
                    if (Validacoes.NrPlataformas == 6)
                    {
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.PesagemRealizadaPlat1.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.PesagemRealizadaPlat2.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        double PesoEixo = Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.PesagemRealizadaPlat3.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.PesagemRealizadaPlat4.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        PesoEixo = Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4;
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.5  : {Validacoes.PesagemRealizadaPlat5.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.6  : {Validacoes.PesagemRealizadaPlat6.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                        buffer = Validacoes.Imprime_linha();
                        output.Write(buffer, 0, buffer.Count());
                        PesoEixo = Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6;
                        buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 3  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                        output.Write(buffer, 0, buffer.Count());
                    }



                    buffer = Validacoes.Configure_linha_Esquerda();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO TOTAL     {Validacoes.PesagemRealizadaTotal.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());

                    System.Threading.Thread.Sleep(300);
                    //GRAVANDO ARQUIVO
                    string pasta = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                    string localizacao = Path.Combine(pasta, $"Ticket{Validacoes.PesagemRealizadaId.PadLeft(6, '0')}.csv");
                    // gravar no arquivo
                    StreamWriter arquivo = new StreamWriter(localizacao, false);
                    string Cabecario = "EMPRESACADASTRADA;CNPJCADASTRADA;DATA;HORA;CLIENTE;PLACA;PRODUTO;MOTORISTA;PESO_PLAT1;PESO_PLAT2;PESO_EIXO1;PESO_PLAT3;PESO_PLAT4;PESO_EIXO2;PESO_PLAT5;PESO_PLAT6;PESO_EIXO3;PESO_TOTAL";
                    arquivo.WriteLine(Cabecario);
                    string LinhaDados = $"{Validacoes.EmpresaNome};{Validacoes.EmpresaCnpj};" +
                                          $"{Validacoes.PesagemRealizadaData};" +
                                          $"{Validacoes.PesagemRealizadaHora};" +
                                          $"{Validacoes.PesagemRealizadaCliente};" +
                                          $"{Validacoes.PesagemRealizadaVeiculo};" +
                                          $"{Validacoes.PesagemRealizadaProduto};" +
                                          $"{Validacoes.PesagemRealizadaMotorista};" +
                                          $"{Validacoes.PesagemRealizadaPlat1};" +
                                          $"{Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat3};" +
                                          $"{Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat5};" +
                                          $"{Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaTotal};";
                    arquivo.WriteLine(LinhaDados);

                    arquivo.Dispose();
                    //socket[0].Dispose();
                    Thread.Sleep(1000);
                    if (Validacoes.NomeImpressora != null)
                        socket[0].Close();
                    Validacoes.ValorTicket = "";


                }
                catch (Exception erro)
                {

                }
            }
        }
        protected override void OnStop()
        {

            Thread.Sleep(1000);
            Finish();
            base.OnStop();
        }

    }
    
        #region [FUNCOES]


        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    //if (item.ItemId == Android.Resource.Id.Home)
        //    //    Finish();

        //    //return base.OnOptionsItemSelected(item);
        //}
        #endregion

    }