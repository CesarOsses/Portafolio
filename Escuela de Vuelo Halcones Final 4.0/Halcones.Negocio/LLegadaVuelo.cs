using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase LLegada Vuelo
    /// </summary>
    public class LLegadaVuelo
    {
        public int _idLLegada {get;set;}
        public DateTime _fechaLLegada {get;set;}
        public int _segundosVuelo {get;set;}
        public int _segundosVueloPiloto { get; set; }
        public int _segundosVueloCoPiloto { get; set; }
        public string _comentarios {get;set;}
        public Vuelo _vuelo {get;set;}

        /// <summary>
        /// Constructor de la clase LLegadaVuelo
        /// </summary>
        public LLegadaVuelo(){
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase LLegadaVuelo
        /// </summary>
        private void Init()
        {
            this._idLLegada = 0;
            this._fechaLLegada = new DateTime();
            this._segundosVuelo = 0;
            this._segundosVueloPiloto = 0;
            this._segundosVueloCoPiloto = 0;
            this._comentarios = string.Empty;
            this._vuelo = new Vuelo();
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Llegada de un Vuelo.
        /// </summary>
        /// <returns>Retorna true si se encontro la llegada del vuelo y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.LLEGADA_VUELO llegada = CommonBC.ModeloEscuelaHalcones.LLEGADA_VUELO.First(
                    ll => ll.ID_VUELO == this._vuelo._idVuelo);

                this._idLLegada = int.Parse(llegada.ID_LLEGADA.ToString());
                this._fechaLLegada = DateTime.Parse(llegada.FECHA_LLEGADA.ToString());
                this._segundosVuelo = int.Parse(llegada.SEGUNDOS_VUELO.ToString());
                this._segundosVueloPiloto = int.Parse(llegada.SEGUNDOS_VUELO_PILOTO.ToString()); ;
                this._segundosVueloCoPiloto = int.Parse(llegada.SEGUNDOS_VUELO_COPILOTO.ToString()); ;
                this._comentarios = llegada.COMENTARIOS;

                //CommonBC.ModeloEscuelaHalcones.Entry(llegada).Reference(a => a.VUELO).Load();
                this._vuelo._idVuelo = int.Parse(llegada.VUELO.ID_VUELO.ToString());                
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra un llegada de un vuelo.
        /// </summary>
        /// <returns>Retorna true si se registro la llegada del vuelo y false de caso contrario</returns>
        public bool Agregar()
        {
            try
            {
                Halcones.DALC.USUARIO usuario = new DALC.USUARIO();

                Halcones.DALC.LLEGADA_VUELO llegada = new DALC.LLEGADA_VUELO();
                llegada.ID_LLEGADA = this._idLLegada;
                llegada.FECHA_LLEGADA = this._fechaLLegada;
                llegada.SEGUNDOS_VUELO = this._segundosVuelo;
                llegada.SEGUNDOS_VUELO_PILOTO = this._segundosVueloPiloto;
                llegada.SEGUNDOS_VUELO_COPILOTO = this._segundosVueloCoPiloto;
                llegada.COMENTARIOS = this._comentarios;
                llegada.ID_VUELO = this._vuelo._idVuelo;
                CommonBC.ModeloEscuelaHalcones.LLEGADA_VUELO.Add(llegada);
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
