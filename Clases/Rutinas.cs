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
        public Ejercicios[] ListaEjercicios 
        {
            get { return _listaEjercicios; }
        }

        public void AgregarEjercicio(Ejercicios ejercicio)
        {
            _listaEjercicios.Append(ejercicio);
        }
        public void EliminarEjercicio(Ejercicios ejercicio)
        {

            for (int pos = 0; pos < _listaEjercicios.Length; pos++) 
            {
                if (_listaEjercicios[pos].PathTxt == ejercicio.PathTxt)
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
        private Ejercicios[] _listaEjercicios = new Ejercicios[1];
        private DayOfWeek _dia;
    }
}
