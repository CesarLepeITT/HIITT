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
            
            if (_rutinasPathListInactivas.Length > 0 || _rutinasPathListActivas.Length > 0)
            {
                //Esto es un textblock
                TextBlock txt1 = new();
                txt1.Text = "Rutinas Activas";
                txt1.VerticalAlignment = VerticalAlignment.Top;
                txt1.HorizontalAlignment = HorizontalAlignment.Center;
                txt1.Margin = new Thickness(0, 10, 0, 10);
                //Asi se agrega n estilo desde c# (code begind)
                //txt1.Style = (Style)Application.Current.Resources["ModernTextBlockStyle"];

                stckpMainStackPanel.Children.Add(txt1);
                GenerarRutinasActivas();

                TextBlock txt2 = new();
                txt2.Text = "Rutinas Inactivas";
                txt2.VerticalAlignment = VerticalAlignment.Top;
                txt2.HorizontalAlignment = HorizontalAlignment.Center;
                txt2.Margin = new Thickness(0, 10, 0, 10);
                stckpMainStackPanel.Children.Add(txt2);
                GenerarRutinasInactivas();

            }
            else
            {
                TextBlock noRutinas = new TextBlock();
                noRutinas.Text = "No hay rutinas aún, pero nunca es mal momento para agregar una. :)";

                Button agregarRutinas = new Button();
                agregarRutinas.Height = 30;
                agregarRutinas.Width = 200;
                agregarRutinas.VerticalAlignment = VerticalAlignment.Bottom;
                agregarRutinas.Content = "Agregar rutina";
                agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

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
                    nombre.VerticalAlignment = VerticalAlignment.Top;
                    nombre.HorizontalAlignment = HorizontalAlignment.Left;
                    nombre.Margin = new Thickness(10, 10, 0, 0);

                    Button editar = new Button();
                    editar.Width = 30;
                    editar.Height = 30;
                    editar.VerticalAlignment = VerticalAlignment.Top;
                    editar.HorizontalAlignment = HorizontalAlignment.Right;
                    editar.Margin = new Thickness(0, 10, 10, 0);
                    editar.Click += new RoutedEventHandler(EditarRutina_Click);

                    Grid grd = new();
                    grd.Height = 100;
                    grd.MaxHeight = 30;

                    grd.Children.Add(nombre);
                    grd.Children.Add(editar);

                    stckpMainStackPanel.Children.Add(grd);

                    Button agregarRutinas = new Button();
                    agregarRutinas.Height = 30;
                    agregarRutinas.Width = 200;
                    agregarRutinas.VerticalAlignment = VerticalAlignment.Bottom;
                    agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                    rpMainGrid.Children.Add(agregarRutinas);
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "Aun no hay rutinas activas.";
                txb.Margin = new Thickness(10, 0, 0, 0);
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
                    nombre.VerticalAlignment = VerticalAlignment.Top;
                    nombre.HorizontalAlignment = HorizontalAlignment.Left;
                    nombre.Margin = new Thickness(10, 10, 0, 0);

                    Button editar = new Button();
                    editar.Width = 30;
                    editar.Height = 30;
                    editar.VerticalAlignment = VerticalAlignment.Top;
                    editar.HorizontalAlignment = HorizontalAlignment.Right;
                    editar.Margin = new Thickness(0, 10, 10, 0);
                    editar.Click += new RoutedEventHandler(EditarRutina_Click);

                    Grid grd = new();
                    grd.Height = 30;
                    grd.MaxHeight = 100;

                    grd.Children.Add(nombre);
                    grd.Children.Add(editar);

                    stckpMainStackPanel.Children.Add(grd);

                    Button agregarRutinas = new Button();
                    agregarRutinas.Height = 30;
                    agregarRutinas.Width = 200;
                    agregarRutinas.VerticalAlignment = VerticalAlignment.Bottom;
                    agregarRutinas.Click += new RoutedEventHandler(AgregarRutinas_click);

                    rpMainGrid.Children.Add(agregarRutinas);
                }
            }
            else
            {
                TextBlock txb = new TextBlock();
                txb.Text = "No hay rutinas inactivas.";
                txb.Margin = new Thickness(10, 0, 0, 0);
                stckpMainStackPanel.Children.Add(txb);
            }
        }

        public void EditarRutina_Click(object sender, RoutedEventArgs e)
        {
            _mainPage.Content = new EditarRutinaPag(_mainPage);
        }

        public void AgregarRutinas_click(object sender, RoutedEventArgs e)
        {
            _mainPage.Content = new AgregarRutinaPag(_mainPage);
        }
    }
}
