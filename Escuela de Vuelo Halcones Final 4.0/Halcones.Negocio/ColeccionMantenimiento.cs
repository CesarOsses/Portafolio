using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionMantenimiento
    {
        public List<MantenimientoAeronave> ListarMantenciones()
        {
            List<DALC.MANTENIMIENTO_AERONAVE> mantenciones = CommonBC.ModeloEscuelaHalcones.MANTENIMIENTO_AERONAVE.
                Where(o => o.ESTADO != "No Disponible").ToList();
            return this.GenerarListado(mantenciones);
        }

        private List<MantenimientoAeronave> GenerarListado(List<DALC.MANTENIMIENTO_AERONAVE> DalcMantenciones)
        {
            try
            {
                List<MantenimientoAeronave> mantencionesAeronave = new List<MantenimientoAeronave>();
                foreach (Halcones.DALC.MANTENIMIENTO_AERONAVE mantAeronave in DalcMantenciones)
                {
                    MantenimientoAeronave mantA = new MantenimientoAeronave();
                    mantA._idMantenimientoAeronave = int.Parse(mantAeronave.ID_MANTENIMIENTO_AERONAVE.ToString());
                    mantA._aeronave._idAeronave = int.Parse(mantAeronave.ID_AERONAVE.ToString());
                    mantA._aeronave._matricula = mantAeronave.AERONAVE.MATRICULA;
                    mantA._estado = mantAeronave.ESTADO;
                    mantA._tipoMantenimiento = mantAeronave.TIPO_MANTENIMIENTO;
                    mantA._fechaManteniminento = DateTime.Parse(mantAeronave.FECHA_MATENIMIENTO.ToString());
                    mantencionesAeronave.Add(mantA);
                }
                return mantencionesAeronave;
            }
            catch (Exception ex)
            {
                CredencialesAutenticacion.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
