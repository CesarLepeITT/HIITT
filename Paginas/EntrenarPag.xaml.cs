using GimApp.Clases;
using HIITT.Clases;
using System;
using System.Collections.Generic;
using System.IO;
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
        public EntrenarPag(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame= mainFrame;
            _bandera = false;
            GenerarEjercicios();
        }
        Frame _mainFrame;
        bool _bandera;
        public void GenerarEjercicios()
        {
            foreach (string rutinaPath in ManejadorTextos.RutinasActivasPathList())
            {
                if (ManejadorTextos.LeerDiaRutina(rutinaPath) == DateTime.Now.DayOfWeek.ToString())
                    GenerarValoresEjercios(ManejadorTextos.LeerPathEjercicios(rutinaPath));
            }
        }

        public void GenerarValoresEjercios(string[] pathsEjercicios)
        {
            foreach (string path in pathsEjercicios)
            {
                _bandera = true;
                StackPanel stck = new();
                Secciones.GenerarTextoNormal("Nombre: "+ManejadorTextos.LeerNombreEjercicio(path),stck);
                Secciones.GenerarTextoNormal("Series: "+ManejadorTextos.LeerSeriesEjercicio(path),stck);
                Secciones.GenerarTextoNormal("Repeticones: " +ManejadorTextos.LeerRepeticionesEjercicio(path),stck);
                Secciones.GenerarTextoNormal("Peso: " + ManejadorTextos.LeerCantidadPesoEjercicio(path),stck);
                Secciones.GenerarTextoNormal(ManejadorTextos.LeerUnidadPesoEjercicio(path),stck);
                Secciones.GenerarTextoNormal("Maquinaria: " + ManejadorTextos.LeerMaquinariaEjercicio(path),stck);
                Secciones.GenerarTextoNormal("Grupo muscular: "+ ManejadorTextos.LeerGrupoMuscularEjercicio(path),stck);
                stck.Margin = new Thickness(10,10,10,10);
                MainStackPanel.Children.Add(stck);
                _bandera = true;
            }
            if (!(_bandera))
                Secciones.GenerarSubTitulos("No hay ejercicios asignados al dia de hoy;", MainStackPanel);
        }
    }
}
