//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group12_iCLOTHINGAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHOPPINGCART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOPPINGCART()
        {
            this.ORDERSTATUS = new HashSet<ORDERSTATUS>();
        }
    
        public string CARTID { get; set; }
        public Nullable<decimal> CARTPROPRICE { get; set; }
        public Nullable<int> CARTPROQUANTITY { get; set; }
        public string CUSTID { get; set; }
        public string PRODID { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERSTATUS> ORDERSTATUS { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
