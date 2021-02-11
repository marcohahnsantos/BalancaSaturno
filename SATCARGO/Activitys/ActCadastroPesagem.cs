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

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroPesagem", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroPesagem : AppCompatActivity
    {
        string[] selecaocliente;
        Spinner spinnercliente;
        public ArrayAdapter adapterccliente { get; set; }

        string[] selecaoveiculos;
        Spinner spinnerveiculo;
        public ArrayAdapter adapterveiculo { get; set; }

        string[] selecaoprodutos;
        Spinner spinnerproduto;
        public ArrayAdapter adapterproduto { get; set; }


        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;
        private Clientes.CarredaDadosClientes item;
        private Veiculos.CarredaDadosVeiculos itemveiculos;
        private Produtos.CarredaDadosProdutos itemprodutos;
        string firstItemcliente = "";
        string firstItemveiculo = "";
        string firstItemproduto = "";
        string Fecharthread = "N";
        private Thread threadBalancaPesagem;
        TextView TxtPeso;
        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        TextView TxtProgress;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem);
            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO DE PESAGEM";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            spinnercliente = FindViewById<Spinner>(Resource.Id.SpinnerCliente);
            spinnerveiculo = FindViewById<Spinner>(Resource.Id.SpinnerVeiculo);
            spinnerproduto = FindViewById<Spinner>(Resource.Id.SpinnerProduto);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairPesagem);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarPesagem);
            TxtPeso = FindViewById<TextView>(Resource.Id.Txtpeso);
            progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.list_progress);
            progressBar.Visibility = Android.Views.ViewStates.Visible;
            TxtProgress = FindViewById<TextView>(Resource.Id.TxtAguardeProgress);
            TxtProgress.Visibility = Android.Views.ViewStates.Visible;



            Fecharthread = "N";





            var NomesClientes = CarregaCliente();
            if (NomesClientes != null)
            {
                selecaocliente = new string[NomesClientes.Count];
                for (int i = 0; NomesClientes.Count > i; i++)
                {
                    selecaocliente[i] = NomesClientes[i].ToString();
                }
                adapterccliente = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaocliente);
                spinnercliente.Adapter = adapterccliente;
            }

            var NomesVeiculos = CarregaVeiculos();
            if (NomesVeiculos != null)
            {
                selecaoveiculos = new string[NomesVeiculos.Count];
                for (int i = 0; NomesVeiculos.Count > i; i++)
                {
                    selecaoveiculos[i] = NomesVeiculos[i].ToString();
                }
                adapterveiculo = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaoveiculos);
                spinnerveiculo.Adapter = adapterveiculo;
            }
            var NomesProdutos = CarregaProdutos();
            if (NomesProdutos != null)
            {
                selecaoprodutos = new string[NomesProdutos.Count];
                for (int i = 0; NomesProdutos.Count > i; i++)
                {
                    selecaoprodutos[i] = NomesProdutos[i].ToString();
                }
                adapterproduto = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaoprodutos);
                spinnerproduto.Adapter = adapterproduto;
            }
            //=================================================================================//
            spinnercliente.ItemSelected += (s, e) =>
            {
                firstItemcliente = spinnercliente.SelectedItem.ToString();
                if (firstItemcliente.Equals(spinnercliente.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
            spinnerveiculo.ItemSelected += (s, e) =>
            {
                firstItemveiculo = spinnerveiculo.SelectedItem.ToString();
                if (firstItemveiculo.Equals(spinnerveiculo.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
            spinnerproduto.ItemSelected += (s, e) =>
            {
                firstItemproduto = spinnerproduto.SelectedItem.ToString();
                if (firstItemproduto.Equals(spinnerproduto.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
            //=================================================================================//
            this.threadBalancaPesagem = new Thread(ProcessoBalancaPesagem);
            if (this.threadBalancaPesagem != null)
            {
                this.threadBalancaPesagem.Start();
                Validacoes.EstadoThread = "START";
            }
            CarregaListaPesagem();
            //========================//
            //        SAIR            //
            //========================//
            BtnSair.Click += delegate
            {
                Fecharthread = "S";
                threadBalancaPesagem.Interrupt();
                Finish();
                this.Dispose();
            };
            //========================//
            //        SALVAR          //
            //========================//
            BtnSalvar.Click += delegate
            {
                //==================================//
                //       Valida Peso Estavel        //
                //==================================//
                if (TxtPeso.CurrentTextColor==(Android.Graphics.Color.Red))
                {
                    Toast.MakeText(this, "PESO NÃO ESTÁ ESTAVEL!", ToastLength.Long).Show();
                    return;
                }
                //=========================//
                //     Capturando Dados    //
                //=========================//
                //        Veiculos         //
                //=========================//
                String[] veiculos = firstItemveiculo.Split("-");
                int id_veiculo = int.Parse(veiculos[0]);
                string placa_veiculo = veiculos[1] + "-" + veiculos[2];
                //=========================//
                //        Clientes         //
                //=========================//
                string[] clientes = firstItemcliente.Split("-");
                int id_cliente = int.Parse(clientes[0]);
                string nome_cliente = clientes[1].ToString();
                //=========================//
                //        Produtos         //
                //=========================//
                string[] produtos = firstItemproduto.Split("-");
                int id_produto = int.Parse(produtos[0]);
                string nome_produto = produtos[1].ToString();
                string Data = System.DateTime.Now.ToShortDateString();
                string Hora = System.DateTime.Now.ToShortTimeString();


                string Valores = id_veiculo + ",'" +
                                     placa_veiculo + "'," +
                                     id_cliente + ",'" +
                                     nome_cliente + "'," +
                                     id_produto + ",'" +
                                     nome_produto + "'," +
                                     Validacoes.Peso1 + "," +
                                     Validacoes.Peso2 + "," +
                                     Validacoes.Peso3 + "," +
                                     Validacoes.Peso4 + "," +
                                     Validacoes.Peso5 + "," +
                                     Validacoes.Peso6 + "," +
                                     int.Parse(TxtPeso.Text) + ",'" +
                                     Data + "','" +
                                     Hora + "'";
                string Campos = "ID_VEICULO," +
                                "VEICULO," +
                                "ID_CLIENTE," +
                                "CLIENTE," +
                                "ID_PRODUTO," +
                                "PRODUTO," +
                                "PESO_PLAT1," +
                                "PESO_PLAT2," +
                                "PESO_PLAT3," +
                                "PESO_PLAT4," +
                                "PESO_PLAT5," +
                                "PESO_PLAT6," +
                                "PESO_TOTAL," +
                                "DATA_CADASTRO," +
                                "HORA_CADASTRO";

                string sSQLQuery = "INSERT INTO " +
                "PESAGEM_REALIZADA " + "(" + Campos + ") " +
                "VALUES(" + Valores + ");";
                sqldTemp.ExecSQL(sSQLQuery);
                Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();

                CarregaListaPesagem();
            };
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }



        #region [FUNCOES]
        public async void 
            MensagemAguarde()
        {
            //using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            //{
            //    await System.Threading.Tasks.Task.Delay(500);
            //}

        }
        private void ProcessoBalancaPesagem()
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
                    if (adaptador?.IsEnabled == false)
                    {
                        var enableBtIntent = "ok";
                    }
                    var address = apa[0].Address;

                    this.AtualizaBalanca1(Validacoes.BSocket[0]);
                    Validacoes.BSocket[0].Close();
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
                socket1.Close();
                socket1.Dispose();
                Thread.Sleep(150);
                socket1 = Validacoes.VerificaDeviceAtivo(socket1);
                socket1.Connect();
                Validacoes.VerificaStatusPlafaforma(socket1, 1);



                if (Validacoes.Nrplataformas > 1)
                {
                    socket1.Close();
                    AtualizaBalanca2(socket1);
                }
                else
                {
                    if (Validacoes.Estabilidade1 == "E" )
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }

                    int Pesototal = Validacoes.Peso1 +
                          Validacoes.Peso2 +
                          Validacoes.Peso3 +
                          Validacoes.Peso4 +
                          Validacoes.Peso5 +
                          Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket1.Close();

                    progressBar.Visibility = Android.Views.ViewStates.Invisible;
                    TxtProgress.Visibility = Android.Views.ViewStates.Invisible;

                    AtualizaBalanca1(socket1);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
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
                Validacoes.VerificaStatusPlafaforma(socket2, 2);

                
                if (Validacoes.Nrplataformas > 2)
                {
                    AtualizaBalanca3(socket2);
                }
                else
                {
                    if (Validacoes.Estabilidade1 == "E" &&
                     Validacoes.Estabilidade2 == "E")
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }
                    int Pesototal = Validacoes.Peso1 +
                         Validacoes.Peso2 +
                         Validacoes.Peso3 +
                         Validacoes.Peso4 +
                         Validacoes.Peso5 +
                         Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket2.Close();
                    AtualizaBalanca1(socket2);
                }

            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
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
                Validacoes.VerificaStatusPlafaforma(socket3, 3);


                if (Validacoes.Nrplataformas > 3)
                {
                    AtualizaBalanca4(socket3);
                }
                else
                {
                    if (Validacoes.Estabilidade1 == "E" &&
                     Validacoes.Estabilidade2 == "E" &&
                     Validacoes.Estabilidade3 == "E")
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }
                    socket3.Close();
                    int Pesototal = Validacoes.Peso1 +
                   Validacoes.Peso2 +
                   Validacoes.Peso3 +
                   Validacoes.Peso4 +
                   Validacoes.Peso5 +
                   Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket3.Close();
                    AtualizaBalanca1(socket3);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
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
                Validacoes.VerificaStatusPlafaforma(socket4, 4);



                
                if (Validacoes.Nrplataformas > 4)
                {
                    AtualizaBalanca5(socket4);
                }
                else
                {
                    if (Validacoes.Estabilidade1 == "E" &&
                     Validacoes.Estabilidade2 == "E" &&
                     Validacoes.Estabilidade3 == "E" &&
                     Validacoes.Estabilidade4 == "E")
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }
                    socket4.Close();
                    int Pesototal = Validacoes.Peso1 +
                    Validacoes.Peso2 +
                    Validacoes.Peso3 +
                    Validacoes.Peso4 +
                    Validacoes.Peso5 +
                    Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket4.Close();
                    AtualizaBalanca1(socket4);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
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
                Validacoes.VerificaStatusPlafaforma(socket5, 5);


                
                if (Validacoes.Nrplataformas > 5)
                {
                    AtualizaBalanca6(socket5);
                }
                else
                {
                    if (Validacoes.Estabilidade1 == "E" &&
                     Validacoes.Estabilidade2 == "E" &&
                     Validacoes.Estabilidade3 == "E" &&
                     Validacoes.Estabilidade4 == "E" &&
                     Validacoes.Estabilidade5 == "E")
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }
                    socket5.Close();
                    int Pesototal = Validacoes.Peso1 +
                    Validacoes.Peso2 +
                    Validacoes.Peso3 +
                    Validacoes.Peso4 +
                    Validacoes.Peso5 +
                    Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                    socket5.Close();
                    AtualizaBalanca1(socket5);
                }
            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
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
                Validacoes.VerificaStatusPlafaforma(socket6, 6);

                if (Validacoes.Estabilidade1 == "E" &&
                     Validacoes.Estabilidade2 == "E" &&
                     Validacoes.Estabilidade3 == "E" &&
                     Validacoes.Estabilidade4 == "E" &&
                     Validacoes.Estabilidade5 == "E" &&
                     Validacoes.Estabilidade6 == "E")
                {
                    TxtPeso.SetTextColor(Android.Graphics.Color.Green);
                }
                else
                {
                    TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                }

                socket6.Close();
                int Pesototal = Validacoes.Peso1 +
                Validacoes.Peso2 +
                Validacoes.Peso3 +
                Validacoes.Peso4 +
                Validacoes.Peso5 +
                Validacoes.Peso6;
                RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal));
                socket6.Close();
                AtualizaBalanca1(socket6);

            }
            catch (Exception ex)
            {
                if (Fecharthread == "S")
                {
                    threadBalancaPesagem.Interrupt();
                }
                else
                {
                    if (socket6.IsConnected == true) socket6.Close();
                    AtualizaBalanca1(socket6);
                }
            }
        }
        public List<string> CarregaCliente()
        {

            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " NOME " +
             " FROM CLIENTES ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> clientes = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    item = new Clientes.CarredaDadosClientes();
                    item.Id = icursorTemp.GetString(0);
                    item.Nome = icursorTemp.GetString(1);
                    clientes.Add(item.Id.PadLeft(6, '0') + "-" + item.Nome);
                }
                return clientes;
            }
            return null;
        }



        public List<string> CarregaVeiculos()
        {
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " PLACA,MONTADORA " +
             " FROM VEICULOS ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> veiculos = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemveiculos = new Veiculos.CarredaDadosVeiculos();
                    itemveiculos.Id = icursorTemp.GetString(0);
                    itemveiculos.Placa = icursorTemp.GetString(1);
                    itemveiculos.Montadora = icursorTemp.GetString(2);
                    veiculos.Add(itemveiculos.Id.PadLeft(6, '0') + " - "
                                 + itemveiculos.Placa + " - " +
                                 itemveiculos.Montadora);
                }
                return veiculos;
            }
            return null;
        }
        public List<string> CarregaProdutos()
        {
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " PRODUTO,VALOR " +
             " FROM PRODUTOS ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> produtos = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemprodutos = new Produtos.CarredaDadosProdutos();
                    itemprodutos.Id = icursorTemp.GetString(0);
                    itemprodutos.Produto = icursorTemp.GetString(1);
                    itemprodutos.Valor = icursorTemp.GetString(2);
                    produtos.Add(itemprodutos.Id.PadLeft(6, '0') + "-"
                                 + itemprodutos.Produto + "-" +
                                 itemprodutos.Valor);
                }
                return produtos;
            }
            return null;
        }

        void CarregaListaPesagem()
        {
            Android.Database.ICursor icursorTemp = null;
            string Data = System.DateTime.Now.ToShortDateString();
            string Hora1 = "00:00:00";
            string Hora2 = "23:59:59";

            string sSQLQuery = "SELECT _id," +
            " DATA_CADASTRO, " +
            " HORA_CADASTRO, " +
            " VEICULO, " +
            " PESO_TOTAL " +
            " FROM PESAGEM_REALIZADA "+
            $" where DATA_CADASTRO='{Data}' and HORA_CADASTRO BETWEEN '{Hora1}' and '{Hora2}'";



            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


            int ValorCursor = icursorTemp.Count;
            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemPesagem = new CarredaDadosPesagem();

                    itemPesagem.Id = icursorTemp.GetString(0);
                    itemPesagem.Data = icursorTemp.GetString(1);
                    itemPesagem.Hora = icursorTemp.GetString(2);
                    itemPesagem.Placa = icursorTemp.GetString(3);
                    itemPesagem.Peso_Total = icursorTemp.GetString(4);
                    char pad = '0';



                    nomes[i] = itemPesagem.Data + " " + itemPesagem.Hora + "         " +
                        itemPesagem.Placa.ToString() + "                   " +
                        itemPesagem.Peso_Total + "";

                }
                ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, nomes);

                Android.Widget.ListView listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaCadastroPesagem);
                listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaCadastroPesagem);

                listview.Adapter = itemsAdapter;


            }
        }


        public class CarredaDadosPesagem
        {
            public string Id { get; set; }
            public string Placa { get; set; }
            public string Peso_Total { get; set; }
            public string Data { get; set; }
            public string Hora { get; set; }
            private SQLiteDatabase sqldTemp;
            private string sSQLQuery;
            BancoDados mdTemp;
        }



        #endregion

    }
}