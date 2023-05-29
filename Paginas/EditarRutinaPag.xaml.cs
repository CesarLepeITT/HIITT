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
        public EditarRutinaPag(Frame MainFrame)
        {
            InitializeComponent();
            _mainFrame = MainFrame;

            string[] rutinasPathList = ManejadorTextos.RutinasActivasPathList();
            if (rutinasPathList.Length > 0)
            {
                foreach (string f in ManejadorTextos.RutinasActivasPathList())
                {
                    ComboBoxItem nombreRutina = new ComboBoxItem();
                    nombreRutina.Content = ManejadorTextos.LeerNombreRutina(f);
                    cbRutinas.Items.Add(nombreRutina);
                }
            }

        }
        Frame _mainFrame;

        private void cbRutinas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
