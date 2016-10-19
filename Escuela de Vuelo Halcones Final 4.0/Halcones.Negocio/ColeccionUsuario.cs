using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    public class ColeccionUsuario
    {
        /// <summary>
        /// Metodo que obtiene el listado de Pilotos
        /// </summary>
        /// <returns>Lista con todos los pilotos encontrados</returns>
        public List<Piloto> ListarPilotos()
        {
            CommonBC.ModeloEscuelaHalcones.PRO_PRUEBA();

            List<DALC.PILOTO> pilotos = CommonBC.ModeloEscuelaHalcones.PILOTO.
                Where(o => o.USUARIO.ESTADO == "Disponible" && o.USUARIO.ID_PERFIL== 4 ).ToList();
            return GenerarListadoPilotos(pilotos);
        }
       
        /// <summary>
        /// Metodo que obtiene el total de Usuarios
        /// </summary>
        /// <param name="idperfil">Identificador del tipo de usuario a Buscar</param>
        /// <returns>Lista con todos los usuarios encontrados</returns>
        public List<Usuario> ListarUsuarios(int idperfil)
        {
            List<DALC.USUARIO> usuarios = CommonBC.ModeloEscuelaHalcones.USUARIO.
                Where(o => o.ID_PERFIL == idperfil && o.ESTADO == "Disponible").ToList();
            return this.GenerarListado(usuarios);
        }

        /// <summary>
        /// Metodo que genera el listado de Usuarios
        /// </summary>
        /// <param name="DalcUsuario">Lista de Usuarios Tipo DALC</param>
        /// <returns>Lista de Usuarios Tipo Usuario</returns>
        private List<Usuario> GenerarListado(List<Halcones.DALC.USUARIO> DalcUsuario)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                foreach (Halcones.DALC.USUARIO usuario in DalcUsuario)
                {
                    Usuario usu = new Usuario();
                    usu._idUsuario = int.Parse(usuario.ID_USUARIO.ToString());
                    usu._username = usuario.USERNAME;
                    usu._rut = usuario.RUT;
                    usu._correo = usuario.CORREO;
                    usu._nombres = usuario.NOMBRES;
                    usu._apellidos = usuario.APELLIDOS;
                    usu._fechaNacimiento = DateTime.Parse(usuario.FECHA_NACIMIENTO.ToString());
                    usuarios.Add(usu);
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }
        
        private List<Piloto> GenerarListadoPilotos(List<Halcones.DALC.PILOTO> DalcPiloto)
        {
            try
            {
                List<Piloto> pilotos = new List<Piloto>();
                foreach (Halcones.DALC.PILOTO piloto in DalcPiloto)
                {
                    Piloto pil = new Piloto();
                    pil._idPiloto = int.Parse(piloto.ID_PILOTO.ToString());
                    pil._nacionalidad = piloto.NACIONALIDAD;
                    pil._comuna = piloto.COMUNA;
                    pil._direccion = piloto.DIRECCION;
                    pil._medicinaAeroespacial = DateTime.Parse(piloto.MEDICINA_AEROSPACIAL.ToString());
                    pil._totalSegundosVuelo = int.Parse(piloto.TOTAL_SEGUNDOS_VUELO.ToString());

                    CommonBC.ModeloEscuelaHalcones.Entry(piloto).Reference(a => a.USUARIO).Load();
                    pil._usuario._idUsuario = int.Parse(piloto.USUARIO.ID_USUARIO.ToString());
                    pil._usuario._nombres = piloto.USUARIO.NOMBRES;
                    pil._usuario._apellidos = piloto.USUARIO.APELLIDOS ;
                    pil._usuario._rut = piloto.USUARIO.RUT;
                    pilotos.Add(pil);
                }
                return pilotos;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return null;
            }
        }

    }
}
