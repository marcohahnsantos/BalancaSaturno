using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SATCARGO.ClassesGerais
{
    class BancoDados
    {
        /// <summary>
        /// SQLiteDatabase object sqldTemp to handle SQLiteDatabase.
        /// </summary>
        private SQLiteDatabase sqldTemp;
        /// <summary>
        /// The sSQLquery for query handling.
        /// </summary>
        private string sSQLQuery;
        /// <summary>
        /// The sMessage to hold message.
        /// </summary>
        private string sMessage;
        /// <summary>
        /// The bDBIsAvailable for database is available or not.
        /// </summary>
        private bool bDBIsAvailable;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDatabaseDemo.MyDatabase"/> class.
        /// </summary>
        /// 


        public BancoDados()
        {
            sMessage = "";
            bDBIsAvailable = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDatabaseDemo.MyDatabase"/> class.
        /// </summary>
        /// <param name='sDatabaseName'>
        /// Pass your database name.
        /// </param>
        public BancoDados(string sDatabaseName)
        {
            try
            {
                sMessage = "";
                bDBIsAvailable = false;
                //  CreateDatabaseVeiculoEmpresa(sDatabaseName);

            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyDatabaseDemo.MyDatabase"/> database available.
        /// </summary>
        /// <value>
        /// <c>true</c> if database available; otherwise, <c>false</c>.
        /// </value>
        public bool DatabaseAvailable
        {
            get { return bDBIsAvailable; }
            set { bDBIsAvailable = value; }
        }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get { return sMessage; }
            set { sMessage = value; }
        }
        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <param name='sDatabaseName'>
        /// Pass database name.
        /// </param>

        public async void CreateDatabases(string sDatabaseName)
        {
            
            try
            {
               

                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);



                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "EMPRESA " +
                       "(_id INTEGER PRIMARY KEY," +
                       "CNPJ VARCHAR," +
                       "IE VARCHAR," +
                       "NOME VARCHAR," +
                       "ENDERECO VARCHAR," +
                       "BAIRRO VARCHAR," +
                       "CIDADE VARCHAR," +
                       "UF VARCHAR," +
                       "DATA_CADASTRO VARCHAR," +
                       "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT  CNPJ,IE,NOME,ENDERECO,BAIRRO,CIDADE,UF " +
                        " FROM EMPRESA WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                Validacoes.EmpresaCnpj =  "92.780.000/0001-45";
                Validacoes.EmpresaIe = "00.00.00.000   ";
                Validacoes.EmpresaNome = "DETECT AUTOMAÇÃO";
                Validacoes.EmpresaEndereco = "RUA DOMINGOS DE ABREU 1005";
                Validacoes.EmpresaBairro = "SARANDI";
                Validacoes.EmpresaCidade = "PORTO ALEGRE";
                Validacoes.EmpresaUf = "RS";


                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.EmpresaCnpj = icursorTemp.GetString(0);
                    Validacoes.EmpresaIe = icursorTemp.GetString(1);
                    Validacoes.EmpresaNome = icursorTemp.GetString(2);
                    Validacoes.EmpresaEndereco = icursorTemp.GetString(3);
                    Validacoes.EmpresaBairro= icursorTemp.GetString(4);
                    Validacoes.EmpresaCidade = icursorTemp.GetString(5);
                    Validacoes.EmpresaUf = icursorTemp.GetString(6);
                }

               
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }


           

            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);
                //sSQLQuery = "DELETE FROM CLIENTES ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;


                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "CLIENTES " +
                       "(_id INTEGER PRIMARY KEY," +
                       "TIPO VARCHAR," +
                       "CNPJ_CPF VARCHAR," +
                       "IE VARCHAR," +
                       "NOME VARCHAR," +
                       "ENDERECO VARCHAR," +
                       "BAIRRO VARCHAR," +
                       "CIDADE VARCHAR," +
                       "UF VARCHAR," +
                       "DATA_CADASTRO VARCHAR," +
                       "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT  CNPJ_CPF,IE,NOME,ENDERECO,BAIRRO,CIDADE,UF " +
                        " FROM CLIENTES WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                Validacoes.ClienteCnpj = "00.000.000/0000-00";
                Validacoes.ClienteIe = "00.00.00.000   ";
                Validacoes.ClienteNome = "EMPRESA DE TESTE";
                Validacoes.ClienteEndereco = "RUA X 101";
                Validacoes.ClienteBairro = "CENTRO";
                Validacoes.ClienteCidade = "PORTO ALEGRE";
                Validacoes.ClienteUf = "RS";


                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.ClienteCnpj = icursorTemp.GetString(0);
                    Validacoes.ClienteIe = icursorTemp.GetString(1);
                    Validacoes.ClienteNome = icursorTemp.GetString(2);
                    Validacoes.ClienteEndereco = icursorTemp.GetString(3);
                    Validacoes.ClienteBairro = icursorTemp.GetString(4);
                    Validacoes.ClienteCidade = icursorTemp.GetString(5);
                    Validacoes.ClienteUf = icursorTemp.GetString(6);
                }

            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }

            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);

                //sSQLQuery = "DROP TABLE IF EXISTS PESAGEM_REALIZADAS ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;
                //sSQLQuery = "DELETE FROM PESAGEMS_REALIZADAS ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;


                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "PESAGEMS_REALIZADAS " +
                       "(_id INTEGER PRIMARY KEY," +
                        "ID_CLIENTE INTEGER," +
                        "CLIENTE VARCHAR," +
                        "ID_VEICULO INTEGER," +
                        "VEICULO VARCHAR," +
                        "ID_PRODUTO INTEGER," +
                        "PRODUTO VARCHAR," +
                        "MOTORISTA VARCHAR," +
                        "NR_PLATAFORMAS NUMERIC(18,0)," +
                        "PESO_PLAT1 NUMERIC(18,0)," +
                        "PESO_PLAT2 NUMERIC(18,0)," +
                        "PESO_EIXO1 NUMERIC(18,0)," +
                        "PESO_PLAT3 NUMERIC(18,0)," +
                        "PESO_PLAT4 NUMERIC(18,0)," +
                        "PESO_EIXO2 NUMERIC(18,0)," +
                        "PESO_PLAT5 NUMERIC(18,0)," +
                        "PESO_PLAT6 NUMERIC(18,0)," +
                        "PESO_EIXO3 NUMERIC(18,0)," +
                        "PESO_TOTAL NUMERIC(18,0)," +
                        "DATA_CADASTRO VARCHAR," +
                        "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;
                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT  " +
                            "ID_CLIENTE," +
                            "CLIENTE," +
                            "ID_VEICULO," +
                            "VEICULO,"+
                            "ID_PRODUTO,"+
                            "PRODUTO,"+
                            "MOTORISTA," +
                            "NR_PLATAFORMAS,"+
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
                            "HORA_CADASTRO "+
                            "FROM PESAGEMS_REALIZADAS WHERE _id=1";


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
                    Validacoes.PesagemRealizadaPlat1 = Convert.ToDouble(icursorTemp.GetString(7));
                    Validacoes.PesagemRealizadaPlat2 = Convert.ToDouble(icursorTemp.GetString(8));
                    Validacoes.PesagemRealizadaPlat3 = Convert.ToDouble(icursorTemp.GetString(9));
                    Validacoes.PesagemRealizadaPlat4 = Convert.ToDouble(icursorTemp.GetString(10));
                    Validacoes.PesagemRealizadaPlat5 = Convert.ToDouble(icursorTemp.GetString(11));
                    Validacoes.PesagemRealizadaPlat6 = Convert.ToDouble(icursorTemp.GetString(12));
                    Validacoes.PesagemRealizadaTotal = Convert.ToDouble(icursorTemp.GetString(13));
                    Validacoes.PesagemRealizadaData = icursorTemp.GetString(14);
                    Validacoes.PesagemRealizadaHora = icursorTemp.GetString(15);
                }



            }




            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }

            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);
                //sSQLQuery = "DELETE FROM VEICULOS ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;
                //sSQLQuery = "DROP TABLE VEICULOS ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;


                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "VEICULOS " +
                       "(_id INTEGER PRIMARY KEY," +
                       "PLACA VARCHAR," +
                       "ANOFAB VARCHAR," +
                       "MONTADORA VARCHAR," +
                       "CATEGORIA VARCHAR," +
                       "PESOTARA VARCHAR," +
                       "PESOBRUTO VARCHAR," +
                       "DATA_CADASTRO VARCHAR," +
                       "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }


            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);

              

                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "PRODUTOS " +
                       "(_id INTEGER PRIMARY KEY," +
                       "PRODUTO VARCHAR," +
                       "VALOR VARCHAR," +
                       "DATA_CADASTRO VARCHAR," +
                       "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);

                //sSQLQuery = "DROP TABLE IF EXISTS CONFIGURACAO_SISTEMA ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;

                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                       "CONFIGURACAO_SISTEMA " +
                       "(_id INTEGER PRIMARY KEY," +
                       "DESCRICAO VARCHAR," +
                       "NR_SEGUNDOS_PESO INT," +
                       "NR_PLATAFORMAS INT," +
                       "CAMPO2 VARCHAR," +
                       "CAMPO3 VARCHAR," +
                       "CAMPO4 VARCHAR," +
                       "CAMPO5 VARCHAR," +
                       "DATA_CADASTRO VARCHAR," +
                       "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT NR_SEGUNDOS_PESO " +
                        " FROM CONFIGURACAO_SISTEMA WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);

                Validacoes.TempoCapturaPeso = 2;
                int ValorCursor = icursorTemp.Count;
                int nrParcelas = 0;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.TempoCapturaPeso = int.Parse(icursorTemp.GetString(0)) + 1;
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }

            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);

                //sSQLQuery = "delete from CONEXAO_PLATAFORMA WHERE _id = 1";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;



                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                        "CONEXAO_PLATAFORMA " +
                        "(_id INTEGER PRIMARY KEY," +
                        "NR_PLATAFORMAS INTEGER," +
                        "DESCRICAO_TIPO_CONEXAO VARCHAR," +
                        "ENDERECO_IP VARCHAR," +
                        "PORTA VARCHAR," +
                        "BLUETOOTH VARCHAR," +
                        "SENHA VARCHAR," +
                        "DATA_CADASTRO VARCHAR," +
                        "HORA_CADASTRO VARCHAR);";
                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }

            try
            {
                sMessage = "";
                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);

                //sSQLQuery = "DROP TABLE IF EXISTS CONEXAO_PRINTER ";
                //sqldTemp.ExecSQL(sSQLQuery);
                //bDBIsAvailable = true;
                
                sSQLQuery = "CREATE TABLE IF NOT EXISTS " +
                        "CONEXAO_PRINTERS " +
                        "(_id INTEGER PRIMARY KEY," +
                        "DESCRICAO_TIPO_CONEXAO VARCHAR," +
                        "ENDERECO_IP VARCHAR," +
                        "PORTA VARCHAR," +
                        "BLUETOOTH VARCHAR," +
                        "SENHA VARCHAR," +
                        "ATIVA VARCHAR," +
                        "DATA_CADASTRO VARCHAR," +
                        "HORA_CADASTRO VARCHAR);";


                sqldTemp.ExecSQL(sSQLQuery);
                bDBIsAvailable = true;

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT BLUETOOTH,ATIVA " +
                        " FROM CONEXAO_PRINTERS WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    Validacoes.NomeImpressora = icursorTemp.GetString(0);
                    Validacoes.ImpressoraAtiva = icursorTemp.GetString(1);
                }


}
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }


        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name='sName'>
        /// Pass name.
        /// </param>
        /// <param name='iAge'>
        /// Pass age.
        /// </param>
        /// <param name='sCountry'>
        /// Pass country.
        /// </param>

        public void FinalizaDatabases(string sDatabaseName)
        {
            sqldTemp.Close();
        }
        public void VerNrPlataformasAtivas()
        {
            try
            {

                Android.Database.ICursor icursorTemp = null;
                sSQLQuery = "SELECT NR_PLATAFORMAS " +
                        " FROM CONEXAO_PLATAFORMA WHERE _id=1";
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);


                int ValorCursor = icursorTemp.Count;
                int nrParcelas = 0;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    nrParcelas = int.Parse(icursorTemp.GetString(0))+1;
                    Validacoes.Nrplataformas = nrParcelas;
                    Validacoes.NrPlataformas = nrParcelas;
                }

            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }



        public void AddRecord(string Tabela, string Campos, string Valores)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    Tabela + "(" + Campos + ") " +
                    "VALUES(" + Valores + ");";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        public void UpdateRecord(string Tabela, string Where, string Valores)
        {
            try
            {
                sSQLQuery = "UPDATE " +
                    Tabela + " SET " + Valores + " " +
                    Where;
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        public void AddRecordComando(string Comando)
        {
            try
            {
                sSQLQuery = Comando;
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";

            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        public void AddRecordUrl(string Valores)
        {
            try
            {
                sSQLQuery = "INSERT INTO CONEXAO_WEBSERVICE"
                    + "(_id,URL_CONEXAO) " +
                    "VALUES(1,'" + Valores + "')";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }


        public void AddRegistros(string Tabela, string Campos, string Valores)
        {
            try
            {
                sSQLQuery = $"INSERT INTO {Tabela} ({Campos}) values({Valores})";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordIPIndicador(string Valores, string Porta)
        {
            try
            {
                sSQLQuery = "INSERT INTO CONEXAO_INDICADOR"
                    + "(_id,IP,PORTA) " +
                    "VALUES(1,'" + Valores + "','" + Porta + "')";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }


        public void AddRecordVeiculoEmpresa(int Id, string Placa)
        {
            try
            {
                Android.Database.ICursor icursorTemporario = null;
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM Veiculo_Empresa ;";
                icursorTemporario = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporario == null))
                {
                    sSQLQuery = "INSERT INTO " +
                        "Veiculo_Empresa " +
                        "(_id,PLACA,MARCADO)" +
                        "VALUES(" + Id + ",'" + Placa + "','" + "0" + "');";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is saved.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordProdutos(int Id, string Produto)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    "Produtos " +
                    "(ID_PRODUTO,DESCRICAO)" +
                    "VALUES(" + Id + ",'" + Produto + "');";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordLocalizacao(int Id, int IdMina, string Descricao)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    "Localizacao " +
                    "(ID_LOCALIZACAO,ID_MINA,DESCRICAO)" +
                    "VALUES(" + Id + "," + IdMina + ",'" + Descricao + "');";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordMovimentacao(int Id, int IdOrigem, int IdDestino, int IdProduto)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    "Movimentacao " +
                    "(ID_MOVIMENTACAO,ID_ORIGEM,ID_DESTINO,ID_PRODUTO)" +
                    "VALUES(" + Id + "," + IdOrigem + "," + IdDestino + "," + IdProduto + ");";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordListaMovimentacao(string Placa, int Id, string Produto, string Origem, string Destino, string Peso)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    "ListaMovimentacao " +
                    "(PLACA,ID,PRODUTO,ORIGEM,DESTINO,TONELADAS)" +
                    "VALUES('" + Placa + "'," + Id + ",'" + Origem + "','" + Destino + "','" + Produto + "','" + Peso + "');";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecordListaPlaca(int _id, string Placa, string Produto, string Origem, string Destino, string Tara)
        {
            try
            {
                sSQLQuery = "INSERT INTO " +
                    "MinhaTabela " +
                    "(_id,Placa,Produto,Origem,Destino,Tara,Marcado)" +
                    "VALUES(" + _id + ",'" + Placa + "','" + Produto + "','" + Origem + "','" + Destino + "','" + Tara + "','');";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void AddRecords(String Tabela, String Campos, String Values)
        {
            try
            {
                sSQLQuery = "INSERT INTO " + Tabela +
                      "(" + Campos + ")" +
                    "VALUES(" + Values + ")";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }


        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name='iId'>
        /// Pass record ID.
        /// </param>
        /// <param name='sName'>
        /// Pass name.
        /// </param>
        /// <param name='iAge'>
        /// Pass age.
        /// </param>
        /// <param name='sCountry'>
        /// Pass country.
        /// </param>

        public void AlterRecordUnico(int Id, string Tabela, string Campo, string ValorRegistro)
        {
            try
            {
                sSQLQuery = "UPDATE  " +
                    Tabela +
                    "SET " + Campo + "='" + ValorRegistro + "' " +
                "where _id=" + Id + "";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is saved.";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }


        public void UpdateRecord(String Tabela, String Set, String Campo, String Codigo)
        {
            try
            {
                sSQLQuery = "UPDATE " + Tabela + " " + Set + " WHERE " + Campo + "='" + Codigo + "';";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is updated: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void UpdateRecordVeiculoEmpresa(string iPlaca)
        {
            try
            {
                sSQLQuery = "UPDATE Veiculo_Empresa " +
                    "SET MARCADO='X' " +
                    "WHERE Placa='" + iPlaca + "';";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is updated: " + iPlaca;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void UpdateRecordXMinhaTabela(string iPlaca)
        {
            try
            {
                sSQLQuery = "UPDATE MinhaTabela " +
                    "SET Marcado='X' " +
                    "WHERE Placa='" + iPlaca + "';";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is updated: " + iPlaca;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        public void UpdateRecordNMinhaTabela(string iPlaca)
        {
            try
            {
                sSQLQuery = "UPDATE MinhaTabela " +
                    "SET Marcado='' " +
                    "WHERE Placa='" + iPlaca + "';";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is updated: " + iPlaca;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        public void UpdateRecordVeiculoExcluiEmpresa(string iPlaca)
        {
            try
            {

                sSQLQuery = "UPDATE Veiculo_Empresa " +
                    "SET MARCADO='0' " +
                    "WHERE Placa='" + iPlaca + "';";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is updated: " + iPlaca;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name='iId'>
        /// Pass ID.
        /// </param>
        public void Delete1Record(int iId, string Tabela)
        {
            try
            {
                sSQLQuery = "DELETE FROM " + Tabela + " WHERE _id=" + iId + "";

                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: " + iId;
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }



        public void DeleteallRecord(string Tabela)
        {
            try
            {
                sSQLQuery = "DELETE FROM " + Tabela + "";

                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordVeiculoEmpresa()
        {
            try
            {
                Android.Database.ICursor icursorTemporario = null;
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM Veiculo_Empresa ;";
                icursorTemporario = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemporario.Count;

                if (ValorCursor == 0)
                {
                    sSQLQuery = "DELETE FROM Veiculo_Empresa;";
                    sqldTemp.ExecSQL(sSQLQuery);
                    sMessage = "Record is deleted: ";
                }
                else
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordProdutos()
        {
            try
            {
                sSQLQuery = "DELETE FROM Produtos;";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordLocalizacao()
        {
            try
            {
                sSQLQuery = "DELETE FROM Localizacao;";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordMovimentacao()
        {
            try
            {
                sSQLQuery = "DELETE FROM Movimentacao;";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordListaMovimentacao()
        {
            try
            {
                sSQLQuery = "DELETE FROM ListaMovimentacao;";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        public void DeleteAllRecordListaPlaca()
        {
            try
            {
                sSQLQuery = "DELETE FROM MinhaTabela;";
                sqldTemp.ExecSQL(sSQLQuery);
                sMessage = "Record is deleted: ";
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }
        /// <summary>
        /// Gets the record cursor.
        /// </summary>
        /// <returns>
        /// The record cursor.
        /// </returns>
        public Android.Database.ICursor GetRecordCursor()
        {
            Android.Database.ICursor icursorTemporario = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM MinhaTabela WHERE Placa IN (SELECT PLACA FROM Veiculo_Empresa WHERE MARCADO='X') ;";
                //sSQLQuery = "SELECT * FROM MinhaTabela ;";
                icursorTemporario = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporario != null))
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporario;
        }
        public Android.Database.ICursor GetRecordCursorMov()
        {
            Android.Database.ICursor icursorTemporario = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT Distinct _id,DATA_ABATE,HORA_ABATE " +
                    " FROM ABATE ;";

                icursorTemporario = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporario != null))
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporario;
        }

        public Android.Database.ICursor GetRecordCursor1()
        {
            Android.Database.ICursor icursorTemporario1 = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM Veiculo_Empresa WHERE MARCADO='0';";
                icursorTemporario1 = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporario1 != null))
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporario1;
        }

        public Android.Database.ICursor GetRecordCursor4()
        {
            Android.Database.ICursor icursorTemporario4 = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM Veiculo_Empresa WHERE MARCADO='X';";
                icursorTemporario4 = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporario4 != null))
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporario4;
        }
        public Android.Database.ICursor GetRecordCursorMarcaMovimentacao()
        {
            Android.Database.ICursor icursorTemporarioMarcaMov = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT Placa FROM MinhaTabela WHERE MARCADO='X';";
                icursorTemporarioMarcaMov = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporarioMarcaMov != null))
                {
                    sMessage = "Nenhum Registro Encontrado";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporarioMarcaMov;
        }

        public Android.Database.ICursor GetRecordCursorAbate()
        {
            Android.Database.ICursor icursorTemporarioMarcaMov = null;
            try
            {
                sSQLQuery = "";
                sSQLQuery = "SELECT * FROM ABATE";
                icursorTemporarioMarcaMov = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icursorTemporarioMarcaMov != null))
                {
                    sMessage = "Nenhum Registro Encontrado";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icursorTemporarioMarcaMov;
        }
        /// <summary>
        /// Gets the record cursor by search criteria.
        /// </summary>
        /// <returns>
        /// The record cursor.
        /// </returns>
        /// <param name='sColumn'>
        /// column filed of MinhaTabela is Name,Age,Country.
        /// </param>
        /// <param name='sValue'>
        /// Value as user input.
        /// </param>
        public Android.Database.ICursor GetRecordCursor(string sColumn, string sValue)
        {
            Android.Database.ICursor icTemp = null;
            try
            {
                sSQLQuery = "SELECT * FROM ListaMovimentacao WHERE " + sColumn + " LIKE '" + sValue + "%';";
                icTemp = sqldTemp.RawQuery(sSQLQuery, null);
                if (!(icTemp != null))
                {
                    sMessage = "Record not found.";
                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icTemp;
        }
        public Android.Database.ICursor PesquisaAparelho()
        {
            Android.Database.ICursor icTemp = null;
            try
            {
                string sSQLQuery = "SELECT NR_PLATAFORMAS," +
                                " DESCRICAO_TIPO_CONEXAO, " +
                                " ENDERECO_IP, " +
                                " PORTA, " +
                                " BLUETOOTH " +
                                " FROM CONEXAO_PLATAFORMA WHERE _id=1";

                string sLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string sDB = Path.Combine(sLocation, "PRINCIPAL");
                sqldTemp = SQLiteDatabase.OpenOrCreateDatabase(sDB, null);
                bool bIsExists = File.Exists(sDB);
                Android.Database.ICursor icursorTemp = null;
                icursorTemp = sqldTemp.RawQuery(sSQLQuery, null);
                int ValorCursor = icursorTemp.Count;
                int nrParcelas = 0;
                if (ValorCursor > 0)
                {
                    icursorTemp.MoveToNext();
                    {
                        Validacoes.Nrplataformas = Convert.ToInt16(icursorTemp.GetString(0));
                        Validacoes.TipoConexaoBalanca = icursorTemp.GetString(1);
                        Validacoes.IpConexaoBalanca= icursorTemp.GetString(2);
                        Validacoes.PortaConexaoBalanca = icursorTemp.GetString(3);
                        Validacoes.NomeConexaoBluetooth = icursorTemp.GetString(4);
                    }

                }
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
            return icTemp;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="MyDatabaseDemo.MyDatabase"/> is reclaimed by garbage collection.
        /// </summary>
        ~BancoDados()
        {
            try
            {
                sMessage = "";
                bDBIsAvailable = false;
                sqldTemp.Close();
            }
            catch (SQLiteException ex)
            {
                sMessage = ex.Message;
            }
        }

    }
}