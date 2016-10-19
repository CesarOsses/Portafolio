using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Mantenimiento Componente
    /// </summary>
    public class MantenimientoComponente
    {
        public int _idMantenimientoComponente {get; set;}
        public DateTime _fechaMantenimiento {get;set;}
        public string _estado {get; set;}
        public Componente _componente {get;set;}
        public MantenimientoAeronave _mantenimientoAeronave {get;set;}

        /// <summary>
        /// Constructor de la clase MantenimientoComponente
        /// </summary>
        public MantenimientoComponente() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Mantenimiento Componente
        /// </summary>
        private void Init()
        {
            this._idMantenimientoComponente = 0;
            this._fechaMantenimiento = new DateTime();
            this._estado = string.Empty;
            this._componente = new Componente();
            this._mantenimientoAeronave = new MantenimientoAeronave();
        }


    }
}
