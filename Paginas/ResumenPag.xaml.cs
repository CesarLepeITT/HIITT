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
            GenerarDia("Hoy");
            GenerarDia("Manaña");
            GenerarHorarioDiario();
        }
        Frame _mainFrame;

        public void GenerarDia(string dia)
        {
            Secciones.GenerarSubTitulos(dia, MainStackPanel);
            string[] rutinasActivasPath = ManejadorTextos.RutinasActivasPathList();
            if (rutinasActivasPath.Length > 0)
                GenerarRutinas(rutinasActivasPath, dia);
            else
                GenerarNoRutinasHoy();
        }

        public void GenerarRutinas(string[] rutinasActivasPath, string dia)
        {
            if (dia == "Hoy")
                foreach (string f in rutinasActivasPath)
                    if (ManejadorTextos.LeerDiaRutina(f) == DateTime.Now.DayOfWeek.ToString())
                        GenerarTextosRutinas(f);
            if (dia == "Manaña")
                foreach (string f in rutinasActivasPath)
                    if (ManejadorTextos.LeerDiaRutina(f) == DateTime.Now.AddDays(1).DayOfWeek.ToString())
                        GenerarTextosRutinas(f);
        }       
        
        public void GenerarTextosRutinas(string path)
        {
            string nombre = ManejadorTextos.LeerNombreRutina(path);

            TextBlock txb = new()
            {
                Text = nombre,
                FontSize= 22,
                Margin = new Thickness(40, 10, 120, 0),
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
                Margin = new Thickness(40, 10, 120, 0),
            };
            Button btn = new()
            {
                Height= 50,
                Width= 150,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(40, 10, 120, 0),
            };
            btn.Click += AgregarRutina;
            Grid grd = new();
            grd.Children.Add(txb);
            grd.Children.Add(btn);

            MainStackPanel.Children.Add(grd);
        }
        public void GenerarHorarioDiario()
        {
            Secciones.GenerarTitulos("Horario Diario",MainStackPanel);
            string[] rutinasActivas = ManejadorTextos.RutinasActivasPathList();
            string[] diasDeLaSemana = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            string[] diasDeLaSemanaIngles = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 7; i++) {
                Secciones.GenerarSubTitulos(diasDeLaSemana[i],MainStackPanel);
                bool bandera = false;
                foreach (string rutinaPath in rutinasActivas)
                    if (ManejadorTextos.LeerDiaRutina(rutinaPath) == diasDeLaSemanaIngles[i])
                    {
                        Secciones.GenerarTextoNormal(ManejadorTextos.LeerNombreRutina(rutinaPath), MainStackPanel);
                        bandera = true;
                    }
                if (!bandera)
                    Secciones.GenerarTextoNormal($"No hay rutinas asignadas al dia {diasDeLaSemana[i].ToLower()}", MainStackPanel);
            }
        }
        private void AgregarRutina(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new AgregarRutinaPag(_mainFrame);
        }
    }
}
