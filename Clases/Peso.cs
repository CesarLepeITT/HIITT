using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimApp.Clases
{
    abstract class Peso
    {
        public decimal Cantidad { set { _cantidad = value; } get { return _cantidad; } }
        public string Unidad { set { _unidad = value; } get { return _unidad; } }
        abstract public Peso ConvertirUnidad(decimal cantidad);

        protected decimal _cantidad;
        protected string _unidad;
    }

    class PesoKG : Peso
    {
        public PesoKG(decimal cantidad)
        {
            Cantidad = cantidad;
            Unidad = "kg";
        }

        private decimal ConvertirAlbs(decimal cantidad) => cantidad / (decimal)0.45;

        public override Pesolbs ConvertirUnidad(decimal cantidad) => new Pesolbs(ConvertirAlbs(Cantidad));

    }

    class Pesolbs : Peso
    {
        public Pesolbs(decimal cantidad)
        {
            Cantidad = cantidad;
            Unidad = "lbs";
        }

        private decimal ConvertirAkg(decimal cantidad) => cantidad * (decimal)0.45;

        public override Pesolbs ConvertirUnidad(decimal cantidad) => new Pesolbs(ConvertirAkg(Cantidad));

    }

}
