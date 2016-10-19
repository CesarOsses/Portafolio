using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Tipo Licencia
    /// </summary>
    public class TipoLicencia
    {
        public int _idLicencia { get; set; }
        public string _licencia { get; set; }
        public int _diasRenovacion { get; set; }
        public string _estado { get; set; }

        /// <summary>
        /// Constructor de la clase TipoLicencia
        /// </summary>
        public TipoLicencia()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase TipoLicencia
        /// </summary>
        private void Init()
        {
            this._idLicencia = 0;
            this._licencia = string.Empty;
            this._diasRenovacion = 0;
            this._estado = string.Empty;
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Tipo de Licencia.
        /// </summary>
        /// <returns>Retorna true si se encontro el tipo de licencia y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = CommonBC.ModeloEscuelaHalcones.LICENCIA.
                    First(li => li.ID_LICENCIA == this._idLicencia);
                this._idLicencia = int.Parse(licencia.ID_LICENCIA.ToString());
                this._diasRenovacion = int.Parse(licencia.DIAS_RENOVACION.ToString());
                this._licencia = licencia.LICENCIA1;
                this._estado = licencia.ESTADO;
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra un Tipo de Licencia.
        /// </summary>
        /// <returns>Retorna true si se registro el tipo de licencia y false de caso contrario</returns>
        public bool Agregar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = new DALC.LICENCIA();
                licencia.ID_LICENCIA = this._idLicencia;
                licencia.LICENCIA1 = this._licencia;
                licencia.DIAS_RENOVACION = this._diasRenovacion;
                licencia.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.LICENCIA.Add(licencia);
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
        /// Metodo que actualiza un Tipo de Licencia
        /// </summary>
        /// <returns>Retorna true si se actualizo el tipo de licencia y false de caso contrario</returns>
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = CommonBC.ModeloEscuelaHalcones.LICENCIA.
                   First(li => li.ID_LICENCIA == this._idLicencia);
                licencia.LICENCIA1 = this._licencia;
                licencia.DIAS_RENOVACION = this._diasRenovacion;
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
        /// Metodo que Da de Baja un Tipo de Licencia
        /// </summary>
        /// <returns>Retorna true si se dio de de baja el tipo de licencia y false de caso contrario</returns>
        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = CommonBC.ModeloEscuelaHalcones.LICENCIA.First(li => li.ID_LICENCIA == this._idLicencia);
                licencia.ESTADO = this._estado;
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
        /// Metodo que verifica la existencia del nombre del tipo de licencia
        /// </summary>
        /// <returns>Retorna true si ya existe un nombre de tipo de licencia y false de caso contrario</returns>
        public bool ExisteLicencia()
        {
            try
            {
                bool existe = false;
                if (this._idLicencia != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.LICENCIA.Any(
                        licencia => licencia.LICENCIA1 == this._licencia &&
                        licencia.ID_LICENCIA != this._idLicencia);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.LICENCIA.Any(licencia => licencia.LICENCIA1 == this._licencia);
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
