using GimApp.Clases;
using GimApp.Paginas;
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
    /// Lógica de interacción para EditarRutinaPag.xaml
    /// </summary>
    public partial class EditarRutinaPag : Page
    {
        public EditarRutinaPag(Frame MainFrame, string nombreRutina)
        {
            InitializeComponent();
            _mainFrame = MainFrame;
            _nombre = nombreRutina;
            _pathRutina = ManejadorTextos.LeerPathRutina(_nombre);
            _dia = ManejadorTextos.LeerDiaRutinadayToOfWeek(_pathRutina);
            _activa = ManejadorTextos.LeerEsActivaRutinaToBool(_pathRutina);

            AsignarValoresDeRutina();
        }
        Frame _mainFrame;
        string _nombre;
        string[] _listaEjercicios;
        DayOfWeek _dia;
        bool _activa = false;
        string _pathRutina;

        public void AsignarValoresDeRutina()
        {
            tbNombre.Text = _nombre;
            if (_dia == DayOfWeek.Sunday)
                cbRADia.SelectedIndex = 0;
            if (_dia == DayOfWeek.Monday)
                cbRADia.SelectedIndex = 1;
            if (_dia == DayOfWeek.Tuesday)
                cbRADia.SelectedIndex = 2;
            if (_dia == DayOfWeek.Wednesday)
                cbRADia.SelectedIndex = 3;
            if (_dia == DayOfWeek.Thursday)
                cbRADia.SelectedIndex = 4;
            if (_dia == DayOfWeek.Friday)
                cbRADia.SelectedIndex = 5;
            if (_dia == DayOfWeek.Saturday)
                cbRADia.SelectedIndex = 6;

            if (_activa)
                checkActiva.IsChecked = true;
            else 
                checkActiva.IsChecked = false;

        }

        private void DesplegarPaginaError(string texto, TextBox sender)
        {
            MainStackPanel.IsEnabled = false;
            ErrorGridText.Text = texto;
            gridError.Visibility = Visibility.Visible;
            sender.Text = "";
        }
        private void DesplegarPaginaError(string texto, ComboBox sender)
        {
            MainStackPanel.IsEnabled = false;
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
                _ = new Rutinas(_nombre, _activa, _dia);
                _mainFrame.Content = new RutinasPag(_mainFrame);
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
            MainStackPanel.IsEnabled = true;

            tbNombre.Text = _nombre;

        }

        private void tbARNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            _nombre = tbNombre.Text;
        }
    }
}
