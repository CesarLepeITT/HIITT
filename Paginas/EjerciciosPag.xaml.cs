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
            _mainPage = mainPage;
            InitializeComponent();

            _rutinasPathListActivas = ManejadorTextos.RutinasActivasPathList();
            _rutinasPathListInactivas = ManejadorTextos.RutinasInactivasPathList();
            TextBlock txttitulo = new();
            txttitulo.Text = "Administrador De Ejercicios";
            txttitulo.Style = (Style)Application.Current.Resources["ModernTextBlockTitulos"];
            MainStackPanel.Children.Add(txttitulo);


            if (_rutinasPathListInactivas.Length > 0 || _rutinasPathListActivas.Length > 0)
            {

                TextBlock txt1 = new();
                txt1.Text = "Ejercicios Activos";
                txt1.Style = (Style)Application.Current.Resources["SubtitulosRutinas"];

                MainStackPanel.Children.Add(txt1);
                GenerarRutinasActivas();

                TextBlock txt2 = new();
                txt2.Text = "EjerciciosInactivos";
                txt2.Style = (Style)Application.Current.Resources["SubtitulosRutinas"];

                MainStackPanel.Children.Add(txt2);
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

                MainStackPanel.Children.Add(noRutinas);
                MainStackPanel.Children.Add(agregarRutinas);
            }
            Button agregarRutina= new Button();
            agregarRutina.Content = "Agregar ejercicio";
            agregarRutina.Click += AgregarRutina_Click;
            MainStackPanel.Children.Add(agregarRutina);
        }
        Frame _mainPage;
        string[] _rutinasPathListActivas;
        string[] _rutinasPathListInactivas;

        private void AgregarRutina_Click(object sender, RoutedEventArgs e) => _mainPage.Content = new AgregarEjerciciosPag(_mainPage);

        public void GenerarRutinasActivas()
        {
            if (_rutinasPathListActivas.Length > 0)
            {
                //hacer esto un metodo y hacerlo que lea rutinas activas e inactivas
                foreach (string rutinaPath in ManejadorTextos.RutinasActivasPathList())
                {
                    if (ManejadorTextos.LeerPathEjercicios(rutinaPath).Length > 0)
                    {
                        foreach (string ejercicioPath in ManejadorTextos.LeerPathEjercicios(rutinaPath))
                        {
                            Grid grd = new();
                            grd.Height = 100;
                            
                            Secciones.GenerarTextoNormal(ManejadorTextos.LeerNombreEjercicio(ejercicioPath) + " en " + ManejadorTextos.LeerNombreRutina(rutinaPath), grd);

                            Button eliminar = new Button();
                            eliminar.Content = "Eliminar";
                            eliminar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                            eliminar.Click += new RoutedEventHandler(EditarRutina_Click);
                            grd.Children.Add(eliminar);

                            Button editar = new Button();
                            editar.Content = "Editar" + $" {ManejadorTextos.LeerNombreEjercicio(ejercicioPath)}";
                            editar.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                            editar.Click += new RoutedEventHandler(EditarRutina_Click);
                            grd.Children.Add(editar);

                            MainStackPanel.Children.Add(grd);

                            Button agregarRutinas = new Button();
                            agregarRutinas.Content = "Agregar rutina";
                            agregarRutinas.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                            agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                            //rpMainGrid.Children.Add(agregarRutinas);
                        }
                    }
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "Aun no hay rutinas activas.";
                txb.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];
                MainStackPanel.Children.Add(txb);
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

                    MainStackPanel.Children.Add(grd);

                    Button agregarRutinas = new Button();
                    agregarRutinas.Content = "Agregar Rutina";
                    agregarRutinas.Foreground = new SolidColorBrush(Colors.White);

                    agregarRutinas.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
                    agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                    //rpMainGrid.Children.Add(agregarRutinas);
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "No hay rutinas inactivas.";
                txb.Style = (Style)Application.Current.Resources["RutinasTextBlockStyle"];
                MainStackPanel.Children.Add(txb);
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
