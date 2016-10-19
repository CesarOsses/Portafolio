using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Piloto
    /// </summary>
    public class Piloto
    {
        private TimeSpan HorasVuelo;

        public int _idPiloto { get; set; }
        public string _nacionalidad { get; set; }
        public string _comuna { get; set; }
        public string _direccion { get; set; }
        public DateTime _medicinaAeroespacial { get; set; }
        public int _totalSegundosVuelo { get; set; }

        public TimeSpan _horasVuelo
        {
            get
            {
                return HorasVuelo = TimeSpan.FromSeconds(this._totalSegundosVuelo);
            }
        }

        public Usuario _usuario { get; set; }




        private int _diasSinVolar;

        public int DiasSinVolar { 
            get{ return _diasSinVolar;}
        }

        /// <summary>
        /// Constructor de la clase Piloto
        /// </summary>
        public Piloto() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Piloto
        /// </summary>
        private void Init()
        {
            this._idPiloto = 0;
            this._nacionalidad = string.Empty;
            this._comuna = string.Empty;
            this._direccion = string.Empty;
            this._medicinaAeroespacial = new DateTime(2016,1,1);
            this._totalSegundosVuelo = 0;
            this._diasSinVolar = 0;
            this._usuario = new Usuario();
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Piloto.
        /// </summary>
        /// <returns>Retorna true si se encontro el Piloto y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.PILOTO piloto = CommonBC.ModeloEscuelaHalcones.PILOTO.First(
                    pil => pil.ID_PILOTO == this._idPiloto);
                this._idPiloto = int.Parse(piloto.ID_PILOTO.ToString());
                this._nacionalidad = piloto.NACIONALIDAD;
                this._comuna = piloto.COMUNA;
                this._direccion = piloto.DIRECCION;
                this._medicinaAeroespacial = DateTime.Parse(piloto.MEDICINA_AEROSPACIAL.ToString());
                this._totalSegundosVuelo = int.Parse(piloto.TOTAL_SEGUNDOS_VUELO.ToString());
                this._usuario._idUsuario = int.Parse(piloto.ID_USUARIO.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra una Piloto.
        /// </summary>
        /// <returns>Retorna true si se registro el Piloto y false de caso contrario</returns>
        public bool Agregar() {
            try
            {
                Halcones.DALC.PILOTO piloto = new DALC.PILOTO();
                piloto.ID_PILOTO = this._idPiloto;
                piloto.NACIONALIDAD = this._nacionalidad;
                piloto.COMUNA = this._comuna;
                piloto.DIRECCION = this._direccion;
                piloto.MEDICINA_AEROSPACIAL = this._medicinaAeroespacial;
                piloto.TOTAL_SEGUNDOS_VUELO = this._totalSegundosVuelo;
                piloto.ID_USUARIO = this._usuario._idUsuario;
                CommonBC.ModeloEscuelaHalcones.PILOTO.Add(piloto);
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
        /// Metodo que actualiza un Piloto
        /// </summary>
        /// <returns>Retorna true si se actualizo el piloto y false de caso contrario</returns>
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.PILOTO piloto = CommonBC.ModeloEscuelaHalcones.PILOTO.First(
                    pil => pil.ID_PILOTO == this._idPiloto);
                piloto.ID_PILOTO = this._idPiloto;
                piloto.COMUNA = this._comuna;
                piloto.NACIONALIDAD = this._nacionalidad;
                piloto.DIRECCION = this._direccion;
                piloto.MEDICINA_AEROSPACIAL = this._medicinaAeroespacial;
                piloto.ID_USUARIO = this._usuario._idUsuario;
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
