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
    public class ActCadastroPesagem4 : AppCompatActivity
    {
        
        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;
        string Fecharthread = "N";
        private Thread threadBalanca1;
        private Thread threadEnviaPeso;
        private Thread threadAtualizaPesoTotal;
        TextView TxtPesoTotal4;
        TextView TxtPlat1_4;
        TextView TxtPlat2_4;
        TextView TxtPlat3_4;
        TextView TxtPlat4_4;
        TextView TxtEixo_1_2_4;
        TextView TxtEixo_3_4_4;
        TextView TxtSoma1_3;
        TextView TxtSoma2_4;
        TextView TxtTensao1;
        TextView TxtTensao2;
        TextView TxtTensao3;
        TextView TxtTensao4;
        int ContaTensao1 = 0;
        int ContaTensao2 = 0;
        int ContaTensao3 = 0;
        int ContaTensao4 = 0;

        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        public Boolean erroconexao = false;
        TextView TxtProgress;
        public bool TelaAguardeComunicacao = true;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem4);
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
            TxtPesoTotal4 = FindViewById<TextView>(Resource.Id.TxtPesoTotal4);
            TxtPlat1_4 = FindViewById<TextView>(Resource.Id.TxtPlat1_4);
            TxtPlat2_4 = FindViewById<TextView>(Resource.Id.TxtPlat2_4);
            TxtPlat3_4 = FindViewById<TextView>(Resource.Id.TxtPlat3_4);
            TxtPlat4_4 = FindViewById<TextView>(Resource.Id.TxtPlat4_4);

            TxtEixo_1_2_4 = FindViewById<TextView>(Resource.Id.TxtpesoEixo1_2);
            TxtEixo_3_4_4 = FindViewById<TextView>(Resource.Id.TxtpesoEixo3_4);
            TxtSoma1_3 = FindViewById<TextView>(Resource.Id.SomaTxtPlat1_3_4);
            TxtSoma2_4 = FindViewById<TextView>(Resource.Id.SomaTxtPlat2_4_4);

            TxtTensao1 = FindViewById<TextView>(Resource.Id.TxtTensao1_4);
            TxtTensao2 = FindViewById<TextView>(Resource.Id.TxtTensao2_4);
            TxtTensao3 = FindViewById<TextView>(Resource.Id.TxtTensao3_4);
            TxtTensao4 = FindViewById<TextView>(Resource.Id.TxtTensao4_4);
            TxtPesoTotal4.SetTextColor(Android.Graphics.Color.DarkGreen);



            // progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.list_progress);
            //progressBar.Visibility = Android.Views.ViewStates.Visible;
            // TxtProgress = FindViewById<TextView>(Resource.Id.TxtAguardeProgress);
            //TxtProgress.Visibility = Android.Views.ViewStates.Visible;
            // EditText Motorista = FindViewById<EditText>(Resource.Id.EditTextMotorista);
            Fecharthread = "N";
            Validacoes.CliqueSaida = false;
            Validacoes.ValorPesoTotalAnt = 0;
            //=================================================================================//
            ProcessoBalanca();
            Thread.Sleep(500);
            this.threadBalanca1 = new Thread(AtualizaBalanca1);
            this.threadBalanca1.Start();
            Validacoes.EstadoThread = "START";
            Thread.Sleep(1000);
            this.threadEnviaPeso = new System.Threading.Thread(AtualizaPeso);
            this.threadEnviaPeso.Start();
            Thread.Sleep(1000);
            this.threadAtualizaPesoTotal = new System.Threading.Thread(AtualizaPesoTotal);
            this.threadAtualizaPesoTotal.Start();
            //========================//
            //        SAIR            //
            //========================//
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                Validacoes.CliqueSaida = true;
                this.threadBalanca1.Abort();
                threadEnviaPeso.Abort();
                this.threadAtualizaPesoTotal.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            };
            //========================//
            //        SALVAR          //
            //========================//
            BtnSalvar.Click += delegate
            {

               
                if (TxtPesoTotal4.CurrentTextColor == (Android.Graphics.Color.Red) && TxtPesoTotal4.Text != "-------------")
                {
                    Toast.MakeText(this, "PESO NÃO ESTÁ ESTAVEL!", ToastLength.Long).Show();
                    return;
                }
                this.threadBalanca1.Abort();
                this.threadEnviaPeso.Abort();
                this.threadAtualizaPesoTotal.Abort();
                if (TxtPesoTotal4.Text == "-------------")
                {
                    Validacoes.CliqueSaida = true;
                    Toast.MakeText(this, "SEM COMUNICAÇÃO COM A PLATAFORMA", ToastLength.Long).Show();
                    Aguarde();
                    BtnSalvar.Enabled = false;
                    this.threadBalanca1.Abort();
                    threadEnviaPeso.Abort();
                    this.threadAtualizaPesoTotal.Abort();
                    Validacoes.BSocket[0].Close();
                    Validacoes.BSocket[0].Dispose();
                    Finish();
                }
                else
                {
                    Validacoes.CliqueSaida = true;
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(TxtPlat1_4.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(TxtPlat2_4.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(TxtPlat3_4.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(TxtPlat4_4.Text.Replace("kg", ""));
                    Aguarde();
                    BtnSalvar.Enabled = false;
                    this.threadBalanca1.Abort();
                    threadEnviaPeso.Abort();
                    this.threadAtualizaPesoTotal.Abort();
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
                erroconexao = true;
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
        public async void MensagemAguarde()
        {
            //using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            //{
            //    await System.Threading.Tasks.Task.Delay(500);
            //}
        }
        public async void Aguarde()
        {
            TelaAguardeComunicacao = false;
            using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(5000);
            }

        }
        public async void AguardeWait(int segundos)
        {

            using (UserDialogs.Instance.Loading($"Aguarde Perda de Comunicação...{segundos}", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(2000);
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
      
        private void AtualizaBalanca1()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                    Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                    Validacoes.VerificaStatusPlafaforma3(Validacoes.BSocket[0]);
                    Validacoes.VerificaStatusPlafaforma4(Validacoes.BSocket[0]);
                

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
                            if (Validacoes.Tensao1 != "")
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

                    if (Validacoes.Tensao3 != "")
                    {
                        if (Validacoes.ErroPlat3 == true)
                        {
                            if (ContaTensao3 == 10)
                            {
                                RunOnUiThread(() => TxtTensao3.Text = "-----");
                            }
                            ContaTensao3 = ContaTensao3 + 1;
                        }
                        else
                        {
                            {
                                RunOnUiThread(() => TxtTensao3.Text = Convert.ToString(Validacoes.Tensao3) + " VDC");
                                ContaTensao3 = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat3 == true)
                        {
                            RunOnUiThread(() => TxtTensao3.Text = "-----");
                        }
                        else
                        {
                            if (Validacoes.Tensao3 != "")
                                RunOnUiThread(() => TxtTensao3.Text = Convert.ToString(Validacoes.Tensao3) + " VDC");
                        }
                    }
               
                    if (Validacoes.Tensao4 != "")
                    {
                        if (Validacoes.ErroPlat4 == true)
                        {
                            if (ContaTensao4 == 10)
                            {
                                RunOnUiThread(() => TxtTensao4.Text = "-----");
                            }
                            ContaTensao4 = ContaTensao4 + 1;
                        }
                        else
                        {
                            {
                                RunOnUiThread(() => TxtTensao4.Text = Convert.ToString(Validacoes.Tensao4) + " VDC");
                                ContaTensao4 = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat4 == true)
                        {
                            RunOnUiThread(() => TxtTensao4.Text = "-----");
                        }
                        else
                        {
                            if (Validacoes.Tensao4 != "")
                                RunOnUiThread(() => TxtTensao4.Text = Convert.ToString(Validacoes.Tensao4) + " VDC");
                        }
                    }
            


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
        private void AtualizaPesoTotal()
        {
            int Contadorerros = 0;
            while (true)
            {
                Thread.Sleep(1000);
                if (Validacoes.ErroPlat2 == true ||
                   Validacoes.ErroPlat1 == true ||
                   Validacoes.ErroPlat3 == true || Validacoes.ErroPlat4 == true)
                {
                    RunOnUiThread(() => TxtPesoTotal4.Text = "-------------");
                    Validacoes.ValorPesoTotalAnt = 0;
                    if (erroconexao == false)
                    {
                        RunOnUiThread(() => TxtPesoTotal4.Text = "-------------");
                        if (TxtPlat1_4.Text.Substring(0, 1) != "E" && TxtPlat2_4.Text.Substring(0, 1) != "E" &&
                            TxtPlat3_4.Text.Substring(0, 1) != "E" && TxtPlat4_4.Text.Substring(0, 1) != "E")
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
                }
                else
                {
                    int Pesototal = Validacoes.DivisaoPeso20(Validacoes.Peso1) + Validacoes.DivisaoPeso20(Validacoes.Peso2) 
                                    + Validacoes.DivisaoPeso20(Validacoes.Peso3) + Validacoes.DivisaoPeso20(Validacoes.Peso4);

                    if (Pesototal != Validacoes.ValorPesoTotalAnt || TxtPesoTotal4.Text == "-------------")
                    {
                        Thread.Sleep(Validacoes.TempoCapturaPeso * 1000);
                        RunOnUiThread(() => TxtPesoTotal4.Text = Convert.ToString(Pesototal) + " kg");
                    }
                    Validacoes.ValorPesoTotalAnt = Pesototal;
                    Contadorerros = 0;
                }
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
                        RunOnUiThread(() => TxtPlat1_4.Text = Validacoes.MensagemerroPlat1);
                        Validacoes.Peso1 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat1_4.Text = Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso1) + " kg"));
                        Validacoes.Peso1 = Validacoes.DivisaoPeso20(Validacoes.Peso1);
                    }
                    if (Validacoes.ErroPlat2 == true)
                    {
                        RunOnUiThread(() => TxtPlat2_4.Text = Validacoes.MensagemerroPlat2);
                        Validacoes.Peso2 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat2_4.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso2))) + " kg");
                        Validacoes.Peso2 = Validacoes.DivisaoPeso20(Validacoes.Peso2);
                    }
                    if (Validacoes.ErroPlat3 == true)
                    {
                        RunOnUiThread(() => TxtPlat3_4.Text = Validacoes.MensagemerroPlat3);
                        Validacoes.Peso3 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat3_4.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso3))) + " kg");
                        Validacoes.Peso3 = Validacoes.DivisaoPeso20(Validacoes.Peso3);
                    }
                    if (Validacoes.ErroPlat4 == true)
                    {
                        RunOnUiThread(() => TxtPlat4_4.Text = Validacoes.MensagemerroPlat4);
                        Validacoes.Peso4 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat4_4.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso4))) + " kg");
                        Validacoes.Peso4 = Validacoes.DivisaoPeso20(Validacoes.Peso4);
                    }


                    int SOMA1_2 = Validacoes.Peso1 + Validacoes.Peso2;
                    int SOMA3_4 = Validacoes.Peso3 + Validacoes.Peso4;
                    int SOMA1_3 = Validacoes.Peso1 + Validacoes.Peso3;
                    int SOMA2_4 = Validacoes.Peso2 + Validacoes.Peso4;

                  
                    RunOnUiThread(() => TxtEixo_1_2_4.Text = " " + Convert.ToString(SOMA1_2) + " kg");
                    RunOnUiThread(() => TxtEixo_3_4_4.Text = " " + Convert.ToString(SOMA3_4) + " kg");
                    RunOnUiThread(() => TxtSoma1_3.Text = Convert.ToString(SOMA1_3) + " kg");
                    RunOnUiThread(() => TxtSoma2_4.Text = Convert.ToString(SOMA2_4) + " kg");
                    
                    //int Pesototal = Validacoes.Peso1 + Validacoes.Peso2 + Validacoes.Peso3 + Validacoes.Peso4;

                    //if (Validacoes.ErroPlat4 == true ||
                    //    Validacoes.ErroPlat3 == true ||
                    //    Validacoes.ErroPlat2 == true ||
                    //    Validacoes.ErroPlat1 == true)
                    //{
                    //    RunOnUiThread(() => TxtPesoTotal4.Text = "-------------");
                    //}
                    //else
                    //    RunOnUiThread(() => TxtPesoTotal4.Text = Convert.ToString(Pesototal) + " kg");





                }
            }
            catch (System.Exception ex)
            {
                //threadBalanca1.Abort();
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

        protected override void OnStop()
        {
            if (Validacoes.CliqueSaida == false)
            {
                Validacoes.CliqueSaida = true;
                this.threadBalanca1.Abort();
                threadEnviaPeso.Abort();
                this.threadAtualizaPesoTotal.Abort();
                Validacoes.BSocket[0].Close();
                Validacoes.BSocket[0].Dispose();
                Finish();
            }

            base.OnStop();
        }
    }

        #endregion

    
}