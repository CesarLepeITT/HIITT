using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace GimApp.Clases
{
    class Ejercicios
    {
        public Ejercicios(string nombreEjercicio, int series, int repeticiones, Peso peso, string maquinaria, string grupoMuscular, string rutinaAlamacenadora)
        {

            //nombreEjercicio ??= "Ejercicio";
            if (nombreEjercicio == "")
                nombreEjercicio = "Ejercicio";
            Nombre = nombreEjercicio;

            RutinaAlamacenadora = rutinaAlamacenadora;

            Series = series;

            Repeticiones = repeticiones;

            _peso = peso;

            maquinaria ??= "Sin especificar";
            Maquinaria = maquinaria;

            grupoMuscular ??= "Sin especificar";
            GrupoMuscular = grupoMuscular;
            try
            {
                //Definir el path
                Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\{Nombre}.txt", UriKind.RelativeOrAbsolute);
                PathTxt= myUri.ToString();
                PathTxt = PathTxt.Substring(8);
                int contador = 1;
                while (File.Exists(PathTxt))//Revisa que no haya un texto con el mismo path
                {
                    //Si el txto existe le da un (numero) para que sea otro path distinto
                    PathTxt = myUri.ToString();
                    PathTxt = PathTxt.Substring(8);
                    PathTxt += $@"({contador}).txt";
                    contador++;
                }
                using (FileStream oFS = File.Create(PathTxt)) //Crea un archivo en el path que se le dio
                {
                    Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8
                    oFS.Write(texto, 0, texto.Length); //Escribe el objeto en el txt
                }

                // Hacer que el Nombre del ejercicio sea igual al nombre del archivo txt
                //
                // Ej ejercicio(1).txt
                // Nombre = ejercicio(1)
                //
            }
            catch (Exception)
            {

            }
        }

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }

        public string RutinaAlamacenadora
        {
            set { _rutinaAlamacenadora = value; }
            get { return _rutinaAlamacenadora; }
        }

        public int Series
        {
            set { _series = value; }
            get { return _series; }
        }

        public int Repeticiones
        {
            set { _repeticiones = value; }
            get { return _repeticiones; }
        }

        public Peso Peso
        {
            set { _peso = value; }
            get { return _peso; }
        }

        public string Maquinaria
        {
            set { _maquinaria = value; }
            get { return _maquinaria; }
        }

        public string GrupoMuscular
        {
            set { _grupoMuscular = value; }
            get { return _grupoMuscular; }
        }

        public string PathTxt
        {
            set { _pathTxt = value; }
            get { return _pathTxt; }
        }
        public Peso CambiarUnidadesPeso(Peso peso, decimal cantidad)
        {
            if (peso.Unidad == "kg")
                return peso.ConvertirUnidad(cantidad);
            else
                return peso.ConvertirUnidad(cantidad);
        }

        public override String ToString()
        {
            return $"Nombre = {_nombre}\n" +
                $"Series = {_series}\n" +
                $"Repeticiones = {_repeticiones}\n" +
                $"PesoCantidad = {_peso.Cantidad}\n" +
                $"PesoUnidad = {_peso.Unidad}\n" +
                $"Maquiaria = {_maquinaria}\n" +
                $"GrupoMuscular = {_grupoMuscular}";
        }

        public void EditarEjercicio(string nombreEjercicio, int series, int repeticiones, Peso peso, string maquinaria, string grupoMuscular, string rutinaContenedora)
        {
            File.Delete(PathTxt);

            nombreEjercicio ??= "Ejercicio";
            Nombre = nombreEjercicio;

            Series = series;

            Repeticiones = repeticiones;

            _peso = peso;

            maquinaria ??= "Sin especificar";
            Maquinaria = maquinaria;

            grupoMuscular ??= "Sin especificar";
            GrupoMuscular = grupoMuscular;

            _rutinaAlamacenadora = rutinaContenedora;

            Ejercicios aux = new Ejercicios(Nombre, Series, Repeticiones, Peso, Maquinaria, GrupoMuscular, _rutinaAlamacenadora);

            PathTxt = aux.PathTxt;

        }

        private string _pathTxt;
        private string? _nombre;
        private int _series;
        private int _repeticiones;
        private Peso _peso;
        private string? _maquinaria;
        private string? _grupoMuscular;
        private string _rutinaAlamacenadora;

    }

}
