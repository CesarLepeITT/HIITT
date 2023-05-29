using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GimApp.Clases
{
    class Rutinas
    {
        public Rutinas(string? nombre, bool activa, DayOfWeek dia)
        {
            if (nombre == "" || nombre == null || string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                nombre = "Rutina";
            Nombre = nombre;
            Activa = activa;
            Dia = dia;

            if (activa)
                CrearArchivoRutinaActiva();
            else
                CrearArchivoRutinaInactiva();
        }

        private void CrearArchivoRutinaActiva()
        {
            //Definir el path de rutinas activas
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{Nombre}.txt", UriKind.RelativeOrAbsolute);
            PathRutina = myUri.ToString();
            PathRutina = PathRutina.Substring(8);
            //Define el path de las rutinas inactivas
            Uri myUri2 = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}.txt", UriKind.RelativeOrAbsolute);
            string PathRutinasInactivas = myUri.ToString();
            PathRutinasInactivas = PathRutinasInactivas.Substring(8);
            
            int contador = 1;
            string enumerador = "";
            while (File.Exists(PathRutina)|| File.Exists(PathRutinasInactivas))//Revisa que no haya un texto con el mismo path
            {
                PathRutina = "";
                enumerador = "";
                //Si el txto existe le da un (numero) para que sea otro path distinto
                myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{Nombre}({contador}).txt", UriKind.RelativeOrAbsolute);
                PathRutina = myUri.ToString();
                PathRutina = PathRutina.Substring(8);
                contador++;
                enumerador = $"({contador - 1})";
            }
            if (enumerador != "")
                Nombre += enumerador;
            using (FileStream oFS = File.Create(PathRutina)) //Crea un archivo en el path que se le dio
            {
                Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8
                oFS.Write(texto, 0, texto.Length); //Escribe el objeto en el txt
            }
        }
        private void CrearArchivoRutinaInactiva()
        {
            //Definir el path
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}.txt", UriKind.RelativeOrAbsolute);
            PathRutina = myUri.ToString();
            PathRutina = PathRutina.Substring(8);
            //Define el path de las rutinas activas
            Uri myUri2 = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\{Nombre}.txt", UriKind.RelativeOrAbsolute);
            string PathRutinasActivas = myUri.ToString();
            PathRutinasActivas = PathRutinasActivas.Substring(8);

            int contador = 1;
            string enumerador = "";
            while (File.Exists(PathRutina))//Revisa que no haya un texto con el mismo path
            {
                PathRutina = "";
                enumerador = "";
                //Si el txto existe le da un (numero) para que sea otro path distinto
                myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\{Nombre}({contador}).txt", UriKind.RelativeOrAbsolute);
                PathRutina = myUri.ToString();
                PathRutina = PathRutina.Substring(8);
                contador++;
                enumerador = $"({contador - 1})";
            }
            if (enumerador != "")
                Nombre += enumerador;
            using (FileStream oFS = File.Create(PathRutina)) //Crea un archivo en el path que se le dio
            {
                Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8
                oFS.Write(texto, 0, texto.Length); //Escribe el objeto en el txt
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
        public string PathRutina
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
            get { return _listaEjercicios; }
        }

        public void AgregarEjercicioARutina(string nombreEjercicio)
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\{nombreEjercicio}.txt", UriKind.RelativeOrAbsolute);
            string pathTexto = myUri.ToString();
            pathTexto = pathTexto.Substring(8);
            _listaEjercicios.Append(pathTexto);
        }        
        public void AgregarEjercicioARutinaPath(string path)
        {
            _listaEjercicios.Append(path);
        }
        public void EliminarEjercicio(Ejercicios ejercicio)
        {
            for (int pos = 0; pos < _listaEjercicios.Length; pos++) 
            {
                if (_listaEjercicios[pos] == ejercicio.Nombre)
                {
                    for (int i = pos;i < _listaEjercicios.Length; i++)
                    {
                        _listaEjercicios[i] = _listaEjercicios[i + 1];
                    }
                    pos = _listaEjercicios.Length;
                }
            }
        }

        public override string ToString()
        {
            string ejercicios = "";
            try
            {
                if (_listaEjercicios != null)
                    for (int i=0; i<_listaEjercicios.Length; i++)
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
        private string[] _listaEjercicios;
        private DayOfWeek _dia;
        private bool _activa;
        private string _PathRutina;
    }
}

