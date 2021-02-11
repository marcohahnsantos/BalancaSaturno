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
using System;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActcadastroClientes", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActcadastroClientes : AppCompatActivity
    {
        private string sMessage;
        string[] nomes;
        public ArrayAdapter adapter { get; private set; }
        private SQLiteDatabase sqldTemp;
        private CarreDadosClientes item;
        BancoDados mdTemp;
        public EditText cnpjcpf { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string sSQLQuery = "";

            SetContentView(Resource.Layout.layouttCliente);

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO DE CLIENTES";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock2);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;

            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairClientes);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarClientes);
            EditText cnpjcpf = FindViewById<EditText>(Resource.Id.txtCnpjCpf);
            cnpjcpf.AfterTextChanged += EditTextcnpjcpf_AfterTextChanged;


            EditText Nome = FindViewById<EditText>(Resource.Id.TxtNomeCliente);
            EditText Endereco = FindViewById<EditText>(Resource.Id.TxtEnderCliente);
            EditText Bairro = FindViewById<EditText>(Resource.Id.TxtBairroCliente);
            EditText Cidade = FindViewById<EditText>(Resource.Id.TxtCidadeCliente);
            EditText Uf = FindViewById<EditText>(Resource.Id.TxtUfCliente);
            TextView codigo = FindViewById<TextView>(Resource.Id.txtCodigoCliente); 
            
            sSQLQuery = "";
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);

            CarregaListaClientes();
            Window.SetSoftInputMode(SoftInput.StateHidden);
            BtnSair.Click += delegate
            {
                Finish();
            };

            BtnSalvar.Click += delegate
            {
                if (cnpjcpf.Text == "")
                {
                    Toast.MakeText(this, "Deve ser digitado uma Cnpj ou Cpd!", ToastLength.Short).Show();
                    return;
                }
                if (Nome.Text == "")
                {
                    Toast.MakeText(this, "Deve ser digitado um nome de cliente!", ToastLength.Short).Show();
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
                sSQLQuery = $"SELECT _id FROM CLIENTES WHERE _id='{codigo.Text}'";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;


                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                    if (cnpjcpf.Text.Length != 14 && cnpjcpf.Text.Length != 18)
                    {
                        Toast.MakeText(this, "Tamanho CPF OU CNPJ Campo Inválido", ToastLength.Short).Show();
                        return;
                    }


                     string tipo = "CNPJ";
                    if (cnpjcpf.Text.Length == 14)
                        tipo = "CPF";





                    string Valores = "'" + cnpjcpf.Text + "','" +
                                        tipo + "','" +
                                        Nome.Text + "','" +
                                        Endereco.Text + "','" +
                                        Bairro.Text + "','" +
                                        Cidade.Text + "','" +
                                        Uf.Text + "','" +
                                        Data + "','" +
                                        Hora + "'";
                    
                    string Campos = "CNPJ_CPF," +
                        "TIPO," +
                        "NOME," +
                        "ENDERECO," +
                        "BAIRRO," +
                        "CIDADE," +
                        "UF," +
                        "DATA_CADASTRO," +
                        "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                        "CLIENTES " + "(" + Campos + ") " +
                        "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                    string ComandoSql = "update CLIENTES set " +
                                $" CNPJ_CPF='{cnpjcpf.Text}'," +
                                $" NOME='{Nome.Text}'," +
                                $" ENDERECO='{Endereco.Text}'," +
                                $" BAIRRO='{Bairro.Text}'," +
                                $" CIDADE='{Cidade.Text}'," +
                                $" UF='{Uf.Text}'," +
                                $" DATA_CADASTRO='{Data}', " +
                                $" HORA_CADASTRO='{Hora}' " +
                                $" where _id={codigo.Text}";

                    sqldTemp.ExecSQL(ComandoSql);
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
                cnpjcpf.Text = "";
                Nome.Text = "";
                Endereco.Text = "";
                Bairro.Text = "";
                Cidade.Text = "";
                Uf.Text = "";
                codigo.Text = "";
                CarregaListaClientes();
            };


            void CarregaListaClientes()
            {
                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT _id,CNPJ_CPF," +
                " NOME "+
                 " FROM CLIENTES ";


                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    nomes = new string[icursorTemp.Count];

                    for (int i = 0; i < icursorTemp.Count; i++)
                    {
                        icursorTemp.MoveToNext();
                        item = new CarreDadosClientes();

                        item.Id = icursorTemp.GetString(0);
                        
                        item.cnpjcpf = icursorTemp.GetString(1);
                        if (item.cnpjcpf.Length == 14)
                            item.cnpjcpf=item.cnpjcpf.PadRight(22,' ');
                            item.nome = icursorTemp.GetString(2);


                        nomes[i] = item.Id.PadLeft(5, '0') + "      " +
                            item.cnpjcpf+ "   "+
                            item.nome;

                    }
                    ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, nomes);

                    Android.Widget.ListView listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaClientes);
                    listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaClientes);

                    listview.Adapter = itemsAdapter;

                    listview.ItemClick += ListView_ItemClick;
                }
                void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
                {
                    Validacoes.ValorItem = nomes[e.Id];

                    sSQLQuery = "SELECT _id," +
                    " CNPJ_CPF, " +
                    " NOME, " +
                    " ENDERECO, " +
                    " BAIRRO, " +
                    " CIDADE, " +
                    " UF " +
                    " FROM CLIENTES " +
                    $" WHERE _id={Convert.ToInt16(Validacoes.ValorItem.Substring(0, 6))}";

                    icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                    ValorCursor = icursorTemp.Count;
                    if (ValorCursor > 0)
                    {
                        icursorTemp.MoveToNext();
                        codigo.Text= icursorTemp.GetString(0);
                        cnpjcpf.Text = icursorTemp.GetString(1);
                        Nome.Text = icursorTemp.GetString(2);
                        Endereco.Text = icursorTemp.GetString(3);
                        Bairro.Text = icursorTemp.GetString(4);
                        Uf.Text = icursorTemp.GetString(5);
                    }
                }
            }


            void EditTextcnpjcpf_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
            {

                var text = e.Editable.ToString();
                cnpjcpf.AfterTextChanged -= EditTextcnpjcpf_AfterTextChanged;
                var formatedText = FormatarCampos.CpnpjCpfValueConverter(text);
                cnpjcpf.Text = formatedText;
                cnpjcpf.SetSelection(formatedText.Length);
                cnpjcpf.AfterTextChanged += EditTextcnpjcpf_AfterTextChanged;
            }


            // Create your application here
        }

        #region [FUNCOES]

    

        public class CarreDadosClientes
        {
            public string Id { get; set; }
            public string tipo { get; set; }
            public string cnpjcpf { get; set; }
            public string nome { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
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