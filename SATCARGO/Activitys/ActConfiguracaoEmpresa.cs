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

using Android.Views.InputMethods;
using Xamarin.Forms;
using Android.Content;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActConfiguracaoEmpresa", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActConfiguracaoEmpresa : AppCompatActivity, Android.Text.ITextWatcher
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
        private SQLiteDatabase sqldTemp;
        private string old;
        private bool isUpdating;
        private string _mask;

        public EditText et { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            EditText TextIp = FindViewById<EditText>(Resource.Id.TextIpConfigura);
            base.OnCreate(bundle);
        
            string sSQLQuery = "";

           


            SetContentView(Resource.Layout.layoutEmpresa);

            SetResult(Result.Canceled);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "CADASTRO EMPRESA PRINCIPAL";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);




            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock2);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;

            EditText et = FindViewById<EditText>(Resource.Id.txtCnpj);

          

            EditText Insc = FindViewById<EditText>(Resource.Id.TxtInsc);
            EditText Nome = FindViewById<EditText>(Resource.Id.TxtNome);
            EditText Endereco = FindViewById<EditText>(Resource.Id.TxtEnder);
            EditText Bairro = FindViewById<EditText>(Resource.Id.TxtBairro);
            EditText Cidade = FindViewById<EditText>(Resource.Id.TxtCidade);
            EditText Uf = FindViewById<EditText>(Resource.Id.TxtUf);
            
            //  var ed = FindViewById<EditText>(Resource.Id.txtCnpj);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairEmpresas);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarEmpresas);

            insert("##.###.###/####-##", et);

            et.AddTextChangedListener(this);
           
            // Create your application here

            sSQLQuery = "";
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);

            sSQLQuery = "";

            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = "SELECT CNPJ," +
                        " IE, " +
                        " NOME, " +
                        " ENDERECO, " +
                        " BAIRRO, " +
                        " CIDADE, " +
                        " UF " +
                        " FROM EMPRESA WHERE _id=1";

            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


            int ValorCursor = icursorTemp.Count;
            if (ValorCursor > 0)
            {
                icursorTemp.MoveToNext();
                et.Text = icursorTemp.GetString(0);
                Insc.Text = icursorTemp.GetString(1);
                Nome.Text = icursorTemp.GetString(2);
                Endereco.Text  = icursorTemp.GetString(3);
                Bairro.Text = icursorTemp.GetString(4);
                Cidade.Text = icursorTemp.GetString(5);
                Uf.Text = icursorTemp.GetString(6);
            
            }
            Window.SetSoftInputMode(SoftInput.StateHidden);

            BtnSair.Click += delegate
            {
                Finish();
            };
            
        BtnSalvar.Click += delegate
            {
                if (et.Text == "")
                {
                    Toast.MakeText(this, "Deve ser digitado um CNPJ!", ToastLength.Short).Show();
                    return;
                }
                if (Nome.Text == "")
                {
                    Toast.MakeText(this, "Nome da empresa deve ser digitado!", ToastLength.Short).Show();
                    return;
                }
                if (Endereco.Text == "")
                {
                    Toast.MakeText(this, "Endereço deve ser digitado!", ToastLength.Short).Show();
                    return;
                }
                if (Bairro.Text == "")
                {
                    Toast.MakeText(this, "Bairro deve ser digitado!", ToastLength.Short).Show();
                    return;
                }
                if (Cidade.Text == "")
                {
                    Toast.MakeText(this, "Cidade deve ser digitada!", ToastLength.Short).Show();
                    return;
                }
                if (Uf.Text == "")
                {
                    Toast.MakeText(this, "Uf deve ser digitada!", ToastLength.Short).Show();
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

              


                sSQLQuery = "";
                sSQLQuery = "SELECT CNPJ " +
                " FROM EMPRESA ";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                ValorCursor = icursorTemp.Count;
                

                string Data = System.DateTime.Today.ToShortDateString();
                string Hora = System.DateTime.Today.ToShortTimeString();

                if (ValorCursor == 0)
                {

                    string Valores = "'"+et.Text + "','" +
                            Insc.Text + "','" +
                            Nome.Text + "','" +
                            Endereco.Text + "','" +
                            Bairro.Text + "','" +
                            Cidade.Text + "','" +
                            Uf.Text + "','" +
                            Data + "','" +
                            Hora + "'";
 
                    string Campos = "CNPJ," +
                            "IE," +
                            "NOME," +
                            "ENDERECO," +
                            "BAIRRO," +
                            "CIDADE," +
                            "UF," +
                            "DATA_CADASTRO," +
                            "HORA_CADASTRO";

                    sSQLQuery = "INSERT INTO " +
                            "EMPRESA " + "(" + Campos + ") " +
                            "VALUES(" + Valores + ");";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                    Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();
                }
                else
                {
                  
                    string ComandoSql = "update EMPRESA set " +
                                   $" CNPJ='{et.Text}'," +
                                   $" IE='{Insc.Text}'," +
                                   $" NOME='{Nome.Text}'," +
                                   $" ENDERECO='{Endereco.Text}', " +
                                   $" BAIRRO='{Bairro.Text}', " +
                                   $" CIDADE='{Cidade.Text}', " +
                                   $" UF='{Uf.Text}', " +
                                   $" DATA_CADASTRO='{Data}', " +
                                   $" HORA_CADASTRO='{Hora}' " +
                                   $" where _id=1  ";

                    sqldTemp.ExecSQL(ComandoSql);
                   
                    Toast.MakeText(this, "Atualização realizada com sucesso", ToastLength.Long).Show();
                }
                Validacoes.EmpresaNome = Nome.Text;
                Validacoes.EmpresaCnpj = et.Text;
                Validacoes.EmpresaIe = Insc.Text;
                Validacoes.EmpresaEndereco = Endereco.Text;
                Validacoes.EmpresaBairro = Bairro.Text;
                Validacoes.EmpresaCidade = Cidade.Text;
                Validacoes.EmpresaUf = Uf.Text;
            };


        }
  
        public void insert(string mask, EditText ediTxt)
        {
            _mask = mask;
            et = ediTxt;
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
            if (str.Length >= 14)
            {
                old = str;
                isUpdating = false;
                return;
            }
            if (isUpdating)
            {
                old = str;
                isUpdating = false;
                return;
            }

            int i = 0;

            foreach (var m in _mask.ToCharArray())
            {
                if (str.Length >= 14)
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

            et.Text = mascara;

            et.SetSelection(mascara.Length);


        }
    

   
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.home, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }

       

       
        
    }
}