//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_Loyalty.Models.lifsEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cuentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuentas()
        {
            this.Movimientos = new HashSet<Movimientos>();
        }
    
        public int CuentaID { get; set; }
        public int UsuarioID { get; set; }
        public int TipoCuentaID { get; set; }
        public decimal Monto { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual TipoCuentas TipoCuentas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}
