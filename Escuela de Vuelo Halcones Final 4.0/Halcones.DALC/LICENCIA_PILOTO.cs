//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Halcones.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class LICENCIA_PILOTO
    {
        public decimal ID_LICENCIA_PILOTO { get; set; }
        public string ESTADO { get; set; }
        public System.DateTime ULTIMO_CONTROL { get; set; }
        public System.DateTime NUEVO_CONTROL { get; set; }
        public decimal ID_PILOTO { get; set; }
        public decimal ID_LICENCIA { get; set; }
    
        public virtual LICENCIA LICENCIA { get; set; }
        public virtual PILOTO PILOTO { get; set; }
    }
}
