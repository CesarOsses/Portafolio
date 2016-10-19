using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Vuelo
    /// </summary>
    public class Vuelo
    {
        public int _idVuelo { get; set; }
        public DateTime _fechaSalida { get; set; }
        public string _estado { get; set; }
        public string _origen { get; set; }
        public string _destino { get; set; }
        public Aeronave _aeronave { get; set; }
        public Piloto _piloto { get; set; }
        public Piloto _copiloto { get; set; }
        public CondicionVuelo _condicion { get; set; }
        public Mision _mision { get; set; }
        
        /// <summary>
        /// Constructor de la clase Vuelo
        /// </summary>
        public Vuelo() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Vuelo
        /// </summary>
        private void Init()
        {
            this._idVuelo = 0;
            this._fechaSalida = new DateTime();
            this._estado = string.Empty;
            this._origen = string.Empty;
            this._destino = string.Empty;
            this._aeronave = new Aeronave();
            this._piloto = new Piloto();
            this._copiloto = new Piloto();
            this._condicion = new CondicionVuelo();
            this._mision = new Mision();
            
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Vuelo.
        /// </summary>
        /// <returns>Retorna true si se encontro el vuelo y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.VUELO vuelo = CommonBC.ModeloEscuelaHalcones.VUELO.
                    First(vue => vue.ID_VUELO == this._idVuelo);

                this._idVuelo = int.Parse(vuelo.ID_VUELO.ToString());
                this._fechaSalida = DateTime.Parse(vuelo.FECHA_SALIDA.ToString());
                this._estado = vuelo.ESTADO;
                this._origen = vuelo.ORIGEN;
                this._destino = vuelo.DESTINO;

                CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.AERONAVE).Load();
                this._aeronave._idAeronave = int.Parse(vuelo.AERONAVE.ID_AERONAVE.ToString());

                CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.PILOTO).Load();
                this._piloto._idPiloto= int.Parse(vuelo.PILOTO.ID_PILOTO.ToString());

                CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.PILOTO1).Load();
                this._copiloto._idPiloto = int.Parse(vuelo.PILOTO1.ID_PILOTO.ToString());

                CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.CONDICION_VUELO).Load();
                this._condicion._idCondicion = int.Parse(vuelo.CONDICION_VUELO.ID_CONDICION.ToString());

                CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.MISION).Load();
                this._mision._idMision = int.Parse(vuelo.MISION.ID_MISION.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        public bool BuscarFechaSalida() {
            try
            {
                Halcones.DALC.VUELO vuelo = CommonBC.ModeloEscuelaHalcones.VUELO.
                    First(vue => vue.ID_VUELO == this._idVuelo);

                this._idVuelo = int.Parse(vuelo.ID_VUELO.ToString());
                this._fechaSalida = DateTime.Parse(vuelo.FECHA_SALIDA.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// Metodo que registra una Vuelo.
        /// </summary>
        /// <returns>Retorna true si se registro el vuelo y false de caso contrario</returns>
        public bool Agregar() {
            try
            {
                Halcones.DALC.VUELO vuelo = new DALC.VUELO();
                vuelo.ID_VUELO = this._idVuelo;
                vuelo.FECHA_SALIDA = this._fechaSalida;
                vuelo.ESTADO = this._estado;
                vuelo.ORIGEN = this._origen;
                vuelo.DESTINO = this._destino;
                vuelo.ID_AERONAVE = this._aeronave._idAeronave;
                vuelo.ID_PILOTO = this._piloto._idPiloto;
                vuelo.ID_COPILOTO = this._copiloto._idPiloto;
                vuelo.ID_CONDICION = this._condicion._idCondicion;
                vuelo.ID_MISION = this._mision._idMision;
                CommonBC.ModeloEscuelaHalcones.VUELO.Add(vuelo);
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
        /// Metodo que Da de Baja una Vuelo
        /// </summary>
        /// <returns>Retorna true si se dio de de baja el vuelo y false de caso contrario</returns>
        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.VUELO vuelo = CommonBC.ModeloEscuelaHalcones.VUELO.First(
                    vue => vue.ID_VUELO == this._idVuelo);
                vuelo.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }




    }
}
