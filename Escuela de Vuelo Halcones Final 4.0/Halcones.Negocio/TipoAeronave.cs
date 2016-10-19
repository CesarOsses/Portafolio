using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Tipo Aeronave
    /// </summary>
    public class TipoAeronave
    {
        public int _idTipoAeronave {get; set;}
        public string _tipoAeronave {get; set;}

        /// <summary>
        /// Constructor de la clase TipoAeronave
        /// </summary>
        public TipoAeronave() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase TipoAeronave
        /// </summary>
        private void Init()
        {
            this._idTipoAeronave = 0;
            this._tipoAeronave = string.Empty;
        }
    }
}
