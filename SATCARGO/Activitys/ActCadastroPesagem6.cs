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
using System.Reflection;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroPesagem", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroPesagem6 : AppCompatActivity
    {

        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;
        string Fecharthread = "N";
        private Thread threadBalanca1;
        private Thread threadEnviaPeso;
        private Thread threadAtualizaPesoTotal;
        TextView TxtPesoTotal6;
        TextView TxtPlat1_6;
        TextView TxtPlat2_6;
        TextView TxtPlat3_6;
        TextView TxtPlat4_6;
        TextView TxtPlat5_6;
        TextView TxtPlat6_6;
        TextView TxtEixo_1_2_6;
        TextView TxtEixo_3_4_6;
        TextView TxtEixo_5_6_6;
        TextView SomaTxtPlat1_3_5;
        TextView SomaTxtPlat2_4_6;
        TextView TxtTensao1;
        TextView TxtTensao2;
        TextView TxtTensao3;
        TextView TxtTensao4;
        TextView TxtTensao5;
        TextView TxtTensao6;
        int ContaTensao1 = 0;
        int ContaTensao2 = 0;
        int ContaTensao3 = 0;
        int ContaTensao4 = 0;
        int ContaTensao5 = 0;
        int ContaTensao6 = 0;
        public bool TelaAguardeComunicacao = true;

        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        TextView TxtProgress;
        public Boolean erroconexao = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem6);
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
            TxtPesoTotal6 = FindViewById<TextView>(Resource.Id.TxtPesoTotal6);
            TxtPlat1_6 = FindViewById<TextView>(Resource.Id.TxtPlat1_6);
            TxtPlat2_6 = FindViewById<TextView>(Resource.Id.TxtPlat2_6);
            TxtPlat3_6 = FindViewById<TextView>(Resource.Id.TxtPlat3_6);
            TxtPlat4_6 = FindViewById<TextView>(Resource.Id.TxtPlat4_6);
            TxtPlat5_6 = FindViewById<TextView>(Resource.Id.TxtPlat5_6);
            TxtPlat6_6 = FindViewById<TextView>(Resource.Id.TxtPlat6_6);

            TxtEixo_1_2_6 = FindViewById<TextView>(Resource.Id.TxtpesoEixo1_2);
            TxtEixo_3_4_6 = FindViewById<TextView>(Resource.Id.TxtpesoEixo3_4);
            TxtEixo_5_6_6 = FindViewById<TextView>(Resource.Id.TxtpesoEixo5_6);

            TxtTensao1 = FindViewById<TextView>(Resource.Id.TxtTensao1_6);
            TxtTensao2 = FindViewById<TextView>(Resource.Id.TxtTensao2_6);
            TxtTensao3 = FindViewById<TextView>(Resource.Id.TxtTensao3_6);
            TxtTensao4 = FindViewById<TextView>(Resource.Id.TxtTensao4_6);
            TxtTensao5 = FindViewById<TextView>(Resource.Id.TxtTensao5_6);
            TxtTensao6 = FindViewById<TextView>(Resource.Id.TxtTensao6_6);

            SomaTxtPlat1_3_5=FindViewById<TextView>(Resource.Id.SomaTxtPlat1_3_5);
            SomaTxtPlat2_4_6=FindViewById<TextView>(Resource.Id.SomaTxtPlat2_4_6);

         

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
            TxtPesoTotal6.SetTextColor(Android.Graphics.Color.DarkGreen);
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
                int Pesototal = 0;
                if (TxtPesoTotal6.CurrentTextColor == (Android.Graphics.Color.Red) && TxtPesoTotal6.Text != "-------------")
                {
                    Toast.MakeText(this, "PESO NÃO ESTÁ ESTAVEL!", ToastLength.Long).Show();
                    return;
                
                }
                this.threadBalanca1.Abort();
                this.threadEnviaPeso.Abort();
                if (TxtPesoTotal6.Text == "-------------")
                {
                    Validacoes.CliqueSaida = true;
                    Toast.MakeText(this, "SEM COMUNICAÇÃO COM A PLATAFORMA", ToastLength.Long).Show();
                    Aguarde();
                    BtnSair.Enabled = false;
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
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(TxtPlat1_6.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(TxtPlat2_6.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(TxtPlat3_6.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(TxtPlat4_6.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat5 = Convert.ToDouble(TxtPlat5_6.Text.Replace("kg", ""));
                    Validacoes.PesagemRealizadaPlat6 = Convert.ToDouble(TxtPlat6_6.Text.Replace("kg", ""));
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
                    Validacoes.VerificaStatusPlafaforma5(Validacoes.BSocket[0]);
                    Validacoes.VerificaStatusPlafaforma6(Validacoes.BSocket[0]);
                  

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

                    if (Validacoes.Tensao5 != "")
                    {
                        if (Validacoes.ErroPlat5 == true)
                        {
                            if (ContaTensao5 == 10)
                            {
                                RunOnUiThread(() => TxtTensao5.Text = "-----");
                            }
                            ContaTensao5 = ContaTensao5 + 1;
                        }
                        else
                        {
                            RunOnUiThread(() => TxtTensao5.Text = Convert.ToString(Validacoes.Tensao5) + " VDC");
                            ContaTensao5 = 0;
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat5 == true)
                        {
                            RunOnUiThread(() => TxtTensao5.Text = "-----");
                        }
                        else
                        {
                            if (Validacoes.Tensao5 != "")
                                RunOnUiThread(() => TxtTensao5.Text = Convert.ToString(Validacoes.Tensao5) + " VDC");
                        }
                    }

                    if (Validacoes.Tensao6 != "")
                    {
                        if (Validacoes.ErroPlat6 == true)
                        {
                            if (ContaTensao6 == 10)
                            {
                                RunOnUiThread(() => TxtTensao6.Text = "-----");
                            }
                            ContaTensao6 = ContaTensao6 + 1;
                        }
                        else
                        {
                            RunOnUiThread(() => TxtTensao6.Text = Convert.ToString(Validacoes.Tensao6) + " VDC");
                            ContaTensao6 = 0;
                        }
                    }
                    else
                    {
                        if (Validacoes.ErroPlat6 == true)
                        {
                            RunOnUiThread(() => TxtTensao6.Text = "-----");
                        }
                        else
                        {
                            if (Validacoes.Tensao6 != "")
                                RunOnUiThread(() => TxtTensao6.Text = Convert.ToString(Validacoes.Tensao6) + " VDC");
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
        private void AtualizaPeso()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    if (Validacoes.ErroPlat1 == true)
                    {
                        RunOnUiThread(() => TxtPlat1_6.Text = Validacoes.MensagemerroPlat1);
                        Validacoes.Peso1 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat1_6.Text = Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso1) + " kg"));
                        Validacoes.Peso1 = Validacoes.DivisaoPeso20(Validacoes.Peso1);
                    }
                    if (Validacoes.ErroPlat2 == true)
                    {
                        RunOnUiThread(() => TxtPlat2_6.Text = Validacoes.MensagemerroPlat2);
                        Validacoes.Peso2 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat2_6.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso2))) + " kg");
                        Validacoes.Peso2 = Validacoes.DivisaoPeso20(Validacoes.Peso2);
                    }
                    if (Validacoes.ErroPlat3 == true)
                    {
                        RunOnUiThread(() => TxtPlat3_6.Text = Validacoes.MensagemerroPlat3);
                        Validacoes.Peso3 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat3_6.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso3))) + " kg");
                        Validacoes.Peso3 = Validacoes.DivisaoPeso20(Validacoes.Peso3);
                    }
                    if (Validacoes.ErroPlat4 == true)
                    {
                        RunOnUiThread(() => TxtPlat4_6.Text = Validacoes.MensagemerroPlat4);
                        Validacoes.Peso4 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat4_6.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso4))) + " kg");
                        Validacoes.Peso4 = Validacoes.DivisaoPeso20(Validacoes.Peso4);
                    }
                    if (Validacoes.ErroPlat5 == true)
                    {
                        RunOnUiThread(() => TxtPlat5_6.Text = Validacoes.MensagemerroPlat5);
                        Validacoes.Peso5 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat5_6.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso5))) + " kg");
                        Validacoes.Peso5 = Validacoes.DivisaoPeso20(Validacoes.Peso5);
                    }
                    if (Validacoes.ErroPlat6 == true)
                    {
                        RunOnUiThread(() => TxtPlat6_6.Text = Validacoes.MensagemerroPlat6);
                        Validacoes.Peso6 = 0;
                    }
                    else
                    {
                        RunOnUiThread(() => TxtPlat6_6.Text = Convert.ToString(Convert.ToString(Validacoes.DivisaoPeso20(Validacoes.Peso6))) + " kg");
                        Validacoes.Peso6 = Validacoes.DivisaoPeso20(Validacoes.Peso6);
                    }
                    int SOMA1_2 = Validacoes.Peso1 + Validacoes.Peso2;
                    RunOnUiThread(() => TxtEixo_1_2_6.Text = " " + Convert.ToString(SOMA1_2) + " kg");
                    int SOMA3_4 = Validacoes.Peso3 + Validacoes.Peso4;
                    int SOMA5_6 = Validacoes.Peso5 + Validacoes.Peso6;
                    int SOMA_1_3_5 = Validacoes.Peso1 + Validacoes.Peso3 + Validacoes.Peso5;
                    int SOMA_2_4_6 = Validacoes.Peso2 + Validacoes.Peso4 + Validacoes.Peso6;



                    RunOnUiThread(() => TxtEixo_3_4_6.Text = " " + Convert.ToString(SOMA3_4) + " kg");
                    RunOnUiThread(() => TxtEixo_5_6_6.Text = " " + Convert.ToString(SOMA5_6) + " kg");
                    RunOnUiThread(() => TxtEixo_5_6_6.Text = " " + Convert.ToString(SOMA5_6) + " kg");

                    RunOnUiThread(() => SomaTxtPlat1_3_5.Text = " " + Convert.ToString(SOMA_1_3_5) + " kg");
                    RunOnUiThread(() => SomaTxtPlat2_4_6.Text = " " + Convert.ToString(SOMA_2_4_6) + " kg");

                    if (Validacoes.Peso5 == -999)
                        Validacoes.Peso5 = 0;

                }
            }
            catch (System.Exception ex)
            {
                //threadBalanca1.Abort();
            }
        }
        private void AtualizaPesoTotal()
        {
            int Contadorerros = 0;
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    if (Validacoes.ErroPlat2 == true ||
                       Validacoes.ErroPlat1 == true ||
                       Validacoes.ErroPlat3 == true ||
                       Validacoes.ErroPlat4 == true ||
                       Validacoes.ErroPlat5 == true ||
                       Validacoes.ErroPlat6 == true)
                    {
                        if (erroconexao == false)
                        {
                         //   Validacoes.ValorPesoTotalAnt = 0;
                            RunOnUiThread(() => TxtPesoTotal6.Text = "-------------");
                            if (TxtPlat1_6.Text.Substring(0, 1) != "E" && TxtPlat2_6.Text.Substring(0, 1) != "E" &&
                                TxtPlat3_6.Text.Substring(0, 1) != "E" && TxtPlat4_6.Text.Substring(0, 1) != "E" &&
                                TxtPlat5_6.Text.Substring(0, 1) != "E" && TxtPlat6_6.Text.Substring(0, 1) != "E")
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
                                        + Validacoes.DivisaoPeso20(Validacoes.Peso3) + Validacoes.DivisaoPeso20(Validacoes.Peso4)
                                        + Validacoes.DivisaoPeso20(Validacoes.Peso5) + Validacoes.DivisaoPeso20(Validacoes.Peso6);

                        
                        if (Pesototal != Validacoes.ValorPesoTotalAnt || TxtPesoTotal6.Text == "-------------")
                        {
                            Thread.Sleep(Validacoes.TempoCapturaPeso * 1000);
                            RunOnUiThread(() => TxtPesoTotal6.Text = Convert.ToString(Pesototal) + " kg");
                        }
                        Validacoes.ValorPesoTotalAnt = Pesototal;
                        Contadorerros = 0;
                    }
                }
                catch
                {

                }
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