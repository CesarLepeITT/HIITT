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
            txb.Style = (Style)Application.Current.Resources["Titulosss"];
            mainStackPanel.Children.Add(txb);
        }
        public static void GenerarSubTitulos(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["Subtitulos"];
            mainStackPanel.Children.Add(txb);
        }
        public static void GenerarTextoNormal(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];

            mainStackPanel.Children.Add(txb);
        }

        public static Grid SeccionNombreEditarBorrar(string texto, Button botonEditar, Button botonBorrar) 
        {
            Grid grd = new Grid();
            grd.Style = (Style)Application.Current.Resources["EstiloSeccionNombreEditarBorrar"];
    

            TextBlock txb = new()
            {
                Text = texto
                
            };

            botonEditar.Content = $"Editar {texto}";
            // Agregar estilo botonEditar.Style

            grd.Children.Add(txb);
            grd.Children.Add(botonEditar);
            grd.Children.Add(botonBorrar);

            return grd;
        }
    }
}
