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

namespace GimApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para RutinasPag.xaml
    /// </summary>
    public partial class RutinasPag : Page
    {
        public RutinasPag(Frame mainPage)
        {
            _mainPage = mainPage;
            InitializeComponent();
            
            _rutinasPathListActivas = ManejadorTextos.RutinasActivasPathList();
            _rutinasPathListInactivas = ManejadorTextos.RutinasInactivasPathList();
            TextBlock txttitulo = new();
            txttitulo.Text = "Administrador De Rutinas";
            txttitulo.Style = (Style)Application.Current.Resources["ModernTextBlockTitulos"];
            stckpMainStackPanel.Children.Add(txttitulo);

            if (_rutinasPathListInactivas.Length > 0 || _rutinasPathListActivas.Length > 0)
            {
              
                //Esto es un textblock
                TextBlock txt1 = new();
                txt1.Text = "Rutinas Activas";
                txt1.Style = (Style)Application.Current.Resources["SubtitulosRutinas"];

                stckpMainStackPanel.Children.Add(txt1);
                GenerarRutinasActivas();

                TextBlock txt2 = new();
                txt2.Text = "Rutinas Inactivas";
                txt2.Style = (Style)Application.Current.Resources["SubtitulosRutinas"];

                stckpMainStackPanel.Children.Add(txt2);
                GenerarRutinasInactivas();

            }
            else
            {
                TextBlock noRutinas = new TextBlock();
                noRutinas.Text = "No hay rutinas aún, pero nunca es mal momento para agregar una. :)";
                noRutinas.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];

                Button agregarRutinas = new Button();
                agregarRutinas.Content = "Agregar rutina";
                agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);
                agregarRutinas.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
              
                stckpMainStackPanel.Children.Add(noRutinas);
                stckpMainStackPanel.Children.Add(agregarRutinas);
            } 

        }
        Frame _mainPage;
        string[] _rutinasPathListActivas;
        string[] _rutinasPathListInactivas;

        public void GenerarRutinasActivas()
        {
            if (_rutinasPathListActivas.Length > 0)
            {
                //hacer esto un metodo y hacerlo que lea rutinas activas e inactivas
                foreach (string f in ManejadorTextos.RutinasActivasPathList())
                {
                    TextBlock nombre = new TextBlock();
                    nombre.Text = ManejadorTextos.LeerNombreRutina(f);
                    nombre.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];

                    Button editar = new Button();
                    editar.Content = "Editar" + $" {nombre.Text}";
                    editar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    editar.Click += new RoutedEventHandler(EditarRutina_Click);

                    Grid grd = new();
                    grd.Height = 100;
                    grd.MaxHeight = 30;

                    grd.Children.Add(nombre);
                    grd.Children.Add(editar);

                    stckpMainStackPanel.Children.Add(grd);

                    Button agregarRutinas = new Button();
                    agregarRutinas.Content = "Agregar rutina";
                    agregarRutinas.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                    rpMainGrid.Children.Add(agregarRutinas);
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "Aun no hay rutinas activas.";
                txb.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];
                stckpMainStackPanel.Children.Add(txb);
            }
        }

        public void GenerarRutinasInactivas()
        {
            if (_rutinasPathListInactivas.Length > 0)
            {
                //hacer esto un metodo y hacerlo que lea rutinas activas e inactivas
                foreach (string f in ManejadorTextos.RutinasInactivasPathList())
                {
                    TextBlock nombre = new TextBlock();
                    nombre.Text = ManejadorTextos.LeerNombreRutina(f);
                    nombre.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];

                    Button editar = new Button();
                    editar.Content = "Editar" + $" {nombre.Text}";
                    editar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    editar.Click += new RoutedEventHandler(EditarRutina_Click);

                    Grid grd = new();
                    grd.Height = 30;
                    grd.MaxHeight = 100;

                    grd.Children.Add(nombre);
                    grd.Children.Add(editar);

                    stckpMainStackPanel.Children.Add(grd);

                    Button agregarRutinas = new Button();
                    agregarRutinas.Content = "Agregar Rutina";
                    agregarRutinas.Foreground = new SolidColorBrush(Colors.White);

                    agregarRutinas.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                    rpMainGrid.Children.Add(agregarRutinas);
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "No hay rutinas inactivas.";
                txb.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];
                stckpMainStackPanel.Children.Add(txb);
            }
        }

        public void EditarRutina_Click(object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            _mainPage.Content = new EditarRutinaPag(_mainPage, objeto.ToString()[39..]);
        }

        public void BorrarRutina_Click(Object sender, RoutedEventArgs e)
        {
            var objeto = e.Source;
            string nombreRutina = objeto.ToString()[39..];
            ManejadorTextos.BorrarArchivo(ManejadorTextos.LeerPathRutina(objeto.ToString()[39..]));
        }

        public void AgregarRutinas_click(object sender, RoutedEventArgs e)
        {
            _mainPage.Content = new AgregarRutinaPag(_mainPage);
        }
    }
}
