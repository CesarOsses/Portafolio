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
    
    public partial class MATENIMIENTO_COMPONENTE
    {
        public decimal ID_MANTENIMIENTO_COMPONENTE { get; set; }
        public System.DateTime FECHA_MANTENIMIENTO { get; set; }
        public string ESTADO { get; set; }
        public decimal ID_COMPONENTE { get; set; }
        public decimal ID_MANTENIMIENTO_AERONAVE { get; set; }
    
        public virtual COMPONENTE COMPONENTE { get; set; }
        public virtual MANTENIMIENTO_AERONAVE MANTENIMIENTO_AERONAVE { get; set; }
    }
}
