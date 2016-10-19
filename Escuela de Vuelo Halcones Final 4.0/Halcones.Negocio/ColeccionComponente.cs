using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionComponente
    {
        public List<Componente> ListarComponentes()
        {
            List<DALC.COMPONENTE> licencias = CommonBC.ModeloEscuelaHalcones.COMPONENTE.
                Where(o => o.ESTADO != "No Disponible").ToList();
            return this.GenerarListado(licencias);
        }

        private List<Componente> GenerarListado(List<DALC.COMPONENTE> DalcComponentes)
        {
            try
            {
                List<Componente> componentes = new List<Componente>();
                foreach (Halcones.DALC.COMPONENTE componente in DalcComponentes)
                {
                    Componente comp = new Componente();
                    comp._idComponente = int.Parse(componente.ID_COMPONENTE.ToString());
                    comp._componente = componente.COMPONENTE1.ToString();
                    comp._fabricante = componente.FABRICANTE.ToString();
                    comp._estado = componente.ESTADO.ToString();
                    componentes.Add(comp);
                }
                return componentes;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
