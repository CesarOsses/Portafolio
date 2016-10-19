using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionCondicionVuelo
    {
        public List<CondicionVuelo> ListarCondicion()
        {
            List<DALC.CONDICION_VUELO> condiciones = CommonBC.ModeloEscuelaHalcones.CONDICION_VUELO.ToList();
            return this.GenerarListado(condiciones);
        }

        private List<CondicionVuelo> GenerarListado(List<DALC.CONDICION_VUELO> DalcCondicion)
        {
            try
            {
                List<CondicionVuelo> condiciones = new List<CondicionVuelo>();
                foreach (Halcones.DALC.CONDICION_VUELO condicion in DalcCondicion)
                {
                    CondicionVuelo cond = new CondicionVuelo();
                    cond._idCondicion = int.Parse(condicion.ID_CONDICION.ToString());
                    cond._condicion = condicion.CONDICION;
                    condiciones.Add(cond);
                }
                return condiciones;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
