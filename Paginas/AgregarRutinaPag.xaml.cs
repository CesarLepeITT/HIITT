using GimApp.Clases;
using GimApp.Paginas;
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
    /// Lógica de interacción para AgregarRutinaPag.xaml
    /// </summary>
    public partial class AgregarRutinaPag : Page
    {
        public AgregarRutinaPag(Frame MainFrame)
        {
            InitializeComponent();
            _MainFrame = MainFrame;
        }

        string _nombre;
        string[] _listaEjercicios;
        DayOfWeek _dia;
        bool _activa = false;
        string _PathRutina;
        Frame _MainFrame;

        private void DesplegarPaginaError(string texto, TextBox sender)
        {
            sckpARMain.IsEnabled = false;
            ErrorGridText.Text = texto;
            gridError.Visibility = Visibility.Visible;
            sender.Text = "";
        }
        private void DesplegarPaginaError(string texto, ComboBox sender)
        {
            sckpARMain.IsEnabled = false;
            ErrorGridText.Text = texto;
            gridError.Visibility = Visibility.Visible;
            sender.SelectedIndex = -1;
        }

        private bool TodoBien()
        {
            if (cbRADia.SelectedIndex != -1)
                    return true;
            return false;   
        }

        private void btnAgregarRutina_Click(object sender, RoutedEventArgs e)
        {
            if (TodoBien())
            {
                new Rutinas(_nombre, _activa, _dia);
                _MainFrame.Content = new RutinasPag(_MainFrame);
            }
            else
                DesplegarPaginaError("Debes de seleccionar un dia de la semana.", cbRADia);

        }

        private void checkActiva_Checked(object sender, RoutedEventArgs e)
        {
            _activa = true;
        }

        private void checkActiva_Unchecked(object sender, RoutedEventArgs e)
        {
            _activa = false;
        }

        private void cbRADia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRADia.SelectedIndex == 0)
                _dia = DayOfWeek.Sunday;  
            if (cbRADia.SelectedIndex == 1)
                _dia = DayOfWeek.Monday;
            if (cbRADia.SelectedIndex == 2)
                _dia = DayOfWeek.Tuesday;
            if (cbRADia.SelectedIndex == 3)
                _dia = DayOfWeek.Wednesday;
            if (cbRADia.SelectedIndex == 4)
                _dia = DayOfWeek.Thursday;
            if (cbRADia.SelectedIndex == 5)
                _dia = DayOfWeek.Friday;
            if (cbRADia.SelectedIndex == 6)
                _dia = DayOfWeek.Saturday;
        }

        private void ErrorGridAceptar_Click(object sender, RoutedEventArgs e)
        {
            gridError.Visibility = Visibility.Hidden;
            ErrorGridText.Text = string.Empty;
            sckpARMain.IsEnabled = true;

            tbARNombre.Text = _nombre;

        }

        private void tbARNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            _nombre = tbARNombre.Text;
        }
    }
}

















