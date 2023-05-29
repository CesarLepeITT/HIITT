using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GimApp;
using GimApp.Clases;
using HIITT.Clases;

namespace HIITT.Paginas
{
    /// <summary>
    /// Lógica de interacción para AgregarEjerciciosPag.xaml
    /// </summary>
    public partial class AgregarEjerciciosPag : Page
    {
        public AgregarEjerciciosPag(Frame MainFrame)
        {
            InitializeComponent();
            _MainFrame = MainFrame;

            string[] rutinasPathList = ManejadorTextos.RutinasActivasPathList();
            if (rutinasPathList.Length > 0)
            {
                foreach (string f in ManejadorTextos.RutinasActivasPathList())
                {
                    ComboBoxItem nombreRutina = new ComboBoxItem();
                    nombreRutina.Content = ManejadorTextos.LeerNombreRutina(f);
                    cbAERutinaContenedora.Items.Add(nombreRutina);
                }
            }
            rutinasPathList = ManejadorTextos.RutinasInactivasPathList();
            if (rutinasPathList.Length > 0)
            {
                foreach (string f in ManejadorTextos.RutinasInactivasPathList())
                {
                    ComboBoxItem nombreRutina = new ComboBoxItem();
                    nombreRutina.Content = ManejadorTextos.LeerNombreRutina(f);
                    cbAERutinaContenedora.Items.Add(nombreRutina);
                }
            }
        }
        Frame _MainFrame;
        string _nombreEjercicio;
        int _series; 
        int _repeticiones;
        decimal _cantidadPeso;
        Peso _peso;
        string _maquinaria;
        string _grupoMuscular;
        string _rutinaAlmacenadora;

        private void DesplegarPaginaError(string texto, TextBox sender)
        {
            sckpMainStackPanel.IsEnabled = false;
            ErrorGridText.Text = texto;
            gridError.Visibility = Visibility.Visible;
            sender.Text = "";
        }
        private void DesplegarPaginaError(string texto, ComboBox sender)
        {
            sckpMainStackPanel.IsEnabled = false;
            ErrorGridText.Text = texto;
            gridError.Visibility = Visibility.Visible;
            sender.SelectedIndex = -1;
        }

        private void AsignarVariables()
        {
            _nombreEjercicio = tbAENombre.Text;
            try 
            { 
                _series = int.Parse(tbAESeries.Text);
                if (!(_series > 0))
                    throw new Exception();
            }
            catch (Exception) { DesplegarPaginaError("No has ingresado un valor para la cantidad de series.", tbAESeries); }

            try 
            { 
                _repeticiones = int.Parse(tbAERepeticiones.Text);
                if (!(_series > 0))
                    throw new Exception();
            }
            catch (Exception) { DesplegarPaginaError("No has ingresado un valor para la cantidad de repeticiones.", tbAERepeticiones); }

            try 
            { 
                _cantidadPeso = decimal.Parse(tbAEPesoCantidad.Text);
                if (!(_series > 0))
                    throw new Exception();
            }
            catch (Exception) { DesplegarPaginaError("No has ingresado un valor para la cantidad de peso.", tbAERepeticiones); }

            if (!(cbAEUnidades.SelectedIndex == -1))
            {
                //Seleccionas KG
                if (cbAEUnidades.SelectedIndex == 0)
                    _peso = new PesoKG(_cantidadPeso);
                //Seleccionas lbs
                if (cbAEUnidades.SelectedIndex == 1)
                    _peso = new Pesolbs(_cantidadPeso);
            }
            else DesplegarPaginaError("Debes seleccionar un tipo de unidad.", cbAEUnidades);
            _maquinaria = tbAEMaquinaria.Text;
            _grupoMuscular = tbAEGrupoMuscular.Text;

            if (cbAERutinaContenedora.SelectedIndex == -1) DesplegarPaginaError("Debes seleccionar una rutina.", cbAERutinaContenedora);
            else { }// TODO: Agregar una manera de meter el nuevo ejercicio creado a una rutina

        }

        private bool RevisarSiTodoCorrecto()
        {
            if (_series > 0)
                if (_repeticiones > 0)
                    if (_cantidadPeso > 0)
                        if (!(cbAEUnidades.SelectedIndex == -1))
                            if (!(cbAERutinaContenedora.SelectedIndex == -1))
                                return true;
            return false; 
        }

        private void btnAEAgregarEjercicio_Click(object sender, RoutedEventArgs e)
        {
            AsignarVariables();
            if (RevisarSiTodoCorrecto())
            {
                new Ejercicios(_nombreEjercicio, _series, _repeticiones, _peso, _maquinaria, _grupoMuscular, _rutinaAlmacenadora);
               // Nombre de la rutina contenedora
                string aux = cbAERutinaContenedora.SelectedValue.ToString().Substring(39);
            }
        }
        //TODO: Corregir funcionamiento de las funciones que revisan los inputs de codigo
        private void tbStr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Verificador.SoloLetras(tbAENombre.Text))
                tbAENombre.Text = "";
            if (!Verificador.SoloLetras(tbAEMaquinaria.Text))
                tbAEMaquinaria.Text = "";
            if (!Verificador.SoloLetras(tbAEGrupoMuscular.Text))
                tbAEGrupoMuscular.Text = "";
        }

        private void tbInt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Verificador.SoloNumeros(tbAERepeticiones.Text))
                tbAERepeticiones.Text = "";
            if (!Verificador.SoloNumeros(tbAESeries.Text))
                tbAESeries.Text = "";
        }

        private void tbDecimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Verificador.SoloNumerosDecimales(tbAEPesoCantidad.Text))
                tbAEPesoCantidad.Text = "";
        }

        private void ErrorGridAceptar_Click(object sender, RoutedEventArgs e)
        {
            gridError.Visibility = Visibility.Hidden;
            ErrorGridText.Text = string.Empty;
            sckpMainStackPanel.IsEnabled = true;

            tbAENombre.Text = _nombreEjercicio;
            if (_series>0) tbAESeries.Text = _series.ToString();
            if (_repeticiones > 0) tbAERepeticiones.Text = _repeticiones.ToString();
            if (_cantidadPeso > 0) tbAEPesoCantidad.Text = _cantidadPeso.ToString();
            tbAEMaquinaria.Text = _maquinaria;
            tbAEGrupoMuscular.Text = _grupoMuscular;

        }

        private void cbAERutinaContenedora_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAERutinaContenedora.SelectedIndex == 0)
                _MainFrame.Content = new AgregarRutinaPag(_MainFrame);
        }

        private void tbAEMaquinaria_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
