using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SATCARGO.ClassesGerais
{
    public class FormatarCampos
    {
        public static string PesoValueConverter(string text)
        {
            var numbers = Regex.Replace(text, @"\D", "");

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length == 4)
                {
                    numbers = numbers.ToString().Substring(0, 1) + "." + numbers.ToString().Substring(1);
                    break;
                }
                if (numbers.Length == 5)
                {
                    numbers = numbers.ToString().Substring(0, 2) + "." + numbers.ToString().Substring(2);
                    break;
                }
                if (numbers.Length == 6)
                {
                    numbers = numbers.ToString().Substring(0, 3) + "." + numbers.ToString().Substring(3);
                    break;
                }
                if (numbers.Length > 6)
                {
                    numbers = numbers.ToString().Substring(0, 3) + "." + numbers.ToString().Substring(3, 3);
                    break;
                }
            }
            return numbers;
        }
        public static string ValorValueConverter(string text)
        {
            var numbers = Regex.Replace(text, @"\D", "");

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length == 3)
                {
                    numbers = numbers.ToString().Substring(0, 1) + "," + numbers.ToString().Substring(1);
                    break;
                }
                if (numbers.Length == 4)
                {
                    numbers = numbers.ToString().Substring(0, 2) + "," + numbers.ToString().Substring(2);
                    break;
                }
                if (numbers.Length == 5)
                {
                    numbers = numbers.ToString().Substring(0, 3) + "," + numbers.ToString().Substring(3);
                    break;
                }
                if (numbers.Length == 6)
                {
                    numbers = numbers.ToString().Substring(0, 1) + "." + numbers.ToString().Substring(1, 3) +","+ numbers.ToString().Substring(4);
                    break;
                }
                if (numbers.Length == 7)
                {
                    numbers = numbers.ToString().Substring(0, 2) + "." + numbers.ToString().Substring(2, 3) + "," + numbers.ToString().Substring(5);
                    break;
                }
                if (numbers.Length == 8)
                {
                    numbers = numbers.ToString().Substring(0, 3) + "." + numbers.ToString().Substring(3, 3) + "," + numbers.ToString().Substring(6);
                    break;
                }
            }
            return numbers;
        }
        public static string CpnpjCpfValueConverter(string text)
        {
            var numbers = Regex.Replace(text, @"\D", "");

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length <= 11)
                {
                    if (numbers.Length >= 4 && numbers.Length <= 5)
                    {
                        numbers = numbers.ToString().Substring(0, 3) + "." + numbers.ToString().Substring(3);
                        break;
                    }
                  
                    if (numbers.Length > 6 && numbers.Length <= 8)
                    {
                        numbers = numbers.ToString().Substring(0, 3) + "." +
                                  numbers.ToString().Substring(3, 3) + "." + numbers.ToString().Substring(6);
                        break;
                    }
                    if (numbers.Length == 6)
                    {
                        numbers = numbers.ToString().Substring(0, 3) + "." +
                                  numbers.ToString().Substring(3, 3)  ;
                        break;
                    }
                    if (numbers.Length == 9)
                    {
                        numbers = numbers.ToString().Substring(0, 3) + "." +
                                  numbers.ToString().Substring(3, 3) + "." +
                                  numbers.ToString().Substring(6, 3) ;
                        break;
                    }
                    if (numbers.Length > 9 )
                    {
                        numbers = numbers.ToString().Substring(0, 3) + "." +
                                  numbers.ToString().Substring(3, 3) + "." + 
                                  numbers.ToString().Substring(6,3) + "-"+ 
                                  numbers.ToString().Substring(9);
                        break;
                    }
                }
                if (numbers.Length > 11)
                {
                    if (numbers.Length == 12 )
                    {
                        numbers = numbers.ToString().Substring(0, 2) + "."
                                + numbers.ToString().Substring(2, 3) + "."
                                + numbers.ToString().Substring(5, 3) + "/" 
                                +numbers.ToString().Substring(8);
                        break;
                    }
                    if (numbers.Length == 13)
                    {
                        numbers = numbers.ToString().Substring(0,2) + "."
                                + numbers.ToString().Substring(2,3) + "."
                                + numbers.ToString().Substring(5,3) + "/"
                                + numbers.ToString().Substring(8,4) + "-" 
                                + numbers.ToString().Substring(12,1);
                        break;
                    }
                    if (numbers.Length >= 14)
                    {
                        numbers = numbers.ToString().Substring(0, 2) + "."
                                + numbers.ToString().Substring(2, 3) + "."
                                + numbers.ToString().Substring(5, 3) + "/"
                                + numbers.ToString().Substring(8, 4) + "-"
                                + numbers.ToString().Substring(12);
                        break;
                    }

                }
            }
            return numbers;
        }

        public static int VerificaEspaco(string text)
        {
            var numbers = Regex.Replace(text, @"0", " ");
            int posicaoDoEspaco = text.IndexOf(" ");
            
            
            int diferenca = 0;
            if (posicaoDoEspaco!=-1)
               diferenca = (text.Length - posicaoDoEspaco)+2;

            return diferenca;

        }
        public static string  RetornaTextoLista(string text)
        {
            var numbers = Regex.Replace(text, @"0", " ");
            return numbers.ToString();
        }

    }
}