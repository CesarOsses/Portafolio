using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Licencia Piloto
    /// </summary>
    public class LicenciaPiloto
    {
        public int _idLicenciaPiloto { get; set; }
        public string _estado { get; set; }
        public DateTime _ultimoControl { get; set; }
        public DateTime _nuevoControl { get; set; }
        public Piloto _piloto { get; set; }
        public TipoLicencia _licencia { get; set; }
             
        /// <summary>
        /// Constructor de la clase LicenciaPiloto
        /// </summary>        
        public LicenciaPiloto()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase LicenciaPiloto
        /// </summary>
        private void Init(){
            this._idLicenciaPiloto = 0;
            this._estado = string.Empty;
            this._ultimoControl = new DateTime(2016, 09, 22);
            this._nuevoControl = new DateTime(2016, 09, 22);
            this._piloto = new Piloto();
            this._licencia = new TipoLicencia();
        }

        /// <summary>
        /// Metodo que obtiene los datos de una licencia asociada a un piloto.
        /// </summary>
        /// <returns>Retorna true si se encontro la licencia del piloto y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.LICENCIA_PILOTO lp = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.
                    First(p => p.ID_LICENCIA_PILOTO == this._idLicenciaPiloto);

                this._idLicenciaPiloto = int.Parse(lp.ID_LICENCIA_PILOTO.ToString());
                this._estado = lp.ESTADO;
                this._ultimoControl = DateTime.Parse(lp.ULTIMO_CONTROL.ToString());
                this._nuevoControl = DateTime.Parse(lp.NUEVO_CONTROL.ToString());
                this._piloto._idPiloto = int.Parse(lp.ID_PILOTO.ToString());

                CommonBC.ModeloEscuelaHalcones.Entry(lp).Reference(a => a.LICENCIA).Load();                
                this._licencia._idLicencia = int.Parse(lp.ID_LICENCIA.ToString());
                this._licencia._licencia = lp.LICENCIA.LICENCIA1;               
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que asigna una licencia a un piloto.
        /// </summary>
        /// <returns>Retorna true si se puede asignar la licencia al piloto y false de caso contrario</returns>
        public bool AsignarLicencia()
        {
            try
            {
                Halcones.DALC.LICENCIA_PILOTO licenciaPiloto = new DALC.LICENCIA_PILOTO();
                licenciaPiloto.ID_LICENCIA_PILOTO = this._idLicenciaPiloto;
                licenciaPiloto.ESTADO = this._estado;
                licenciaPiloto.NUEVO_CONTROL = this._nuevoControl;
                licenciaPiloto.ULTIMO_CONTROL = this._ultimoControl;
                licenciaPiloto.ID_PILOTO = this._piloto._idPiloto;
                licenciaPiloto.ID_LICENCIA = this._licencia._idLicencia;               
                CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.Add(licenciaPiloto);
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
        /// Metodo que desvincula una licencia de un piloto
        /// </summary>
        /// <returns>Retorna true si se desvinculo la licencia del piloto y false de caso contrario</returns>
        public bool DesvincularLicencia()
        {
            try
            {
                Halcones.DALC.LICENCIA_PILOTO lp = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.
                    First(p => p.ID_LICENCIA_PILOTO == this._idLicenciaPiloto);
                CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.Remove(lp);
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
        /// Metodo que configura una licencia de un Piloto
        /// </summary>
        /// <returns>Retorna true si se configuro la licencia del piloto y false de caso contrario</returns>   
        public bool ConfigurarLicencia()
        {
            try
            {
                Halcones.DALC.LICENCIA_PILOTO licenciaPiloto = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.
                    First( lip => lip.ID_LICENCIA_PILOTO == this._idLicenciaPiloto);
                licenciaPiloto.ID_LICENCIA = this._licencia._idLicencia;
                licenciaPiloto.ID_PILOTO = this._piloto._idPiloto;
                licenciaPiloto.NUEVO_CONTROL = this._nuevoControl;
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
        /// Metodo que verifica la existencia de asociacion de la licencia al piloto
        /// </summary>
        /// <returns>Retorna true si ya esta asociada la licencia al piloto y false de caso contrario</returns>
        public bool ExisteLicencia()
        {
            try
            {
                bool existe = false;
                if (this._idLicenciaPiloto != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.Any(
                        lp => lp.ID_LICENCIA == this._licencia._idLicencia &&
                            lp.ID_LICENCIA_PILOTO != this._idLicenciaPiloto
                        );
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.Any(
                        lp => lp.ID_LICENCIA == this._licencia._idLicencia);
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
