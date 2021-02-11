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
    [Activity(Label = "ActConfiguracaoSistema", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class ActConfiguracaoSistema : AppCompatActivity
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
       

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.LayoutConfiguracaoSistema);
           
          SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CONFIGURAÇÃO SISTEMA";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock1);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;
            Validacoes.NrSegundosPeso = 1;
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairComunicacao);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarComunicacao);

            Android.Support.V7.Widget.AppCompatButton BtnliberaCalibracao = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.btnLiberarCalibracao);


            BtnliberaCalibracao.Click += (sender, e) =>
            {
                 StartActivity(typeof(ActSenhaCalibracao));
               
             
            //    Finish();
            };

            spinner = FindViewById<Spinner>(Resource.Id.spinnernrplataformas);
            selecao = new string[10];
            selecao[0] = "01";
            selecao[1] = "02";
            selecao[2] = "03";
            selecao[3] = "04";
            selecao[4] = "05";
            selecao[5] = "06";
            selecao[6] = "07";
            selecao[7] = "08";
            selecao[8] = "09";
            selecao[9] = "10";
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
            sSQLQuery = "SELECT NR_SEGUNDOS_PESO " +
                        " FROM CONFIGURACAO_SISTEMA WHERE _id=1";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;
            int nrParcelas = 0;
           
            if (ValorCursor > 0)
            {
                icursorTemp.MoveToNext();
                string TotalSegundos = icursorTemp.GetString(0);
                Validacoes.NrSegundosPeso = int.Parse(TotalSegundos);
            }
            Window.SetSoftInputMode(SoftInput.StateHidden);

            //==============================================//
            //                  BLUETOOTH                   //
            //==============================================//

            if (Validacoes.NrSegundosPeso > 0)
            {
                spinner.SetSelection(Validacoes.NrSegundosPeso);
            }
            spinner.ItemSelected += (s, e) =>
            {
                firstItem = spinner.SelectedItem.ToString();
                if (firstItem.Equals(spinner.SelectedItem.ToString()))
                {

                    Validacoes.NrSegundosPeso = int.Parse(spinner.SelectedItem.ToString());

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }

            };




           
            // Register for broadcasts when a device is discovered

            BtnSair.Click += delegate
            {
                Finish();
            };

            
            BtnSalvar.Click += delegate
            {
                string DescricaoComunicao = "";



                //==============================================================================================//
                //                             VERIFICA SE JÁ EXISTE UM ENDEREÇO GRAVADO                        //
                //==============================================================================================//
                sSQLQuery = "";
                sSQLQuery = "SELECT NR_SEGUNDOS_PESO " +
                      " FROM CONFIGURACAO_SISTEMA ";

                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                ValorCursor = icursorTemp.Count;
               

                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                    string Valores = int.Parse(spinner.SelectedItem.ToString()) - 1 + ",'" +
                            Data + "','" +
                            Hora + "'";
                    string Campos = "NR_SEGUNDOS_PESO," +
                            "DATA_CADASTRO," +
                            "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                            "CONFIGURACAO_SISTEMA " + "(" + Campos + ") " +
                            "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update CONFIGURACAO_SISTEMA set " +
                                   $" NR_SEGUNDOS_PESO={int.Parse(spinner.SelectedItem.ToString()) - 1}," +
                                   $" DATA_CADASTRO='{Data}', " +
                                   $" HORA_CADASTRO='{Hora}' " +
                                   $" where _id=1  ";

                    sqldTemp.ExecSQL(ComandoSql);
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
                Validacoes.TempoCapturaPeso = int.Parse(spinner.SelectedItem.ToString()) - 1;
            };
           

        }

       

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }


    }

}
