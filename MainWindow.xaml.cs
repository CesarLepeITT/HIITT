using GimApp.Paginas;
using HIITT.Paginas;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace GimApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new ResumenPag();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void NavItemMouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void NavItemSelection(object sender, RoutedEventArgs e)
        {
            if (NavListBox.SelectedIndex == 0)
            {
                Main.Content = new ResumenPag();
            }
            if (NavListBox.SelectedIndex == 1)
            {
               Main.Content = new EjerciciosPag();
            }
            if (NavListBox.SelectedIndex == 2)
            {
                Main.Content = new RutinasPag();
            }
            if (NavListBox.SelectedIndex == 3)
            {
               Main.Content = new CalendarioPag();
            }
        }

        private void AgregarEjercicio_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new AgregarEjercicioPag();

        }
    }
}
