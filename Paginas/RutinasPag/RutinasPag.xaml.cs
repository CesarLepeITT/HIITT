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

namespace GimApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para RutinasPag.xaml
    /// </summary>
    public partial class RutinasPag : Page
    {
        Frame _mainPage;
        public RutinasPag(Frame mainPage)
        {
            _mainPage = mainPage;
            InitializeComponent();

            string[] rutinasPathList = ManejadorTextos.RutinasPathList();
            if (rutinasPathList.Length>0)
            {
                foreach (string f in ManejadorTextos.RutinasPathList())
                {
                    TextBlock nombre = new TextBlock();
                    nombre.Text = ManejadorTextos.LeerNombreRutina(f);
                    stckpMainStackPanel.Children.Add(nombre);

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

        public void AgregarRutinas_click(object sender, RoutedEventArgs e)
        {
            _mainPage.Content = new AgregarRutinaPag();
        }
    }
}
