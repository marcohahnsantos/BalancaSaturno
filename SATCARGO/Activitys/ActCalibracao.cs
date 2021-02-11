using Android.App;
using Android.Bluetooth;
using Android.Database.Sqlite;
using Android.OS;
using Android.Views;
using Android.Widget;
using SATCARGO.ClassesGerais;
using System;
using System.Collections.Generic;
using System.Linq;
using Thread = System.Threading.Thread;
using Xamarin.Forms;
using Android.Content.PM;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCalibracao", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]

    public class ActCalibracao : Activity
    {
        public SQLiteDatabase sqldTemporario;
        /// <summary>
        /// The sSQLquery for query handling.
        /// </summary>
        /// <summary>
        /// The sMessage to hold message.
        /// </summary>
        BancoDados mdTemp;
        int QuantZero = 0;
        private SQLiteDatabase sqldTemp;
        //========================//
        //      TEXTVIEW          //
        //========================//
        TextView TxtPeso1;
        TextView TxtPeso2;
        TextView TxtPeso3;
        TextView TxtPeso4;
        TextView TxtPeso5;
        TextView TxtPeso6;
        TextView TxtPeso7;
        TextView TxtNeg1;
        TextView TxtProgress;
        Android.Widget.ProgressBar progressBar;
        //========================//
        //      BUTTON            //
        //========================//
        Android.Widget.Button BtnZerar1;
        Android.Widget.Button BtnZerar2;
        Android.Widget.Button BtnZerar3;
        Android.Widget.Button BtnZerar4;
        Android.Widget.Button BtnZerar5;
        Android.Widget.Button BtnZerar6;
        Android.Widget.Button BtnCalibrar1;
        Android.Widget.Button BtnCalibrar2;
        Android.Widget.Button BtnCalibrar3;
        Android.Widget.Button BtnCalibrar4;
        Android.Widget.Button BtnCalibrar5;
        Android.Widget.Button BtnCalibrar6;
        Android.Widget.ImageButton BtnSair;
        //========================//
        //     EDITTEXT           //
        //========================//
        EditText TxtPesoCal1;
        EditText TxtPesoCal2;
        EditText TxtPesoCal3;
        EditText TxtPesoCal4;
        EditText TxtPesoCal5;
        EditText TxtPesoCal6;
        //========================//
        //     FRAMELAYOUTS       //
        //========================//
        FrameLayout FrameLayout1;
        FrameLayout FrameLayout11;
        FrameLayout FrameLayout2;
        FrameLayout FrameLayout21;
        FrameLayout FrameLayout3;
        FrameLayout FrameLayout31;
        FrameLayout FrameLayout4;
        FrameLayout FrameLayout41;
        FrameLayout FrameLayout5;
        FrameLayout FrameLayout51;
        FrameLayout FrameLayout6;
        FrameLayout FrameLayout61;
        int Pesototal = 0;
        //==================================================================//
        private System.Threading.Thread threadBalanca1;
        private System.Threading.Thread threadEnviaPeso;
        //==================================================================//
        bool ZeraBalanca = false;
        BluetoothSocket[] socket = new BluetoothSocket[1];
        //==================================================================//
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LayoutCalibracao);
            //=======================================================//
            // Referenciando Objetos                                 //
            //=======================================================//
            TxtPeso1 = FindViewById<TextView>(Resource.Id.TextPeso1);
            TxtPeso2 = FindViewById<TextView>(Resource.Id.TextPeso2);
            TxtPeso3 = FindViewById<TextView>(Resource.Id.TextPeso3);
            TxtPeso4 = FindViewById<TextView>(Resource.Id.TextPeso4);
            TxtPeso5 = FindViewById<TextView>(Resource.Id.TextPeso5);
            TxtPeso6 = FindViewById<TextView>(Resource.Id.TextPeso6);
            TxtPeso7 = FindViewById<TextView>(Resource.Id.TxtPesoTotalCalibracao);
            // TxtNeg1 = FindViewById<TextView>(Resource.Id.TxtNeg1);
            //==============================================================================//
            TxtPesoCal1 = FindViewById<EditText>(Resource.Id.TextPesoCal1);
            TxtPesoCal2 = FindViewById<EditText>(Resource.Id.TextPesoCal2);
            TxtPesoCal3 = FindViewById<EditText>(Resource.Id.TextPesoCal3);
            TxtPesoCal4 = FindViewById<EditText>(Resource.Id.TextPesoCal4);
            TxtPesoCal5 = FindViewById<EditText>(Resource.Id.TextPesoCal5);
            TxtPesoCal6 = FindViewById<EditText>(Resource.Id.TextPesoCal6);
            BtnZerar1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar1);
            BtnZerar2 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar2);
            BtnZerar3 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar3);
            BtnZerar4 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar4);
            BtnZerar5 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar5);
            BtnZerar6 = FindViewById<Android.Widget.Button>(Resource.Id.BtnZerar6);
            BtnCalibrar1 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar1);
            BtnCalibrar2 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar2);
            BtnCalibrar3 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar3);
            BtnCalibrar4 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar4);
            BtnCalibrar5 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar5);
            BtnCalibrar6 = FindViewById<Android.Widget.Button>(Resource.Id.BtnCalibrar6);
            //==================================================================================//
            FrameLayout1 = FindViewById<FrameLayout>(Resource.Id.frameLayout1);
            FrameLayout11 = FindViewById<FrameLayout>(Resource.Id.frameLayout11);
            FrameLayout2 = FindViewById<FrameLayout>(Resource.Id.frameLayout2);
            FrameLayout21 = FindViewById<FrameLayout>(Resource.Id.frameLayout21);
            FrameLayout3 = FindViewById<FrameLayout>(Resource.Id.frameLayout3);
            FrameLayout31 = FindViewById<FrameLayout>(Resource.Id.frameLayout31);
            FrameLayout4 = FindViewById<FrameLayout>(Resource.Id.frameLayout4);
            FrameLayout41 = FindViewById<FrameLayout>(Resource.Id.frameLayout41);
            FrameLayout5 = FindViewById<FrameLayout>(Resource.Id.frameLayout5);
            FrameLayout51 = FindViewById<FrameLayout>(Resource.Id.frameLayout51);
            FrameLayout6 = FindViewById<FrameLayout>(Resource.Id.frameLayout6);
            FrameLayout61 = FindViewById<FrameLayout>(Resource.Id.frameLayout61);
            //==================================================================================//
            progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.list_progressCal);
            TxtProgress = FindViewById<Android.Widget.TextView>(Resource.Id.TxtAguardeProgressCal);
            //==================================================================================//
            BtnSair = FindViewById<Android.Widget.ImageButton>(Resource.Id.BtnSairComunicacao);
            TxtPeso7.Text = "0";
            ProcessoBalanca();
            Thread.Sleep(1000);
            //=================================================================================//
            this.threadBalanca1 = new System.Threading.Thread(AtualizaBalancas);
            if (this.threadBalanca1 != null)
            {
                this.threadBalanca1.Start();
                Validacoes.EstadoThread = "START";
            }

            BtnCalibrar1.Visibility = ViewStates.Invisible;
            BtnCalibrar2.Visibility = ViewStates.Invisible;
            BtnCalibrar3.Visibility = ViewStates.Invisible;
            BtnCalibrar4.Visibility = ViewStates.Invisible;
            BtnCalibrar5.Visibility = ViewStates.Invisible;
            BtnCalibrar6.Visibility = ViewStates.Invisible;
            TxtPesoCal1.Visibility = ViewStates.Invisible;
            TxtPesoCal2.Visibility = ViewStates.Invisible;
            TxtPesoCal3.Visibility = ViewStates.Invisible;
            TxtPesoCal4.Visibility = ViewStates.Invisible;
            TxtPesoCal5.Visibility = ViewStates.Invisible;
            TxtPesoCal6.Visibility = ViewStates.Invisible;
            int nrPlataformas = Validacoes.Nrplataformas + 1;
            if (nrPlataformas == 1)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                }
                FrameLayout2.Visibility = ViewStates.Invisible;
                FrameLayout21.Visibility = ViewStates.Invisible;
                FrameLayout3.Visibility = ViewStates.Invisible;
                FrameLayout31.Visibility = ViewStates.Invisible;
                FrameLayout4.Visibility = ViewStates.Invisible;
                FrameLayout41.Visibility = ViewStates.Invisible;
                FrameLayout5.Visibility = ViewStates.Invisible;
                FrameLayout51.Visibility = ViewStates.Invisible;
                FrameLayout6.Visibility = ViewStates.Invisible;
                FrameLayout61.Visibility = ViewStates.Invisible;
            }
            //=================================================================================//
            if (nrPlataformas == 2)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    BtnCalibrar2.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                    TxtPesoCal2.Visibility = ViewStates.Visible;
                }
                FrameLayout3.Visibility = ViewStates.Invisible;
                FrameLayout31.Visibility = ViewStates.Invisible;
                FrameLayout4.Visibility = ViewStates.Invisible;
                FrameLayout41.Visibility = ViewStates.Invisible;
                FrameLayout5.Visibility = ViewStates.Invisible;
                FrameLayout51.Visibility = ViewStates.Invisible;
                FrameLayout6.Visibility = ViewStates.Invisible;
                FrameLayout61.Visibility = ViewStates.Invisible;
            }
            //=================================================================================//
            if (nrPlataformas == 3)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    BtnCalibrar2.Visibility = ViewStates.Visible;
                    BtnCalibrar3.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                    TxtPesoCal2.Visibility = ViewStates.Visible;
                    TxtPesoCal3.Visibility = ViewStates.Visible;
                }
                FrameLayout4.Visibility = ViewStates.Invisible;
                FrameLayout41.Visibility = ViewStates.Invisible;
                FrameLayout5.Visibility = ViewStates.Invisible;
                FrameLayout51.Visibility = ViewStates.Invisible;
                FrameLayout6.Visibility = ViewStates.Invisible;
                FrameLayout61.Visibility = ViewStates.Invisible;
            }
            //=================================================================================//
            if (nrPlataformas == 4)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    BtnCalibrar2.Visibility = ViewStates.Visible;
                    BtnCalibrar3.Visibility = ViewStates.Visible;
                    BtnCalibrar4.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                    TxtPesoCal2.Visibility = ViewStates.Visible;
                    TxtPesoCal3.Visibility = ViewStates.Visible;
                    TxtPesoCal4.Visibility = ViewStates.Visible;
                }
                FrameLayout5.Visibility = ViewStates.Invisible;
                FrameLayout51.Visibility = ViewStates.Invisible;
                FrameLayout6.Visibility = ViewStates.Invisible;
                FrameLayout61.Visibility = ViewStates.Invisible;
            }
            //=================================================================================//
            if (nrPlataformas == 5)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    BtnCalibrar2.Visibility = ViewStates.Visible;
                    BtnCalibrar3.Visibility = ViewStates.Visible;
                    BtnCalibrar4.Visibility = ViewStates.Visible;
                    BtnCalibrar5.Visibility = ViewStates.Visible;
                    FrameLayout6.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                    TxtPesoCal2.Visibility = ViewStates.Visible;
                    TxtPesoCal3.Visibility = ViewStates.Visible;
                    TxtPesoCal4.Visibility = ViewStates.Visible;
                    TxtPesoCal5.Visibility = ViewStates.Visible;
                }
                FrameLayout61.Visibility = ViewStates.Invisible;
            }
            if (nrPlataformas == 6)
            {
                if (Validacoes.SenhaCalibracao == true)
                {
                    BtnCalibrar1.Visibility = ViewStates.Visible;
                    BtnCalibrar2.Visibility = ViewStates.Visible;
                    BtnCalibrar3.Visibility = ViewStates.Visible;
                    BtnCalibrar4.Visibility = ViewStates.Visible;
                    BtnCalibrar5.Visibility = ViewStates.Visible;
                    BtnCalibrar6.Visibility = ViewStates.Visible;
                    TxtPesoCal1.Visibility = ViewStates.Visible;
                    TxtPesoCal2.Visibility = ViewStates.Visible;
                    TxtPesoCal3.Visibility = ViewStates.Visible;
                    TxtPesoCal4.Visibility = ViewStates.Visible;
                    TxtPesoCal5.Visibility = ViewStates.Visible;
                    TxtPesoCal6.Visibility = ViewStates.Visible;
                }
            }


            this.threadEnviaPeso = new System.Threading.Thread(AtualizaPeso);
            if (this.threadEnviaPeso != null)
            {
                this.threadEnviaPeso.Start();
                Validacoes.EstadoThread = "START";
            }
            //=================================================================================//
            
            Window.SetSoftInputMode(SoftInput.StateHidden);


            BtnSair.Click += delegate
            {
                try
                {
                    Validacoes.SenhaCalibracao = false;
                    Finish();
                }
                catch
                {
                    threadEnviaPeso.Interrupt();
                    Thread.Sleep(2000);
                    threadEnviaPeso.Abort();
                    Finish();
                }
            };
            BtnZerar1.Click += async delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma1();
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnCalibrar1.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma1();
                MensagemToast("PLATAFORMA CALIBRADA");
            };
            BtnZerar2.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma(0x32);
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnCalibrar2.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma(0x32,TxtPesoCal2.Text);
                MensagemToast("PLATAFORMA CALIBRADA");
            };
            BtnZerar3.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma(0x33);
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnZerar4.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma(0x34);
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnCalibrar3.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma(0x33,TxtPesoCal3.Text);
                MensagemToast("PLATAFORMA CALIBRADA");
            };
            BtnCalibrar4.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma(0x34,TxtPesoCal4.Text);
                MensagemToast("PLATAFORMA CALIBRADA");
            };
            BtnZerar5.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma(0x35);
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnCalibrar5.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma(0x35,TxtPesoCal5.Text);
                MensagemToast("PLATAFORMA CALIBRADA");
            };
            BtnZerar6.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                ZerarPlataforma(0x36);
                MensagemToast("PLATAFORMA ZERADA");
            };
            BtnCalibrar6.Click += delegate
            {
                Bloquearbotoes();
                MensagemToast("AGUARDE");
                CalibrarPlataforma(0x36,TxtPesoCal6.Text);
                MensagemToast("PLATAFORMA CALIBRADA");
            };
        }
        public void MensagemToast(string Mensagem)
        {
            Toast toast = Toast.MakeText(this, Mensagem, ToastLength.Long);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Show();
        }
        private void AtualizaPeso()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    RunOnUiThread(() => TxtPeso1.Text = Convert.ToString(Validacoes.Peso1));
                    RunOnUiThread(() => TxtPeso2.Text = Convert.ToString(Validacoes.Peso2));
                    RunOnUiThread(() => TxtPeso3.Text = Convert.ToString(Validacoes.Peso3));
                    RunOnUiThread(() => TxtPeso4.Text = Convert.ToString(Validacoes.Peso4));
                    RunOnUiThread(() => TxtPeso5.Text = Convert.ToString(Validacoes.Peso5));
                    RunOnUiThread(() => TxtPeso6.Text = Convert.ToString(Validacoes.Peso6));
                    Pesototal = Validacoes.Peso1 +
                              Validacoes.Peso2 +
                              Validacoes.Peso3 +
                              Validacoes.Peso4 +
                              Validacoes.Peso5 +
                              Validacoes.Peso6;
                    RunOnUiThread(() => TxtPeso7.Text = Convert.ToString(Pesototal));
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        #region AtualizaBalanca]
        private void AtualizaBalancas()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (ZeraBalanca == false)
                    {
                        if (Validacoes.Nrplataformas + 1 == 1)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                        }
                        if (Validacoes.Nrplataformas + 1 == 2)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                        }
                        if (Validacoes.Nrplataformas + 1 == 3)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma3(Validacoes.BSocket[0]);
                        }
                        if (Validacoes.Nrplataformas + 1 == 4)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma3(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma4(Validacoes.BSocket[0]);
                        }
                        if (Validacoes.Nrplataformas + 1 == 5)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma3(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma4(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma5(Validacoes.BSocket[0]);
                        }
                        if (Validacoes.Nrplataformas + 1 == 6)
                        {
                            Validacoes.VerificaStatusPlafaforma1(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma2(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma3(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma4(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma5(Validacoes.BSocket[0]);
                            Validacoes.VerificaStatusPlafaforma6(Validacoes.BSocket[0]);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        #endregion
        #region Zerar
        private void ZerarPlataforma1()
        {
            ZeraBalanca = true;
            Thread.Sleep(1000);
            int Contador = 0;
            // Thread.Sleep(10000);
            Contador = Contador + 1;
            //=================================+
            //  PRIMEIRO 05 CARACTERES FIXO   //
            //================================//
            //           >00A1                //
            //================================//
            byte[] buffer = new byte[7];
            buffer[0] = 0x3E;
            buffer[1] = 0x30;
            buffer[2] = 0x31;
            buffer[3] = 0x31;
            buffer[4] = 0x31;
            buffer[5] = 0x30;
            buffer[6] = 0x30;
            var output = Validacoes.BSocket[0].OutputStream;
            var readput = Validacoes.BSocket[0].InputStream;
            output.Write(buffer, 0, 7);
            output.Write(buffer, 0, 7);
            Thread.Sleep(1000);
            ZeraBalanca = false;
            Desbloquearbotoes();
        }
        private void ZerarPlataforma(System.Byte zerar)
        {
            ZeraBalanca = false;
            Thread.Sleep(500);
            int Contador = 0;
            //=================================+
            //  PRIMEIRO 05 CARACTERES FIXO   //
            //================================//
            //           >00A1                //
            //================================//
            byte[] buffer = new byte[21];
            buffer[0] = 0x3E;
            buffer[1] = 0x30;
            buffer[2] = 0x30;
            buffer[3] = 0x41;
            buffer[4] = 0x31;
            //==================================
            //   06 CARACTERE FIXO            //
            //================================//
            //           >                    //
            //================================//
            buffer[5] = 0x3E;
            //==================================
            //   7 E 8                        //
            //================================//
            //   ID PLATAFORMA = NRPLATAFORMA //
            //================================//
            buffer[6] = 0x30;
            buffer[7] = zerar;
            //==================================
            //   9 E 10  CARACTERES FIXOS     //
            //================================//
            //   OPERACAO 61                  //
            //================================//
            buffer[8] = 0x36;
            buffer[9] = 0x31; ;
            //==================================
            //   10 A 16  SEQUENCIACOMANDOS   //
            //================================//
            //  “FF3F0100    FF3F0100         //
            //================================//
            buffer[10] = 0x46;
            buffer[11] = 0x46;
            buffer[12] = 0x33;
            buffer[13] = 0x46;
            buffer[14] = 0x30;
            buffer[15] = 0x31;
            buffer[16] = 0x30;
            buffer[17] = 0x30;
            buffer[18] = 0x30;
            buffer[19] = 0x30;
            buffer[20] = 0x0D;
            var output = Validacoes.BSocket[0].OutputStream;
            output.Write(buffer, 0, 21);
            output.Write(buffer, 0, 21);
            Thread.Sleep(1000);
            ZeraBalanca = false;
            Desbloquearbotoes();
        }
        private void Bloquearbotoes()
        {
            BtnSair.Enabled = false;
            BtnZerar1.Enabled = false;
            BtnZerar2.Enabled = false;
            BtnZerar3.Enabled = false;
            BtnZerar4.Enabled = false;
            BtnZerar5.Enabled = false;
            BtnZerar6.Enabled = false;
            //=========================//
            BtnCalibrar1.Enabled = false;
            BtnCalibrar2.Enabled = false;
            BtnCalibrar3.Enabled = false;
            BtnCalibrar4.Enabled = false;
            BtnCalibrar5.Enabled = false;
            BtnCalibrar6.Enabled = false;
        }
        private void Desbloquearbotoes()
        {
            BtnSair.Enabled = true;
            BtnZerar1.Enabled = true;
            BtnZerar2.Enabled = true;
            BtnZerar3.Enabled = true;
            BtnZerar4.Enabled = true;
            BtnZerar5.Enabled = true;
            BtnZerar6.Enabled = true;
            //=========================//
            BtnCalibrar1.Enabled = true;
            BtnCalibrar2.Enabled = true;
            BtnCalibrar3.Enabled = true;
            BtnCalibrar4.Enabled = true;
            BtnCalibrar5.Enabled = true;
            BtnCalibrar6.Enabled = true;
        }
        #endregion
        #region Calibrar
        private void CalibrarPlataforma1()
        {
            ZeraBalanca = true;
            Thread.Sleep(1000);
            int Contador = 0;
            //=================================+
            //  PRIMEIRO 05 CARACTERES FIXO   //
            //================================//
            // >FF5F0000320301AAAAAA          //
            //================================//
            int TamanhoStringPesoCalibracao = TxtPesoCal1.Length();
            byte[] buffer = new byte[21 + TamanhoStringPesoCalibracao + 1];
            // byte[] buffer = new byte[26];
            buffer[0] = 0x3E;  // >
            buffer[1] = 0x46;  // F
            buffer[2] = 0x46;  // F
            buffer[3] = 0x35;  // 5
            buffer[4] = 0x46;  // F
            buffer[5] = 0x30;  // 0
            buffer[6] = 0x30;  // 0
            buffer[7] = 0x30;  // 0
            buffer[8] = 0x30;  // 0
            buffer[9] = 0x33;  // 3
            buffer[10] = 0x32; // 2 
            buffer[11] = 0x30; // 0
            buffer[12] = 0x33; // 3
            buffer[13] = 0x30; // 0
            buffer[14] = 0x31; // 1
            buffer[15] = 0x41; // A
            buffer[16] = 0x41; // A
            buffer[17] = 0x41; // A
            buffer[18] = 0x41; // A
            buffer[19] = 0x41; // A
            buffer[20] = 0x41; // A
            //==========================================//
            //          LENDO  VALOR PESO CONHECIDO     //
            //==========================================//
            int arraycont = 21;
            byte ValorHex = 0X30;
            for (int i = 0; i < TamanhoStringPesoCalibracao; i++)
            {
                ValorHex = Validacoes.ConverteCaracterehex(TxtPesoCal1.Text.Substring(i, 1));
                buffer[arraycont] = Convert.ToByte(ValorHex);
                arraycont = arraycont + 1;
            }
            buffer[buffer.Count() - 1] = 0x0A; // 0A
            var output = Validacoes.BSocket[0].OutputStream;
            output.Write(buffer, 0, buffer.Count());
            Thread.Sleep(1000);
            ZeraBalanca = false;
            Desbloquearbotoes();
        }
        private void CalibrarPlataforma(System.Byte calibrar,String PesoCal)
        {
            ZeraBalanca = true;
            Thread.Sleep(1000);
            //=================================+
            //  PRIMEIRO 05 CARACTERES FIXO   //
            //================================//
            // >FF5F0000320302AAAAAA          //
            //================================//
            int TamanhoStringPesoCalibracao = PesoCal.Length;
            byte[] buffer = new byte[21 + TamanhoStringPesoCalibracao + 1];
            buffer[0] = 0x3E;  // >
            buffer[1] = 0x46;  // F
            buffer[2] = 0x46;  // F
            buffer[3] = 0x35;  // 5
            buffer[4] = 0x46;  // F
            buffer[5] = 0x30;  // 0
            buffer[6] = 0x30;  // 0
            buffer[7] = 0x30;  // 0
            buffer[8] = 0x30;  // 0
            buffer[9] = 0x33;  // 3
            buffer[10] = 0x32; // 2 
            buffer[11] = 0x30; // 0
            buffer[12] = 0x33; // 3
            buffer[13] = 0x30; // 0
            buffer[14] = calibrar; // 2
            buffer[15] = 0x41; // A
            buffer[16] = 0x41; // A
            buffer[17] = 0x41; // A
            buffer[18] = 0x41; // A
            buffer[19] = 0x41; // A
            buffer[20] = 0x41; // A
            //==========================================//
            //          LENDO  VALOR PESO CONHECIDO     //
            //==========================================//
            int arraycont = 21;
            byte ValorHex = 0X30;
            for (int i = 0; i < TamanhoStringPesoCalibracao; i++)
            {
                ValorHex = Validacoes.ConverteCaracterehex(PesoCal.Substring(i, 1));
                buffer[arraycont] = Convert.ToByte(ValorHex);
                arraycont = arraycont + 1;
            }
            buffer[buffer.Count() - 1] = 0x0A; // 0A
            var output = Validacoes.BSocket[0].OutputStream;
            output.Write(buffer, 0, buffer.Count());
            Thread.Sleep(1000);
            ZeraBalanca = false;
            Desbloquearbotoes();
        }
      
        #endregion
        private void ProcessoBalanca()
        {
            BancoDados banco = new BancoDados();
            banco.PesquisaAparelho();
            try
            {
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
                Thread.Sleep(3000);
                if (Validacoes.BSocket[0].IsConnected == false)
                {
                    Validacoes.BSocket[0].Connect();
                }
                Thread.Sleep(1000);
            }
            catch (System.Exception erro)
            {
                Validacoes.CliqueSaida = true;
                Toast.MakeText(this, "FALHA DE COMUNICACAO !", ToastLength.Long).Show();
                Finish();
                Validacoes.EstadoConexao = "NAO";
            }
        }
        protected override void OnStop()
        {
            threadBalanca1.Interrupt();
            threadBalanca1.Abort();
            Validacoes.AdaptadorBluetooth.Dispose();
            Validacoes.BSocket[0].Close();
            Validacoes.BSocket[0].Dispose();
            threadEnviaPeso.Interrupt();
            Thread.Sleep(2000);
            threadEnviaPeso.Abort();
            Finish();
            base.OnStop();
        }
    }
}
