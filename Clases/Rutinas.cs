using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace GimApp.Clases
{
    class Rutinas
    {
        public Rutinas(string? nombre, bool activa, DayOfWeek dia)
        {
           if (nombre == "" || nombre == null || string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                Nombre = "Rutina";
            Activa = activa;
            Dia = dia;
            //CrearArchivoRutina(activa);
            //if (activa)
            //    CrearArchivoRutinaActiva();
            //else 
            //    CrearArchivoRutinaInactiva();

            CrearArchivoRutina(activa);

        }
        //No funciona como debe, cicla el programa
        private void CrearArchivoRutina(bool activa)
        {
            //Definir el path de rutinas activas
            string PathRutinaActiva = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{Nombre}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
            string pathRutinaInactivas = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
            int contador = 1;
            string aux = "";
            while (File.Exists(PathRutinaActiva) | File.Exists(pathRutinaInactivas))//Revisa que no haya un texto con el mismo path
            {
                aux = Nombre + $"({contador})";
                PathRutinaActiva = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{aux}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
                pathRutinaInactivas = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{aux}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
                contador++;
            }
            if (aux != "")
                Nombre = aux;

            ////Define el path de las rutinas inactivas
            //string pathRutinaInactivas = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
            //aux = "";
            //while (File.Exists(pathRutinaInactivas))//Revisa que no haya un texto con el mismo path
            //{
            //    aux = Nombre + $"({contador})";
            //    pathRutinaInactivas = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{aux}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
            //    contador++;
            //}
            //if (aux != "")
            //    Nombre = aux;

            if (activa)
            {
                _PathRutina = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{Nombre}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
                using (FileStream oFS = File.Create(_PathRutina)) //Crea un archivo en el path que se le dio
                {
                    Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8
                    oFS.Write(texto, 0, texto.Length); //Escribe el objeto en el txt
                }
            }
            if (!activa)
            {
                _PathRutina = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}.txt", UriKind.RelativeOrAbsolute).ToString().Substring(8);
                using (FileStream oFS = File.Create(_PathRutina)) //Crea un archivo en el path que se le dio
                {
                    Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8
                    oFS.Write(texto, 0, texto.Length); //Escribe el objeto en el txt
                }
            }
        }
        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }
        public bool Activa
        {
            set { _activa = value; }
            get { return _activa; }
        }       
        public string pathRutinaActiva
        {
            set { _PathRutina = value; }
            get { return _PathRutina; }
        }

        public DayOfWeek Dia
        {
            set { _dia = value; }
            get { return _dia; }
        }
        public string[] ListaEjercicios 
        {
            get { return _listaEjerciciosPath; }
        }

        public void AgregarEjercicioARutina(string nombreEjercicio)
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\{nombreEjercicio}.txt", UriKind.RelativeOrAbsolute);
            string pathTexto = myUri.ToString();
            pathTexto = pathTexto.Substring(8);
            _listaEjerciciosPath.Append(pathTexto);
        }        
        public void AgregarEjercicioARutinaPath(string path)
        {
            _listaEjerciciosPath.Append(path);
        }
        public void EliminarEjercicio(Ejercicios ejercicio)
        {
            for (int pos = 0; pos < _listaEjerciciosPath.Length; pos++) 
            {
                if (_listaEjerciciosPath[pos] == ejercicio.Nombre)
                {
                    for (int i = pos;i < _listaEjerciciosPath.Length; i++)
                    {
                        _listaEjerciciosPath[i] = _listaEjerciciosPath[i + 1];
                    }
                    pos = _listaEjerciciosPath.Length;
                }
            }
        }

        public override string ToString()
        {
            string ejercicios = "";
            try
            {
                if (_listaEjerciciosPath != null)
                    for (int i=0; i<_listaEjerciciosPath.Length; i++)
                        ejercicios += $"{ListaEjercicios[i]}\n";
            }
            catch (Exception) { }
            return $"Nombre = {Nombre}\n" +
                $"Activa = {_activa.ToString()}\n" +
                $"Dia = {_dia.ToString()}\n" +
                $"{ejercicios}";
        }
        public void EditarRutina(string nombre, bool activa, DayOfWeek dia) {  }

        private string? _nombre;
        private string[] _listaEjerciciosPath;
        private DayOfWeek _dia;
        private bool _activa;
        private string _PathRutina;
    }
}

