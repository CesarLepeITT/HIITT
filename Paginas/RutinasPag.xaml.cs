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

namespace GimApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para RutinasPag.xaml
    /// </summary>
    public partial class RutinasPag : Page
    {
        public RutinasPag()
        {
            InitializeComponent();

            if (ManejadorTextos.RutinasPathList() != null)
            {
                foreach (string f in ManejadorTextos.RutinasPathList())
                {
                    TextBlock nombre = new TextBlock();
                    nombre.Text = ManejadorTextos.LeerNombreRutina(f);
                    stckpMainStackPanel.Children.Add(nombre);
                } 
            }

        }
    }
}
