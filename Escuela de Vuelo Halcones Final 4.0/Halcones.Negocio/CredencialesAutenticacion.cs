using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class CredencialesAutenticacion
    {
        private static int _idUsuario;
        private static string _nombresUsuario;
        private static string _apellidosUsuario;
        private static bool _estadoUsuario;
        private static int _idGlobal;
        private static int _tipo;

        public static int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public static int IdGlobal
        {
            get { return _idGlobal; }
            set { _idGlobal = value; }
        }

        public static int Id
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public static string Nombres
        {
            get { return _nombresUsuario; }
            set { _nombresUsuario = value; }
        }

        public static string Apellidos
        {
            get { return _apellidosUsuario; }
            set { _apellidosUsuario = value; }
        }

        public static bool Estado
        {
            get { return _estadoUsuario; }
            set { _estadoUsuario = value; }
        }

        public static void LimpiarVariables()
        {
            _idUsuario = 0;
            _nombresUsuario = String.Empty;
            _apellidosUsuario = String.Empty;
            _estadoUsuario = false;
            _idGlobal = 0;
        }

        public static void GenerarLog(string tipo, string mensaje)
        {
            try
            {
                StreamWriter writer = null;
                StringBuilder strBuilder = null;
                string direccion = "C:\\Logs\\";
                if (!Directory.Exists(direccion))
                {
                    Directory.CreateDirectory(direccion);
                }
                string path = Path.Combine(direccion, "Logs.log");
                string log = string.Format("LOG = ( Fecha:[{0}] - Tipo:[{1}] - [{2}])", DateTime.Today, tipo, mensaje);
                strBuilder = new StringBuilder(log);
                //strBuilder.AppendLine();
                writer = new StreamWriter(path, true);
                writer.WriteLine(strBuilder);
                writer.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
