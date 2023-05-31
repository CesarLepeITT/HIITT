using GimApp.Clases;
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

namespace GimApp
{
    /// <summary>
    /// Lógica de interacción para ResumenPag.xaml
    /// </summary>
    public partial class ResumenPag : Page
    {
        public ResumenPag(Frame mainPage)
        {
            InitializeComponent();
            _mainFrame = mainPage;
            GenerarHoy();
            //GenerarManana()
        }
        Frame _mainFrame;

        //public void GenerarDia(string dia) { }


        public void GenerarHoy()
        {
            GenerarTitulos("Hoy");
            string[] rutinasActivasPath = ManejadorTextos.RutinasActivasPathList();
            if (rutinasActivasPath.Length > 0)
                GenerarRutinasHoy(rutinasActivasPath);
            else
                GenerarNoRutinasHoy();
        }
        //Textos genericos
        public void GenerarTitulos(string texto)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.HorizontalAlignment = HorizontalAlignment.Left;
            txb.Margin = new Thickness(10, 10, 0, 0);
            MainStackPanel.Children.Add(txb);
        }
        //Rutinas de hoy
        public void GenerarRutinasHoy(string[] rutinasActivasPath)
        {
            foreach (string f in rutinasActivasPath)
                if (ManejadorTextos.LeerDiaRutina(f) == DateTime.Now.DayOfWeek.ToString())
                    GenerarTextosRutinas(f);
                else
                {
                    TextBlock txb = new();
                    txb.Text = ManejadorTextos.LeerDiaRutina(f);
                    MainStackPanel.Children.Add(txb);  
                    TextBlock txb2 = new();
                    txb2.Text = DateTime.Now.DayOfWeek.ToString();
                    MainStackPanel.Children.Add(txb2);

                }
                    
        }       
        
        public void GenerarTextosRutinas(string path)
        {
            string nombre = ManejadorTextos.LeerNombreRutina(path);
            TextBlock txb = new()
            {
                Text = nombre,
                Margin = new Thickness(10, 10, 10, 10),
            };
            Grid grd = new();
            grd.Children.Add(txb);
            MainStackPanel.Children.Add(grd);
        }

        // Cuando no hay rutinas
        public void GenerarNoRutinasHoy()
        {
            TextBlock txb = new()
            {
                Text = "No tienes rutinas activas, pero nunca es mal momento para agregar una o activar las disponibles.:)",
                Margin = new Thickness(10, 10, 10, 10),
            };
            Button btn = new()
            {
                Height = 10,
                Width = 10,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 10, 10, 0),
            };
            btn.Click += AgregarRutina;
            Grid grd = new();
            grd.Children.Add(txb);
            grd.Children.Add(btn);

            MainStackPanel.Children.Add(grd);
        }

        private void AgregarRutina(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new AgregarRutinaPag(_mainFrame);
        }
    }
}
