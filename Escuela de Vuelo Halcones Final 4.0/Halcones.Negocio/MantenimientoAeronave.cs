using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Mantenimiento Aeronave
    /// </summary>
    public class MantenimientoAeronave
    {
        public int _idMantenimientoAeronave {get; set;}
        public string _tipoMantenimiento {get;set;}
        public DateTime _fechaManteniminento {get ;set ;}
        public string _estado {get; set;}
        public Aeronave _aeronave {get;set;}

        /// <summary>
        /// Constructor de la clase Mantenimiento Aeronave
        /// </summary>
        public MantenimientoAeronave() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Mantenimiento Aeronave
        /// </summary>
        private void Init()
        {
            this._idMantenimientoAeronave = 0;
            this._tipoMantenimiento = string.Empty;
            this._fechaManteniminento = new DateTime(2016, 10, 12);
            this._estado = string.Empty;
            this._aeronave = new Aeronave();
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Mantenimiento de una Aeronave.
        /// </summary>
        /// <returns>Retorna true si se encontro el mantenimiento de la aeronave y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.MANTENIMIENTO_AERONAVE mantAeronave = CommonBC.ModeloEscuelaHalcones.MANTENIMIENTO_AERONAVE.
                     First(li => li.ID_MANTENIMIENTO_AERONAVE == this._idMantenimientoAeronave);
                this._idMantenimientoAeronave = int.Parse(mantAeronave.ID_MANTENIMIENTO_AERONAVE.ToString());                
                this._estado = mantAeronave.ESTADO;
                this._tipoMantenimiento = mantAeronave.TIPO_MANTENIMIENTO;
                this._fechaManteniminento = DateTime.Parse(mantAeronave.FECHA_MATENIMIENTO.ToString());
                CommonBC.ModeloEscuelaHalcones.Entry(mantAeronave).Reference(a => a.AERONAVE).Load();
                this._aeronave._idAeronave = int.Parse(mantAeronave.AERONAVE.ID_AERONAVE.ToString());
                this._aeronave._matricula = mantAeronave.AERONAVE.MATRICULA;
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra un Mantenimiento No Programado.
        /// </summary>
        /// <returns>Retorna true si se registro el mantenimiento a la aeronave y false de caso contrario</returns>
        public bool RegistrarMantenimiento()
        {
            try
            {
                Halcones.DALC.MANTENIMIENTO_AERONAVE mantAeronave = new DALC.MANTENIMIENTO_AERONAVE();
                mantAeronave.ID_MANTENIMIENTO_AERONAVE = this._idMantenimientoAeronave;
                mantAeronave.TIPO_MANTENIMIENTO = this._tipoMantenimiento;
                mantAeronave.FECHA_MATENIMIENTO = this._fechaManteniminento;
                mantAeronave.ESTADO = this._estado;
                mantAeronave.ID_AERONAVE = this._aeronave._idAeronave;
                CommonBC.ModeloEscuelaHalcones.MANTENIMIENTO_AERONAVE.Add(mantAeronave);
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /*
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.MANTENIMIENTO_AERONAVE mantAeronave = CommonBC.ModeloEscuelaHalcones.MANTENIMIENTO_AERONAVE.
                    First(li => li.ID_MANTENIMIENTO_AERONAVE == this._idMantenimientoAeronave);
                mantAeronave.FECHA_MATENIMIENTO = this._fechaManteniminento;
                mantAeronave.ID_AERONAVE = this._aeronave._idAeronave;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.MANTENIMIENTO_AERONAVE mantAeronave = CommonBC.ModeloEscuelaHalcones.MANTENIMIENTO_AERONAVE.
                    First(li => li.ID_MANTENIMIENTO_AERONAVE == this._idMantenimientoAeronave);
                mantAeronave.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }*/
    }
}
