using GimApp.Clases;
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
        public ResumenPag()
        {
            InitializeComponent();
            Ejercicios myej = new Ejercicios("prueba", 1, 1, new PesoKG(2), "", "");
            prueba.Text = myej.PathTxt;
        }
    }
}
