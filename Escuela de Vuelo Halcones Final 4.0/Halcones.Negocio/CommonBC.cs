using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Halcones.DALC;

namespace Halcones.Negocio
{
    /// <summary>
    ///  Clase CommonBC
    /// </summary>
    public class CommonBC
    {
        private static HalconesEntities _modeloEscuelaHalcones;

        public static HalconesEntities ModeloEscuelaHalcones
        {
            get
            {
                if (_modeloEscuelaHalcones == null)
                {
                    _modeloEscuelaHalcones = new HalconesEntities();
                }
                return CommonBC._modeloEscuelaHalcones;
            }
        }

        public CommonBC()
        {

        }
    }
}
