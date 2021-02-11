using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SATCARGO.Model
{
    public class Pesagens
    {
        public class CarreDadosPesagem
        {

            public string Id { get; set; }
            public string Id_cliente { get; set; }
            public string Cliente { get; set; }
            public string Id_veiculo { get; set; }
            public string Veiculo { get; set; }
            public string Id_produto { get; set; }
            public string Produto { get; set; }
            public string Motorista { get; set; }
            public string Nr_plataformas { get; set; }
            public string Peso_plat1 { get; set; }
            public string Peso_plat2 { get; set; }
            public string Peso_eixo1 { get; set; }
            public string Peso_plat3 { get; set; }
            public string Peso_plat4 { get; set; }
            public string Peso_eixo2 { get; set; }
            public string Peso_plat5 { get; set; }
            public string Peso_plat6 { get; set; }
            public string Peso_eixo3 { get; set; }
            public string Peso_total { get; set; }
            public string Data { get; set; }
            public string Hora { get; set; }
           
           
        }

    }
}