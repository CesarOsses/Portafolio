using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionCondicion
    {
        public List<Condicion> ListarCondicion()
        {
            List<DALC.CONDICION_VUELO> condiciones = CommonBC.ModeloEscuelaHalcones.CONDICION_VUELO.ToList();
            return this.GenerarListado(condiciones);
        }

        private List<Condicion> GenerarListado(List<DALC.CONDICION_VUELO> DalcCondicion)
        {
            try
            {
                List<Condicion> condiciones = new List<Condicion>();
                foreach (Halcones.DALC.CONDICION_VUELO condicion in DalcCondicion)
                {
                    Condicion cond = new Condicion();
                    cond._idCondicion = int.Parse(condicion.ID_CONDICION.ToString());
                    cond._condicion = condicion.CONDICION;
                    condiciones.Add(cond);
                }
                return condiciones;
            }
            catch (Exception ex)
            {
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
