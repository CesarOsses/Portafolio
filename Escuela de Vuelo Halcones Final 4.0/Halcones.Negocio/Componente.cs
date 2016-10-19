using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Componente
    /// </summary>
    public class Componente
    {
        public int _idComponente { get; set; }
        public string _componente { get; set; }
        public string _fabricante { get; set; }
        public string _estado { get; set; }

        /// <summary>
        /// Constructor de la clase Componente
        /// </summary>
        public Componente() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Componente
        /// </summary>
        private void Init()
        {
            this._idComponente = 0;
            this._componente = string.Empty;
            this._fabricante = string.Empty;
            this._estado = string.Empty;
        }

        /// <summary>
        /// Metodo que obtiene los datos de un Componente.
        /// </summary>
        /// <returns>Retorna true si se encontro el componente y false de caso contrario</returns>
        public bool Buscar()
        {
            try
            {
                Halcones.DALC.COMPONENTE comp = CommonBC.ModeloEscuelaHalcones.COMPONENTE.First(
                    c => c.ID_COMPONENTE == this._idComponente);
                this._idComponente = int.Parse(comp.ID_COMPONENTE.ToString());
                this._componente = comp.COMPONENTE1.ToString();
                this._fabricante = comp.FABRICANTE.ToString();
                this._estado = comp.ESTADO;
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que registra un Componente.
        /// </summary>
        /// <returns>Retorna true si se registro el usuario y false de caso contrario</returns>
        public bool Agregar()
        {
            try
            {
                Halcones.DALC.COMPONENTE componente = new DALC.COMPONENTE();
                Halcones.DALC.LICENCIA licencia = new DALC.LICENCIA();
                componente.ID_COMPONENTE = this._idComponente;
                componente.COMPONENTE1 = this._componente;
                componente.FABRICANTE = this._fabricante;
                componente.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.COMPONENTE.Add(componente);
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que actualiza un Componente
        /// </summary>
        /// <returns>Retorna true si se actualizo el componente y false de caso contrario</returns>
        public bool Actualizar()
        {
            try
            {
                Halcones.DALC.COMPONENTE comp = CommonBC.ModeloEscuelaHalcones.COMPONENTE.First(
                    c => c.ID_COMPONENTE == this._idComponente);
                comp.ID_COMPONENTE = this._idComponente;
                comp.COMPONENTE1 = this._componente;
                comp.FABRICANTE = this._fabricante;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que Da de Baja un Componente
        /// </summary>
        /// <returns>Retorna true si se dio de de baja el componente y false de caso contrario</returns>
        public bool DarDeBaja()
        {
            try
            {
                Halcones.DALC.COMPONENTE comp = CommonBC.ModeloEscuelaHalcones.COMPONENTE.First(
                    c => c.ID_COMPONENTE == this._idComponente);
                comp.ESTADO = this._estado;
                CommonBC.ModeloEscuelaHalcones.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica la existencia del Componente
        /// </summary>
        /// <returns>Retorna true si ya existe un componente y false de caso contrario</returns>
        public bool ExisteComponente()
        {
            try
            {
                bool existe = false;
                if (this._idComponente != 0)
                {
                    existe = CommonBC.ModeloEscuelaHalcones.COMPONENTE.Any(
                        cus => cus.COMPONENTE1 == this._componente &&
                        cus.ID_COMPONENTE != this._idComponente);
                }
                else
                {
                    existe = CommonBC.ModeloEscuelaHalcones.COMPONENTE.Any(
                        cus => cus.COMPONENTE1 == this._componente);
                }
                return existe;
            }
            catch (Exception ex)
            {
                ConfigHalcones.GenerarLog("ERROR", ex.ToString());
                return false;
            }
        }
    }
}
