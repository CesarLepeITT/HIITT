using GimApp;
using HIITT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HIITT.Paginas
{
    /// <summary>
    /// Lógica de interacción para EjerciciosPag.xaml
    /// </summary>
    public partial class EjerciciosPag : Page
    {
        public EjerciciosPag(Frame mainPage)
        {
            _mainFrame = mainPage;
            InitializeComponent();

            StackPanel stk = new StackPanel();
            stk.Margin = new Thickness(10, 10, 10, 10);
            if (ManejadorTextos.EjerciciosPathList().Length > 0)
            {
                Secciones.GenerarSubTitulos("Ejercicios activos", stk);
                stk.Children.Add(GenerarEjercicios());
            }
            else
                Secciones.GenerarSubTitulos("No hay ejercicios aún, pero nunca es mal momento para agregar una. :)", stk);
            MainStackPanel.Children.Add(stk);

        }
        Frame _mainFrame;

        public Grid GenerarEjercicios(string rutinasEstado)
        {
            Grid grd = new();
            grd.Margin = new Thickness(5, 0, 5, 0);

            ComboBox cb = new();

            string[] pathEjercicios = ManejadorTextos.EjerciciosPathList();
            for (int i = 0; i < pathEjercicios.Length; i++)
            {
                string ejercicioPath = pathEjercicios[i];
                string[] pathRutinasActivas = ManejadorTextos.RutinasActivasPathList();
                for (int j = 0; j < pathRutinasActivas.Length;j++)
                {
                    string[] pathsEjerciciosEnRutina = ManejadorTextos.LeerPathsEjerciciosEnRutina(pathRutinasActivas[j]);     
                    foreach(string path in pathsEjerciciosEnRutina) 
                        if(path == pathEjercicios[i]) 
                        {
                            ComboBoxItem cbi = new();
                            cbi.Content= ManejadorTextos.LeerNombreRutina(pathRutinasActivas[j]);
                            cb.Items.Add(cbi);
                        }
                }
                string[] pathRutinasInactivas = ManejadorTextos.RutinasActivasPathList();
                for (int j = 0; j < pathRutinasInactivas.Length; j++)
                {
                    string[] pathsEjerciciosEnRutina = ManejadorTextos.LeerPathsEjerciciosEnRutina(pathRutinasInactivas[j]);
                    foreach (string path in pathsEjerciciosEnRutina)
                        if (path == pathEjercicios[i])
                        {
                            ComboBoxItem cbi = new();
                            cbi.Content = ManejadorTextos.LeerNombreRutina(pathRutinasInactivas[j]) + "*";
                            cb.Items.Add(cbi);
                        }
                }
            }
        }
    }
}
