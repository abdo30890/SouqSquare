//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final.Project.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Cart()
        {
            this.Cart_Details = new HashSet<Cart_Details>();
            this.Tbl_ShippingDetails = new HashSet<Tbl_ShippingDetails>();
        }
    
        public int CartId { get; set; }
        public string Cart_Status { get; set; }
        public Nullable<int> MemberId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart_Details> Cart_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
        public virtual Tbl_Members Tbl_Members { get; set; }
    }
}
