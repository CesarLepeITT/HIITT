using GimApp.Clases;
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
using System.IO;

namespace HIITT.Paginas
{
    /// <summary>
    /// Lógica de interacción para EditarEjercicioPag.xaml
    /// </summary>
    public partial class EditarEjercicioPag : Page
    {
        public EditarEjercicioPag(Frame MainFrame, string nombreEjercicio)
        {
            InitializeComponent();
            _MainFrame = MainFrame;


            string[] rutinasPathList = ManejadorTextos.RutinasActivasPathList();
            if (rutinasPathList.Length > 0)
            {
                foreach (string f in ManejadorTextos.RutinasActivasPathList())
                {
                    ComboBoxItem nombreRutina = new();
                    nombreRutina.Content = ManejadorTextos.LeerNombreRutina(f);
                    cbAERutinaContenedora.Items.Add(nombreRutina);
                }
            }
            rutinasPathList = ManejadorTextos.RutinasInactivasPathList();
            if (rutinasPathList.Length > 0)
            {
                foreach (string f in ManejadorTextos.RutinasInactivasPathList())
                {
                    ComboBoxItem nombreRutina = new();
                    nombreRutina.Content = ManejadorTextos.LeerNombreRutina(f);
                    cbAERutinaContenedora.Items.Add(nombreRutina);
                }
            }

            _nombreEjercicio = nombreEjercicio;
            _pathEjercicio = ManejadorTextos.LeerPathEjercicio(_nombreEjercicio);
            _series = int.Parse(ManejadorTextos.LeerSeriesEjercicio(_pathEjercicio));
            _repeticiones = int.Parse(ManejadorTextos.LeerRepeticionesEjercicio(_pathEjercicio));
            _cantidadPeso = decimal.Parse(ManejadorTextos.LeerCantidadPesoEjercicio(_pathEjercicio));
            if (ManejadorTextos.LeerUnidadPesoEjercicio(_pathEjercicio) == "kg")
                _peso = new PesoKG(_cantidadPeso);
            if (ManejadorTextos.LeerUnidadPesoEjercicio(_pathEjercicio) == "lbs")
                _peso = new Pesolbs(_cantidadPeso);
            _maquinaria = ManejadorTextos.LeerMaquinariaEjercicio(_pathEjercicio);
            _grupoMuscular = ManejadorTextos.LeerGrupoMuscularEjercicio(_pathEjercicio);
            //_rutinaAlmacenadora = ManejadorTextos.almac
            DesplegarVariables();
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
        string _pathEjercicio;

        
        private void DesplegarVariables()
        {
            tbAENombre.Text = _nombreEjercicio;
            tbAESeries.Text = _series.ToString();
            tbAERepeticiones.Text = _repeticiones.ToString();
            tbAEPesoCantidad.Text = _cantidadPeso.ToString();
            if (_peso.Unidad == "kg")
                cbAEUnidades.SelectedIndex = 0;
            if (_peso.Unidad == "lbs")
                cbAEUnidades.SelectedIndex = 1;
            tbAEMaquinaria.Text = _maquinaria;
        }

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
            if (tbAENombre.Text != "")
                _nombreEjercicio = tbAENombre.Text;
            else
                DesplegarPaginaError("No has ingresado un valor para el nombre del ejercicio.", tbAENombre);

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
        }
        private bool RevisarSiTodoCorrecto()
        {
            if (_nombreEjercicio != "")
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
                // Editar el texto del ejercicio
                using (StreamWriter editor = new StreamWriter(_pathEjercicio))
                {
                    File.WriteAllText(_pathEjercicio, string.Empty);
                    File.WriteAllText(_pathEjercicio,
                        $"Nombre = {_nombreEjercicio}\n" +
                        $"Series = {_series.ToString()}\n" +
                        $"Repeticiones = {_repeticiones.ToString()}\n" +
                        $"PesoCantidad = {_peso.Cantidad.ToString()}\n" +
                        $"PesoUnidad = {_peso.Unidad}\n" +
                        $"Maquiaria = {_maquinaria}\n" +
                        $"GrupoMuscular = {_grupoMuscular}\n" +
                        $"Path = {_pathEjercicio}");
                }
                // Revisar si la rutina seleccionada ya tiene el path, si no lo tiene definir
                DefinirRutinaAlmacenadora();
                if (!ManejadorTextos.LeerExisteEjercicioEnRutina(_rutinaAlmacenadora, _pathEjercicio))
                    ManejadorTextos.AgregarPathEjercicioARutina(_nombreEjercicio, _rutinaAlmacenadora);
                _MainFrame.Content = new RutinasPag(_MainFrame);
            }
        }
        private void DefinirRutinaAlmacenadora()
        {
            object obj = cbAERutinaContenedora.SelectedItem;
            _rutinaAlmacenadora = obj.ToString();
            _rutinaAlmacenadora = _rutinaAlmacenadora[38..];
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
            if (_series > 0) tbAESeries.Text = _series.ToString();
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
