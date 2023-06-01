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
            //txb.Margin = new Thickness(10,0,10,0);
            mainStackPanel.Children.Add(txb);
        }        
        public static TextBlock GenerarSubTitulos(string texto)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["Subtitulos"];
            //txb.Margin = new Thickness(10,0,10,0);
            return txb;
        } 
        public static void GenerarSubTitulos2(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["Subtitulos2"];
            //txb.Margin = new Thickness(10,0,10,0);
            mainStackPanel.Children.Add(txb);
        }        
        public static TextBlock GenerarSubTitulos2(string texto)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["Subtitulos2"];
            //txb.Margin = new Thickness(10,0,10,0);
            return txb;
        } 
        public static void GenerarTextoNormal(string texto, StackPanel mainStackPanel)
        {
            TextBlock txb = new();
            txb.Text = texto;
           // txb.HorizontalAlignment = HorizontalAlignment.Left;
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];

            mainStackPanel.Children.Add(txb);
        }
        public static TextBlock GenerarTextoNormal(string texto)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];
            return txb;
        }

        public static void GenerarTextoNormal(string texto, Grid mainGrid)
        {
            TextBlock txb = new();
            txb.Text = texto;
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];
            mainGrid.Children.Add(txb);
        }

        public static Grid GenerarGridDosTextBlock(TextBlock txb1, TextBlock txb2)
        {
            Grid grd = new Grid();
            //grd.Height= 40;
            //grd.Margin = new Thickness(10,0,10,0);

            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            grd.ColumnDefinitions.Add(colDef1);
            grd.ColumnDefinitions.Add(colDef2);


            txb1.HorizontalAlignment= HorizontalAlignment.Left;
            txb1.VerticalAlignment= VerticalAlignment.Center;
            Grid.SetColumn(txb1, 0);

            txb2.HorizontalAlignment = HorizontalAlignment.Left;
            txb2.VerticalAlignment = VerticalAlignment.Center;
            txb2.Margin = new Thickness(10,0,0,0);
            Grid.SetColumn(txb2, 1);
            
            grd.Children.Add(txb1);
            grd.Children.Add(txb2);

            return grd;
        }

        public static Grid SeccionNombreEditarBorrar(string texto, Button botonEditar, Button botonBorrar) 
        {
            Grid grd = new Grid();
            grd.Height = 40;
            grd.ColumnDefinitions.Add(new ColumnDefinition());
            grd.ColumnDefinitions.Add(new ColumnDefinition());
            grd.ColumnDefinitions.Add(new ColumnDefinition());
            grd.Style = (Style)Application.Current.Resources["EstiloSeccionNombreEditarBorrar"];

            TextBlock txb = new()
            {
                Text = texto
            };
            txb.Style = (Style)Application.Current.Resources["TextoNormal"];


            botonEditar.Content = $"Editar {texto}";
            // Agregar estilo botonEditar.Style

            grd.Children.Add(txb);
            grd.Children.Add(botonEditar);
            grd.Children.Add(botonBorrar);

            return grd;
        }
    }
}
