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
    /// Lógica de interacción para EjerciciosPag.xaml
    /// </summary>
    public partial class EjerciciosPag : Page
    {
        public EjerciciosPag()
        {
            InitializeComponent();

            btnEditarEjercicio.Click += BtnEditarEjercicio_Click;
            btnBorrarEjercico.Click += BtnBorrarEjercico_Click;

            Secciones.GenerarSubTitulos("Ejercicios Activos", MainStackPanel);

        }
        Button btnEditarEjercicio;
        Button btnBorrarEjercico;
        public void DesplegarEjerciciosActivos()
        {
            foreach (string rutinaActiva in ManejadorTextos.RutinasActivasPathList()) 
            {

            }

          //Secciones.SeccionNombreEditarBorrar()
        }
       // public void DesplegarEjerciciosActivos()
        public void BtnBorrarEjercico_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void BtnEditarEjercicio_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
