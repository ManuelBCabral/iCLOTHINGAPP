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
    
    public partial class ITEMDELIVERY
    {
        public string STICKERID { get; set; }
        public Nullable<System.DateTime> STICKERDATE { get; set; }
        public string CUSTID { get; set; }
        public string PROID { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
