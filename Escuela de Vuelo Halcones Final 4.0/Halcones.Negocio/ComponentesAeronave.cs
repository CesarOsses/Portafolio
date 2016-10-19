using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Componentes Aeronave
    /// </summary>
    public class ComponentesAeronave
    {
        public int _idComponenteAeronave { get; set; }
        public int _totalHorasVuelo { get; set; }
        public Aeronave _aeronave { get; set; }
        public Componente _componente { get; set; }
        public string _estado { get; set; }

        /// <summary>
        /// Construcor de la clase ComponentesAeronaves
        /// </summary>
        public ComponentesAeronave() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Usuario
        /// </summary>
        private void Init()
        {
            this._idComponenteAeronave = 0;
            this._totalHorasVuelo = 0;
            this._aeronave = new Aeronave();
            this._componente = new Componente();
        }

        /// <summary>
        /// Metodo que asocia un componente a una Aeronave.
        /// </summary>
        /// <returns>Retorna true si se asocio el componente a la aeronave y false de caso contrario</returns>
        public bool AsociarComponente()
        {
            try
            {
                Halcones.DALC.COMPONENTES_AERONAVE compAero = new DALC.COMPONENTES_AERONAVE();
                compAero.ID_COMPONENTE_AERONAVE = this._idComponenteAeronave;
                compAero.TOTAL_SEGUNDOS_VUELO = this._totalHorasVuelo;
                compAero.ID_AERONAVE = this._aeronave._idAeronave;
                compAero.ID_COMPONENTE = this._componente._idComponente;
                CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.Add(compAero);
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
        /// Metodo que desvincula un componente de una Aeronave
        /// </summary>
        /// <returns>Retorna true si se desvinculo el compontenen de la aeronave y false de caso contrario</returns>
        public bool DesvincularComponente()
        {
            try
            {
                Halcones.DALC.COMPONENTES_AERONAVE compAero = CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.
                    First(p => p.ID_COMPONENTE_AERONAVE == this._idComponenteAeronave);
                CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.Remove(compAero);
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
        /// Metodo que verifica la existencia de un componente asociado a la aeronave
        /// </summary>
        /// <returns>Retorna true si ya existe un username y false de caso contrario</returns>
        public bool ExisteComponente()
        {
            try
            {
                bool existe = false;
                if (this._idComponenteAeronave != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.Any(
                        compAero => compAero.ID_COMPONENTE == this._componente._idComponente &&
                            compAero.ID_COMPONENTE_AERONAVE != this._idComponenteAeronave
                        );
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.Any(
                        compAero => compAero.ID_COMPONENTE == this._componente._idComponente );
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
