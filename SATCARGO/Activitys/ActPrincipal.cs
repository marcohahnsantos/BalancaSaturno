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

using Acr.UserDialogs;
using Android;
using Android.Bluetooth;
using Java.Lang;
using System.Collections.Generic;

namespace SATCARGO
{
    [Activity(Label = "ActPrincipal", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActPrincipal : AppCompatActivity
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
        public SQLiteDatabase sqldTemp;
        Android.Database.ICursor icursorTemp = null;
        string sSQLQuery = "";
        BluetoothSocket[] socket = new BluetoothSocket[1];

        protected override void OnCreate(Bundle bundle)
        {
            EditText TextIp = FindViewById<EditText>(Resource.Id.TextIpConfigura);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layoutprincipal);
            //==========================================================//
            //              CRIAR BANCO DE DADOS                        //
            //==========================================================//
            mdTemp = new BancoDados("PRINCIPAL");
            mdTemp.CreateDatabases("PRINCIPAL");
            //==========================================================//
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "SISTEMA DE PESAGEM PLATAFORMAS VERSÃO 4.6.0";
            var relogioDigital = FindViewById<DigitalClock>(Resource.Id.digitalClock1);
            relogioDigital.Visibility = Android.Views.ViewStates.Visible;
            Android.Support.V7.Widget.AppCompatImageButton BtnCadastroPesagem = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnCadastroPesagem);
            Android.Support.V7.Widget.AppCompatButton BtnClientes = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.BtnClientesCad);
            Android.Support.V7.Widget.AppCompatButton BtnVeiculos = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.BtnVeiculosCad);
            Android.Support.V7.Widget.AppCompatButton BtnProdutos = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.BtnProdutosCad);
            Android.Support.V7.Widget.AppCompatButton BtnPesagem = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.BtnPesagemCad);
            Android.Support.V7.Widget.AppCompatButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatButton>(Resource.Id.BtnSair);
         

            if ((int)Build.VERSION.SdkInt < 23)
            {
                // return;
            }
            else
            {
                if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                {
                    var permissions = new string[]
                    { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                    RequestPermissions(permissions, 1);
                }
            }
         
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                this.FinishAffinity();
                //Finish();
            };
            BtnClientes.Click += delegate
            {
                StartActivity(typeof(ActcadastroClientes));
               // this.FinishAffinity();
                //Finish();
            };
            BtnVeiculos.Click += delegate
            {
                StartActivity(typeof(ActCadastroVeiculos));
                // this.FinishAffinity();
                //Finish();
            };
            BtnProdutos.Click += delegate
            {
                StartActivity(typeof(ActProdutos));
                // this.FinishAffinity();
                //Finish();
            };
            BtnPesagem.Click += delegate
            {
                StartActivity(typeof(ActConsultaPesagens));
                // this.FinishAffinity();
                //Finish();
            };

            BtnCadastroPesagem.Click += delegate
            {
                mdTemp.VerNrPlataformasAtivas();
               

                if (Validacoes.Nrplataformas == 1)
                {
                    StartActivity(typeof(ActCadastroPesagem1));
                    Aguarde();
                }
                if (Validacoes.Nrplataformas == 2)
                {
                    StartActivity(typeof(ActCadastroPesagem2));
                    Aguarde();
                }
                if (Validacoes.Nrplataformas == 3)
                {
                    Aguarde();
                    StartActivity(typeof(ActCadastroPesagem3));
                }
                if (Validacoes.Nrplataformas == 4)
                {
                    Aguarde();
                    StartActivity(typeof(ActCadastroPesagem4));
                }
                if (Validacoes.Nrplataformas == 5)
                {
                    Aguarde();
                    StartActivity(typeof(ActCadastroPesagem5));
                }
                if (Validacoes.Nrplataformas == 6)
                {
                    Aguarde();
                    StartActivity(typeof(ActCadastroPesagem6));
                }
            };
            // Create your application here
        }

        public async void Aguarde()
        {

            using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(9000);
            }

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
                //Validacoes.BSocket[0].Close();
                //ProcessoBalanca();
            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            //================================================================================//
            //                              VALOR CADASTRADOS                                 //
            //================================================================================//
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            if (item.ToString()=="Configuração Comunicação Plataformas")
            {
                StartActivity(typeof(ActConfiguraComunicacao));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Configuração Impressora")
            {
                StartActivity(typeof(ActConfiguraPrinter));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Configuração Sistema")
            {
                StartActivity(typeof(ActConfiguracaoSistema));
                return base.OnOptionsItemSelected(item);
            }

            
            if (item.ToString() == "Cadastro Empresa")
            {
                StartActivity(typeof(ActConfiguracaoEmpresa));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Cadastro Veiculos")
            {
                StartActivity(typeof(ActCadastroVeiculos));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Cadastro Produtos")
            {
                StartActivity(typeof(ActProdutos));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Cadastro Clientes")
            {
                StartActivity(typeof(ActcadastroClientes));
                return base.OnOptionsItemSelected(item);
            }
            if (item.ToString() == "Calibração")
            {
                Aguarde();

                sSQLQuery = "SELECT NR_PLATAFORMAS " +
                            " FROM CONEXAO_PLATAFORMA WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;
                int nrParcelas = 0;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    nrParcelas = int.Parse(icursorTemp.GetString(0));
                    Validacoes.Nrplataformas = nrParcelas;
                    //StartActivity(typeof(ActConfigura4Plataformas));
                    StartActivity(typeof(ActCalibracao));
                    return base.OnOptionsItemSelected(item);
                }  
            }
            if (item.ToString() == "Pesagens Realizadas")
            {
                StartActivity(typeof(ActConsultaPesagens));
                return base.OnOptionsItemSelected(item);
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}