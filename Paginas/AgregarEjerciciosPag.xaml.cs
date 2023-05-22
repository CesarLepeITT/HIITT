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
using GimApp.Clases;
using HIITT.Clases;

namespace HIITT.Paginas
{
    /// <summary>
    /// Lógica de interacción para AgregarEjerciciosPag.xaml
    /// </summary>
    public partial class AgregarEjerciciosPag : Page
    {
        public AgregarEjerciciosPag()
        {
            InitializeComponent();
        }
        string _nombreEjercicio;
        int _series; 
        int _repeticiones;
        decimal _cantidadPeso;
        Peso _peso;
        string _maquinaria;
        string _grupoMuscular;
        string _rutinaContenedora;

        private void AsignarVariables()
        {

            _nombreEjercicio = tbAENombre.Text;
            try { _series = int.Parse(tbAESeries.Text); }
            catch (ArgumentNullException)
            {
                gridMainGrid.IsEnabled = false;
                ErrorGridText.Text = "No has ingresado un valor para la cantidad de series.";
                gridError.Visibility= Visibility.Visible;
                tbAESeries.Text = "";
            }
            try { _repeticiones = int.Parse(tbAERepeticiones.Text); }
            catch (ArgumentNullException)
            {
                gridMainGrid.IsEnabled = false;
                ErrorGridText.Text = "No has ingresado un valor para la cantidad de repeticiones.";
                gridError.Visibility = Visibility.Visible;
                tbAERepeticiones.Text = "";
            }
            if (!(cbAEUnidades.SelectedIndex == -1))
            {
                //Seleccionas KG
                if (cbAEUnidades.SelectedIndex == 0)
                    _peso = new PesoKG(_cantidadPeso);
                //Seleccionas lbs
                if (cbAEUnidades.SelectedIndex == 1)
                    _peso = new Pesolbs(_cantidadPeso);
            }
            else
            {
                //Terminar de agregar como funcina la seleccion de indices
            }

            string _maquinaria;
            string _grupoMuscular;
            string _rutinaContenedora;

        }
        //private void VerificarVariables()
        //{
        //    if()



        //}

        private void btnAEAgregarEjercicio_Click(object sender, RoutedEventArgs e)
        {
            var rutina = new Ejercicios(_nombreEjercicio, _series, _repeticiones, _peso, _maquinaria, _grupoMuscular, _rutinaContenedora);
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
            gridMainGrid.IsEnabled = true;
        }
    }
}
