using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GimApp.Clases
{
    class Ejercicios
    {
        public Ejercicios(string nombreEjercicio, int series, int repeticiones, Peso peso, string maquinaria, string grupoMuscular)
        {

            //nombreEjercicio ??= "Ejercicio";
            if (nombreEjercicio == "")
                nombreEjercicio = "Ejercicio";
            Nombre = nombreEjercicio;

            Series = series;

            Repeticiones = repeticiones;

            _peso = peso;

            maquinaria ??= "Sin especificar";
            Maquinaria = maquinaria;

            grupoMuscular ??= "Sin especificar";
            GrupoMuscular = grupoMuscular;

            //Definir el path
            //C:\Users\Linux-1\Source\Repos\CesarLepeITT\HIITT\saves\saves_ejercicios\

            PathTxt = $@"C:\Users\Linux-1\Source\Repos\CesarLepeITT\HIITT\saves\saves_ejercicios\{Nombre}.txt";

            while (File.Exists(PathTxt))
            {
                int contador = 1;
                PathTxt = $@"C:\Users\Linux-1\Source\Repos\CesarLepeITT\HIITT\saves\saves_ejercicios\{Nombre}({contador}).txt";
                contador++;
            }
            using (FileStream oFS = File.Create(PathTxt))
            {
                Byte[] texto = new UTF8Encoding(true).GetBytes(ToString());
                oFS.Write(texto, 0, texto.Length);
            }
            using (FileStream oFS = File.Create(PathTxt))
            {

            }

        }

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
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
   
            return $"Nombre = {_nombre}\n " +
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

            Ejercicios aux = new Ejercicios(Nombre, Series, Repeticiones, Peso, Maquinaria, GrupoMuscular);

            PathTxt = aux.PathTxt;

        }

        private string _pathTxt;
        private string? _nombre;
        private int _series;
        private int _repeticiones;
        private Peso _peso;
        private string? _maquinaria;
        private string? _grupoMuscular;

    }

}
