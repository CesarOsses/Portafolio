using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcones.Negocio
{
    /// <summary>
    /// Clase SubComponentes Componente
    /// </summary>
    public class ComponentesComponente
    {
        public int _idComponentesComponente { get; set; }
        public Componente _componente {get ; set;}
        public Componente _subComponente {get; set;}

        /// <summary>
        /// Constructor de la clase ComponentesComponente
        /// </summary>
        public ComponentesComponente() {
            this.Init();
        }

        /// <summary>
        /// Inicializador de las variables de la clase ComponentesComponente
        /// </summary>
        private void Init()
        {
            this._idComponentesComponente = 0;
            this._componente = new Componente();
            this._subComponente = new Componente();
        }
    }
}
