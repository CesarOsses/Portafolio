using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Usuario
    /// </summary>
    public class Usuario
    {
        public int _idUsuario { get; set; }
        public string _username { get; set; }
        public string _contrasena { get; set; }
        public string _correo { get; set; }
        public string _rut { get; set; }
        public string _nombres { get; set; }
        public string _apellidos { get; set; }
        public DateTime _fechaNacimiento { get; set; }
        public string _estado { get; set; }
        public int _idPerfil { get; set; }

        /// <summary>
        /// Constructor de la clase Usuario
        /// </summary>
        public Usuario()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Usuario
        /// </summary>
        private void Init()
        {
            _idUsuario = 0;
            _username = string.Empty;
            _contrasena = string.Empty;
            _correo = string.Empty;
            _rut = string.Empty;
            _nombres = string.Empty;
            _apellidos = string.Empty;
            _fechaNacimiento = new DateTime(2016, 09, 22);
            _estado = string.Empty;
            _idPerfil = 0;
        }

        /// <summary>
        /// Metodo que verifica si las credenciales del usuario son validas
        /// </summary>
        /// <returns>Retorna true si es un usuario valido y false de caso contrario</returns>
        public bool Login()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = CommonBC.ModeloEscuelaHalcones.USUARIO.First(
                    p => p.USERNAME == this._username && p.PASSWORD == this._contrasena);
                this._idUsuario = int.Parse(usuario.ID_USUARIO.ToString());
                this._nombres = usuario.NOMBRES;
                this._apellidos = usuario.APELLIDOS;
                this._estado = usuario.ESTADO;
                this._idPerfil = int.Parse(usuario.ID_PERFIL.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que obtiene los datos de un usuario.
        /// </summary>
        /// <returns>Retorna true si se encontro el usuario y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = CommonBC.ModeloEscuelaHalcones.USUARIO.First(
                    usu => usu.ID_USUARIO == this._idUsuario);
                this._idUsuario = int.Parse(usuario.ID_USUARIO.ToString());
                this._username = usuario.USERNAME;
                this._correo = usuario.CORREO;
                this._rut = usuario.RUT;
                this._nombres = usuario.NOMBRES;
                this._apellidos = usuario.APELLIDOS;
                this._fechaNacimiento = DateTime.Parse(usuario.FECHA_NACIMIENTO.ToString());
                this._estado = usuario.ESTADO;
                this._idPerfil = int.Parse(usuario.ID_PERFIL.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra un usuario.
        /// </summary>
        /// <returns>Retorna true si se registro el usuario y false de caso contrario</returns>
        public bool Agregar()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = new DALC.USUARIO();
                usuario.ID_USUARIO = this._idUsuario;
                usuario.USERNAME = this._username;
                usuario.PASSWORD = this._contrasena;
                usuario.CORREO = this._correo;
                usuario.RUT = this._rut;
                usuario.NOMBRES = this._nombres;
                usuario.APELLIDOS = this._apellidos;
                usuario.FECHA_NACIMIENTO = this._fechaNacimiento;
                usuario.ESTADO = this._estado;
                usuario.ID_PERFIL = this._idPerfil;
                CommonBC.ModeloEscuelaHalcones.USUARIO.Add(usuario);
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que actualiza un usuario
        /// </summary>
        /// <returns>Retorna true si se actualizo el usuario y false de caso contrario</returns>
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = CommonBC.ModeloEscuelaHalcones.USUARIO.First(usu => usu.ID_USUARIO == this._idUsuario);
                usuario.USERNAME = this._username;
                if (this._contrasena != string.Empty)
                {
                    usuario.PASSWORD = this._contrasena;
                }
                usuario.CORREO = this._correo;
                usuario.RUT = this._rut;
                usuario.NOMBRES = this._nombres;
                usuario.APELLIDOS = this._apellidos;
                usuario.FECHA_NACIMIENTO = this._fechaNacimiento;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que Da de Baja un usuario
        /// </summary>
        /// <returns>Retorna true si se dio de de baja el usuario y false de caso contrario</returns>
        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = CommonBC.ModeloEscuelaHalcones.USUARIO.First(
                    usu => usu.ID_USUARIO == this._idUsuario);
                usuario.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que obtiene el Identificador de un Usuario
        /// </summary>
        public void ObtenerId()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = CommonBC.ModeloEscuelaHalcones.USUARIO.
                    First(p => p.USERNAME == this._username && p.RUT == this._rut);
                this._idUsuario = int.Parse(usuario.ID_USUARIO.ToString());
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
            }
        }

        /// <summary>
        /// Metodo que verifica la existencia de un Username
        /// </summary>
        /// <returns>Retorna true si ya existe un username y false de caso contrario</returns>
        public bool ExisteUsername()
        {
            try
            {
                bool existe = false;
                if (this._idUsuario != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(
                        cus => cus.USERNAME == this._username &&
                        cus.ID_USUARIO != this._idUsuario);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(cus => cus.USERNAME == this._username);
                }
                return existe;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica la existencia de un Correo
        /// </summary>
        /// <returns>Retorna true si ya existe un correo y false de caso contrario</returns>
        public bool ExisteCorreo()
        {
            try
            {
                bool existe = false;
                if (this._idUsuario != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(
                        cus => cus.CORREO == this._correo &&
                        cus.ID_USUARIO != this._idUsuario);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(cus => cus.CORREO == this._correo);
                }
                return existe;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica la existencia de un Rut
        /// </summary>
        /// <returns>Retorna true si ya existe un rut y false de caso contrario</returns>
        public bool ExisteRut()
        {
            try
            {
                bool existe = false;
                if (this._idUsuario != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(
                        cus => cus.RUT == this._rut &&
                        cus.ID_USUARIO != this._idUsuario);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.USUARIO.Any(cus => cus.RUT == this._rut);
                }
                return existe;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

    }
}
