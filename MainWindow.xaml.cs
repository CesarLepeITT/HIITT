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
                // Main.Content = new Resumen();
            }
            if (NavListBox.SelectedIndex == 1)
            {
               // Main.Content = new Ejercicios();
            }
            if (NavListBox.SelectedIndex == 2)
            {
                //Main.Content = new Rutinas();
            }
            if (NavListBox.SelectedIndex == 3)
            {
               // Main.Content = new Calendario();
            }
        }

        private void NavListBox_Initialized(object sender, EventArgs e)
        {
            if (NavListBox.SelectedIndex == -1)
            {
                NavListBox.SelectedIndex = 0;
            }
        }

        private void AgregarEjercicio_Click(object sender, RoutedEventArgs e)
        {



        }
    }
}
