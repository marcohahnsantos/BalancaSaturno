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
using Android;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActCadastroPesagem1_1", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActCadastroPesagem1_1 : AppCompatActivity
    {
        string[] selecaocliente;
        Spinner spinnercliente;
        public ArrayAdapter adapterccliente { get; set; }

        string[] selecaoveiculos;
        Spinner spinnerveiculo;
        public ArrayAdapter adapterveiculo { get; set; }

        string[] selecaoprodutos;
        Spinner spinnerproduto;
        public ArrayAdapter adapterproduto { get; set; }


        private SQLiteDatabase sqldTemp;
        BancoDados mdTemp;
        string[] nomes;
        private Clientes.CarredaDadosClientes item;
        private Veiculos.CarredaDadosVeiculos itemveiculos;
        private Produtos.CarredaDadosProdutos itemprodutos;
        string firstItemcliente = "";
        string firstItemveiculo = "";
        string firstItemproduto = "";
        TextView TxtPeso;
        private CarredaDadosPesagem itemPesagem;
        Android.Widget.ProgressBar progressBar;
        TextView TxtProgress;
        BluetoothSocket[] socketImpressora = new BluetoothSocket[1];
        private string requestLegacyExternalStorage;

        public EditText Motorista { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.LayoutCadastroPesagem1_1);
            SetResult(Result.Canceled);
            if (Validacoes.ImpressoraAtiva == "S")
            {
                if (Validacoes.NomeImpressora != null)
                {
                    if (Validacoes.NomeImpressora != "")
                    {
                        Validacoes.ConectaImpressora();
                        Thread.Sleep(3000);
                    }
                }
            }

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
            spinnercliente = FindViewById<Spinner>(Resource.Id.SpinnerCliente);
            spinnerveiculo = FindViewById<Spinner>(Resource.Id.SpinnerVeiculo);
            spinnerproduto = FindViewById<Spinner>(Resource.Id.SpinnerProduto);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSairPesagem);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvarPesagem);
            TxtPeso = FindViewById<TextView>(Resource.Id.Txtpeso);
            progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.list_progress);
            progressBar.Visibility = Android.Views.ViewStates.Invisible;
            TxtProgress = FindViewById<TextView>(Resource.Id.TxtAguardeProgress);
            TxtProgress.Visibility = Android.Views.ViewStates.Invisible;
            EditText Motorista = FindViewById<EditText>(Resource.Id.EditTextMotorista);

            if (Validacoes.Nrplataformas + 1 == 1)
                TxtPeso.Text = Validacoes.PesagemRealizadaPlat1.ToString();
            if (Validacoes.Nrplataformas + 1 == 2)
            {
                Validacoes.Peso1 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat1);
                Validacoes.Peso2 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat2);
                TxtPeso.Text = Convert.ToString(Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2);
            }
            if (Validacoes.Nrplataformas + 1 == 3)
            {
                Validacoes.Peso1 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat1);
                Validacoes.Peso2 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat2);
                Validacoes.Peso3 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat3);
                TxtPeso.Text = Convert.ToString(Validacoes.PesagemRealizadaPlat1 +
                                                Validacoes.PesagemRealizadaPlat2 +
                                                Validacoes.PesagemRealizadaPlat3);
            }
            if (Validacoes.Nrplataformas + 1 == 4)
            {
                Validacoes.Peso1 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat1);
                Validacoes.Peso2 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat2);
                Validacoes.Peso3 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat3);
                Validacoes.Peso4 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat4);
                TxtPeso.Text = Convert.ToString(Validacoes.PesagemRealizadaPlat1 +
                                                Validacoes.PesagemRealizadaPlat2 +
                                                Validacoes.PesagemRealizadaPlat3 +
                                                Validacoes.PesagemRealizadaPlat4);
            }
            if (Validacoes.Nrplataformas + 1 == 5)
            {
                Validacoes.Peso1 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat1);
                Validacoes.Peso2 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat2);
                Validacoes.Peso3 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat3);
                Validacoes.Peso4 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat4);
                Validacoes.Peso5 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat5);
                TxtPeso.Text = Convert.ToString(Validacoes.PesagemRealizadaPlat1 +
                                                Validacoes.PesagemRealizadaPlat2 +
                                                Validacoes.PesagemRealizadaPlat3 +
                                                Validacoes.PesagemRealizadaPlat4 +
                                                Validacoes.PesagemRealizadaPlat5);
            }
            if (Validacoes.Nrplataformas + 1 == 6)
            {
                Validacoes.Peso1 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat1);
                Validacoes.Peso2 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat2);
                Validacoes.Peso3 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat3);
                Validacoes.Peso4 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat4);
                Validacoes.Peso5 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat5);
                Validacoes.Peso6 = Convert.ToInt32(Validacoes.PesagemRealizadaPlat6);
                TxtPeso.Text = Convert.ToString(Validacoes.PesagemRealizadaPlat1 +
                                                Validacoes.PesagemRealizadaPlat2 +
                                                Validacoes.PesagemRealizadaPlat3 +
                                                Validacoes.PesagemRealizadaPlat4 +
                                                Validacoes.PesagemRealizadaPlat5 +
                                                Validacoes.PesagemRealizadaPlat6);
            }


            var NomesClientes = CarregaCliente();
            if (NomesClientes != null)
            {
                selecaocliente = new string[NomesClientes.Count];
                for (int i = 0; NomesClientes.Count > i; i++)
                {
                    selecaocliente[i] = NomesClientes[i].ToString();
                }
                adapterccliente = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaocliente);
                spinnercliente.Adapter = adapterccliente;
            }

            var NomesVeiculos = CarregaVeiculos();
            if (NomesVeiculos != null)
            {
                selecaoveiculos = new string[NomesVeiculos.Count];
                for (int i = 0; NomesVeiculos.Count > i; i++)
                {
                    selecaoveiculos[i] = NomesVeiculos[i].ToString();
                }
                adapterveiculo = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaoveiculos);
                spinnerveiculo.Adapter = adapterveiculo;
            }
            var NomesProdutos = CarregaProdutos();
            if (NomesProdutos != null)
            {
                selecaoprodutos = new string[NomesProdutos.Count];
                for (int i = 0; NomesProdutos.Count > i; i++)
                {
                    selecaoprodutos[i] = NomesProdutos[i].ToString();
                }
                adapterproduto = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, selecaoprodutos);
                spinnerproduto.Adapter = adapterproduto;
            }
            //=================================================================================//
            spinnercliente.ItemSelected += (s, e) =>
            {
                firstItemcliente = spinnercliente.SelectedItem.ToString();
                if (firstItemcliente.Equals(spinnercliente.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
            spinnerveiculo.ItemSelected += (s, e) =>
            {
                firstItemveiculo = spinnerveiculo.SelectedItem.ToString();
                if (firstItemveiculo.Equals(spinnerveiculo.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
            spinnerproduto.ItemSelected += (s, e) =>
            {
                firstItemproduto = spinnerproduto.SelectedItem.ToString();
                if (firstItemproduto.Equals(spinnerproduto.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(),
                        ToastLength.Short).Show();
                }
            };
           
            CarregaListaPesagem();
            Window.SetSoftInputMode(SoftInput.StateHidden);
            //========================//
            //        SAIR            //
            //========================//
            BtnSair.Click += delegate
            {
                BtnSair.Enabled = false;
                Validacoes.AdaptadorBluetooth.Dispose();
                if (Validacoes.ImpressoraAtiva == "S")
                {
                    Thread.Sleep(1000);
                    if (Validacoes.NomeImpressora != null)
                    {
                        if (Validacoes.BSocketImpressora != null)
                        {
                            if (Validacoes.BSocketImpressora[0].IsConnected == true)
                                Validacoes.BSocketImpressora[0].Close();
                        }
                    }
                }
                Thread.Sleep(1000);
                Finish();
            };
            //========================//
            //        SALVAR          //
            //========================//
            BtnSalvar.Click += delegate
            {
                //define o alerta para executar a tarefa
                Android.App.AlertDialog.Builder alerta = new Android.App.AlertDialog.Builder(this);
              

                //==================================//
                //  return;
                //==================================//
                //       VALIDACOES                 //
                //==================================//
                if (firstItemcliente.ToString()=="")
                {
                    Toast.MakeText(this, "Campo cliente deve ser selecionado", ToastLength.Long).Show();
                    spinnercliente.GetFocusable();
                    return;
                }
                if (firstItemproduto.ToString() == "")
                {
                    Toast.MakeText(this, "Campo produto deve ser selecionado", ToastLength.Long).Show();
                    spinnerproduto.GetFocusable();
                    return;
                }
                if (firstItemveiculo.ToString() == "")
                {
                    Toast.MakeText(this, "Campo veiculo deve ser selecionado", ToastLength.Long).Show();
                    spinnercliente.GetFocusable();
                    return;
                }
                if (Motorista.Text == "")
                {
                    Toast.MakeText(this, "Campo Motorista deve ser preenchido", ToastLength.Long).Show();
                    return;
                }
                

                //Validacoes.Peso1 = Convert.ToInt32(TxtPeso.Text);
                //=========================//
                //     Capturando Dados    //
                //=========================//
                //        Veiculos         //
                //=========================//
                String[] veiculos = firstItemveiculo.Split("-");
                int id_veiculo = int.Parse(veiculos[0]);
                string placa_veiculo = veiculos[1] + "-" + veiculos[2];
                //=========================//
                //        Clientes         //
                //=========================//
                string[] clientes = firstItemcliente.Split("-");
                int id_cliente = int.Parse(clientes[0]);
                string nome_cliente = clientes[1].ToString();
                //=========================//
                //        Produtos         //
                //=========================//
                string[] produtos = firstItemproduto.Split("-");
                int id_produto = int.Parse(produtos[0]);
                string nome_produto = produtos[1].ToString();
                string Data = System.DateTime.Now.ToShortDateString();
                string Hora = System.DateTime.Now.ToShortTimeString();

                double PesoTotal = Validacoes.Peso1 +
                                 Validacoes.Peso2 +
                                 Validacoes.Peso3 +
                                 Validacoes.Peso4 +
                                 Validacoes.Peso5 +
                                 Validacoes.Peso6;


                string Valores = id_veiculo + ",'" +
                                     placa_veiculo + "'," +
                                     id_cliente + ",'" +
                                     nome_cliente + "'," +
                                     id_produto + ",'" +
                                     nome_produto + "','" +
                                     Motorista.Text + "'," +
                                     Validacoes.NrPlataformas.ToString() + "," +
                                     Validacoes.Peso1 + "," +
                                     Validacoes.Peso2 + "," +
                                     (Validacoes.Peso1 + Validacoes.Peso1) + "," +
                                     Validacoes.Peso3 + "," +
                                     Validacoes.Peso4 + "," +
                                     (Validacoes.Peso3 + Validacoes.Peso4) + "," +
                                     Validacoes.Peso5 + "," +
                                     Validacoes.Peso6 + "," +
                                     (Validacoes.Peso5 + Validacoes.Peso6) + "," +
                                     PesoTotal + ",'" +
                                     Data + "','" +
                                     Hora + "'";
                string Campos = "ID_VEICULO," +
                                "VEICULO," +
                                "ID_CLIENTE," +
                                "CLIENTE," +
                                "ID_PRODUTO," +
                                "PRODUTO," +
                                "MOTORISTA," +
                                "NR_PLATAFORMAS," +
                                "PESO_PLAT1," +
                                "PESO_PLAT2," +
                                "PESO_EIXO1," +
                                "PESO_PLAT3," +
                                "PESO_PLAT4," +
                                "PESO_EIXO2," +
                                "PESO_PLAT5," +
                                "PESO_PLAT6," +
                                "PESO_EIXO3," +
                                "PESO_TOTAL," +
                                "DATA_CADASTRO," +
                                "HORA_CADASTRO";

                string sSQLQuery = "INSERT INTO " +
                "PESAGEMS_REALIZADAS " + "(" + Campos + ") " +
                "VALUES(" + Valores + ");";
                sqldTemp.ExecSQL(sSQLQuery);
                Toast.MakeText(this, "REGISTRO GRAVADO COM SUCESSO", ToastLength.Long).Show();

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT  " +
                            "ID_CLIENTE," +
                            "CLIENTE," +
                            "ID_VEICULO," +
                            "VEICULO," +
                            "ID_PRODUTO," +
                            "PRODUTO," +
                            "MOTORISTA," +
                            "NR_PLATAFORMAS," +
                            "PESO_PLAT1," +
                            "PESO_PLAT2," +
                            "PESO_PLAT3," +
                            "PESO_PLAT4," +
                            "PESO_PLAT5," +
                            "PESO_PLAT6," +
                            "PESO_TOTAL," +
                            "DATA_CADASTRO," +
                            "HORA_CADASTRO, " +
                            "_id " +
                            "FROM PESAGEMS_REALIZADAS ORDER BY _id DESC LIMIT 1";



                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;



                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.PesagemRealizadaIdCliente = icursorTemp.GetString(0);
                    Validacoes.PesagemRealizadaCliente = icursorTemp.GetString(1);
                    Validacoes.PesagemRealizadaIdVeiculo = icursorTemp.GetString(2);
                    Validacoes.PesagemRealizadaVeiculo = icursorTemp.GetString(3);
                    Validacoes.PesagemRealizadaIdProduto = icursorTemp.GetString(4);
                    Validacoes.PesagemRealizadaProduto = icursorTemp.GetString(5);
                    Validacoes.PesagemRealizadaMotorista = icursorTemp.GetString(6);
                    Validacoes.PesagemRealizadaNrPlataformas = icursorTemp.GetString(7);
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(icursorTemp.GetString(8));
                    Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(icursorTemp.GetString(9));
                    Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(icursorTemp.GetString(10));
                    Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(icursorTemp.GetString(11));
                    Validacoes.PesagemRealizadaPlat5 = Convert.ToDouble(icursorTemp.GetString(12));
                    Validacoes.PesagemRealizadaPlat6 = Convert.ToDouble(icursorTemp.GetString(13));
                    Validacoes.PesagemRealizadaTotal = Convert.ToDouble(icursorTemp.GetString(14));
                    Validacoes.PesagemRealizadaData = icursorTemp.GetString(15);
                    Validacoes.PesagemRealizadaHora = icursorTemp.GetString(16);
                    Validacoes.PesagemRealizadaId = icursorTemp.GetString(17);
                }


                if (Validacoes.ImpressoraAtiva == "S")
                {
                    if (Validacoes.NomeImpressora != null)
                    {
                        if (Validacoes.NomeImpressora != "")
                        {
                            //define o titulo e o ícone a exibir no dialogo
                            alerta.SetTitle(" SATCARGO - IMPRESSÃO ");
                            alerta.SetIcon(Android.Resource.Drawable.IcInputAdd);
                            //define a mensagem
                            alerta.SetMessage("Deseja imprimir ?");
                            //define o botão positivo
                            alerta.SetPositiveButton("Sim", (senderAlert, args) =>
                            {
                                Thread.Sleep(1000);
                                Imprimir();
                            });
                            //define o botão negativo
                            alerta.SetNegativeButton("Não", (senderAlert, args) =>
                            {
                                Toast.MakeText(this, "Impressão Cancelada !", ToastLength.Short).Show();
                                string pasta = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                                string localizacao = Path.Combine(pasta, $"Ticket{Validacoes.PesagemRealizadaId.PadLeft(6, '0')}.csv");
                                // gravar no arquivo
                                StreamWriter arquivo = new StreamWriter(localizacao, false);
                                string Cabecario = "EMPRESACADASTRADA;CNPJCADASTRADA;DATA;HORA;CLIENTE;PLACA;PRODUTO;MOTORISTA;PESO_PLAT1;PESO_PLAT2;PESO_EIXO1;PESO_PLAT3;PESO_PLAT4;PESO_EIXO2;PESO_PLAT5;PESO_PLAT6;PESO_EIXO3;PESO_TOTAL";
                                arquivo.WriteLine(Cabecario);
                                string LinhaDados = $"{Validacoes.PesagemRealizadaData};" +
                                                      $"{Validacoes.PesagemRealizadaHora};" +
                                                      $"{Validacoes.PesagemRealizadaCliente};" +
                                                      $"{Validacoes.PesagemRealizadaVeiculo};" +
                                                      $"{Validacoes.PesagemRealizadaProduto};" +
                                                      $"{Validacoes.PesagemRealizadaMotorista};" +
                                                      $"{Validacoes.PesagemRealizadaPlat1};" +
                                                      $"{Validacoes.PesagemRealizadaPlat2};" +
                                                      $"{Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2};" +
                                                      $"{Validacoes.PesagemRealizadaPlat3};" +
                                                      $"{Validacoes.PesagemRealizadaPlat4};" +
                                                      $"{Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4};" +
                                                      $"{Validacoes.PesagemRealizadaPlat5};" +
                                                      $"{Validacoes.PesagemRealizadaPlat6};" +
                                                      $"{Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6};" +
                                                      $"{Validacoes.PesagemRealizadaTotal};";
                                arquivo.WriteLine(LinhaDados);

                                arquivo.Dispose();
                                Validacoes.AdaptadorBluetooth.Dispose();
                                BtnSair.Enabled = false;
                                if (Validacoes.ImpressoraAtiva == "S")
                                {
                                    Thread.Sleep(1000);
                                    if (Validacoes.NomeImpressora != null)
                                    {
                                        if (Validacoes.BSocketImpressora != null)
                                        {
                                            if (Validacoes.BSocketImpressora[0].IsConnected == true)
                                                Validacoes.BSocketImpressora[0].Close();
                                        }
                                    }
                                }
                                Finish();
                            });
                            //cria o alerta e exibe
                            Dialog dialog = alerta.Create();
                            dialog.Show();
                            Validacoes.AdaptadorBluetooth.Dispose();
                            Thread.Sleep(1000);
                            BtnSair.Enabled = false;
                        }
                        else
                        {

                            Validacoes.AdaptadorBluetooth.Dispose();
                            BtnSair.Enabled = false;
                            if (Validacoes.ImpressoraAtiva == "S")
                            {
                                Thread.Sleep(1000);
                                if (Validacoes.NomeImpressora != null)
                                {
                                    if (Validacoes.BSocketImpressora != null)
                                    {
                                        if (Validacoes.BSocketImpressora[0].IsConnected == true)
                                            Validacoes.BSocketImpressora[0].Close();
                                    }
                                }
                            }
                            Finish();
                        }

                    }
                }
                else
                {
                    string pasta = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                    string localizacao = Path.Combine(pasta, $"Ticket{Validacoes.PesagemRealizadaId.PadLeft(6, '0')}.csv");
                    // gravar no arquivo
                    StreamWriter arquivo = new StreamWriter(localizacao, false);
                    string Cabecario = "EMPRESACADASTRADA;CNPJCADASTRADA;DATA;HORA;CLIENTE;PLACA;PRODUTO;MOTORISTA;PESO_PLAT1;PESO_PLAT2;PESO_EIXO1;PESO_PLAT3;PESO_PLAT4;PESO_EIXO2;PESO_PLAT5;PESO_PLAT6;PESO_EIXO3;PESO_TOTAL";
                    arquivo.WriteLine(Cabecario);
                    string LinhaDados = $"{Validacoes.EmpresaNome};{Validacoes.EmpresaCnpj};" +
                                          $"{Validacoes.PesagemRealizadaData};" +
                                          $"{Validacoes.PesagemRealizadaHora};" +
                                          $"{Validacoes.PesagemRealizadaCliente};" +
                                          $"{Validacoes.PesagemRealizadaVeiculo};" +
                                          $"{Validacoes.PesagemRealizadaProduto};" +
                                          $"{Validacoes.PesagemRealizadaMotorista};" +
                                          $"{Validacoes.PesagemRealizadaPlat1};" +
                                          $"{Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2};" +
                                          $"{Validacoes.PesagemRealizadaPlat3};" +
                                          $"{Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4};" +
                                          $"{Validacoes.PesagemRealizadaPlat5};" +
                                          $"{Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6};" +
                                          $"{Validacoes.PesagemRealizadaTotal};";
                    arquivo.WriteLine(LinhaDados);
                    arquivo.Dispose();
                    Validacoes.AdaptadorBluetooth.Dispose();
                    Thread.Sleep(1000);
                    BtnSair.Enabled = false;
                    if (Validacoes.ImpressoraAtiva == "S")
                    {
                        if (Validacoes.NomeImpressora != null)
                        {
                            if (Validacoes.BSocketImpressora != null)
                            {
                                if (Validacoes.BSocketImpressora[0].IsConnected == true)
                                    Validacoes.BSocketImpressora[0].Close();
                            }
                        }
                    }
                    Finish();
                    return;
                }
            };
        }



        #region [FUNCOES]
        public async void
         MensagemAguarde()
        {
            //using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            //{
            //    await System.Threading.Tasks.Task.Delay(500);
            //}

        }
        public void Imprimir()
        {

            try
            {

                var output = Validacoes.BSocketImpressora[0].OutputStream;
                var readput = Validacoes.BSocketImpressora[0].InputStream;
                byte[] buffer1 = new byte[3];
                buffer1[0] = 0x1B;
                buffer1[1] = 0x21;
                buffer1[2] = 0x08;
                output.Write(buffer1, 0, buffer1.Count());
                String Cnpj= $"CNPJ : {Validacoes.EmpresaCnpj}";
                String Ie = $"IE :{Validacoes.EmpresaIe}";
                String CidaeUf= $"{Validacoes.EmpresaCidade } - { Validacoes.EmpresaUf}";
                byte[] buffer = new byte[35];
                //======================================//
                //          CABEÇARIO                   //
                //======================================//

                buffer = Validacoes.Configure_linha_Centro();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaNome}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"{Cnpj}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"{Ie}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaEndereco}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"{Validacoes.EmpresaCidade} - {Validacoes.EmpresaUf}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Configure_linha_Esquerda();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"DATA/HORA : {Validacoes.PesagemRealizadaData} {Validacoes.PesagemRealizadaHora}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"PLACA     :{Validacoes.PesagemRealizadaVeiculo}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"PRODUTO   : {Validacoes.PesagemRealizadaProduto}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"MOTORISTA : {Validacoes.PesagemRealizadaMotorista}");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"CLIENTE   : {Validacoes.PesagemRealizadaCliente}");
                output.Write(buffer, 0, buffer.Count());
                //  buffer = Validacoes.Imprime_linha_Empresa($"UF            : {Validacoes.EmpresaUf}");
                //  output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());

                if (Validacoes.NrPlataformas == 1)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLATAFORMA 1  :  {Validacoes.PesagemRealizadaTotal.ToString()} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }
                if (Validacoes.NrPlataformas == 2)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.Peso1.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.Peso2.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }
                if (Validacoes.NrPlataformas == 3)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.Peso1.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.Peso2.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.Peso3.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }
                if (Validacoes.NrPlataformas == 4)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.Peso1.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.Peso2.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.Peso3.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.Peso4.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    PesoEixo = Validacoes.Peso3 + Validacoes.Peso4;
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }
                if (Validacoes.NrPlataformas == 5)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.Peso1.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.Peso2.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.Peso3.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.Peso4.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    PesoEixo = Validacoes.Peso3 + Validacoes.Peso4;
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.5  : {Validacoes.Peso5.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }
                if (Validacoes.NrPlataformas == 6)
                {
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.1  : {Validacoes.Peso1.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.2  : {Validacoes.Peso2.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    double PesoEixo = Validacoes.Peso1 + Validacoes.Peso2;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 1  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.3  : {Validacoes.Peso3.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.4  : {Validacoes.Peso4.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    PesoEixo = Validacoes.Peso3 + Validacoes.Peso4;
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 2  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.5  : {Validacoes.Peso5.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO PLAT.6  : {Validacoes.Peso6.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                    buffer = Validacoes.Imprime_linha();
                    output.Write(buffer, 0, buffer.Count());
                    PesoEixo = Validacoes.Peso5 + Validacoes.Peso6;
                    buffer = Validacoes.Imprime_linha_Empresa($"PESO EIXO 3  : {PesoEixo.ToString().PadLeft(10, ' ')} Kg");
                    output.Write(buffer, 0, buffer.Count());
                }



                buffer = Validacoes.Configure_linha_Esquerda();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha_Empresa($"PESO TOTAL     {Validacoes.PesagemRealizadaTotal.ToString().PadLeft(10, ' ')} Kg");
                output.Write(buffer, 0, buffer.Count());
                buffer = Validacoes.Imprime_linha();
                output.Write(buffer, 0, buffer.Count());

                System.Threading.Thread.Sleep(300);
                //GRAVANDO ARQUIVO
                string pasta = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string localizacao = Path.Combine(pasta, $"Ticket{Validacoes.PesagemRealizadaId.PadLeft(6, '0')}.csv");
                // gravar no arquivo
                StreamWriter arquivo = new StreamWriter(localizacao, false);
                string Cabecario = "EMPRESACADASTRADA;CNPJCADASTRADA;DATA;HORA;CLIENTE;PLACA;PRODUTO;MOTORISTA;PESO_PLAT1;PESO_PLAT2;PESO_EIXO1;PESO_PLAT3;PESO_PLAT4;PESO_EIXO2;PESO_PLAT5;PESO_PLAT6;PESO_EIXO3;PESO_TOTAL";
                arquivo.WriteLine(Cabecario);
                string LinhaDados = $"{Validacoes.EmpresaNome};{Validacoes.EmpresaCnpj};" +
                                      $"{Validacoes.PesagemRealizadaData};" +
                                      $"{Validacoes.PesagemRealizadaHora};" +
                                      $"{Validacoes.PesagemRealizadaCliente};" +
                                      $"{Validacoes.PesagemRealizadaVeiculo};" +
                                      $"{Validacoes.PesagemRealizadaProduto};" +
                                      $"{Validacoes.PesagemRealizadaMotorista};" +
                                      $"{Validacoes.PesagemRealizadaPlat1};" +
                                      $"{Validacoes.PesagemRealizadaPlat2};" +
                                      $"{Validacoes.PesagemRealizadaPlat1 + Validacoes.PesagemRealizadaPlat2};" +
                                      $"{Validacoes.PesagemRealizadaPlat3};" +
                                      $"{Validacoes.PesagemRealizadaPlat4};" +
                                      $"{Validacoes.PesagemRealizadaPlat3 + Validacoes.PesagemRealizadaPlat4};" +
                                      $"{Validacoes.PesagemRealizadaPlat5};" +
                                      $"{Validacoes.PesagemRealizadaPlat6};" +
                                      $"{Validacoes.PesagemRealizadaPlat5 + Validacoes.PesagemRealizadaPlat6};" +
                                      $"{Validacoes.PesagemRealizadaTotal};";
                arquivo.WriteLine(LinhaDados);

                arquivo.Dispose();
                Validacoes.AdaptadorBluetooth.Dispose();
                Thread.Sleep(1000);
                if (Validacoes.NomeImpressora != null)
                    Validacoes.BSocketImpressora[0].Close();

                Finish();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "NÃO FOI POSSIVEL REALIZAR A CONEXÃO", ToastLength.Long).Show();

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

                    if (Validacoes.Estabilidade1 == "E")
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.LimeGreen);
                    }
                    else
                    {
                        TxtPeso.SetTextColor(Android.Graphics.Color.Red);
                    }
                }
            }
            catch (System.Exception ex)
            {
                //threadBalanca1.Interrupt();
            }
        }


        public List<string> CarregaCliente()
        {

            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " NOME " +
             " FROM CLIENTES ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> clientes = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    item = new Clientes.CarredaDadosClientes();
                    item.Id = icursorTemp.GetString(0);
                    item.Nome = icursorTemp.GetString(1);
                    clientes.Add(item.Id.PadLeft(6, '0') + "-" + item.Nome);
                }
                return clientes;
            }
            return null;
        }



        public List<string> CarregaVeiculos()
        {
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " PLACA,MONTADORA " +
             " FROM VEICULOS ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> veiculos = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemveiculos = new Veiculos.CarredaDadosVeiculos();
                    itemveiculos.Id = icursorTemp.GetString(0);
                    itemveiculos.Placa = icursorTemp.GetString(1);
                    itemveiculos.Montadora = icursorTemp.GetString(2);
                    veiculos.Add(itemveiculos.Id.PadLeft(6, '0') + " - "
                                 + itemveiculos.Placa + " - " +
                                 itemveiculos.Montadora);
                }
                return veiculos;
            }
            return null;
        }
        public List<string> CarregaProdutos()
        {
            string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string sDB = Path.Combine(sLocation, "PRINCIPAL");
            sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
            bool bIsExists = File.Exists(sDB);
            string sSQLQuery = "";
            Android.Database.ICursor icursorTemp = null;
            sSQLQuery = sSQLQuery = "SELECT _id," +
            " PRODUTO,VALOR " +
             " FROM PRODUTOS ";
            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
            int ValorCursor = icursorTemp.Count;

            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];
                List<string> produtos = new List<string>();

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemprodutos = new Produtos.CarredaDadosProdutos();
                    itemprodutos.Id = icursorTemp.GetString(0);
                    itemprodutos.Produto = icursorTemp.GetString(1);
                    itemprodutos.Valor = icursorTemp.GetString(2);
                    produtos.Add(itemprodutos.Id.PadLeft(6, '0') + "-"
                                 + itemprodutos.Produto + "-" +
                                 itemprodutos.Valor);
                }
                return produtos;
            }
            return null;
        }
        public async void Aguarde()
        {

            using (UserDialogs.Instance.Loading("Aguarde...", null, null, true, MaskType.Black))
            {
                await System.Threading.Tasks.Task.Delay(5000);
            }

        }
        void CarregaListaPesagem()
        {
            Android.Database.ICursor icursorTemp = null;
            string Data = System.DateTime.Now.ToShortDateString();
            string Hora1 = "00:00:00";
            string Hora2 = "23:59:59";

            string sSQLQuery = "SELECT _id," +
            " DATA_CADASTRO, " +
            " HORA_CADASTRO, " +
            " VEICULO, " +
            " PESO_TOTAL " +
            " FROM PESAGEMS_REALIZADAS " +
            $" where DATA_CADASTRO='{Data}' and HORA_CADASTRO BETWEEN '{Hora1}' and '{Hora2}'";



            icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


            int ValorCursor = icursorTemp.Count;
            if (ValorCursor > 0)
            {
                nomes = new string[icursorTemp.Count];

                for (int i = 0; i < icursorTemp.Count; i++)
                {
                    icursorTemp.MoveToNext();
                    itemPesagem = new CarredaDadosPesagem();

                    itemPesagem.Id = icursorTemp.GetString(0);
                    itemPesagem.Data = icursorTemp.GetString(1);
                    itemPesagem.Hora = icursorTemp.GetString(2);
                    itemPesagem.Placa = icursorTemp.GetString(3);
                    itemPesagem.Peso_Total = icursorTemp.GetString(4);
                    char pad = '0';



                    nomes[i] = itemPesagem.Data + " " + itemPesagem.Hora + "         " +
                        itemPesagem.Placa.ToString() + "                   " +
                        itemPesagem.Peso_Total + "";

                }
                ArrayAdapter<System.String> itemsAdapter = new ArrayAdapter<System.String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, nomes);

                Android.Widget.ListView listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaCadastroPesagem);
                listview = FindViewById<Android.Widget.ListView>(Resource.Id.ListaCadastroPesagem);

                listview.Adapter = itemsAdapter;


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

        //protected override void OnStop()
        //{
            
        //   // Finish();
        //    base.OnStop();
            
            
        //}

        #endregion

    }
}