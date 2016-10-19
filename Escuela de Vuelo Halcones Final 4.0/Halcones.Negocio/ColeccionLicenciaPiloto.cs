using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionLicenciaPiloto
    {
        public List<LicenciaPiloto> LicenciasPiloto(int idPiloto)
        {
            //CommonBC.ModeloEscuelaHalcones.Configuration.AutoDetectChangesEnabled = true;
            List<DALC.LICENCIA_PILOTO> licenciasPiloto = CommonBC.ModeloEscuelaHalcones.LICENCIA_PILOTO.
                Where(l => l.ID_PILOTO == idPiloto).ToList();
            return this.GenerarListado(licenciasPiloto);
        }

        private List<LicenciaPiloto> GenerarListado(List<DALC.LICENCIA_PILOTO> DalcLicenciaPiloto)
        {
            try
            {
                List<LicenciaPiloto> licenciasPiloto = new List<LicenciaPiloto>();
                foreach (Halcones.DALC.LICENCIA_PILOTO licenciaPiloto in DalcLicenciaPiloto)
                {
                    LicenciaPiloto lp = new LicenciaPiloto();
                    lp._idLicenciaPiloto = int.Parse(licenciaPiloto.ID_LICENCIA_PILOTO.ToString());
                    lp._estado = licenciaPiloto.ESTADO;
                    lp._ultimoControl = DateTime.Parse(licenciaPiloto.ULTIMO_CONTROL.ToString());
                    lp._nuevoControl = DateTime.Parse(licenciaPiloto.NUEVO_CONTROL.ToString());
                    lp._piloto._idPiloto = int.Parse(licenciaPiloto.ID_PILOTO.ToString());

                    CommonBC.ModeloEscuelaHalcones.Entry(licenciaPiloto).Reference(a => a.LICENCIA).Load();
                    lp._licencia._idLicencia = int.Parse(licenciaPiloto.ID_LICENCIA.ToString());
                    lp._licencia._licencia = licenciaPiloto.LICENCIA.LICENCIA1;   

                    licenciasPiloto.Add(lp);
                }
                return licenciasPiloto;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
