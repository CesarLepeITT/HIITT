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
            StackPanel stk = new();
            stk.Margin = new Thickness(10,20,10,0);
            stk.Children.Add(Secciones.GenerarSubTitulos(dia));
            MainStackPanel.Children.Add(stk);
            string[] rutinasActivasPath = ManejadorTextos.RutinasActivasPathList();
            if (rutinasActivasPath.Length > 0)
                GenerarRutinas(rutinasActivasPath, dia);
            else
                GenerarNoRutinas();
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
            TextBlock txb = new();
            txb.Text = nombre;
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];
            Grid grd = new();
            grd.Margin = new Thickness(15,0,10,0);
            grd.Children.Add(txb);
            MainStackPanel.Children.Add(grd);
        }

        // Cuando no hay rutinas
        public void GenerarNoRutinas()
        {
            Grid grd = new();
            grd.Margin=new Thickness(10,20,10,0);
            grd.RowDefinitions.Add(new RowDefinition());
            grd.RowDefinitions.Add(new RowDefinition());

            TextBlock txb = new();
            txb.Text = "No tienes rutinas activas, pero nunca es mal momento para agregar una o activar las disponibles.:)";
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];
            Grid.SetRow(txb,0);

            Button btn = new()
            {
                Height = 35,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = "Agregar rutina",
                Margin = new Thickness(0,10,0,0),
            };
            btn.Style = (Style)Application.Current.Resources["EstiloBotonesRutinas"];
            btn.Click += AgregarRutina;
            Grid.SetRow(btn, 1);

            grd.Children.Add(txb);
            grd.Children.Add(btn);

            MainStackPanel.Children.Add(grd);
        }

        public void GenerarHorarioDiario()
        {
            StackPanel stk = new();
            stk.Margin = new Thickness(10, 20, 10, 0);

            Secciones.GenerarSubTitulos("Horario Diario",stk);
            string[] rutinasActivas = ManejadorTextos.RutinasActivasPathList();
            string[] diasDeLaSemana = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            string[] diasDeLaSemanaIngles = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 7; i++) {
                Grid grd = new();
                grd.Margin = new Thickness(15,0,0,0);
                grd.Children.Add(Secciones.GenerarSubTitulos2(diasDeLaSemana[i]));
                stk.Children.Add(grd);
                bool bandera = false;
                foreach (string rutinaPath in rutinasActivas)
                    if (ManejadorTextos.LeerDiaRutina(rutinaPath) == diasDeLaSemanaIngles[i])
                    {
                        StackPanel stk2 = new();
                        stk2.Margin = new Thickness(25,0,0,0);
                        Secciones.GenerarTextoNormal(ManejadorTextos.LeerNombreRutina(rutinaPath), stk2);
                        stk.Children.Add(stk2);
                        bandera = true;
                    }
                if (!bandera)
                {

                    StackPanel stk2 = new();
                    stk2.Margin = new Thickness(25, 0, 0, 0);
                    Secciones.GenerarTextoNormal($"No hay rutinas asignadas al dia {diasDeLaSemana[i].ToLower()}", stk2);
                    stk.Children.Add(stk2);
                }
            }
            MainStackPanel.Children.Add(stk);
        }
        private void AgregarRutina(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new AgregarRutinaPag(_mainFrame);
        }
    }
}
