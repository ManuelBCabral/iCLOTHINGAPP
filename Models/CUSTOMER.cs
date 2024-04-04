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
    
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.EMAIL = new HashSet<EMAIL>();
            this.ITEMDELIVERY = new HashSet<ITEMDELIVERY>();
            this.SHOPPINGCART = new HashSet<SHOPPINGCART>();
            this.USERCOMMENTS = new HashSet<USERCOMMENTS>();
            this.USERQUERY = new HashSet<USERQUERY>();
        }
    
        public string CUSTOMERID { get; set; }
        public string NAME { get; set; }
        public string SHIPPINGADDRESS { get; set; }
        public string BILLINGADDRESS { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string GENDER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMAIL> EMAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMDELIVERY> ITEMDELIVERY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOPPINGCART> SHOPPINGCART { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERCOMMENTS> USERCOMMENTS { get; set; }
        public virtual USERPASSWORD USERPASSWORD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERQUERY> USERQUERY { get; set; }
    }
}