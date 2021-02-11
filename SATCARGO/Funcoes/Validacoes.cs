using System;
using System.Drawing;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;
using System.Collections;
using Android.Bluetooth;
using System.Collections.Generic;
using Android.OS;
using Xamarin.Forms;
using System.Text;
using System.Threading.Tasks;

namespace SATCARGO
{
    public class Validacoes
    {

        protected static bool senhaCalibracao;
        public static bool SenhaCalibracao
        {
            get { return senhaCalibracao; }
            set { senhaCalibracao = value; }
        }


        protected static int newBuilder;
        public static int NewBuilder
        {
            get { return NewBuilder; }
            set { NewBuilder = value; }
        }

        protected static String tipoOperacao;
        public static String TipoOperacao
        {
            get { return tipoOperacao; }
            set { tipoOperacao = value; }
        }

        protected static bool conexaoWifiBluetooth;
        public static bool ConexaoWifiBluetooth
        {
            get { return conexaoWifiBluetooth; }
            set { conexaoWifiBluetooth = value; }
        }


        protected static String estadoConexao;
        public static String EstadoConexao
        {
            get { return estadoConexao; }
            set { estadoConexao = value; }
        }

        protected static int nrSegundosPeso;
        public static int NrSegundosPeso
        {
            get { return nrSegundosPeso; }
            set { nrSegundosPeso = value; }
        }

        protected static int nrPlataformas;
        public static int NrPlataformas
        {
            get { return nrPlataformas; }
            set { nrPlataformas = value; }
        }

        protected static string npeso1;
        public static string Npeso1
        {
            get { return npeso1; }
            set { npeso1 = value; }
        }

        protected static int peso1;
        public static int Peso1
        {
            get { return peso1; }
            set { peso1 = value; }
        }

        protected static int tempoCapturaPeso;
        public static int TempoCapturaPeso
        {
            get { return tempoCapturaPeso; }
            set { tempoCapturaPeso = value; }
        }

        protected static string estabilidade1;
        public static string Estabilidade1
        {
            get { return estabilidade1; }
            set { estabilidade1 = value; }
        }

        protected static string tensao1;
        public static string Tensao1
        {
            get { return tensao1; }
            set { tensao1 = value; }
        }


        protected static int peso2;
        public static int Peso2
        {
            get { return peso2; }
            set { peso2 = value; }
        }

        protected static string estabilidade2;
        public static string Estabilidade2
        {
            get { return estabilidade2; }
            set { estabilidade2 = value; }
        }

        protected static string tensao2;
        public static string Tensao2
        {
            get { return tensao2; }
            set { tensao2 = value; }
        }

        protected static int peso3;
        public static int Peso3
        {
            get { return peso3; }
            set { peso3 = value; }
        }

        protected static string estabilidade3;
        public static string Estabilidade3
        {
            get { return estabilidade3; }
            set { estabilidade3 = value; }
        }
        protected static string tensao3;
        public static string Tensao3
        {
            get { return tensao3; }
            set { tensao3 = value; }
        }

        protected static int peso4;
        public static int Peso4
        {
            get { return peso4; }
            set { peso4 = value; }
        }

        protected static string estabilidade4;
        public static string Estabilidade4
        {
            get { return estabilidade4; }
            set { estabilidade4 = value; }
        }

        protected static string tensao4;
        public static string Tensao4
        {
            get { return tensao4; }
            set { tensao4 = value; }
        }

        protected static int peso5;
        public static int Peso5
        {
            get { return peso5; }
            set { peso5 = value; }
        }

        protected static bool erroPlat1;
        public static bool ErroPlat1
        {
            get { return erroPlat1; }
            set { erroPlat1 = value; }
        }

        protected static bool erroPlat2;
        public static bool ErroPlat2
        {
            get { return erroPlat2; }
            set { erroPlat2 = value; }
        }
        protected static string mensagemerroPlat1;
        public static string MensagemerroPlat1
        {
            get { return mensagemerroPlat1; }
            set { mensagemerroPlat1 = value; }
        }
        protected static string mensagemerroPlat2;
        public static string MensagemerroPlat2
        {
            get { return mensagemerroPlat2; }
            set { mensagemerroPlat2 = value; }
        }
        protected static string mensagemerroPlat3;
        public static string MensagemerroPlat3
        {
            get { return mensagemerroPlat3; }
            set { mensagemerroPlat3 = value; }
        }

        protected static string mensagemerroPlat4;
        public static string MensagemerroPlat4
        {
            get { return mensagemerroPlat4; }
            set { mensagemerroPlat4 = value; }
        }

        protected static string mensagemerroPlat5;
        public static string MensagemerroPlat5
        {
            get { return mensagemerroPlat5; }
            set { mensagemerroPlat5 = value; }
        }
        protected static string mensagemerroPlat6;
        public static string MensagemerroPlat6
        {
            get { return mensagemerroPlat6; }
            set { mensagemerroPlat6 = value; }
        }

        protected static bool erroPlat3;
        public static bool ErroPlat3
        {
            get { return erroPlat3; }
            set { erroPlat3 = value; }
        }

        protected static bool erroPlat4;
        public static bool ErroPlat4
        {
            get { return erroPlat4; }
            set { erroPlat4 = value; }
        }

        protected static bool erroPlat5;
        public static bool ErroPlat5
        {
            get { return erroPlat5; }
            set { erroPlat5 = value; }
        }

        protected static bool erroPlat6;
        public static bool ErroPlat6
        {
            get { return erroPlat6; }
            set { erroPlat6 = value; }
        }


        protected static string estabilidade5;
        public static string Estabilidade5
        {
            get { return estabilidade5; }
            set { estabilidade5 = value; }
        }
        protected static string tensao5;
        public static string Tensao5
        {
            get { return tensao5; }
            set { tensao5 = value; }
        }
        protected static string tensao61;
        public static string Tensao61
        {
            get { return tensao61; }
            set { tensao61 = value; }
        }


        protected static int peso6;
        public static int Peso6
        {
            get { return peso6; }
            set { peso6 = value; }
        }

        protected static string estabilidade6;
        public static string Estabilidade6
        {
            get { return estabilidade6; }
            set { estabilidade6 = value; }
        }
        protected static string tensao6;
        public static string Tensao6
        {
            get { return tensao6; }
            set { tensao6 = value; }
        }
        
        protected static String estadoThread;
        public static String EstadoThread
        {
            get { return estadoThread; }
            set { estadoThread = value; }
        }

        protected static String nomeUsuario;
        public static String NomeUsuario
        {
            get { return nomeUsuario; }
            set { nomeUsuario = value; }
        }

        protected static String tipoConexaoBalanca;
        public static String TipoConexaoBalanca
        {
            get { return tipoConexaoBalanca; }
            set { tipoConexaoBalanca = value; }
        }

        protected static String ipConexaoBalanca;
        public static String IpConexaoBalanca
        {
            get { return ipConexaoBalanca; }
            set { ipConexaoBalanca = value; }
        }

        protected static String portaConexaoBalanca;
        public static String PortaConexaoBalanca
        {
            get { return portaConexaoBalanca; }
            set { portaConexaoBalanca = value; }
        }

        protected static String nomeConexaoBluetooth;
        public static String NomeConexaoBluetooth
        {
            get { return nomeConexaoBluetooth; }
            set { nomeConexaoBluetooth = value; }
        }

        protected static BluetoothSocket[] bSocket;
        public static BluetoothSocket[] BSocket
        {
            get { return bSocket; }
            set { bSocket = value; }
        }

        protected static BluetoothSocket[] bSocketImpressora;
        public static BluetoothSocket[] BSocketImpressora
        {
            get { return bSocketImpressora; }
            set { bSocketImpressora = value; }
        }


        protected static BluetoothAdapter adaptadorBluetooth;
        public static BluetoothAdapter AdaptadorBluetooth
        {
            get { return adaptadorBluetooth; }
            set { adaptadorBluetooth = value; }
        }
        protected static BluetoothAdapter adaptadorBluetoothImpressora;
        public static BluetoothAdapter AdaptadorBluetoothImpressora
        {
            get { return adaptadorBluetoothImpressora; }
            set { adaptadorBluetoothImpressora = value; }
        }
        protected static Boolean cliqueSaida;
        public static Boolean CliqueSaida
        {
            get { return cliqueSaida; }
            set { cliqueSaida = value; }
        }


        protected static int nrplataformas;
        public static int Nrplataformas
        {
            get { return nrplataformas; }
            set { nrplataformas = value; }
        }

        protected static String impressoraAtiva;
        public static String ImpressoraAtiva
        {
            get { return impressoraAtiva; }
            set { impressoraAtiva = value; }
        }
        protected static String nomeImpressora;
        public static String NomeImpressora
        {
            get { return nomeImpressora; }
            set { nomeImpressora = value; }
        }
        //==========================================//
        protected static String empresaCnpj;
        public static String EmpresaCnpj
        {
            get { return empresaCnpj; }
            set { empresaCnpj = value; }
        }
        protected static String empresaIe;
        public static String EmpresaIe
        {
            get { return empresaIe; }
            set { empresaIe = value; }
        }
        protected static String empresaNome;
        public static String EmpresaNome
        {
            get { return empresaNome; }
            set { empresaNome = value; }
        }
        protected static String empresaEndereco;
        public static String EmpresaEndereco
        {
            get { return empresaEndereco; }
            set { empresaEndereco = value; }
        }
        protected static String empresaBairro;
        public static String EmpresaBairro
        {
            get { return empresaBairro; }
            set { empresaBairro = value; }
        }
        protected static String empresaCidade;
        public static String EmpresaCidade
        {
            get { return empresaCidade; }
            set { empresaCidade = value; }
        }
        protected static String empresaUf;
        public static String EmpresaUf
        {
            get { return empresaUf; }
            set { empresaUf = value; }
        }
        //=====================================================//
        protected static String clienteCnpj;
        public static String ClienteCnpj
        {
            get { return clienteCnpj; }
            set { clienteCnpj = value; }
        }
        protected static String clienteIe;
        public static String ClienteIe
        {
            get { return clienteIe; }
            set { clienteIe = value; }
        }
        protected static String clienteNome;
        public static String ClienteNome
        {
            get { return clienteNome; }
            set { clienteNome = value; }
        }
        protected static String clienteEndereco;
        public static String ClienteEndereco
        {
            get { return clienteEndereco; }
            set { clienteEndereco = value; }
        }
        protected static String clienteBairro;
        public static String ClienteBairro
        {
            get { return clienteBairro; }
            set { clienteBairro = value; }
        }
        protected static String clienteCidade;
        public static String ClienteCidade
        {
            get { return clienteCidade; }
            set { clienteCidade = value; }
        }
        protected static String clienteUf;
        public static String ClienteUf
        {
            get { return clienteUf; }
            set { clienteUf = value; }
        }
        //=================================================
        protected static String pesagemRealizadaId;
        public static String PesagemRealizadaId
        {
            get { return pesagemRealizadaId; }
            set { pesagemRealizadaId = value; }
        }


        protected static String pesagemRealizadaIdCliente;
        public static String PesagemRealizadaIdCliente
        {
            get { return pesagemRealizadaIdCliente; }
            set { pesagemRealizadaIdCliente = value; }
        }
        protected static String pesagemRealizadaCliente;
        public static String PesagemRealizadaCliente
        {
            get { return pesagemRealizadaCliente; }
            set { pesagemRealizadaCliente = value; }
        }
        protected static String pesagemRealizadaIdVeiculo;
        public static String PesagemRealizadaIdVeiculo
        {
            get { return pesagemRealizadaIdVeiculo; }
            set { pesagemRealizadaIdVeiculo = value; }
        }
        protected static String pesagemRealizadaVeiculo;
        public static String PesagemRealizadaVeiculo
        {
            get { return pesagemRealizadaVeiculo; }
            set { pesagemRealizadaVeiculo = value; }
        }
        protected static String pesagemRealizadaIdProduto;
        public static String PesagemRealizadaIdProduto
        {
            get { return pesagemRealizadaIdProduto; }
            set { pesagemRealizadaIdProduto = value; }
        }
        protected static String pesagemRealizadaProduto;
        public static String PesagemRealizadaProduto
        {
            get { return pesagemRealizadaProduto; }
            set { pesagemRealizadaProduto = value; }
        }
        protected static String pesagemRealizadaMotorista;
        public static String PesagemRealizadaMotorista
        {
            get { return pesagemRealizadaMotorista; }
            set { pesagemRealizadaMotorista = value; }
        }
        protected static String pesagemRealizadaNrPlataformas;
        public static String PesagemRealizadaNrPlataformas
        {
            get { return pesagemRealizadaNrPlataformas; }
            set { pesagemRealizadaNrPlataformas = value; }
        }
        protected static double pesagemRealizadaPlat1;
        public static double PesagemRealizadaPlat1
        {
            get { return pesagemRealizadaPlat1; }
            set { pesagemRealizadaPlat1 = value; }
        }
        protected static double pesagemRealizadaPlat2;
        public static double PesagemRealizadaPlat2
        {
            get { return pesagemRealizadaPlat2; }
            set { pesagemRealizadaPlat2 = value; }
        }
        protected static double pesagemRealizadaPlat3;
        public static double PesagemRealizadaPlat3
        {
            get { return pesagemRealizadaPlat3; }
            set { pesagemRealizadaPlat3 = value; }
        }
        protected static double pesagemRealizadaPlat4;
        public static double PesagemRealizadaPlat4
        {
            get { return pesagemRealizadaPlat4; }
            set { pesagemRealizadaPlat4 = value; }
        }
        protected static double pesagemRealizadaPlat5;
        public static double PesagemRealizadaPlat5
        {
            get { return pesagemRealizadaPlat5; }
            set { pesagemRealizadaPlat5 = value; }
        }
        protected static double pesagemRealizadaPlat6;
        public static double PesagemRealizadaPlat6
        {
            get { return pesagemRealizadaPlat6; }
            set { pesagemRealizadaPlat6 = value; }
        }
        protected static double pesagemRealizadaTotal;
        public static double PesagemRealizadaTotal
        {
            get { return pesagemRealizadaTotal; }
            set { pesagemRealizadaTotal = value; }
        }
        protected static string pesagemRealizadaData;
        public static string PesagemRealizadaData
        {
            get { return pesagemRealizadaData; }
            set { pesagemRealizadaData = value; }
        }
        protected static string pesagemRealizadaHora;
        public static string PesagemRealizadaHora
        {
            get { return pesagemRealizadaHora; }
            set { pesagemRealizadaHora = value; }
        }
        //===============================================================




        protected static String existeUsuario;
        public static String ExisteUsuario
        {
            get { return existeUsuario; }
            set { existeUsuario = value; }
        }

        protected static String perfilUsuario;
        public static String PerfilUsuario
        {
            get { return perfilUsuario; }
            set { perfilUsuario = value; }
        }

        protected static String valorItem;
        public static String ValorItem
        {
            get { return valorItem; }
            set { valorItem = value; }
        }
        protected static String valorTicket;
        public static String ValorTicket
        {
            get { return valorTicket; }
            set { valorTicket = value; }
        }

        protected static String valorEnderecoIP;
        public static String ValorEnderecoIP
        {
            get { return valorEnderecoIP; }
            set { valorEnderecoIP = value; }
        }

        protected static String valorEnderecoIPMySql;
        public static String ValorEnderecoIPMySql
        {
            get { return valorEnderecoIPMySql; }
            set { valorEnderecoIPMySql = value; }
        }

        protected static String valorDataBaseMySql;
        public static String ValorDataBaseMySql
        {
            get { return valorDataBaseMySql; }
            set { valorDataBaseMySql = value; }
        }


        protected static String internetConectada;
        public static String InternetConectada
        {
            get { return internetConectada; }
            set { internetConectada = value; }
        }

        protected static String valorUserMySql;
        public static String ValorUserMySql
        {
            get { return valorUserMySql; }
            set { valorUserMySql = value; }
        }

        protected static String valorPasswordMySql;
        public static String ValorPasswordMySql
        {
            get { return valorPasswordMySql; }
            set { valorPasswordMySql = value; }
        }

        protected static String valorPorta;
        public static String ValorPorta
        {
            get { return valorPorta; }
            set { valorPorta = value; }
        }

        protected static String dataPesquisar;
        public static String DataPesquisar
        {
            get { return dataPesquisar; }
            set { dataPesquisar = value; }
        }




        protected static string dataPesquisa;
        public static string DataPesquisa
        {
            get { return dataPesquisa; }
            set { dataPesquisa = value; }
        }

        protected static string dataPesquisaFim;
        public static string DataPesquisaFim
        {
            get { return dataPesquisaFim; }
            set { dataPesquisaFim = value; }
        }


        protected static bool existeTag;
        public static bool ExisteTag
        {
            get { return existeTag; }
            set { existeTag = value; }
        }
        protected static bool existeImpressora;
        public static bool ExisteImpressora
        {
            get { return existeImpressora; }
            set { existeImpressora = value; }
        }


        protected static ArrayList despositos;
        public static ArrayList Despositos
        {
            get { return despositos; }
            set { despositos = value; }
        }


        protected static ArrayList despositosN;
        public static ArrayList DespositosN
        {
            get { return despositosN; }
            set { despositosN = value; }
        }
        //====================================================//
        //          Variaveis Plataformas Pesagem             //
        //====================================================//
        protected static bool validaPeso1;
        public static bool ValidaPeso1
        {
            get { return validaPeso1; }
            set { validaPeso1 = value; }
        }
        protected static bool validaPeso2;
        public static bool ValidaPeso2
        {
            get { return validaPeso2; }
            set { validaPeso2 = value; }
        }
        protected static bool validaPeso3;
        public static bool ValidaPeso3
        {
            get { return validaPeso3; }
            set { validaPeso3 = value; }
        }
        protected static bool validaPeso4;
        public static bool ValidaPeso4
        {
            get { return validaPeso4; }
            set { validaPeso4 = value; }
        }
        protected static bool validaPeso5;
        public static bool ValidaPeso5
        {
            get { return validaPeso5; }
            set { validaPeso5 = value; }
        }
        protected static bool validaPeso6;
        public static bool ValidaPeso6
        {
            get { return validaPeso6; }
            set { validaPeso6 = value; }
        }

        protected static int valorPesoTotalAnt;
        public static int ValorPesoTotalAnt
        {
            get { return valorPesoTotalAnt; }
            set  { valorPesoTotalAnt = value; }
        }
        protected static bool deviceListPrinter;
        public static bool DeviceListPrinter
        {
            get { return deviceListPrinter; }
            set { deviceListPrinter = value; }
        }

        protected static bool tecladoSaida;
        public static bool TecladoSaida
        {
            get { return tecladoSaida; }
            set { deviceListPrinter = value; }
        }



        public static BluetoothSocket socket1;
        public static BluetoothSocket Socket1
        {
            get { return socket1; }
            set { socket1 = value; }
        }

        //========================================================
        public static string VerificaSenha(string Senha)
        {
            string dec = string.Empty;
            for (int i = 0; i < Senha.Length; i++)
            {

                string cDec = ConverteCaractere(((byte)Senha[i]).ToString());
                if (cDec.Length < 3)
                    cDec = cDec.PadLeft(3, '0');

                dec += cDec;
            }
            return dec;
        }
        public static Int32 DivisaoPeso20(Int32 Peso)
        {
            Int32 Divisao = Peso / 20;
            double RestoDivisao= Peso % 20;
            if (RestoDivisao >= 10)
                Divisao = Divisao + 1;
            return Divisao * 20;
        }
        public static string RetornaValorCampo(string ValorCampo, int ValorNrCaracTotal)
        {
            int ValorNrCaractereCampo = ValorCampo.Length;
            string retorno = " ";
            var i = ValorCampo.Split(' ');
            int i1 = 1;

            if (i.Count() > 1)
                i1 = i.Count() + 2;

            if (ValorNrCaracTotal < ValorNrCaractereCampo)
            {
                retorno = ValorCampo.Substring(0, ValorNrCaracTotal).PadRight(ValorNrCaracTotal, ' ');
            }
            else
            {
                if (ValorNrCaractereCampo <= 10)
                    retorno = ValorCampo.Substring(0, ValorNrCaractereCampo).PadRight(ValorNrCaracTotal + (6 + (i1)), ' ');
                else if (ValorNrCaractereCampo <= 14)
                    retorno = ValorCampo.Substring(0, ValorNrCaractereCampo).PadRight(ValorNrCaracTotal + 8, ' ');
                else
                    retorno = ValorCampo.Substring(0, ValorNrCaractereCampo).PadRight(ValorNrCaracTotal + 2, ' ');

            }
            return retorno;
        }


        public static string ConverteCaractere(string caractere)
        {
            string retorno = RetornoClipCaractere(int.Parse(caractere));
            return retorno;
        }

        public static string RetornoClipCaractere(int Caractere)
        {
            string caractere;
            char c;
            if (Convert.ToInt16(Caractere) <= 50)
            {
                caractere = (Convert.ToInt16(Caractere) + 4).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }
            if (Convert.ToInt16(Caractere) > 50 && Convert.ToInt16(Caractere) <= 60)
            {
                caractere = (Convert.ToInt16(Caractere) + 7).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }
            if (Convert.ToInt16(Caractere) > 61 && Convert.ToInt16(Caractere) <= 80)
            {
                caractere = (Convert.ToInt16(Caractere) + 2).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }
            if (Convert.ToInt16(Caractere) == 80)
            {
                caractere = (Convert.ToInt16(67)).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }

            if (Convert.ToInt16(Caractere) > 81 && Convert.ToInt16(Caractere) <= 100)
            {
                caractere = (Convert.ToInt16(Caractere) + 3).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }
            if (Convert.ToInt16(Caractere) > 101 && Convert.ToInt16(Caractere) <= 255)
            {
                caractere = (Convert.ToInt16(Caractere) - 11).ToString();
                c = Convert.ToChar(int.Parse(caractere));
                return c.ToString();
            }

            return "";
        }
        public static bool RetornaCaractereNumericoValido(string c)
        {
            if (c.ToString() != "0" &&
                              c.ToString() != "1" &&
                              c.ToString() != "2" &&
                              c.ToString() != "3" &&
                              c.ToString() != "4" &&
                              c.ToString() != "5" &&
                              c.ToString() != "6" &&
                              c.ToString() != "7" &&
                              c.ToString() != "8" &&
                              c.ToString() != "9")
            {
                return false;
            }
            return true;
        }

        public static BluetoothSocket VerificaDeviceAtivo(BluetoothSocket Socket)
        {
            BluetoothAdapter adaptador = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
            ICollection<BluetoothDevice> aparelhos = adaptador.BondedDevices;
            BluetoothDevice[] apa = new BluetoothDevice[aparelhos.Count];
            ParcelUuid[] chaves;
            BluetoothSocket[] socket = new BluetoothSocket[aparelhos.Count];
            Validacoes.BSocket = socket;

            int X = 0;
            string Conectado = "nao";
            foreach (BluetoothDevice aparelho in aparelhos)
            {
                apa[X] = aparelho;
                chaves = aparelho.GetUuids();
                Validacoes.BSocket[X] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chaves[X].Uuid);
                if (socket[X].IsConnected == true)
                    socket[X].Close();
                if (aparelho.Name == Validacoes.NomeConexaoBluetooth)
                {
                    break;
                }
                X++;
            }
            var address = apa[0].Address;
            return Validacoes.BSocket[0];
        }
        public async static void VerificaStatusPlafaforma(BluetoothSocket Socket,
                                              int NrPlataforma)
        {

            bool ValidaPeso = false;
            string Peso1 = string.Empty;
            string Peso2 = string.Empty;
            string Peso3 = string.Empty;
            string Peso4 = string.Empty;
            string Peso5 = string.Empty;
            string Peso6 = string.Empty;
            string Estabilidade = "E";


            int Contador = 0;
            while (!ValidaPeso)
            {
                if (Contador > 10)
                    break;

                Contador = Contador + 1;
                byte[] buffer = new byte[2];
                buffer[0] = 0x7D;
                if (NrPlataforma == 1)
                {
                    buffer[1] = 0x01;
                    Peso1 = string.Empty;
                }
                if (NrPlataforma == 2)
                {
                    buffer[1] = 0x02;
                    Peso1 = string.Empty;
                }
                if (NrPlataforma == 3)
                {
                    buffer[1] = 0x03;
                    Peso1 = string.Empty;
                }
                if (NrPlataforma == 4)
                {
                    buffer[1] = 0x04;
                    Peso1 = string.Empty;
                }
                if (NrPlataforma == 5)
                {
                    buffer[1] = 0x05;
                    Peso1 = string.Empty;
                }
                if (NrPlataforma == 6)
                {
                    buffer[1] = 0x06;
                    Peso1 = string.Empty;
                }

                var output = Socket.OutputStream;
                var readput = Socket.InputStream;
                output.Write(buffer, 0, 2);
                byte[] rbuffer = new byte[12];
                System.Threading.Thread.Sleep(100);



                var readByte = readput.Read(rbuffer, 0, rbuffer.Length);
                // char cc1;

                //cc1 = Convert.ToChar(Convert.ToUInt16(rbuffer[9].ToString().Substring(0, 2)));
                //Estabilidade = cc1.ToString();
                //string Estavel = "Nao";
                //if (Estabilidade == "O") Estavel = "Sim";
                //if (Estabilidade == "E") Estavel = "Sim";

                //while (Estavel=="Nao")
                //{
                //    output.Write(buffer, 0, 2);
                //    System.Threading.Thread.Sleep(100);
                //    readByte = readput.Read(rbuffer, 0, rbuffer.Length);
                //    cc1 = Convert.ToChar(Convert.ToUInt16(rbuffer[9].ToString().Substring(0, 2)));
                //    Estabilidade = cc1.ToString();
                //    if (Estabilidade == "O") Estavel = "Sim";
                //    if (Estabilidade == "E") Estavel = "Sim";
                //}

                char c1;

                for (int i = 0; rbuffer.Count() > i; i++)
                {
                    if (i > 2 && i < 9)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[i].ToString().Substring(0, 2)));
                        if (Validacoes.RetornaCaractereNumericoValido(c1.ToString()) == false)
                        {
                            ValidaPeso = false;
                            if (NrPlataforma == 1)
                                Peso1 = string.Empty;
                            if (NrPlataforma == 2)
                                Peso2 = string.Empty;
                            if (NrPlataforma == 3)
                                Peso3 = string.Empty;
                            if (NrPlataforma == 4)
                                Peso4 = string.Empty;
                            if (NrPlataforma == 5)
                                Peso5 = string.Empty;
                            if (NrPlataforma == 6)
                                Peso6 = string.Empty;

                            break;
                        }
                        if (NrPlataforma == 1)
                            Peso1 += c1.ToString();
                        if (NrPlataforma == 2)
                            Peso2 += c1.ToString();
                        if (NrPlataforma == 3)
                            Peso3 += c1.ToString();
                        if (NrPlataforma == 4)
                            Peso4 += c1.ToString();
                        if (NrPlataforma == 5)
                            Peso5 += c1.ToString();
                        if (NrPlataforma == 6)
                            Peso6 += c1.ToString();



                    }
                    if (i == 9)
                    {

                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[9].ToString().Substring(0, 2)));
                        Estabilidade = c1.ToString();
                        ValidaPeso = true;

                        if (NrPlataforma == 1)
                        {
                            Validacoes.Peso1 = Convert.ToInt16(Peso1);
                            Validacoes.Estabilidade1 = Estabilidade;
                        }
                        if (NrPlataforma == 2)
                        {
                            Validacoes.Peso2 = Convert.ToInt16(Peso2);
                            Validacoes.Estabilidade2 = Estabilidade;
                        }
                        if (NrPlataforma == 3)
                        {
                            Validacoes.Peso3 = Convert.ToInt16(Peso3);
                            Validacoes.Estabilidade3 = Estabilidade;
                        }
                        if (NrPlataforma == 4)
                        {
                            Validacoes.Peso4 = Convert.ToInt16(Peso4);
                            Validacoes.Estabilidade4 = Estabilidade;
                        }
                        if (NrPlataforma == 5)
                        {
                            Validacoes.Peso5 = Convert.ToInt16(Peso5);
                            Validacoes.Estabilidade5 = Estabilidade;
                        }
                        if (NrPlataforma == 6)
                        {
                            Validacoes.Peso6 = Convert.ToInt16(Peso6);
                            Validacoes.Estabilidade6 = Estabilidade;
                        }
                    }
                    if (i == 10)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[10].ToString().Substring(0, 2)));
                        if (NrPlataforma == 1)
                        {
                            Validacoes.Tensao1 = c1.ToString();
                        }
                        if (NrPlataforma == 2)
                        {
                            Validacoes.Tensao2 = c1.ToString();
                        }
                        if (NrPlataforma == 3)
                        {
                            Validacoes.Tensao3 = c1.ToString();
                        }
                        if (NrPlataforma == 4)
                        {
                            Validacoes.Tensao4 = c1.ToString();
                        }
                        if (NrPlataforma == 5)
                        {
                            Validacoes.Tensao5 = c1.ToString();
                        }
                        if (NrPlataforma == 6)
                        {
                            Validacoes.Tensao6 = c1.ToString();
                        }
                    }
                    if (i == 11)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[11].ToString().Substring(0, 2)));

                        if (NrPlataforma == 1)
                        {
                            Validacoes.Tensao1 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao1, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao1 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao1 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);
                        }
                        if (NrPlataforma == 2)
                        {
                            Validacoes.Tensao2 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao2, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao2 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao2 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);
                        }
                        if (NrPlataforma == 3)
                        {
                            Validacoes.Tensao3 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao3, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao3 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao3 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);
                        }
                        if (NrPlataforma == 4)
                        {
                            Validacoes.Tensao4 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao4, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao4 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao4 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);
                        }
                        if (NrPlataforma == 5)
                        {
                            Validacoes.Tensao5 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao5, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao5 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao5 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);

                        }
                        if (NrPlataforma == 6)
                        {
                            Validacoes.Tensao6 = c1.ToString();
                            int decValue = Convert.ToInt32(Validacoes.Tensao6, 16);
                            if (decValue.ToString().Length == 2)
                                Validacoes.Tensao6 = decValue.ToString().Substring(0, 1) + "," + decValue.ToString().Substring(1);
                            if (decValue.ToString().Length == 3)
                                Validacoes.Tensao6 = decValue.ToString().Substring(0, 2) + "," + decValue.ToString().Substring(2);
                        }
                    }
                }
            }
        }
        #region VerificaPlataformas
        public static void VerificaStatusPlafaforma1(BluetoothSocket Socket)
        {

            try
            {
                string Peso1 = string.Empty;
                string Estabilidade = "E";


                int Contador = 0;

                Contador = Contador + 1;
                byte[] buffer = new byte[2];
                buffer[0] = 0x7D;
                buffer[1] = 0x01;
                Peso1 = string.Empty;
                Tensao1 = string.Empty;
                var output = Socket.OutputStream;
                var readput = Socket.InputStream;
                output.Write(buffer, 0, 2);
                byte[] rbuffer = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte = readput.Read(rbuffer, 0, rbuffer.Length);
                readByte = readput.Read(rbuffer, 0, rbuffer.Length);

                char c1;
                char c11;

                for (int i = 0; rbuffer.Count() > i; i++)
                {
                    if (i == 3)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[i].ToString().Substring(0, 2)));
                        MensagemerroPlat1 = c1.ToString();
                        if (c1 == 69)
                        {
                            c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[4].ToString().Substring(0, 2)));
                            MensagemerroPlat1 += c1.ToString();
                            c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[5].ToString().Substring(0, 2)));
                            MensagemerroPlat1 += c1.ToString();
                            c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[6].ToString().Substring(0, 2)));
                            MensagemerroPlat1 += c1.ToString();
                        }
                    }
                    if (i > 2 && i < 9)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[i].ToString().Substring(0, 2)));
                        Peso1 += c1.ToString();
                    }
                    if (i == 9)
                    {
                        c1 = Convert.ToChar(Convert.ToUInt16(rbuffer[9].ToString().Substring(0, 2)));
                        Estabilidade = c1.ToString();
                        //Validacoes.Peso1 = Convert.ToInt16(Peso1);
                        Validacoes.Estabilidade1 = Estabilidade;

                        if (rbuffer[2] == 45)
                            Validacoes.Peso1 = -Convert.ToInt16(Peso1);
                        if (rbuffer[2] == 32)
                            Validacoes.Peso1 = Convert.ToInt16(Peso1);
                        Validacoes.ErroPlat1 = false;
                    }
                    if (i == 10)
                    {
                        c11 = Convert.ToChar(Convert.ToUInt16(rbuffer[i].ToString().Substring(0, 2)));
                        Tensao1 += c11.ToString();
                    }
                    if (i == 11)
                    {
                        c11 = Convert.ToChar(Convert.ToUInt16(rbuffer[i].ToString().Substring(0, 2)));
                        string resultado = VerificaCaractereTensao(c11.ToString());
                        Tensao1 +=  resultado;
                        if (Tensao1.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao1, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao1 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao1 =ValorTensao1.ToString();
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat1 = true;
            }
        }
        public static void VerificaStatusPlafaforma2(BluetoothSocket Socket)
        {

            try
            {
                string Peso2 = string.Empty;
                string Estabilidade2 = "E";
                byte[] buffer2 = new byte[2];
                buffer2[0] = 0x7D;
                buffer2[1] = 0x02;
                Peso2 = string.Empty;
                Tensao2 = string.Empty;
                var output2 = Socket.OutputStream;
                var readput2 = Socket.InputStream;
                output2.Write(buffer2, 0, 2);
                byte[] rbuffer2 = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte2 = readput2.Read(rbuffer2, 0, rbuffer2.Length);
                readByte2 = readput2.Read(rbuffer2, 0, rbuffer2.Length);
                char c2;
                char c21;

                for (int i = 0; rbuffer2.Count() > i; i++)
                {
                    if(i==3)
                    {
                        c2 = Convert.ToChar(Convert.ToUInt16(rbuffer2[i].ToString().Substring(0, 2)));
                        MensagemerroPlat2 = c2.ToString();
                        if(c2==69)
                        {
                            c2= Convert.ToChar(Convert.ToUInt16(rbuffer2[4].ToString().Substring(0, 2)));
                            MensagemerroPlat2 += c2.ToString();
                            c2 = Convert.ToChar(Convert.ToUInt16(rbuffer2[5].ToString().Substring(0, 2)));
                            MensagemerroPlat2 += c2.ToString();
                            c2 = Convert.ToChar(Convert.ToUInt16(rbuffer2[6].ToString().Substring(0, 2)));
                            MensagemerroPlat2 += c2.ToString();
                        }
                    }
                    
                    if (i > 2 && i < 9)
                    {
                        c2 = Convert.ToChar(Convert.ToUInt16(rbuffer2[i].ToString().Substring(0, 2)));
                        Peso2 += c2.ToString();
                    }
                    if (i == 9)
                    {
                        c2 = Convert.ToChar(Convert.ToUInt16(rbuffer2[9].ToString().Substring(0, 2)));
                        Estabilidade2 = c2.ToString();
                        //Validacoes.Peso2 = Convert.ToInt16(Peso2);
                        Validacoes.Estabilidade2 = Estabilidade2;

                        if (rbuffer2[2] == 45)
                            Validacoes.Peso2 = -Convert.ToInt16(Peso2);
                        if (rbuffer2[2] == 32)
                            Validacoes.Peso2 = Convert.ToInt16(Peso2);
                        Validacoes.ErroPlat2 = false;
                    }

                    if (i == 10)
                    {
                        c21 = Convert.ToChar(Convert.ToUInt16(rbuffer2[i].ToString().Substring(0, 2)));
                        Tensao2 += c21.ToString();
                    }
                    if (i == 11)
                    {
                        c21 = Convert.ToChar(Convert.ToUInt16(rbuffer2[i].ToString().Substring(0, 2)));

                        string resultado = VerificaCaractereTensao(c21.ToString());
                        Tensao2 +=  resultado;
                        if (Tensao2.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao2, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao2 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao2 = ValorTensao2.ToString();
                        }
                    }
                }

            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat2 = true;
            
            }
        }
        public static void VerificaStatusPlafaforma3(BluetoothSocket Socket)
        {

            try
            {
                string Peso3 = string.Empty;
                string Estabilidade3 = "E";
                byte[] buffer3 = new byte[2];
                buffer3[0] = 0x7D;
                buffer3[1] = 0x03;
                Peso3 = string.Empty;
                Tensao3 = string.Empty;
                var output3 = Socket.OutputStream;
                var readput3 = Socket.InputStream;
                output3.Write(buffer3, 0, 2);
                byte[] rbuffer3 = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte3 = readput3.Read(rbuffer3, 0, rbuffer3.Length);
                readByte3 = readput3.Read(rbuffer3, 0, rbuffer3.Length);
                char c3;
                char c31;

                for (int i = 0; rbuffer3.Count() > i; i++)
                {
                    if (i == 3)
                    {
                        c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[i].ToString().Substring(0, 2)));
                        MensagemerroPlat3 = c3.ToString();
                        if (c3 == 69)
                        {
                            c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[4].ToString().Substring(0, 2)));
                            MensagemerroPlat3 += c3.ToString();
                            c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[5].ToString().Substring(0, 2)));
                            MensagemerroPlat3 += c3.ToString();
                            c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[6].ToString().Substring(0, 2)));
                            MensagemerroPlat3 += c3.ToString();
                        }
                    }

                    if (i > 2 && i < 9)
                    {
                        c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[i].ToString().Substring(0, 2)));
                        Peso3 += c3.ToString();

                    }
                    if (i == 9)
                    {
                        c3 = Convert.ToChar(Convert.ToUInt16(rbuffer3[9].ToString().Substring(0, 2)));
                        Estabilidade3 = c3.ToString();
                        //Validacoes.Peso3 = Convert.ToInt16(Peso3);
                        Validacoes.Estabilidade3 = Estabilidade3;
                        if (rbuffer3[2] == 45)
                            Validacoes.Peso3 = -Convert.ToInt16(Peso3);
                        if (rbuffer3[2] == 32)
                            Validacoes.Peso3 = Convert.ToInt16(Peso3);
                        Validacoes.ErroPlat3 = false;
                    }
                    if (i == 10)
                    {
                        c31 = Convert.ToChar(Convert.ToUInt16(rbuffer3[i].ToString().Substring(0, 2)));
                        Tensao3 += c31.ToString();
                    }
                    if (i == 11)
                    {
                        c31 = Convert.ToChar(Convert.ToUInt16(rbuffer3[i].ToString().Substring(0, 2)));
                        string resultado = VerificaCaractereTensao(c31.ToString());
                        Tensao3 +=  resultado;

                        if (Tensao3.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao3, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao3 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao3 = ValorTensao3.ToString();
                        }
                    }

                }

            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat3 = true;
            }
        }
        public static void VerificaStatusPlafaforma4(BluetoothSocket Socket)
        {
            try
            {
                string Peso4 = string.Empty;
                string Estabilidade4 = "E";
                byte[] buffer4 = new byte[2];
                buffer4[0] = 0x7D;
                buffer4[1] = 0x04;
                Peso4 = string.Empty;
                Tensao4 = string.Empty;
                var output4 = Socket.OutputStream;
                var readput4 = Socket.InputStream;
                output4.Write(buffer4, 0, 2);
                byte[] rbuffer4 = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte4 = readput4.Read(rbuffer4, 0, rbuffer4.Length);
                readByte4 = readput4.Read(rbuffer4, 0, rbuffer4.Length);
                char c4;
                char c41;
                for (int i = 0; rbuffer4.Count() > i; i++)
                {
                    if (i == 3)
                    {
                        c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[i].ToString().Substring(0, 2)));
                        MensagemerroPlat4 = c4.ToString();
                        if (c4 == 69)
                        {
                            c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[4].ToString().Substring(0, 2)));
                            MensagemerroPlat4 += c4.ToString();
                            c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[5].ToString().Substring(0, 2)));
                            MensagemerroPlat4 += c4.ToString();
                            c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[6].ToString().Substring(0, 2)));
                            MensagemerroPlat4 += c4.ToString();
                        }
                    }

                    if (i > 2 && i < 9)
                    {
                        c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[i].ToString().Substring(0, 2)));
                        Peso4 += c4.ToString();
                    }
                    if (i == 9)
                    {
                        c4 = Convert.ToChar(Convert.ToUInt16(rbuffer4[9].ToString().Substring(0, 2)));
                        Estabilidade4 = c4.ToString();
                        // Validacoes.Peso4 = Convert.ToInt16(Peso4);
                        Validacoes.Estabilidade4 = Estabilidade4;
                        if (rbuffer4[2] == 45)
                            Validacoes.Peso4 = -Convert.ToInt16(Peso4);
                        if (rbuffer4[2] == 32)
                            Validacoes.Peso4 = Convert.ToInt16(Peso4);
                        Validacoes.ErroPlat4 = false;
                    }
                    if (i == 10)
                    {
                        c41 = Convert.ToChar(Convert.ToUInt16(rbuffer4[i].ToString().Substring(0, 2)));
                        Tensao4 += c41.ToString();
                    }
                    if (i == 11)
                    {
                        c41 = Convert.ToChar(Convert.ToUInt16(rbuffer4[i].ToString().Substring(0, 2)));
                        string resultado = VerificaCaractereTensao(c41.ToString());
                        Tensao4 +=  resultado;

                        if (Tensao4.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao4, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao4 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao4 = ValorTensao4.ToString();
                        }
                    }

                }
            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat4 = true;
            }
        }
        public static void VerificaStatusPlafaforma5(BluetoothSocket Socket)
        {
            try
            {
                string Peso5 = string.Empty;
                string Estabilidade5 = "E";
                byte[] buffer5 = new byte[2];
                buffer5[0] = 0x7D;
                buffer5[1] = 0x05;
                Peso5 = string.Empty;
                Tensao5 = string.Empty;
                var output5 = Socket.OutputStream;
                var readput5 = Socket.InputStream;
                output5.Write(buffer5, 0, 2);
                byte[] rbuffer5 = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte5 = readput5.Read(rbuffer5, 0, rbuffer5.Length);
                readByte5 = readput5.Read(rbuffer5, 0, rbuffer5.Length);
                char c5;
                char c51;
                for (int i = 0; rbuffer5.Count() > i; i++)
                {
                    if (i == 3)
                    {
                        c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[i].ToString().Substring(0, 2)));
                        MensagemerroPlat5 = c5.ToString();
                        if (c5 == 69)
                        {
                            c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[4].ToString().Substring(0, 2)));
                            MensagemerroPlat5 += c5.ToString();
                            c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[5].ToString().Substring(0, 2)));
                            MensagemerroPlat5 += c5.ToString();
                            c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[6].ToString().Substring(0, 2)));
                            MensagemerroPlat5 += c5.ToString();
                        }
                    }


                    if (i > 2 && i < 9)
                    {
                        c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[i].ToString().Substring(0, 2)));
                        Peso5 += c5.ToString();
                    }
                    if (i == 9)
                    {
                        c5 = Convert.ToChar(Convert.ToUInt16(rbuffer5[9].ToString().Substring(0, 2)));
                        Estabilidade5 = c5.ToString();
                        //Validacoes.Peso5 = Convert.ToInt16(Peso5);
                        Validacoes.Estabilidade5 = Estabilidade5;
                        if (rbuffer5[2] == 45)
                            Validacoes.Peso5 = -Convert.ToInt16(Peso5);
                        if (rbuffer5[2] == 32)
                            Validacoes.Peso5 = Convert.ToInt16(Peso5);
                        Validacoes.ErroPlat5 = false;
                    }

                    if (i == 10)
                    {
                        c51 = Convert.ToChar(Convert.ToUInt16(rbuffer5[i].ToString().Substring(0, 2)));
                        Tensao5 += c51.ToString();
                    }
                    if (i == 11)
                    {
                        c51 = Convert.ToChar(Convert.ToUInt16(rbuffer5[i].ToString().Substring(0, 2)));
                        string resultado = VerificaCaractereTensao(c51.ToString());
                        Tensao5 +=  resultado;

                        if (Tensao5.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao5, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao5 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao5 = ValorTensao5.ToString();
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat5 = true;
            }
        }
        public static void VerificaStatusPlafaforma6(BluetoothSocket Socket)
        {
            try
            {
                string Peso6 = string.Empty;
                string Estabilidade6 = "E";
                byte[] buffer6 = new byte[2];
                buffer6[0] = 0x7D;
                buffer6[1] = 0x06;
                Peso6 = string.Empty;
                Tensao6 = string.Empty;
                var output6 = Socket.OutputStream;
                var readput6 = Socket.InputStream;
                output6.Write(buffer6, 0, 2);
                byte[] rbuffer6 = new byte[15];
                System.Threading.Thread.Sleep(130);
                var readByte6 = readput6.Read(rbuffer6, 0, rbuffer6.Length);
                readByte6 = readput6.Read(rbuffer6, 0, rbuffer6.Length);
                char c6;
                char c61;


                for (int i = 0; rbuffer6.Count() > i; i++)
                {
                    if (i == 3)
                    {
                        c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[i].ToString().Substring(0, 2)));
                        MensagemerroPlat6 = c6.ToString();
                        if (c6 == 69)
                        {
                            c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[4].ToString().Substring(0, 2)));
                            MensagemerroPlat6 += c6.ToString();
                            c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[5].ToString().Substring(0, 2)));
                            MensagemerroPlat6 += c6.ToString();
                            c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[6].ToString().Substring(0, 2)));
                            MensagemerroPlat6 += c6.ToString();
                        }
                    }

                    if (i > 2 && i < 9)
                    {
                        c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[i].ToString().Substring(0, 2)));
                        Peso6 += c6.ToString();
                    }
                    if (i == 9)
                    {
                        c6 = Convert.ToChar(Convert.ToUInt16(rbuffer6[9].ToString().Substring(0, 2)));
                        Estabilidade6 = c6.ToString();
                        //Validacoes.Peso6 = Convert.ToInt16(Peso6);
                        Validacoes.Estabilidade6 = Estabilidade6;
                        if (rbuffer6[2] == 45)
                            Validacoes.Peso6 = -Convert.ToInt16(Peso6);
                        if (rbuffer6[2] == 32)
                            Validacoes.Peso6 = Convert.ToInt16(Peso6);
                        Validacoes.ErroPlat6 = false;
                    }
                    if (i == 10)
                    {
                        c61 = Convert.ToChar(Convert.ToUInt16(rbuffer6[i].ToString().Substring(0, 2)));
                        Tensao6 += c61.ToString();
                    }
                    if (i == 11)
                    {
                        c61 = Convert.ToChar(Convert.ToUInt16(rbuffer6[i].ToString().Substring(0, 2)));
                        string resultado = VerificaCaractereTensao(c61.ToString());
                        Tensao6 +=  resultado;

                        if (Tensao6.Length >= 2)
                        {
                            string decValue = int.Parse(Tensao6, System.Globalization.NumberStyles.HexNumber).ToString();
                            decimal ValorTensao6 = Convert.ToDecimal(decValue) / 10;
                            Validacoes.Tensao6 = ValorTensao6.ToString();
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                Validacoes.ErroPlat6 = true;
            }
        }


        public static void ConectaImpressora()
        {
            try
            {
                Thread.Sleep(2000);
                BluetoothAdapter adaptadorImpressora = BluetoothAdapter.DefaultAdapter; // procura o adap. bluetooth 
                Validacoes.AdaptadorBluetoothImpressora = adaptadorImpressora;
                ICollection<BluetoothDevice> aparelhos = Validacoes.AdaptadorBluetooth.BondedDevices;
                BluetoothDevice[] apaImpressora = new BluetoothDevice[aparelhos.Count];
                ParcelUuid[] chavesImpressora;
                BluetoothSocket[] socketImpressora = new BluetoothSocket[1];
                Validacoes.BSocketImpressora = socketImpressora;
                int i = 0;
                string Conectado = "nao";
                foreach (BluetoothDevice aparelho in aparelhos)
                {
                    apaImpressora[i] = aparelho;
                    if (aparelho.Name == Validacoes.NomeImpressora)
                    {
                        Conectado = "sim";
                        chavesImpressora = aparelho.GetUuids();
                        Validacoes.BSocketImpressora[0] = aparelho.CreateInsecureRfcommSocketToServiceRecord(chavesImpressora[0].Uuid);
                        Thread.Sleep(1000);
                    }

                    i++;
                }



                var address = apaImpressora[0].Address;
                Thread.Sleep(500);
                if (Validacoes.BSocketImpressora[0].IsConnected == false)
                {
                    Validacoes.ExisteImpressora = true;
                    Validacoes.BSocketImpressora[0].Connect();
                }
            }
            catch (Exception erro)
            {
               if (existeImpressora==true)
                    Validacoes.NomeImpressora = "";

                //  Validacoes.BSocketImpressora[0].Close();
            }
        }

        public static string VerificaCaractereTensao(string ValorCaractere)
        {
            try
            {
                if(ValorCaractere.ToUpper()=="A" )
                    return ValorCaractere;
                if (ValorCaractere.ToUpper() == "B")
                    return ValorCaractere;
                if (ValorCaractere.ToUpper() == "C")
                    return ValorCaractere;
                if (ValorCaractere.ToUpper() == "D")
                    return ValorCaractere;
                if (ValorCaractere.ToUpper() == "E")
                    return ValorCaractere;
                if (ValorCaractere.ToUpper() == "F")
                    return ValorCaractere;

                if (Convert.ToInt16(ValorCaractere) >= 0 && Convert.ToInt16(ValorCaractere) <= 9)
                {
                    return ValorCaractere;
                }
                return ValorCaractere;
            }
            catch
            {
                return "0";
            }
        }
        public static int VerificaEspacoBrancoValorEsquerda(string ValorValor)
        {
            if(ValorValor.Length==4)
                 return 15;
            if (ValorValor.Length == 5)
                return 10;


            return 15;
        }
        public static int VerificaEspacoBrancoTextoEsquerda(string ValorTexto,string ValorValor)
        {
            int Tamanho = 51;
            
            //if (ValorValor.Length == 5)
            //{
              
            //    if (ValorTexto.Trim().Length == 1)
            //        return 52 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 2)
            //        return 51 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 3)
            //        return 50 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 4)
            //        return 49 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 5)
            //        return 48 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 6)
            //        return 47 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 7)
            //        return 46 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 8)
            //        return 45 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 9)
            //        return 44 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 10)
            //        return 43 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 11)
            //        return 42 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 12)
            //        return 42 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 13)
            //        return 41 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 14)
            //        return 40 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 15)
            //        return 39 - (ValorTexto.Trim().Length);

            //}
       
            //if (ValorValor.Length == 4)
            //{
            //    if (ValorTexto.Trim().Length == 1)
            //        return 50- (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 2)
            //        return 49- (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 3)
            //        return 48- (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 4)
            //        return 47-(ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 5)
            //        return 46 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 6)
            //        return 45 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 7)
            //        return 44 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 8)
            //        return 43 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 9)
            //        return 42 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 10)
            //        return 41 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 11)
            //        return 40 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 12)
            //        return 39 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 13)
            //        return 38 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 14)
            //        return 37 - (ValorTexto.Trim().Length);
            //    if (ValorTexto.Trim().Length == 15)
            //        return 36 - (ValorTexto.Trim().Length);

            //}




            return 47 -(ValorTexto.Trim().Length);
            
        }

        
        #endregion

        #region Impressao
        public static System.Byte[] Imprime_linha()
        {
            byte[] Linha = new byte[35];
            for (int i = 0; i < 35; i++)
            {
                if (i == 0)
                    Linha[i] = 0x1B;
                else if (i == 34)
                    Linha[i] = 0x0A;
                else
                    Linha[i] = 0x2D;
            }
            return Linha;
        }
        public static System.Byte[] Configure_linha_Centro()
        {
            byte[] Linha = new byte[35];
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    Linha[i] = 0x1B;
                if (i == 1)
                    Linha[i] = 0x61;
                if (i == 2)
                    Linha[i] = 0x01;
                if (i == 3)
                    Linha[i] = 0x0A;
            }
            return Linha;
        }
        public static System.Byte[] Configure_linha_Esquerda()
        {
            byte[] Linha = new byte[35];
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    Linha[i] = 0x1B;
                if (i == 1)
                    Linha[i] = 0x61;
                if (i == 2)
                    Linha[i] = 0x00;
                if (i == 3)
                    Linha[i] = 0x0A;
            }
            return Linha;
        }

        public static System.Byte[] Imprime_linha_Empresa(string ValorLinha)
        {
            byte[] Linha = new byte[35];

            Encoding ascii = Encoding.ASCII;
            // Convert the string into a byte array.
            byte[] unicodeBytes = ascii.GetBytes(ValorLinha);
            for (int i = 0; i < 35; i++)
            {
               if (i == 34)
                    Linha[i] = 0x0A;
                else
                {
                    if (i < unicodeBytes.Length)
                    {
                        Linha[i] = unicodeBytes[i];
                        if (Linha[i] == 63)
                        {
                            Linha[i] = ConverteCaracterehex(ValorLinha.Substring(i, 1));
                        }
                    }
                    else
                    {
                        Linha[i] = 0x0A;
                        break;
                    }
                }
            }
            return Linha;
        }

        public static System.Byte[] Imprime_linha_Teste(string ValorLinha)
        {
            byte[] Linha = new byte[35];

            Encoding ascii = Encoding.ASCII;
            // Convert the string into a byte array.
            byte[] unicodeBytes = ascii.GetBytes(ValorLinha);
            for (int i = 0; i < 35; i++)
            {
                if (i == 34)
                    Linha[i] = 0x0A;
                else
                {
                    if (i < unicodeBytes.Length)
                    {
                        Linha[i] = unicodeBytes[i];
                        if(Linha[i]==63)
                        {
                            Linha[i] = ConverteCaracterehex(ValorLinha.Substring(i, 1));
                        }
                    }
                    else
                    {
                        Linha[i] = 0x0A;
                        break;
                    }
                }
            }
           
            
            
            return Linha;
        }

        #endregion


        public static System.Byte ConverteCaracterehex(string caractere)
        {
            Byte retorno = 0X30;
            if (caractere == "0")
                retorno = 0X30;
            if (caractere == "1")
                retorno = 0X31;
            if (caractere == "2")
                retorno = 0X32;
            if (caractere == "3")
                retorno = 0X33;
            if (caractere == "4")
                retorno = 0X34;
            if (caractere == "5")
                retorno = 0X35;
            if (caractere == "6")
                retorno = 0X36;
            if (caractere == "7")
                retorno = 0X37;
            if (caractere == "8")
                retorno = 0X38;
            if (caractere == "9")
                retorno = 0X39;
            if (caractere == "Ç")
                retorno = 0X80;
            if (caractere == "ç")
                retorno = 0X87;
            if (caractere == "Ã")
                retorno = 0X8e;
            if (caractere == "ã")
                retorno = 0X84;
            if (caractere == "Ô")
                retorno = 0X99;
            if (caractere == "ô")
                retorno = 0X93;
            if (caractere == "ê")
                retorno = 0X88;
            if (caractere == "ê")
                retorno = 0X88;
            if (caractere == "Ê")
                retorno = 0XD3;
            return retorno;
        }

   



        public static void ZeraPlafaforma(BluetoothSocket Socket,
                                              int NrPlataforma)
        {

            bool ValidaPeso = false;
        

            int Contador = 0;
             
                Contador = Contador + 1;
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
                if(NrPlataforma==1)
                    buffer[7] =0x31;
                if (NrPlataforma == 2)
                    buffer[7] = 0x32;
                if (NrPlataforma == 3)
                    buffer[7] = 0x33;
                if (NrPlataforma == 4)
                    buffer[7] = 0x34;
                if (NrPlataforma == 5)
                    buffer[7] = 0x35;
                if (NrPlataforma == 6)
                    buffer[7] = 0x36;
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


          
                var output = Socket.OutputStream;
                var readput = Socket.InputStream;
                output.Write(buffer, 0, 21);
            
        }

        public static void CalibraPeso(BluetoothSocket Socket,
                                              int NrPlataforma,
                                              string Peso)
        {

            bool ValidaPeso = false;


            int Contador = 0;

            Contador = Contador + 1;
            //=================================+
            //  PRIMEIRO 05 CARACTERES FIXO   //
            //================================//
            //        >FF5F00003203           //
            //================================//
            byte[] buffer = new byte[30];
            buffer[0] = 0x3E;
            buffer[1] = 0x46;
            buffer[2] = 0x46;
            buffer[3] = 0x35;
            buffer[4] = 0x46;
            buffer[5] = 0x30;
            buffer[6] = 0x30;
            buffer[7] = 0x30;
            buffer[8] = 0x30;
            buffer[9] = 0x33;
            buffer[10] = 0x32;
            buffer[11] = 0x30;
            buffer[12] = 0x33;
            buffer[13] = 0x30;

            //==================================
            //   7 E 8                        //
            //================================//
            //   ID PLATAFORMA = NRPLATAFORMA //
            //================================//
            if (NrPlataforma == 1)
                buffer[14] = 0x31;
            if (NrPlataforma == 2)
                buffer[14] = 0x32;
            if (NrPlataforma == 3)
                buffer[14] = 0x33;
            if (NrPlataforma == 4)
                buffer[14] = 0x34;
            if (NrPlataforma == 5)
                buffer[14] = 0x35;
            if (NrPlataforma == 6)
                buffer[14] = 0x36;
            //==================================
            //  15 A 20  CARACTERES FIXOS     //
            //================================//
            //   COMANDO AAAAAA               //
            //================================//
            buffer[15] = 0x41;
            buffer[16] = 0x41;
            buffer[17] = 0x41;
            buffer[18] = 0x41;
            buffer[19] = 0x41;
            buffer[20] = 0x41;

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

            byte caractere;
            for (int i=0;i<=6;i++)
            {
                if(Peso.Substring(i,1)=="0")
                    buffer[20+i] = 0x30;
                if (Peso.Substring(i, 1) == "1")
                    buffer[20 + i] = 0x31;
                if (Peso.Substring(i, 1) == "2")
                    buffer[20 + i] = 0x32;
                if (Peso.Substring(i, 1) == "3")
                    buffer[20 + i] = 0x33;
                if (Peso.Substring(i, 1) == "4")
                    buffer[20 + i] = 0x34;
                if (Peso.Substring(i, 1) == "5")
                    buffer[20 + i] = 0x35;
                if (Peso.Substring(i, 1) == "6")
                    buffer[20 + i] = 0x36;
                if (Peso.Substring(i, 1) == "7")
                    buffer[20 + i] = 0x37;
                if (Peso.Substring(i, 1) == "8")
                    buffer[20 + i] = 0x38;
                if (Peso.Substring(i, 1) == "9")
                    buffer[20 + i] = 0x39;
            }


            var output = Socket.OutputStream;
            var readput = Socket.InputStream;
            output.Write(buffer, 0, 21);

        }



    }
}