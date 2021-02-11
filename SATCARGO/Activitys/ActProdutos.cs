using System;
using System.Timers;
using System.Collections;
using System.Runtime.InteropServices;
using Android.App;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
using System.Data.Common;
using Android.Database.Sqlite;
using System.Data;
using System.IO;
using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.PM;
using SATCARGO.Activitys;
using SATCARGO.ClassesGerais;
using Android.Database.Sqlite;
using System.IO;
using Android.Text;
using Java.Lang;
using Xamarin.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Globalization;
using Java.Util;

namespace SATCARGO.Activitys
{
   
    [Activity(Label = "ActProdutos", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActProdutos : AppCompatActivity
    {
      
        string[] nomes;
        private string sMessage;
        private bool bDBIsAvailable;
        public ArrayAdapter adapter { get; private set; }
        private SQLiteDatabase sqldTemp;
        private CarreDadosProdutos item;
        BancoDados mdTemp;
        public EditText valor { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string sSQLQuery = "";

            SetContentView(Resource.Layout.layoutProdutos);

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO DE PRODUTOS";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock2);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;

            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnVoltarProduto);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarProduto);

            EditText produto = FindViewById<EditText>(Resource.Id.TxtDescicaoProduto);
            EditText valor = FindViewById<EditText>(Resource.Id.TextValorProduto);
            TextView codigo = FindViewById<TextView>(Resource.Id.TxtCodigoProduto); 

            sSQLQuery = "";
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);


            valor.AfterTextChanged += EditTextValor_AfterTextChanged;

            nomes = new string[1];
            for (int i = 0; i < 1; i++)
            {
                nomes[i] = " ".ToString();
            }
            CarregaListaProdutos();
            Window.SetSoftInputMode(SoftInput.StateHidden);

            BtnSair.Click += delegate
            {
                Finish();
            };

            BtnSalvar.Click += delegate
            {
                if (produto.Text == "")
                {
                    Toast.MakeText(this, "Deve ser digitada uma PRODUTO!", ToastLength.Short).Show();
                    return;
                }
                if (valor.Text == "")
                {
                    Toast.MakeText(this, "Deve ser selecionado um valor de PRODUTO!", ToastLength.Short).Show();
                    return;
                }

                //==============================================================================================//
                //                             VERIFICA SE JÁ EXISTE UM ENDEREÇO GRAVADO                        //
                //==============================================================================================//

                sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bIsExists = File.Exists(sDB);


                Android.Database.ICursor icursorTemp = null;

                sSQLQuery = "";
                sSQLQuery = $"SELECT _id FROM PRODUTOS WHERE _id='{codigo.Text}'";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;


                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                      //  string ValorProduto = System.String.Format(valor.Text,"C2");
                        

                        string Valores = "'" + produto.Text + "','" +
                        valor.Text +"','" +
                        Data + "','" +
                        Hora + "'";

                    string Campos = "PRODUTO," +
                        "VALOR," +
                        "DATA_CADASTRO," +
                        "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                        "PRODUTOS " + "(" + Campos + ") " +
                        "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update PRODUTOS set " +
                                $" PRODUTO='{produto.Text}'," +
                                $" VALOR='{valor.Text}'," +
                                $" DATA_CADASTRO='{Data}', " +
                                $" HORA_CADASTRO='{Hora}' " +
                                $" where _id={codigo.Text}";

                    sqldTemp.ExecSQL(ComandoSql);
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
                produto.Text = "";
                valor.Text = "";
                codigo.Text = "";
                CarregaListaProdutos();
            };


            void EditTextValor_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
            {
                var text = e.Editable.ToString();
                valor.AfterTextChanged -= EditTextValor_AfterTextChanged;
                var formatedText = FormatarCampos.ValorValueConverter(text);
                valor.Text = formatedText;
                valor.SetSelection(formatedText.Length);
                valor.AfterTextChanged += EditTextValor_AfterTextChanged;
            }
            void CarregaListaProdutos()
            {
                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT _id," +
                " PRODUTO, " +
                " VALOR " +
                 " FROM PRODUTOS ";


                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    nomes = new string[icursorTemp.Count];

                    for (int i = 0; i < icursorTemp.Count; i++)
                    {
                        icursorTemp.MoveToNext();
                        item = new CarreDadosProdutos();
                        item.Id = icursorTemp.GetString(0);
                        item.Produto = icursorTemp.GetString(1);
                        item.Valor = icursorTemp.GetString(2);
                       // item.Produto = FormatarCampos.RetornaTextoLista(item.Produto.PadRight(35, '0'));
                        string Linha = "";
                        Linha = item.Id.PadLeft(5, '0') + "       " +
                        item.Produto.PadRight(15, '_') +
                        item.Valor.PadLeft(20,'_');
                        nomes[i] = Linha;
                    }
                    ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, nomes);
                  


                    Android.Widget.ListView listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaProdutos);
                    listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaProdutos);

                    listview.Adapter = itemsAdapter;

                    listview.ItemClick += ListView_ItemClick;
                }

                void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
                {
                    Validacoes.ValorItem = nomes[e.Id];

                    sSQLQuery = "SELECT _id," +
                    " PRODUTO, " +
                    " VALOR " +
                    " FROM PRODUTOS " +
                    $" WHERE _id={Convert.ToInt16(Validacoes.ValorItem.Substring(0, 6))}";

                    icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                    ValorCursor = icursorTemp.Count;
                    if (ValorCursor > 0)
                    {
                        icursorTemp.MoveToNext();
                        codigo.Text = icursorTemp.GetString(0);
                        produto.Text = icursorTemp.GetString(1);
                        valor.Text = icursorTemp.GetString(2);
                    }
                }
            }
        }
        #region [FUNCOES]
        public class CarreDadosProdutos
        {
            public string Id { get; set; }
            public string Produto { get; set; }
            public string Valor { get; set; }
            public string Data { get; set; }
            public string Hora { get; set; }
            private SQLiteDatabase sqldTemp;
            private string sSQLQuery;
            BancoDados mdTemp;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
        #endregion
    }
}