using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionComponenteAeronave
    {
        public List<ComponentesAeronave> ComponentesAeronave(int idAeronave)
        {
            List<DALC.COMPONENTES_AERONAVE> componentesAeronave = CommonBC.ModeloEscuelaHalcones.COMPONENTES_AERONAVE.
                Where(l => l.ID_AERONAVE == idAeronave).ToList();
            return this.GenerarListado(componentesAeronave);
        }

        private List<ComponentesAeronave> GenerarListado(List<DALC.COMPONENTES_AERONAVE> DalcComponenteAeronave)
        {
            try
            {
                List<ComponentesAeronave> componentesAeronave = new List<ComponentesAeronave>();
                foreach (Halcones.DALC.COMPONENTES_AERONAVE itemCA in DalcComponenteAeronave)
                {
                    ComponentesAeronave compAeromave = new ComponentesAeronave();
                    compAeromave._idComponenteAeronave = int.Parse(itemCA.ID_COMPONENTE_AERONAVE.ToString());
                    compAeromave._totalHorasVuelo = int.Parse(itemCA.TOTAL_SEGUNDOS_VUELO.ToString());

                    CommonBC.ModeloEscuelaHalcones.Entry(itemCA).Reference(a => a.AERONAVE).Load();
                    compAeromave._aeronave._idAeronave = int.Parse(itemCA.AERONAVE.ID_AERONAVE.ToString());
                    compAeromave._aeronave._matricula = itemCA.AERONAVE.MATRICULA;

                    CommonBC.ModeloEscuelaHalcones.Entry(itemCA).Reference(a => a.COMPONENTE).Load();
                    compAeromave._componente._idComponente = int.Parse(itemCA.COMPONENTE.ID_COMPONENTE.ToString());
                    compAeromave._componente._componente = itemCA.COMPONENTE.COMPONENTE1;

                    componentesAeronave.Add(compAeromave);
                }
                return componentesAeronave;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }

    }
}
