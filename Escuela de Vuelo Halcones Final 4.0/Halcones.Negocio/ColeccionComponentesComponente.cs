using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionComponentesComponente
    {
        public List<ComponentesComponente> ListaComponentesComponente(int idComponente)
        {
            List<DALC.COMPONENTES_COMPONENTE> ComponentesComponente = CommonBC.ModeloEscuelaHalcones.
                COMPONENTES_COMPONENTE.Where( cc => cc.ID_COMPONENTE==idComponente).ToList();
            return this.GenerarListado(ComponentesComponente);
        }

        private List<ComponentesComponente> GenerarListado(List<DALC.COMPONENTES_COMPONENTE> DALC_ComponentesComponente)
        {
            try
            {
                List<ComponentesComponente> componentesComponente = new List<ComponentesComponente>();
                foreach (Halcones.DALC.COMPONENTES_COMPONENTE itemCC in DALC_ComponentesComponente)
                {
                    ComponentesComponente componenteComp = new ComponentesComponente();
                    componenteComp._idComponentesComponente = int.Parse(itemCC.ID_COMPONENTES_COMPONENTE.ToString());

                    CommonBC.ModeloEscuelaHalcones.Entry(itemCC).Reference(a => a.COMPONENTE).Load();
                    componenteComp._componente._idComponente = int.Parse(itemCC.COMPONENTE.ID_COMPONENTE.ToString());
                    componenteComp._componente._componente = itemCC.COMPONENTE.COMPONENTE1;

                    CommonBC.ModeloEscuelaHalcones.Entry(itemCC).Reference(a => a.COMPONENTE1).Load();
                    componenteComp._subComponente._idComponente = int.Parse(itemCC.COMPONENTE1.ID_COMPONENTE.ToString());
                    componenteComp._subComponente._componente = itemCC.COMPONENTE1.COMPONENTE1;

                    componentesComponente.Add(componenteComp);
                }
                return componentesComponente;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
