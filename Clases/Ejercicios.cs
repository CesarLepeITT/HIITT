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
        public Ejercicios(string nombreEjercicio, int series, int repeticiones, Peso peso, string maquinaria, string grupoMuscular, string rutinaContenedora)
        {

            if (nombreEjercicio == null)
                nombreEjercicio = "Ejercicio";
            Nombre = nombreEjercicio;

            Series = series;

            Repeticiones = repeticiones;

            _peso = peso;

            if (maquinaria == null)
                maquinaria = "Sin especificar";
            Maquinaria = maquinaria;

            if (grupoMuscular == null)
                grupoMuscular = "Sin especificar";
            GrupoMuscular = grupoMuscular;

            //Definir el path
            Path = $@"C:\Users\Linux-1\source\repos\GimApp\saves\saves_ejercicios\{Nombre}.txt";

            while (File.Exists(Path))
            {
                int contador = 1;
                Path = $@"C:\Users\Linux-1\source\repos\GimApp\Guardado\saves_ejercicios\{Nombre}({contador}).txt";
                contador++;
            }
            using (FileStream oFS = File.Create(Path))
            {
                Byte[] texto = new UTF8Encoding(true).GetBytes(ToString());
                oFS.Write(texto, 0, texto.Length);
            }

            RutinaContenedora = rutinaContenedora;

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

        public string RutinaContenedora
        {
            set { _rutinaContenedora = value; }
            get { return _rutinaContenedora; }
        }

        public string Path
        {
            set { _path = value; }
            get { return _path; }
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
                $"Peso = {_peso.Cantidad} {_peso.Unidad}\n" +
                $"Maquiaria = {_maquinaria}\n" +
                $"Grupo Muscular = {_grupoMuscular}";
        }

        public void EditarEjercicio(string nombreEjercicio, int series, int repeticiones, Peso peso, string maquinaria, string grupoMuscular, string rutinaContenedora)
        {
            File.Delete(Path);

            if (nombreEjercicio == null)
                nombreEjercicio = "Ejercicio";
            Nombre = nombreEjercicio;

            Series = series;

            Repeticiones = repeticiones;

            _peso = peso;

            if (maquinaria == null)
                maquinaria = "Sin especificar";
            Maquinaria = maquinaria;

            if (grupoMuscular == null)
                grupoMuscular = "Sin especificar";
            GrupoMuscular = grupoMuscular;

            RutinaContenedora= rutinaContenedora;

            Ejercicios aux = new Ejercicios(Nombre, Series, Repeticiones, Peso, Maquinaria, GrupoMuscular, RutinaContenedora);

            Path = aux.Path;

        }

        private string _path;
        private string? _nombre;
        private int _series;
        private int _repeticiones;
        private Peso _peso;
        private string? _maquinaria;
        private string? _grupoMuscular;
        private string _rutinaContenedora;
    }

}
