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
    
    public partial class MISION
    {
        public MISION()
        {
            this.VUELO = new HashSet<VUELO>();
        }
    
        public decimal ID_MISION { get; set; }
        public string MISION1 { get; set; }
    
        public virtual ICollection<VUELO> VUELO { get; set; }
    }
}
