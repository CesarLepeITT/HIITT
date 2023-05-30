using System;
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
        PesoUnidad = unidadpeso
        GrupoMuscular = grupomuscularingresado
         */
        public string[] EjerciciosPathList()
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\", UriKind.RelativeOrAbsolute);
            string path = myUri.ToString();
            path = path.Substring(8);
            return Directory.GetFiles(path);
        }
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
        // Estructura de un archivo txt de un ejercicio
        /*
        Nombre = nombreingresado
        Dia = dia
        Activa = True/False
        PathEjercicio 1 
        PathEjercicio 2
        ...
        PathEjercicio n
         */
        public static string[] RutinasActivasPathList()
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasActivas\", UriKind.RelativeOrAbsolute);
            string path = myUri.ToString();
            path = path.Substring(8);
            return Directory.GetFiles(path);
        }
        public static string[] RutinasInactivasPathList()
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas\rutinasInactivas\", UriKind.RelativeOrAbsolute);
            string path = myUri.ToString();
            path = path.Substring(8);
            return Directory.GetFiles(path);
        }
        public static string LeerRutina(string path) { return "No implementado"; }

        public static string LeerNombreRutina(string path) 
        {
            string nombre = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Nombre"))
                    {
                        nombre = line.Remove(0, 8);
                    }
                }
            }
            return nombre;
        }

        public static string LeerDiaRutina(string path) { return "No implementado"; }

        public static string LeerEsActivaRutina(string path) { return "No implementado"; }

        //public static string[] LeerPathEjercicios(string pathRutina) 
        //{

        //r
            
        //}

        public static void AgregarPathEjercicioARutina(string nombreEjercicio, string nombreRutina)
        {
            // Con el nombre del ejercicio buscas el path del archivo del ejercicio
            string pathEjercicio;
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\{nombreEjercicio}.txt", UriKind.RelativeOrAbsolute);
            pathEjercicio = myUri.ToString();
            pathEjercicio = pathEjercicio.Substring(8);
            // Editas el archivo para guardar el ejercicio
            //////using (FileStream fs = File.Create(path))
            //////{
            //////    AddText(fs, "This is some text");
            //////    AddText(fs, "This is some more text,");
            //////    AddText(fs, "\r\nand this is on a new line");
            //////    AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

            //////    for (int i = 1; i < 120; i++)
            //////    {
            //////        AddText(fs, Convert.ToChar(i).ToString());
            //////    }
            //////}

            // Con el nombre de la rutina buscas el path del archivo de la rutina
            string pathRutina;
            Uri uriRutina = new(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas");
            pathRutina = uriRutina.ToString();
            pathRutina = pathRutina.Substring(8);

            if (File.Exists(pathRutina + $@"\rutinasActivas\{nombreRutina}.txt"))
                pathRutina += $@"\rutinasActivas\{nombreRutina}.txt";
            if (File.Exists(pathRutina + $@"\rutinasInactivas\{nombreRutina}.txt"))
                pathRutina += $@"\rutinasActivas\{nombreRutina}.txt";

            using (FileStream fs = File.Open(pathEjercicio,FileMode.Open))
            {
                //AddText(fs, pathRUtina);
                string _pathEjercicio = "\n" + pathEjercicio;
                // Byte[] texto = new UTF8Encoding(true).GetBytes(ToString()); //Codifica el objeto utf8

                byte[] texto = new UTF8Encoding(true).GetBytes(_pathEjercicio);
                File.AppendAllText(pathRutina,_pathEjercicio);
            }



        }

        //// Metodos para funcionamiento de agregar ejercicio a una rutina

        ////string pathEjercicio = ManejadorTextos.LeerPathEjercicio(nombreEjercicio);
        ////string pathRutina = ManejadorTextos.LeerPathRutina(nombreRutina);

        //public string LeerPathEjercicio(string nombreEjercicio) 
        //{
        //    //Buscar el archivo en saves/rutinas/rutinasActivas
        //    foreach(f in )
        //    //Buscar el archivo en saves/rutinas/rutinasInactivas
        //    //Devolver el path en formato string

        //}

    }
}
