using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace HIITT.Clases
{
    class Secciones
    {
        public static void GenerarTitulos(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.HorizontalAlignment = HorizontalAlignment.Left;
            txb.Margin = new Thickness(10, 10, 0, 0);
            mainStackPanel.Children.Add(txb);
        }
        public static void GenerarSubTitulos(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.HorizontalAlignment = HorizontalAlignment.Left;
            txb.Margin = new Thickness(10, 10, 0, 0);
            mainStackPanel.Children.Add(txb);
        }
        public static void GenerarTextoNormal(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.HorizontalAlignment = HorizontalAlignment.Left;
            txb.Margin = new Thickness(10, 10, 0, 0);
            mainStackPanel.Children.Add(txb);
        }
    }
}
