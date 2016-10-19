using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionTipoAeronave
    {
        public List<TipoAeronave> ListarTiposAeronaves()
        {
            List<DALC.TIPO_AERONAVE> tiposAeronaves= CommonBC.ModeloEscuelaHalcones.TIPO_AERONAVE.ToList();
            return this.GenerarListado(tiposAeronaves);
        }

        private List<TipoAeronave> GenerarListado(List<DALC.TIPO_AERONAVE> DalcTipoAeronaves)
        {
            try
            {
                List<TipoAeronave> tipoAeronaves = new List<TipoAeronave>();
                foreach (Halcones.DALC.TIPO_AERONAVE tipoAeronave in DalcTipoAeronaves)
                {
                    TipoAeronave tipo = new TipoAeronave();
                    tipo._idTipoAeronave = int.Parse(tipoAeronave.ID_TIPO_AERONAVE.ToString());
                    tipo._tipoAeronave=tipoAeronave.TIPO_AERONAVE1;
                    tipoAeronaves.Add(tipo);
                }
                return tipoAeronaves;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
