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

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroVeiculos", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroVeiculos : AppCompatActivity, Android.Text.ITextWatcher
    {
        public SQLiteDatabase sqldTemporario;
        /// <summary>
        /// The sSQLquery for query handling.
        /// </summary>

        /// <summary>
        /// The sMessage to hold message.
        /// </summary>
        private string sMessage;
        private bool bDBIsAvailable;
        BancoDados mdTemp;
        string[] selecao;
        string[] selecaocategoria;
        Spinner spinner;
        Spinner spinnercategoria;
        string firstItem = "";
        string firstItemcategoria = "";
        string[] nomes;
        public ArrayAdapter adapter { get; private set; }
        public ArrayAdapter adaptercategoria { get; private set; }
        private SQLiteDatabase sqldTemp;
        private string old;
        private bool isUpdating;
        private string _mask;
        private CarredaDadosVeiculos item;

        public EditText placa { get; set; }
        public EditText pesotara { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string sSQLQuery = "";

            SetContentView(Resource.Layout.layoutVeiculos);

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO DE VEÍCULOS";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock2);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;

            EditText placa = FindViewById<EditText>(Resource.Id.TxtPlaca);
            EditText pesotara = FindViewById<EditText>(Resource.Id.TxtPesoTara);
            EditText pesobruto = FindViewById<EditText>(Resource.Id.TxtPesoBruto);
            EditText anofab = FindViewById<EditText>(Resource.Id.TxtAnoFab);


            spinner = FindViewById<Spinner>(Resource.Id.spinnermontadoras);
            selecao = new string[8];
            selecao[0] = "Mercedes Benz";
            selecao[1] = "Volkswagem";
            selecao[2] = "Volvo";
            selecao[3] = "Fiat";
            selecao[4] = "Iveco";
            selecao[5] = "Ford";
            selecao[6] = "Scania";
            selecao[7] = "Outros";
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecao);
            spinner.Adapter = adapter;

            spinnercategoria = FindViewById<Spinner>(Resource.Id.spinnercategoria);
            selecaocategoria = new string[5];
            selecaocategoria[0] = "Pesado";
            selecaocategoria[1] = "Semipesado";
            selecaocategoria[2] = "Médio";
            selecaocategoria[3] = "Leve";
            selecaocategoria[4] = "Outros";
            adaptercategoria = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaocategoria);
            spinnercategoria.Adapter = adaptercategoria;


            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.VoltarVeiculo);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.SalvarVeiculo);



            insertPlaca("###-####", placa);
            placa.AddTextChangedListener(this);

            pesotara.AfterTextChanged += EditTextPesoTara_AfterTextChanged;
            pesobruto.AfterTextChanged += EditTextPesoBruto_AfterTextChanged;

            // Create your application here

            sSQLQuery = "";
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            int PosicaoMontadora = 0;
            int PosicaoCategoria = 0;
            spinner.ItemSelected += (s, e) =>
            {
                firstItem = spinner.SelectedItem.ToString();
                if (firstItem.Equals(spinner.SelectedItem.ToString()))
                {
                    PosicaoMontadora = spinner.SelectedItemPosition;
                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }

            };
            
            spinnercategoria.ItemSelected += (s, e) =>
            {
                firstItemcategoria = spinnercategoria.SelectedItem.ToString();
                if (firstItemcategoria.Equals(spinnercategoria.SelectedItem.ToString()))
                {
                   PosicaoCategoria = spinnercategoria.SelectedItemPosition;
                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }

            };
            nomes = new string[1];
            for (int i = 0; i < 1; i++)
            {
                nomes[i] = " ".ToString();
            }
            CarregaListaVeiculos();
            Window.SetSoftInputMode(SoftInput.StateHidden);

            BtnSair.Click += delegate
            {
                Finish();
            };

            BtnSalvar.Click += delegate
            {
                if (placa.Text == "")
                {
                    Toast.MakeText(this, "Deve ser digitada uma PLACA!", ToastLength.Short).Show();
                    return;
                }
                if (anofab.Text == "")
                {
                    Toast.MakeText(this, "Dece ser selecionado um ano de fabricação!", ToastLength.Short).Show();
                    return;
                }
                if (pesobruto.Text == "")
                {
                    Toast.MakeText(this, "Peso bruto deve ser informado !", ToastLength.Short).Show();
                    return;
                }
                if (pesotara.Text == "")
                {
                    Toast.MakeText(this, "Peso tara deve ser informado !", ToastLength.Short).Show();
                    return;
                }

                string DescricaoComunicao = "";

                //==============================================================================================//
                //                             VERIFICA SE JÁ EXISTE UM ENDEREÇO GRAVADO                        //
                //==============================================================================================//

                sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bIsExists = File.Exists(sDB);


                Android.Database.ICursor icursorTemp = null;

                sSQLQuery = "";
                sSQLQuery = $"SELECT _id FROM VEICULOS WHERE PLACA='{placa.Text}'";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;


                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                    string Valores = "'" + placa.Text + "','" +
                        anofab.Text + "','" +
                        spinner.SelectedItem.ToString() + "','" +
                        spinnercategoria.SelectedItem.ToString() + "','" +
                        pesotara.Text + "','" +
                        pesobruto.Text + "','" +
                        Data + "','" +
                        Hora + "'";



                    string Campos = "PLACA," +
                        "ANOFAB," +
                        "MONTADORA," +
                        "CATEGORIA," +
                        "PESOTARA," +
                        "PESOBRUTO," +
                        "DATA_CADASTRO," +
                        "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                        "VEICULOS " + "(" + Campos + ") " +
                        "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update VEICULOS set " +
                                $" PLACA='{placa.Text}'," +
                                $" ANOFAB='{anofab.Text}'," +
                                $" MONTADORA='{spinner.SelectedItem.ToString()}'," +
                                $" CATEGORIA='{spinnercategoria.SelectedItem.ToString()}', " +
                                $" PESOTARA='{pesotara.Text}', " +
                                $" PESOBRUTO='{pesobruto.Text}', " +
                                $" DATA_CADASTRO='{Data}', " +
                                $" HORA_CADASTRO='{Hora}' " +
                                $" where PLACA='{placa.Text}'";

                    sqldTemp.ExecSQL(ComandoSql);
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
                placa.Text = "";
                pesotara.Text = "";
                pesobruto.Text = "";
                anofab.Text = "";
                CarregaListaVeiculos();
            };
            bool OnOptionsItemSelected(IMenuItem item)
            {
                if (item.ItemId == Android.Resource.Id.Home)
                    Finish();

                return base.OnOptionsItemSelected(item);
            }
            void EditTextPesoTara_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
            {
                var text = e.Editable.ToString();
                pesotara.AfterTextChanged -= EditTextPesoTara_AfterTextChanged;
                var formatedText = FormatarCampos.PesoValueConverter(text);
                pesotara.Text = formatedText;
                pesotara.SetSelection(formatedText.Length);
                pesotara.AfterTextChanged += EditTextPesoTara_AfterTextChanged;
            }
            void EditTextPesoBruto_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
            {
                var text = e.Editable.ToString();
                pesobruto.AfterTextChanged -= EditTextPesoBruto_AfterTextChanged;
                var formatedText = FormatarCampos.PesoValueConverter(text);
                pesobruto.Text = formatedText;
                pesobruto.SetSelection(formatedText.Length);
                pesobruto.AfterTextChanged += EditTextPesoBruto_AfterTextChanged;
            }
            void CarregaListaVeiculos()
            {
                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT _id," +
                " ANOFAB, " +
                " PESOTARA, " +
                " PESOBRUTO, " +
                 " PLACA " +
                 " FROM VEICULOS ";


                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    nomes = new string[icursorTemp.Count];

                    for (int i = 0; i < icursorTemp.Count; i++)
                    {
                        icursorTemp.MoveToNext();
                        item = new CarredaDadosVeiculos();

                        item.Id = icursorTemp.GetString(0);
                        item.AnoFab = icursorTemp.GetString(1);
                        item.PesoTara = icursorTemp.GetString(2);
                        item.PesoBruto = icursorTemp.GetString(3);
                        item.Placa = icursorTemp.GetString(4);
                        char pad = '0';



                        nomes[i] = item.Id.PadLeft(5, '0') + "       " +
                            item.AnoFab.ToString() + "       " +
                            item.PesoTara.PadLeft(6, pad) + "        " +
                            item.PesoBruto.PadLeft(6, ' ') + "      " +
                            item.Placa.ToString().PadLeft(7, ' ');

                    }
                    ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, nomes);

                    Android.Widget.ListView listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaVeiculos);
                    listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaVeiculos);

                    listview.Adapter = itemsAdapter;

                    listview.ItemClick += ListView_ItemClick;
                }

                void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
                {
                    Validacoes.ValorItem = nomes[e.Id];

                    sSQLQuery = "SELECT _id," +
                    " PLACA, " +
                    " ANOFAB, " +
                    " MONTADORA, " +
                    " CATEGORIA, " +
                    " PESOTARA, " +
                    " PESOBRUTO " +
                    " FROM VEICULOS " +
                    $" WHERE _id={Convert.ToInt16(Validacoes.ValorItem.Substring(0, 6))}";

                    icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                    ValorCursor = icursorTemp.Count;
                    if (ValorCursor > 0)
                    {
                        icursorTemp.MoveToNext();
                        placa.Text = icursorTemp.GetString(1);
                        anofab.Text = icursorTemp.GetString(2);
                        firstItem= icursorTemp.GetString(3);
                        firstItemcategoria= icursorTemp.GetString(4);
                        pesotara.Text= icursorTemp.GetString(5);
                        pesobruto.Text = icursorTemp.GetString(6);
                        for (int i=0;spinner.Count>i;i++)
                        {
                            spinner.SetSelection(i);
                            if (firstItem.Equals(spinner.SelectedItem.ToString()))
                            {
                                break;
                            }
                        }
                        for (int i = 0; spinnercategoria.Count > i; i++)
                        {
                            spinnercategoria.SetSelection(i);
                            if (firstItemcategoria.Equals(spinnercategoria.SelectedItem.ToString()))
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        #region [FUNCOES]
        public class CarredaDadosVeiculos
        {
            public string Id { get; set; }
            public string Placa { get; set; }
            public string AnoFab { get; set; }
            public string Montadora { get; set; }
            public string Categoria { get; set; }
            public string PesoTara { get; set; }
            public string PesoBruto { get; set; }
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

        public void insertPesotara(string mask, EditText ediTxt)
        {
            _mask = mask;
            pesotara = ediTxt;
        }

        

        public void insertPlaca(string mask, EditText ediTxt)
        {
            _mask = mask;
            placa = ediTxt;
        }
        


        public static string unmask(string s)
        {
            return s.Replace(".", "").Replace("-", "")
                    .Replace("/", "").Replace("(", "")
                    .Replace(")", "");
        }

        public void AfterTextChanged(IEditable s)
        {
         
        }



        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {

          
        }
        public static string Unmask(string s)
        {
            return s.Replace(".", "").Replace("-", "")
                .Replace("/", "").Replace("(", "")
                .Replace(")", "").Replace(" ", "");
        }
        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            string str = Unmask(s.ToString());
            string mascara = "";
            //if (str.Length >= 14)
            //{
            //    old = str;
            //    isUpdating = false;
            //    return;
            //}
            if (isUpdating)
            {
                old = str;
                isUpdating = false;
                return;
            }

            int i = 0;

            foreach (var m in _mask.ToCharArray())
            {
                if (str.Length >= 7)
                    return;
                if (m != '#' && str.Length > old.Length)
                {
                    mascara += m;
                    continue;
                }
                try
                {
                    mascara += str[i];
                }
                catch (System.Exception ex)
                {
                    Android.Util.Log.Debug("Exmasc", ex?.Message);
                    break;
                }
                i++;
            }

            isUpdating = true;
            placa.Text = mascara;
            placa.SetSelection(mascara.Length);
          
        }
        #endregion

    }
}