using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SATCARGO.ClassesGerais;
using Android.Database.Sqlite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SATCARGO.Model
{
    public class Clientes
    {
        public class CarredaDadosClientes
        {
            public string Id { get; set; }
            public string Tipo { get; set; }
            public string Nome { get; set; }
            public string Cnpj_Cpf { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public string Data { get; set; }
            public string Hora { get; set; }
            private SQLiteDatabase sqldTemp;
            private string sSQLQuery;
            BancoDados mdTemp;
        }

    }
}