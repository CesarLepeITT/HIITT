﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace HIITT.Clases
{
    internal class ManejadorTextos
    {
        // Estructura de un archivo txt de un ejercicio
        /*
        Nombre = nombreingresado
        Series = serieingresada
        Repeticiones = numeroingresado
        PesoCantidad = cantidadpesoingresad
        PesoUnidad = unidadpesoingresad
        GrupoMuscular = grupomuscularingresado
         */


        // De un archivo txt lee el texto que tiene dentro como los datos de un ejercicio
        // Puedes darle el path del archivo o el nombre del archivo y que te busque por acad clase el path
        //Devuelve todos los datos del ejercicio
        public  string LeerEjercicio(string path)
        {
            string ejercicio = string.Empty;

            StringBuilder sb = new StringBuilder();
                sb.AppendLine("Nombre: " + LeerNombreEjercicio(path));
                sb.AppendLine("Series: " + LeerSeriesEjercicio(path));
                sb.AppendLine("Repeticiones: " + LeerRepeticionesEjercicio(path));
                sb.AppendLine("Peso Cantidad: " + LeerCantidadPesoEjercicio(path));
                sb.AppendLine("Peso Unidad: " + LeerUnidadPesoEjercicio(path));
                sb.AppendLine("Maquinaria: " + LeerMaquinariaEjercicio(path));
                sb.AppendLine("Grupo Muscular: " + LeerGrupoMuscularEjercicio(path));

                ejercicio = sb.ToString();
            

            return ejercicio;
        }

        //Devuelve solo el nombre del ejercicio
        public string LeerNombreEjercicio(string path)
        {
            string nombre = string.Empty;

          
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Nombre"))
                        {
                            // Utiliza Regex.Match para encontrar el nombre del ejercicio
                            Match match = Regex.Match(line, @"🙁.*)$");
                            if (match.Success)
                            {
                                nombre = match.Groups[1].Value.Trim();
                            }
                            break;
                        }
                    }
                }
           

            return nombre;
        }

        //Devuelve solo las series del ejercicio
        public int LeerSeriesEjercicio(string path)
        {
            int series = 0;

            
            
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Series"))
                        {
                            // Utiliza Regex.Match para encontrar el valor de las series
                            Match match = Regex.Match(line, @"=(\d+)$");
                            if (match.Success)
                            {
                                series = int.Parse(match.Groups[1].Value);
                            }
                            break;
                        }
                    }
                }
            
           

            return series;
        }

        //Y asi suscesivamnete
      public int LeerRepeticionesEjercicio(string path)
{
    int repeticiones = 0;

   
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Repeticiones"))
                {
                    Match match = Regex.Match(line, @"=(\d+)$");
                    if (match.Success)
                    {
                        repeticiones = int.Parse(match.Groups[1].Value);
                    }
                    break;
                }
            }
        }
   
    return repeticiones;
}

public int LeerCantidadPesoEjercicio(string path)
{
    int cantidadPeso = 0;

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("PesoCantidad"))
                {
                    Match match = Regex.Match(line, @"=(\d+)$");
                    if (match.Success)
                    {
                        cantidadPeso = int.Parse(match.Groups[1].Value);
                    }
                    break;
                }
            }
        }
  

    return cantidadPeso;
}

public int LeerUnidadPesoEjercicio(string path)
{
    int unidadPeso = 0;

    
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("PesoUnidad"))
                {
                    Match match = Regex.Match(line, @"=(\d+)$");
                    if (match.Success)
                    {
                        unidadPeso = int.Parse(match.Groups[1].Value);
                    }
                    break;
                }
            }
        }
    

    return unidadPeso;
}

public string LeerMaquinariaEjercicio(string path)
{
    string maquinaria = string.Empty;

   
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Maquinaria"))
                {
                    Match match = Regex.Match(line, @"🙁.*)$");
                    if (match.Success)
                    {
                        maquinaria = match.Groups[1].Value.Trim();
                    }
                    break;
                }
            }
        }
   

    return maquinaria;
}

public string LeerGrupoMuscularEjercicio(string path)
{
    string grupoMuscular = string.Empty;

     using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("GrupoMuscular"))
                {
                    Match match = Regex.Match(line, @"🙁.*)$");
                    if (match.Success)
                    {
                        grupoMuscular = match.Groups[1].Value.Trim();
                    }
                    break;
                }
            }
        }
   
    return grupoMuscular;
}


        // De un archivo txt lee el texto que tiene dentro como los datos de una rutina


    }
}