using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionVuelo
    {
        public List<Vuelo> ListarVuelos()
        {
            CommonBC.ModeloEscuelaHalcones.PRO_ESTADO_VUELO();
            List<DALC.VUELO> vuelos = CommonBC.ModeloEscuelaHalcones.VUELO.
                Where(v => v.ESTADO != "No Disponible").ToList();
            return this.GenerarListado(vuelos);
        }

        private List<Vuelo> GenerarListado(List<DALC.VUELO> DalcVuelos)
        {
            try
            {
                List<Vuelo> vuelos = new List<Vuelo>();
                foreach (Halcones.DALC.VUELO vuelo in DalcVuelos)
                {
                    Vuelo vu = new Vuelo();

                    vu._idVuelo = int.Parse(vuelo.ID_VUELO.ToString());
                    vu._fechaSalida = DateTime.Parse(vuelo.FECHA_SALIDA.ToString());
                    vu._estado = vuelo.ESTADO;
                    vu._origen = vuelo.ORIGEN;
                    vu._destino = vuelo.DESTINO;

                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.AERONAVE).Load();
                    vu._aeronave._idAeronave = int.Parse(vuelo.AERONAVE.ID_AERONAVE.ToString());
                    vu._aeronave._matricula = vuelo.AERONAVE.MATRICULA;

                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.PILOTO).Load();
                    vu._piloto._idPiloto = int.Parse(vuelo.PILOTO.ID_PILOTO.ToString());
                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo.PILOTO).Reference(a => a.USUARIO).Load();
                    vu._piloto._usuario._rut = vuelo.PILOTO.USUARIO.RUT;
                    vu._piloto._usuario._nombres = vuelo.PILOTO.USUARIO.NOMBRES;
                    vu._piloto._usuario._apellidos = vuelo.PILOTO.USUARIO.APELLIDOS;

                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.PILOTO1).Load();
                    vu._copiloto._idPiloto = int.Parse(vuelo.PILOTO1.ID_PILOTO.ToString());
                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo.PILOTO1).Reference(a => a.USUARIO).Load();
                    vu._copiloto._usuario._rut = vuelo.PILOTO1.USUARIO.RUT;
                    vu._copiloto._usuario._nombres = vuelo.PILOTO1.USUARIO.NOMBRES;
                    vu._copiloto._usuario._apellidos = vuelo.PILOTO1.USUARIO.APELLIDOS;

                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.CONDICION_VUELO).Load();
                    vu._condicion._idCondicion = int.Parse(vuelo.CONDICION_VUELO.ID_CONDICION.ToString());
                    vu._condicion._condicion = vuelo.CONDICION_VUELO.CONDICION;

                    CommonBC.ModeloEscuelaHalcones.Entry(vuelo).Reference(a => a.MISION).Load();
                    vu._mision._idMision = int.Parse(vuelo.MISION.ID_MISION.ToString());
                    vu._mision._mision = vuelo.MISION.MISION1;

                    vuelos.Add(vu);
                }
                return vuelos;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
    }
}
