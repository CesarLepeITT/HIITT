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
            InitializeComponent();
            _mainFrame = mainPage;

            StackPanel stk = new StackPanel();
            stk.Margin = new Thickness(10, 10, 10, 10);
            if (ManejadorTextos.EjerciciosPathList().Length > 0)
            {
                Secciones.GenerarSubTitulos("Ejercicios", stk);
                stk.Children.Add(GenerarEjercicios());
            }
            else
                Secciones.GenerarSubTitulos("No hay ejercicios aún, pero nunca es mal momento para agregar una. :)", stk);
            MainStackPanel.Children.Add(stk);

        }
        Frame _mainFrame;

        public Grid GenerarEjercicios()
        {
            Grid grd = new();
            grd.ColumnDefinitions.Add(new ColumnDefinition());
            grd.ColumnDefinitions.Add(new ColumnDefinition());
            grd.Margin = new Thickness(5, 0, 5, 0);

            string[] pathEjercicios = ManejadorTextos.EjerciciosPathList();
            for (int i = 0; i < pathEjercicios.Length; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(35);
                grd.RowDefinitions.Add(rd);

                TextBlock txb = Secciones.GenerarTextoNormal($"{ManejadorTextos.LeerNombreEjercicio(pathEjercicios[i])}");
                Grid.SetColumn(txb, 0);
                Grid.SetRow(txb, i);
                grd.Children.Add(txb);

                StackPanel stk = new();
                stk.Orientation = Orientation.Horizontal;

                ComboBox cb = new();
                cb.Width = 175;

              
                string[] pathRutinasActivas = ManejadorTextos.RutinasActivasPathList();
                for (int j = 0; j < pathRutinasActivas.Length;j++)
                {
                    string[] pathsEjerciciosEnRutina = ManejadorTextos.LeerPathsEjerciciosEnRutina(pathRutinasActivas[j]);
                    foreach (string path in pathsEjerciciosEnRutina)
                        if (path == pathEjercicios[i]) 
                        {
                            ComboBoxItem cbi = new();
                            cbi.Content= ManejadorTextos.LeerNombreRutina(pathRutinasActivas[j]);
                            cb.Items.Add(cbi);
                        }
                }
                string[] pathRutinasInactivas = ManejadorTextos.RutinasInactivasPathList();
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

                Button editar = new Button();
                editar.Content = "Editar" + $" {ManejadorTextos.LeerNombreRutina(pathEjercicios[i])}";
                editar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                editar.Click += new RoutedEventHandler(EditarEjercicicio_Click);
                editar.Width = 47;
                editar.Margin = new Thickness(10, 0, 0, 0);


                Button eliminar = new Button();
                eliminar.Content = "Eliminar" + $" {ManejadorTextos.LeerNombreRutina(pathEjercicios[i])}";
                eliminar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                eliminar.Click += new RoutedEventHandler(EliminarEjercicio_Click);
                eliminar.Width = 65;
                eliminar.Margin = new Thickness(10, 0, 0, 0);

                cb.SelectedIndex = 0;
                stk.Children.Add(cb);
                stk.Children.Add(editar);
                stk.Children.Add(eliminar);

                stk.HorizontalAlignment = HorizontalAlignment.Right;
                Grid.SetColumn(stk, 1);
                Grid.SetRow(stk, i);
                grd.Children.Add(stk);

            }
            return grd;
        }
        public void EditarEjercicicio_Click(object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            _mainFrame.Content = new EditarEjercicioPag(_mainFrame, objeto.ToString()[39..]);
        }

        public void EliminarEjercicio_Click(object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            string pathEjercicio = ManejadorTextos.LeerPathEjercicio(objeto.ToString()[41..]);

            foreach (string pathRutina in ManejadorTextos.RutinasActivasPathList())
            {
                if (ManejadorTextos.LeerExisteEjercicioEnRutina(pathRutina, pathEjercicio))
                    ManejadorTextos.BorrarEjercicioEnRutina(pathRutina, pathEjercicio);
            }
            foreach (string pathRutina in ManejadorTextos.RutinasInactivasPathList())
            {
                if (ManejadorTextos.LeerExisteEjercicioEnRutina(pathRutina, pathEjercicio))
                    ManejadorTextos.BorrarEjercicioEnRutina(pathRutina, pathEjercicio);
            }

            ManejadorTextos.BorrarArchivo(pathEjercicio);
            _mainFrame.Content = new EjerciciosPag(_mainFrame);
        }
        public void AgregarEjercicios_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new AgregarEjerciciosPag(_mainFrame);
        }
    }
}
