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
    
    public partial class LLEGADA_VUELO
    {
        public decimal ID_LLEGADA { get; set; }
        public System.DateTime FECHA_LLEGADA { get; set; }
        public decimal SEGUNDOS_VUELO { get; set; }
        public decimal SEGUNDOS_VUELO_PILOTO { get; set; }
        public decimal SEGUNDOS_VUELO_COPILOTO { get; set; }
        public string COMENTARIOS { get; set; }
        public decimal ID_VUELO { get; set; }
    
        public virtual VUELO VUELO { get; set; }
    }
}
