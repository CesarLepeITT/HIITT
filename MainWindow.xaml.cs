using GimApp.Paginas;
using HIITT.Paginas;
using System;
using System.Windows;
using System.Windows.Controls;
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
            NavListBox.SelectedIndex = 0;
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
                MainPag.Content = new ResumenPag();
            }
            if (NavListBox.SelectedIndex == 1)
            {
               MainPag.Content = new EjerciciosPag();
            }
            if (NavListBox.SelectedIndex == 2)
            {
                MainPag.Content = new RutinasPag(MainPag);
            }
            if (NavListBox.SelectedIndex == 3)
            {
               MainPag.Content = new CalendarioPag();
            }
        }

        private void AgregarEjercicio_Click(object sender, RoutedEventArgs e)
        {

            MainPag.Content = new AgregarEjerciciosPag(MainPag);

        }

    }
}
