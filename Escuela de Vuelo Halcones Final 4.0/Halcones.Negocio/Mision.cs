using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase Mision
    /// </summary>
    public class Mision
    {
        public int _idMision { get; set; }
        public string _mision { get; set; }

        /// <summary>
        /// Constructor de la clase Mision
        /// </summary>
        public Mision()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase Mision
        /// </summary>
        private void Init()
        {
            this._idMision = 0;
            this._mision = string.Empty;
        }
    }
}
