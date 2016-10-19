using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionLicencia
    {
        public List<TipoLicencia> ListarLicencias()
        {
            List<DALC.LICENCIA> licencias = CommonBC.ModeloEscuelaHalcones.LICENCIA.
                Where(o => o.ESTADO == "Disponible").ToList();
            return this.GenerarListado(licencias);
        }

        private List<TipoLicencia> GenerarListado(List<DALC.LICENCIA> DalcLicencias)
        {
            try
            {
                List<TipoLicencia> licencias = new List<TipoLicencia>();
                foreach (Halcones.DALC.LICENCIA licencia in DalcLicencias)
                {
                    TipoLicencia li = new TipoLicencia();
                    li._idLicencia = int.Parse(licencia.ID_LICENCIA.ToString());
                    li._licencia = licencia.LICENCIA1;
                    li._diasRenovacion = int.Parse(licencia.DIAS_RENOVACION.ToString());
                    licencias.Add(li);
                }
                return licencias;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }

    }
}
