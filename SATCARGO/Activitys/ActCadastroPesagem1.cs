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
using Java.Net;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroPesagem", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroPesagem1 : AppCompatActivity
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
        private Thread threadBalancaPesagem;
        private System.Threading.Thread threadEnviaPeso;
        TextView TxtPeso;
        TextView TxtTensao;
        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        int ContaTensao = 0;
        TextView TxtProgress;
        BluetoothSocket[] socket = new BluetoothSocket[1];
        public EditText Motorista { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem1);
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
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairPesagem);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarPesagem);
            TxtPeso = FindViewById<TextView>(Resource.Id.Txtpeso);
            TxtTensao = FindViewById<TextView>(Resource.Id.TxtTensao1);
            //=================================================================================//
            Validacoes.CliqueSaida = false;
            ProcessoBalanca();
            //AtualizaTensao();
            Thread.Sleep(500);
            TxtPeso.SetTextColor(Android.Graphics.Color.DarkGreen);

            this.threadBalancaPesagem = new Thread(AtualizaBalanca1);
            if (this.threadBalancaPesagem != null)
            {
                this.threadBalancaPesagem.Start();
                Validacoes.EstadoThread = "START";
            }
            Thread.Sleep(1000);
            this.threadEnviaPeso = new System.Threading.Thread(AtualizaPeso);
            if (this.threadEnviaPeso != null)
            {
                this.threadEnviaPeso.Start();
                Validacoes.EstadoThread = "START";
            }
            //========================//
            //        SAIR            //
            //========================//
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                Validacoes.CliqueSaida = true;
                this.threadBalancaPesagem.Abort();
                threadEnviaPeso.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            };
            //========================//
            //        SALVAR          //
            //========================//
            BtnSalvar.Click += delegate
            {

                if (TxtPeso.CurrentTextColor == (Android.Graphics.Color.Red))
                { 
                    Toast.MakeText(this, "PESO NÃO ESTÁ ESTAVEL!", ToastLength.Long).Show();
                    return;
                }
                this.threadBalancaPesagem.Abort();
                this.threadEnviaPeso.Abort();

                Aguarde();

                if (TxtPeso.Text == "-------------")
                {
                    Toast.MakeText(this, "SEM COMUNICAÇÃO COM A PLATAFORMA", ToastLength.Long).Show();
                    Aguarde();
                    BtnSalvar.Enabled = false;
                    this.threadBalancaPesagem.Abort();
                    threadEnviaPeso.Abort();
                    socket[0].Close();
                    socket[0].Dispose();
                    //Validacoes.BSocket[0].Close();
                    Validacoes.BSocket[0].Dispose();
                    Finish();
                }
                else
                {
                    Validacoes.CliqueSaida = true;
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(TxtPeso.Text.Replace("kg", ""));
                    Aguarde();
                    BtnSalvar.Enabled = false;
                    this.threadBalancaPesagem.Abort();
                    threadEnviaPeso.Abort();
                    socket[0].Close();
                    Validacoes.BSocket[0].Close();
                    Validacoes.BSocket[0].Dispose();
                    Finish();
                    StartActivity(typeof(ActCadastroPesagem1_1));
                }
            };
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
                Thread.Sleep(500);
                BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
                Validacoes.AdaptadorBluetooth = adaptador;
                ICollection<BluetoothDevice> aparelhos = Validacoes.AdaptadorBluetooth.BondedDevices;
                BluetoothDevice[] apa = new BluetoothDevice[aparelhos.Count];
                ParcelUuid[] chaves;
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
                        Validacoes.AdaptadorBluetooth.CancelDiscovery();
                        Validacoes.BSocket[0] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[0].Uuid);
                        Thread.Sleep(1000);
                        break;
                    }
                    i++;
                }



                var address = apa[0].Address;
                Thread.Sleep(100);
                if (Validacoes.BSocket[0].IsConnected == false)
                {
                    Validacoes.BSocket[0].Connect();
                }
            }
            catch (System.Exception erro)
            {
                Validacoes.CliqueSaida = true;
                Toast.MakeText(this, "FALHA DE COMUNICACAO !", ToastLength.Long).Show();
                Finish();
                Validacoes.EstadoConexao = "NAO";
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }


        #region [FUNCOES]
        //public async void
        //MensagemAguarde()
        //{
        //    //using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
        //    //{
        //    //    await System.Threading.Tasks.Task.Delay(500);
        //    //}

        //}

        private void AtualizaPeso()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);


                    int Pesototal = Validacoes.Peso1 ;
                    if (Validacoes.ErroPlat1 == true)
                    {
                        RunOnUiThread(() => TxtPeso.Text = Validacoes.MensagemerroPlat1);
                        Validacoes.Peso1 = 0;
                    }
                    else
                    {
                        Validacoes.Peso1 = Validacoes.DivisaoPeso20(Validacoes.Peso1);
                        RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso1)) + " kg");
                       
                    }


                    if (Validacoes.Tensao1 != "")
                    {
                        if (Validacoes.ErroPlat1 == false)
                        {
                            if (ContaTensao == 10)
                            {
                                RunOnUiThread(() => TxtTensao.Text = "-----");
                                ContaTensao = ContaTensao + 1;
                            }
                            else
                            {
                                RunOnUiThread(() => TxtTensao.Text = Convert.ToString(Validacoes.Tensao1) + " VDC");
                                ContaTensao = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat1 == true)
                            if (ContaTensao == 10)
                            {
                                RunOnUiThread(() => TxtTensao.Text = "-----");
                                ContaTensao = ContaTensao + 1;
                            }
                            else
                            {
                                RunOnUiThread(() => TxtTensao.Text = Convert.ToString(Validacoes.Tensao1) + " VDC");
                                ContaTensao = 0;
                            }
                    }
                }
            }
            catch (System.Exception ex)
            {
                //threadBalanca1.Abort();
            }
        }
        
        
        private void AtualizaBalanca1()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(Validacoes.TempoCapturaPeso * 1000);
                    if (TxtPeso.Text != "-------------")
                    {
                        Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                        int Pesototal = Convert.ToInt32(TxtPeso.Text.Replace("kg", "").Trim());
                        //if (Validacoes.ValorPesoTotalAnt == Pesototal)
                        //{
                        //    TxtPeso.SetTextColor(Android.Graphics.Color.DarkGreen);
                        //}
                        //else
                        //{
                        //    TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                        //}
                        Validacoes.ValorPesoTotalAnt = Convert.ToInt32(TxtPeso.Text.Replace("kg", "").Trim());
                    }    
              
                    if (Validacoes.CliqueSaida == true)
                        break;
                }
            }
            catch (System.Exception ex)
            {
                if(Validacoes.CliqueSaida==false)
                    AtualizaBalanca1();
              
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
        public async void Aguarde()
        {

            using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(5000);
            }

        }
        protected override void OnStop()
        {
            if (Validacoes.CliqueSaida==false)
            {
                Validacoes.CliqueSaida = true;
                this.threadBalancaPesagem.Abort();
                threadEnviaPeso.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            }
                    
            base.OnStop();
        }

        #endregion

    }
}