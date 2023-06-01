using GimApp;
using HIITT.Clases;
using HIITT.Paginas;
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
    /// Lógica de interacción para RutinasPag.xaml
    /// </summary>
    public partial class RutinasPag : Page
    {
        public RutinasPag(Frame mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
            //Secciones.GenerarTitulos("Administrador De Rutinas", MainStackPanel);
            StackPanel stk = new StackPanel();
            stk.Margin = new Thickness(10, 10, 10, 10);
            if (ManejadorTextos.RutinasActivasPathList().Length > 0 | ManejadorTextos.RutinasInactivasPathList().Length > 0)
            {
                Secciones.GenerarSubTitulos("Rutinas activas", stk);
                stk.Children.Add(GenerarRutinas("Activas"));
                Secciones.GenerarSubTitulos("Rutinas inactivas", stk);
                stk.Children.Add(GenerarRutinas("Inactivas"));
            }
            else
                Secciones.GenerarSubTitulos("No hay rutinas aún, pero nunca es mal momento para agregar una. :)", stk);
            MainStackPanel.Children.Add(stk);
        }
        Frame _mainPage;

        public Grid GenerarRutinas(string rutinasEstado)
        {
            Grid grd = new();
            // grd.Height = 130;
            grd.Margin = new Thickness(5, 0, 5, 0);

            string[] pathRutinas = new string[0];
            if (rutinasEstado == "Activas")
                pathRutinas = ManejadorTextos.RutinasActivasPathList();
            if (rutinasEstado == "Inactivas")
                pathRutinas = ManejadorTextos.RutinasInactivasPathList();

            if (pathRutinas.Length > 0)
            {
                grd.ColumnDefinitions.Add(new ColumnDefinition());
                grd.ColumnDefinitions.Add(new ColumnDefinition());
                //hacer esto un metodo y hacerlo que lea rutinas activas e inactivas
                int row = 0;
                foreach (string pathRutina in pathRutinas)
                {
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(35);
                    grd.RowDefinitions.Add(rd);
                    TextBlock txb = Secciones.GenerarTextoNormal($"{ManejadorTextos.LeerNombreRutina(pathRutina)}");
                    Grid.SetColumn(txb, 0);
                    Grid.SetRow(txb, row);
                    grd.Children.Add(txb);

                    StackPanel stk = new();
                    stk.Orientation = Orientation.Horizontal;

                    //Editar estilo de los botones
                    //Editar width para que solos se vea editar/eliminar
                    Button editar = new Button();
                    editar.Content = "Editar" + $" {ManejadorTextos.LeerNombreRutina(pathRutina)}";
                    editar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    editar.Click += new RoutedEventHandler(EditarRutina_Click);
                    editar.Width = 47;
                    // editar.Margin= new Thickness(0, 0, 10, 0);

                    Button eliminar = new Button();
                    eliminar.Content = "Eliminar" + $" {ManejadorTextos.LeerNombreRutina(pathRutina)}";
                    eliminar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    eliminar.Click += new RoutedEventHandler(EliminarRutina_Click);
                    eliminar.Width = 65;
                    eliminar.Margin = new Thickness(10, 0, 0, 0);

                    stk.Children.Add(editar);
                    stk.Children.Add(eliminar);

                    stk.HorizontalAlignment = HorizontalAlignment.Right;
                    Grid.SetColumn(stk, 1);
                    Grid.SetRow(stk, row);
                    grd.Children.Add(stk);

                    row++;
                }
                grd.RowDefinitions.Add(new RowDefinition());
            }
            else
                Secciones.GenerarTextoNormal($"Aun no hay rutinas {rutinasEstado.ToLower()}.", grd);
            return grd;
        }

        public void EditarRutina_Click(object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            _mainPage.Content = new EditarRutinaPag(_mainPage, objeto.ToString()[39..]);
        }

        public void EliminarRutina_Click(object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            ManejadorTextos.BorrarArchivo(ManejadorTextos.LeerPathRutina(objeto.ToString()[41..]));
            _mainPage.Content = new RutinasPag(_mainPage);
        }
        public void AgregarRutinas_click(object sender, RoutedEventArgs e)
        {
            _mainPage.Content = new AgregarRutinaPag(_mainPage);
        }
    }
}
