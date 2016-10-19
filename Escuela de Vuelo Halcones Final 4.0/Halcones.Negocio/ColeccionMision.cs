using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionMision
    {
        public List<Mision> ListarMision()
        {
            List<DALC.MISION> condiciones = CommonBC.ModeloEscuelaHalcones.MISION.ToList();
            return this.GenerarListado(condiciones);
        }

        private List<Mision> GenerarListado(List<DALC.MISION> DalcMisiones)
        {
            try
            {
                List<Mision> misiones = new List<Mision>();
                foreach (Halcones.DALC.MISION mision in DalcMisiones)
                {
                    Mision mis = new Mision();
                    mis._idMision =  int.Parse(mision.ID_MISION.ToString());
                    mis._mision = mision.MISION1;
                    misiones.Add(mis);
                }
                return misiones;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
