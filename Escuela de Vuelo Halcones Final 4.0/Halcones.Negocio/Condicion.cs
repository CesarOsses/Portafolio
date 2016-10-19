using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halcones.Negocio
{
    public class Condicion
    {
        public int _idCondicion { get; set; }
        public string _condicion { get; set; }

        public Condicion() {
            this.Init();
        }

        private void Init()
        {
            this._idCondicion = 0;
            this._condicion = string.Empty;
        }
    }
}
