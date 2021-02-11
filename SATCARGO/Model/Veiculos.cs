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
    public class Veiculos
    {
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

    }
}