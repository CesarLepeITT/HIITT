using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HIITT.Clases
{
    internal class Verificador
    {
        // Comprueba si una textbox tiene solo letras
        public static bool SoloLetras(string texto)
        {
            if (Regex.IsMatch(texto, @"\w+"))
                return true;
            else 
                return false;
        }
        //Comprueba si una textbox tiene solo numeros
        public static bool SoloNumeros(string texto)
        {
            if (Regex.IsMatch(texto, @"^[0-9]+"))
                return true;
            else
                return false;
        }
        //Comprueba si una textbox tiene numeros enteros o numeros decimales
        public static bool SoloNumerosDecimales(string texto)
        {
            if (Regex.IsMatch(texto, @"^[0-9]+"))
                return true;
            else
                return false;
        }

    }
}
