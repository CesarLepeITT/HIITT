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

        public static void BorrarArchivo(string path) => File.Delete(path);

        private static string LectorPropiedad(string path, string nombrePropiedad)
        {
            string valor = "Error";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    if (line.StartsWith(nombrePropiedad))
                        valor = line.Substring(nombrePropiedad.Length + 3);
            }
            return valor;
        }

        public string[] EjerciciosPathList()
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\", UriKind.RelativeOrAbsolute);
            string path = myUri.ToString();
            path = path.Substring(8);
            return Directory.GetFiles(path);
        }
        public string LeerEjercicio(string path)
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
        public static string LeerNombreEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "Nombre");

        //Devuelve solo las series del ejercicio
        public static string LeerSeriesEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "Series");

        public static string LeerRepeticionesEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "Repeticiones");

        public static string LeerCantidadPesoEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "PesoCantidad");

        public static string LeerUnidadPesoEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "PesoUnidad");

        public static string LeerMaquinariaEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "Maquinaria");

        public static string LeerGrupoMuscularEjercicio(string path) => ManejadorTextos.LectorPropiedad(path, "GrupoMuscular");
        public static string LeerPathEjercicio(string nombre)
        {
            Uri myUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\ejercicios\{nombre}.txt", UriKind.RelativeOrAbsolute);
            string path = myUri.ToString();
            path = path.Substring(8);

            return ManejadorTextos.LectorPropiedad(path, "Path");
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

        public static string LeerNombreRutina(string path) => ManejadorTextos.LectorPropiedad(path, "Nombre");
        public static string LeerDiaRutina(string path) => ManejadorTextos.LectorPropiedad(path, "Dia");
        public static DayOfWeek LeerDiaRutinadayToOfWeek(string path)
        {
            string diaString = ManejadorTextos.LectorPropiedad(path, "Dia");
            DayOfWeek diaSemana = DayOfWeek.Saturday;
            for (int i = 0; i < 7; i++)
            {
                diaSemana = (DayOfWeek)i;
                if (diaString == diaSemana.ToString())
                    return diaSemana;
            }
            return diaSemana;
        }
        public static string LeerEsActivaRutina(string path) => ManejadorTextos.LectorPropiedad(path, "Activa");
        public static bool LeerEsActivaRutinaToBool(string path)
        {
            if (ManejadorTextos.LectorPropiedad(path, "Activa") == "True")
                return true;
            else return false;
        }
        public static string[] LeerPathEjercicios(string pathRutina)
        {
            List<string> pathsEjercicios = new();
            string pathEjercicio;
            int linea = 0;
            using (StreamReader reader = new StreamReader(pathRutina))
            {
                while ((pathEjercicio = reader.ReadLine()) != null)
                {
                    linea++;
                    if (linea > 3)
                        pathsEjercicios.Add(pathEjercicio);
                }
            }
            return pathsEjercicios.ToArray();
        }
        public static string LeerPathRutina(string nombreRutina)
        {
            string pathRutina;
            Uri uriRutina = new(AppDomain.CurrentDomain.BaseDirectory + $@"..\..\..\saves\rutinas");
            pathRutina = uriRutina.ToString();
            pathRutina = pathRutina.Substring(8);
            if (File.Exists($@"{pathRutina}\rutinasActivas\{nombreRutina}.txt"))
                pathRutina += $@"\rutinasActivas\{nombreRutina}.txt";
            if (File.Exists($@"{pathRutina}\rutinasInactivas\{nombreRutina}.txt"))
                pathRutina += $@"\rutinasInactivas\{nombreRutina}.txt";
            return pathRutina;
        }
        public static void AgregarPathEjercicioARutina(string nombreEjercicio, string nombreRutina)
        {
            string pathEjercicio = ManejadorTextos.LeerPathEjercicio(nombreEjercicio);
            string pathRutina = ManejadorTextos.LeerPathRutina(nombreRutina);
            using (FileStream fs = File.OpenWrite(pathRutina))
            {
                fs.Close();
                File.AppendAllText(pathRutina, pathEjercicio+"\n");
            }
        }
    }
}
