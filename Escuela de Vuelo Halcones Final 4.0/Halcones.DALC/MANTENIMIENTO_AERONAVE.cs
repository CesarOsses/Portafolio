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
    
    public partial class MANTENIMIENTO_AERONAVE
    {
        public MANTENIMIENTO_AERONAVE()
        {
            this.MATENIMIENTO_COMPONENTE = new HashSet<MATENIMIENTO_COMPONENTE>();
        }
    
        public decimal ID_MANTENIMIENTO_AERONAVE { get; set; }
        public string TIPO_MANTENIMIENTO { get; set; }
        public System.DateTime FECHA_MATENIMIENTO { get; set; }
        public string ESTADO { get; set; }
        public decimal ID_AERONAVE { get; set; }
    
        public virtual AERONAVE AERONAVE { get; set; }
        public virtual ICollection<MATENIMIENTO_COMPONENTE> MATENIMIENTO_COMPONENTE { get; set; }
    }
}
