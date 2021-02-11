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

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroPesagem", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroPesagem2 : AppCompatActivity
    {


        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;
        private Clientes.CarredaDadosClientes item;
        private Veiculos.CarredaDadosVeiculos itemveiculos;
        private Produtos.CarredaDadosProdutos itemprodutos;
        string Fecharthread = "N";
        private Thread threadBalanca1;
        private Thread threadAtualizaPesoTotal;
        private Thread threadEnviaPeso;

        TextView TxtTensao1;
        TextView TxtTensao2;
        TextView TxtPeso;
        TextView TxtPlat1;
        TextView TxtPlat2;
        TextView TxtPesoTotal;
        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        TextView TxtProgress;
        int ContaTensao1 = 0;
        int ContaTensao2 = 0;
        public bool TelaAguardeComunicacao = true;
        public Boolean erroconexao = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem2);
            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            //mdTemp = new BancoDados("PRINCIPAL");
            //mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO DE PESAGEM";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairPesagem);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarPesagem);
            TxtPeso = FindViewById<TextView>(Resource.Id.Txtpeso);
            TxtPlat1 = FindViewById<TextView>(Resource.Id.TxtPlat1);
            TxtPlat2 = FindViewById<TextView>(Resource.Id.TxtPlat2);
            TxtPesoTotal = FindViewById<TextView>(Resource.Id.TxtPesoTotal);
            TxtTensao1 = FindViewById<TextView>(Resource.Id.TxtTensao1);
            TxtTensao2 = FindViewById<TextView>(Resource.Id.TxtTensao2);
            //progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.list_progress);
            //progressBar.Visibility = Android.Views.ViewStates.Invisible;
            //TxtProgress = FindViewById<TextView>(Resource.Id.TxtAguardeProgress);
            //TxtProgress.Visibility = Android.Views.ViewStates.Invisible;
            // EditText Motorista = FindViewById<EditText>(Resource.Id.EditTextMotorista);
            Fecharthread = "N";
            Validacoes.CliqueSaida = false;
            TxtPesoTotal.SetTextColor(Android.Graphics.Color.DarkGreen);
            //=================================================================================//
            ProcessoBalanca();
            Thread.Sleep(500);
            // Validacoes.ConectaImpressora();
            this.threadBalanca1 = new Thread(AtualizaBalanca1);
            if (this.threadBalanca1 != null)
            {
                this.threadBalanca1.Start();
                Validacoes.EstadoThread = "START";
            }
            Thread.Sleep(1000);
            this.threadEnviaPeso = new System.Threading.Thread(AtualizaPeso);
            if (this.threadEnviaPeso != null)
            {
                this.threadEnviaPeso.Start();
                Validacoes.EstadoThread = "START";
            }
            Thread.Sleep(1000);
            this.threadAtualizaPesoTotal = new System.Threading.Thread(AtualizaPesoTotal);
            if (this.threadAtualizaPesoTotal != null)
            {
                this.threadAtualizaPesoTotal.Start();
                Validacoes.EstadoThread = "START";
            }
            

            //========================//
            //        SAIR            //
            //========================//
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                Validacoes.CliqueSaida = true;
                this.threadBalanca1.Abort();
                threadEnviaPeso.Abort();
                threadAtualizaPesoTotal.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            };
            //========================//
            //        SALVAR          //
            //========================//
            BtnSalvar.Click += delegate
            {

                if (TxtPeso.CurrentTextColor == (Android.Graphics.Color.Red) && TxtPesoTotal.Text != "-------------")
                {
                    Toast.MakeText(this, "PESO NÃO ESTÁ ESTAVEL!", ToastLength.Long).Show();
                    return;
                }
                this.threadBalanca1.Abort();
                this.threadEnviaPeso.Abort();
                threadAtualizaPesoTotal.Abort();
                if (TxtPesoTotal.Text == "-------------")
                {
                    Validacoes.CliqueSaida = true;
                    BtnSair.Enabled = false;
                    Toast.MakeText(this, "SEM COMUNICAÇÃO COM A PLATAFORMA", ToastLength.Long).Show();
                    Aguarde();
                    this.threadBalanca1.Abort();
                    threadEnviaPeso.Abort();
                    threadAtualizaPesoTotal.Abort();
                    Validacoes.BSocket[0].Close();
                    Validacoes.BSocket[0].Dispose();
                    Finish();
                }
                else
                {
                    Validacoes.CliqueSaida = true;
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(TxtPlat1.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(TxtPlat2.Text.Replace("kg", ""));
                    Aguarde();
                    BtnSair.Enabled = false;
                    this.threadBalanca1.Abort();
                    threadEnviaPeso.Abort();
                    threadAtualizaPesoTotal.Abort();
                    Validacoes.BSocket[0].Close();
                    Validacoes.BSocket[0].Dispose();
                    Finish();
                    StartActivity(typeof(ActCadastroPesagem1_1));
                }
            };
        }

        public async void Aguarde()
        {

            using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(5000);
            }

        }
        public async void AguardeSemComunicacao()
        {
            using (UserDialogs.Instance.Loading("SAINDO POR PERDA DE COMUNICAÇÃO", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(2000);
                this.threadBalanca1.Abort();
                threadEnviaPeso.Abort();
                threadAtualizaPesoTotal.Abort();
                TelaAguardeComunicacao = false;
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                this.Finish();
                StartActivity(typeof(ActPrincipal));
            }
        }
        public async void AguardeWait(int segundos)
        {
            using (UserDialogs.Instance.Loading($"Aguarde Perda de Comunicação...{segundos}", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(2000);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
        private void AtualizaPesoTotal()
        {
            int  Contadorerros = 0;
            while (true)
            {
                Thread.Sleep(1000);
                if (Validacoes.ErroPlat2 == true ||
                   Validacoes.ErroPlat1 == true)
                {
                   RunOnUiThread(() => TxtPesoTotal.Text = "-------------");
                   Validacoes.ValorPesoTotalAnt = 0;

                    if (TxtPlat1.Text.Substring(0, 1) != "E" && TxtPlat2.Text.Substring(0, 1) != "E")
                    {
                        Validacoes.ValorPesoTotalAnt = 0;
                        Contadorerros++;
                        Thread.Sleep(1000);
                        if (TelaAguardeComunicacao == true && Contadorerros <= 6)
                            AguardeWait(Contadorerros);

                        if (Contadorerros == 6)
                        {
                            Validacoes.CliqueSaida = true;
                            AguardeSemComunicacao();
                        }
                    }
                }
                else
                {
                    int Pesototal = Validacoes.DivisaoPeso20(Validacoes.Peso1) + Validacoes.DivisaoPeso20(Validacoes.Peso2);

                    if (Pesototal != Validacoes.ValorPesoTotalAnt || TxtPesoTotal.Text == "-------------")
                    {
                        Thread.Sleep(Validacoes.TempoCapturaPeso * 1000);
                        RunOnUiThread(() => TxtPesoTotal.Text = Convert.ToString(Pesototal) + " kg");
                    }
                    Validacoes.ValorPesoTotalAnt = Pesototal;
                    Contadorerros = 0;
                }
            }
        }
        private void AtualizaBalanca1()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                    Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                    if (Validacoes.CliqueSaida == true)
                        break;
                }
            }
            catch (System.Exception ex)
            {
                if (Validacoes.CliqueSaida == false)
                    AtualizaBalanca1();
            }
        }

        private void AtualizaPeso()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    if (Validacoes.ErroPlat1 == true)
                    {
                        RunOnUiThread(() => TxtPlat1.Text = Validacoes.MensagemerroPlat1);
                        Validacoes.Peso1 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat1.Text = Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso1) + " kg"));
                        Validacoes.Peso1 = Validacoes.DivisaoPeso20(Validacoes.Peso1);
                    }
                    if (Validacoes.ErroPlat2 == true)
                    {
                        RunOnUiThread(() => TxtPlat2.Text = Validacoes.MensagemerroPlat2);
                        Validacoes.Peso2 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat2.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso2))) + " kg");
                        Validacoes.Peso2 = Validacoes.DivisaoPeso20(Validacoes.Peso2);
                    }


                    int Pesototal = Validacoes.Peso1 + Validacoes.Peso2;
                    
                    RunOnUiThread(() => TxtPeso.Text = Convert.ToString(Pesototal) + " kg");
                   




                    if (Validacoes.Tensao1 != "")
                    {
                        if (Validacoes.ErroPlat1 == true)
                        {
                            if (ContaTensao1 == 10)
                            {
                                RunOnUiThread(() => TxtTensao1.Text = "-----");
                            }

                            ContaTensao1 = ContaTensao1 + 1;
                        }
                        else
                        {
                            {
                                RunOnUiThread(() => TxtTensao1.Text = Convert.ToString(Validacoes.Tensao1) + " VDC");
                                ContaTensao1 = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat1 == true)
                        {
                            RunOnUiThread(() => TxtTensao1.Text = "-----");
                        }
                        else
                        {
                            if(Validacoes.Tensao1!="") 
                                RunOnUiThread(() => TxtTensao1.Text = Convert.ToString(Validacoes.Tensao1) + " VDC");
                        }
                    }

                    if (Validacoes.Tensao2 != "")
                    {
                        if (Validacoes.ErroPlat2 == true)
                        {
                            if (ContaTensao2 == 10)
                            {
                                RunOnUiThread(() => TxtTensao2.Text = "-----");
                            }

                            ContaTensao2 = ContaTensao2 + 1;
                        }
                        else
                        {
                            {
                                RunOnUiThread(() => TxtTensao2.Text = Convert.ToString(Validacoes.Tensao2) + " VDC");
                                ContaTensao2 = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat2 == true)
                        { 
                            RunOnUiThread(() => TxtTensao2.Text = "-----");
                        }
                        else
                        {
                            if (Validacoes.Tensao2 != "")
                                RunOnUiThread(() => TxtTensao2.Text = Convert.ToString(Validacoes.Tensao2) + " VDC");
                        }
                    }


                    
                    

                }
            }
            catch (System.Exception ex)
            {
                //threadBalanca1.Abort();
            }
        }

        #region [FUNCOES]
        public async void MensagemAguarde()
        {
            //using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            //{
            //    await System.Threading.Tasks.Task.Delay(500);
            //}

        }

        private void ProcessoBalanca()
        {
            BancoDados banco = new BancoDados();
            banco.PesquisaAparelho();
            try
            {
                Thread.Sleep(500);
                BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
                Validacoes.AdaptadorBluetooth = adaptador;
                ICollection<BluetoothDevice> aparelhos = Validacoes.AdaptadorBluetooth.BondedDevices;
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
        protected override void OnStop()
        {
            if (Validacoes.CliqueSaida == false)
            {
                Validacoes.CliqueSaida = true;
                this.threadBalanca1.Abort();
                threadEnviaPeso.Abort();
                threadAtualizaPesoTotal.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            }

            base.OnStop();
        }
    }
}

