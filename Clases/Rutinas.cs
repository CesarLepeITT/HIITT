using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimApp.Clases
{
    class Rutinas
    {
        public Rutinas(string nombre) 
        {       
            Nombre = nombre;
        }        
        public Rutinas(string nombre, DayOfWeek dia) 
        {
            Nombre = nombre;
            Dia= dia;
        }

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
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

        public void AgregarEjercicio(string nombreEjercicio)
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\Clases\saves\{nombreEjercicio}.txt", UriKind.RelativeOrAbsolute);
            string pathTexto = myUri.ToString();
            pathTexto = pathTexto.Substring(8);
            _listaEjercicios.Append(pathTexto);
        }        
        public void AgregarEjercicioPath(string path)
        {
            _listaEjercicios.Append(path);
        }
        public void EliminarEjercicio(string path)
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

        private string? _nombre;
        private string[] _listaEjercicios;
        private DayOfWeek _dia;
    }
}
