using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionAeronaves
    {
        public List<Aeronave> ListarAeronaves()
        {
            List<DALC.AERONAVE> aeroanves = CommonBC.ModeloEscuelaHalcones.AERONAVE.
                Where(o => o.ESTADO != "No Disponible").ToList();
            return this.GenerarListado(aeroanves);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DalcAeronaves"></param>
        /// <returns></returns>
        private List<Aeronave> GenerarListado(List<DALC.AERONAVE> DalcAeronaves)
        {
            try
            {
                List<Aeronave> Aeronaves = new List<Aeronave>();
                foreach (Halcones.DALC.AERONAVE itemAeronave in DalcAeronaves)
                {
                    Aeronave aeronave = new Aeronave();
                    aeronave._idAeronave = int.Parse(itemAeronave.ID_AERONAVE.ToString());
                    aeronave._matricula = itemAeronave.MATRICULA;
                    aeronave._totalSegundosVuelo = int.Parse(itemAeronave.TOTAL_SEGUNDOS_VUELO.ToString());
                    aeronave._fechaInspeccionAnual = DateTime.Parse(itemAeronave.FECHA_INSPECCION_ANUAL.ToString());
                    aeronave._fechaAeronavegabilidad = DateTime.Parse(itemAeronave.FECHA_AERONAVEGABILIDAD.ToString());
                    aeronave._annoFabricacion = int.Parse(itemAeronave.ANNO_FABRICACION.ToString());
                    aeronave._diasMantencion = int.Parse(itemAeronave.DIAS_MANTENCION.ToString());
                    aeronave._horasVueloMantencion = int.Parse(itemAeronave.HORAS_VUELO_MANTENCION.ToString()); ;
                    aeronave._totalHorasVueloMantencion = int.Parse(itemAeronave.TOTAL_HORAS_VUELO_MANTENCION.ToString()); ;
                    aeronave._ultimoMantenimiento = DateTime.Parse(itemAeronave.ULTIMO_MANTENIMIENTO.ToString());
                    aeronave._estado = itemAeronave.ESTADO;

                    CommonBC.ModeloEscuelaHalcones.Entry(itemAeronave).Reference(a => a.TIPO_AERONAVE).Load();
                    aeronave._tipoAeronave._idTipoAeronave = int.Parse(itemAeronave.ID_TIPO_AERONAVE.ToString());
                    aeronave._tipoAeronave._tipoAeronave = itemAeronave.TIPO_AERONAVE.TIPO_AERONAVE1;
                    Aeronaves.Add(aeronave);
                }
                return Aeronaves;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
