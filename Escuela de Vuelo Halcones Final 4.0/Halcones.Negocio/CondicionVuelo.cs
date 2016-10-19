using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Condicion de Vuelo
    /// </summary>
    public class CondicionVuelo
    {
        public int _idCondicion { get; set; }
        public string _condicion { get; set; }

        /// <summary>
        /// Constructor de la clase CondicionVuelo
        /// </summary>
        public CondicionVuelo() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase CondicionVuelo
        /// </summary>
        private void Init()
        {
            this._idCondicion = 0;
            this._condicion = string.Empty;
        }
    }
}
