using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Aeronave
    /// </summary>
    public class Aeronave
    {
        private TimeSpan HorasVuelo;

        public int _idAeronave { get; set; }
        public string _matricula { get; set; }
        public int _totalSegundosVuelo { get; set; }        
        public TimeSpan _horasVuelo {
            get
            {
                /*TimeSpan horas = new TimeSpan();
                if (TimeSpan.TryParse(_totalSegundosVuelo.ToString(), out horas))
                {*/
                    return HorasVuelo = TimeSpan.FromSeconds(this._totalSegundosVuelo);                   
                //}
            }            
        }
        public DateTime _fechaInspeccionAnual { get; set; }
        public DateTime _fechaAeronavegabilidad { get; set; }
        public int _annoFabricacion { get; set; }
        public int _diasMantencion { get; set; }
        public int _horasVueloMantencion { get; set; }
        public int _totalHorasVueloMantencion { get; set; }
        public DateTime _ultimoMantenimiento { get; set; }
        public string _estado { get; set; }
        public TipoAeronave _tipoAeronave { get; set; }
        
        /// <summary>
        /// Constructor de la clase Aeronave
        /// </summary>
        public Aeronave()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Aeronave
        /// </summary>
        private void Init()
        {
            this._idAeronave = 0;
            this._matricula = string.Empty;
            this._totalSegundosVuelo = 0;
            this.HorasVuelo = new TimeSpan();
            this._fechaInspeccionAnual = new DateTime(2016, 09, 22);
            this._fechaAeronavegabilidad = new DateTime(2016, 09, 22);
            this._annoFabricacion = 0;
            this._diasMantencion = 0;
            this._horasVueloMantencion = 0;
            this._totalHorasVueloMantencion = 0;
            this._ultimoMantenimiento = new DateTime(2016, 09, 22);
            this._estado = string.Empty;
            this._tipoAeronave = new TipoAeronave();
        }

        /// <summary>
        /// Metodo que obtiene los datos de una Aeronave.
        /// </summary>
        /// <returns>Retorna true si se encontro la aeronave y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {                
                Halcones.DALC.AERONAVE aeronave = CommonBC.ModeloEscuelaHalcones.AERONAVE.
                    First(aero => aero.ID_AERONAVE == this._idAeronave);
                this._idAeronave = int.Parse(aeronave.ID_AERONAVE.ToString());
                this._matricula = aeronave.MATRICULA;
                this._totalSegundosVuelo = int.Parse(aeronave.TOTAL_SEGUNDOS_VUELO.ToString());
                this._fechaInspeccionAnual = DateTime.Parse(aeronave.FECHA_INSPECCION_ANUAL.ToString());
                this._fechaAeronavegabilidad = DateTime.Parse(aeronave.FECHA_AERONAVEGABILIDAD.ToString());
                this._annoFabricacion = int.Parse(aeronave.ANNO_FABRICACION.ToString());
                this._diasMantencion = int.Parse(aeronave.DIAS_MANTENCION.ToString());
                this._horasVueloMantencion = int.Parse(aeronave.HORAS_VUELO_MANTENCION.ToString()); ;
                this._totalHorasVueloMantencion = int.Parse(aeronave.TOTAL_HORAS_VUELO_MANTENCION.ToString()); ;
                this._ultimoMantenimiento = DateTime.Parse(aeronave.ULTIMO_MANTENIMIENTO.ToString());
                this._estado = aeronave.ESTADO;

                CommonBC.ModeloEscuelaHalcones.Entry(aeronave).Reference(a => a.TIPO_AERONAVE).Load();                
                this._tipoAeronave._idTipoAeronave = int.Parse(aeronave.ID_TIPO_AERONAVE.ToString());
                this._tipoAeronave._tipoAeronave = aeronave.TIPO_AERONAVE.TIPO_AERONAVE1;
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra una Aeronave.
        /// </summary>
        /// <returns>Retorna true si se registro la aeronave y false de caso contrario</returns>
        public bool Agregar()
        {
            try
            {
                Halcones.DALC.AERONAVE aeronave = new DALC.AERONAVE();
                aeronave.ID_AERONAVE = this._idAeronave;
                aeronave.MATRICULA = this._matricula.ToString();
                aeronave.TOTAL_SEGUNDOS_VUELO = this._totalSegundosVuelo;
                aeronave.FECHA_INSPECCION_ANUAL = DateTime.Parse(this._fechaInspeccionAnual.ToString());
                aeronave.FECHA_AERONAVEGABILIDAD = DateTime.Parse(this._fechaAeronavegabilidad.ToString());
                aeronave.ULTIMO_MANTENIMIENTO = DateTime.Parse(this._ultimoMantenimiento.ToString());
                aeronave.ANNO_FABRICACION = int.Parse(this._annoFabricacion.ToString());
                aeronave.DIAS_MANTENCION = int.Parse(this._diasMantencion.ToString());
                aeronave.HORAS_VUELO_MANTENCION = int.Parse(this._horasVueloMantencion.ToString());
                aeronave.TOTAL_HORAS_VUELO_MANTENCION = int.Parse(this._totalHorasVueloMantencion.ToString());
                aeronave.ESTADO = this._estado.ToString();
                aeronave.ID_TIPO_AERONAVE = this._tipoAeronave._idTipoAeronave;
                CommonBC.ModeloEscuelaHalcones.AERONAVE.Add(aeronave);
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
        /// Metodo que actualiza una Aeronave
        /// </summary>
        /// <returns>Retorna true si se actualizo la aeronave y false de caso contrario</returns>
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.AERONAVE aeronave = CommonBC.ModeloEscuelaHalcones.AERONAVE.
                  First(aero => aero.ID_AERONAVE == this._idAeronave);

                aeronave.ID_AERONAVE = this._idAeronave;
                aeronave.MATRICULA = this._matricula;
                aeronave.FECHA_INSPECCION_ANUAL = this._fechaInspeccionAnual;
                aeronave.FECHA_AERONAVEGABILIDAD = this._fechaAeronavegabilidad;
                aeronave.ANNO_FABRICACION = this._annoFabricacion;
                aeronave.ID_TIPO_AERONAVE = this._tipoAeronave._idTipoAeronave;
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
        /// Metodo que Da de Baja una Aeronave
        /// </summary>
        /// <returns>Retorna true si se dio de de baja la aeronave y false de caso contrario</returns>
        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.AERONAVE aeronave = CommonBC.ModeloEscuelaHalcones.AERONAVE.First(
                    aero => aero.ID_AERONAVE == this._idAeronave);
                aeronave.ESTADO = this._estado;
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
        /// Metodo que verifica la existencia de una Matricula
        /// </summary>
        /// <returns>Retorna true si ya existe la matricula y false de caso contrario</returns>
        public bool ExisteMatricula()
        {
            try
            {
                bool existe = false;
                if (this._idAeronave != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.AERONAVE.Any(
                        cus => cus.MATRICULA == this._matricula &&
                        cus.ID_AERONAVE != this._idAeronave);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.AERONAVE.
                        Any(cus => cus.MATRICULA == this._matricula);
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
