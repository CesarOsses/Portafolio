using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class Licencia
    {
        public int _idLicencia { get; set; }
        public string _licencia { get; set; }
        public string _estado { get; set; }

        public Licencia()
        {
            this.Init();
        }

        private void Init()
        {
            _idLicencia = 0;
            _licencia = string.Empty;
            _estado = string.Empty;
        }

        public bool Buscar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = CommonBC.ModeloEscuelaHalcones.LICENCIA.
                    First(li => li.ID_LICENCIA == this._idLicencia);
                this._idLicencia = int.Parse(licencia.ID_LICENCIA.ToString());
                this._licencia = licencia.LICENCIA1;
                this._estado = licencia.ESTADO;
                return true;
            }
            catch (Exception ex)
            {
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        public bool Agregar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = new DALC.LICENCIA();
                licencia.ID_LICENCIA = this._idLicencia;
                licencia.LICENCIA1 = this._licencia;
                licencia.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.LICENCIA.Add(licencia);
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.LICENCIA licencia = CommonBC.ModeloEscuelaHalcones.LICENCIA.
                   First(li => li.ID_LICENCIA == this._idLicencia);
                licencia.LICENCIA1 = this._licencia;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

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
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }
        
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
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
