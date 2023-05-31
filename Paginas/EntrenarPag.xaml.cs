using GimApp.Clases;
using HIITT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GimApp
{
    /// <summary>
    /// Lógica de interacción para Ejercicios.xaml
    /// </summary>
    public partial class EntrenarPag : Page
    {
        public EntrenarPag()
        {
            InitializeComponent();
        }

        public void GenerarEjercicios()
        {
            string[] rutinasActivas = ManejadorTextos.RutinasActivasPathList();
            string[] diasDeLaSemanaIngles = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            foreach (string rutinaPath in rutinasActivas)
            {
                if (ManejadorTextos.LeerDiaRutina(rutinaPath) == DateTime.Now.DayOfWeek.ToString())
                    GenerarValoresEjercios(ManejadorTextos.LeerPathEjercicios(rutinaPath));
            }
        }

        public void GenerarValoresEjercios(string[] pathsEjercicios)
        {
            foreach (string path in pathsEjercicios)
            {
                StackPanel stck = new();
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerNombreEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerSeriesEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerRepeticionesEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerCantidadPesoEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerUnidadPesoEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerMaquinariaEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerGrupoMuscularEjercicio(path),stck);

                stck.Margin = new Thickness(10,10,10,10);
            }
        }
    }
}
