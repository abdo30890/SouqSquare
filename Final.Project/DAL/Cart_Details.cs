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
    
    public partial class Cart_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cart_Details()
        {
            this.Tbl_Order = new HashSet<Tbl_Order>();
        }
    
        public int ProductId { get; set; }
        public Nullable<int> product_Quantity { get; set; }
        public int CartDetailsID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<decimal> Total_Price { get; set; }
        public Nullable<int> CartId { get; set; }
        public Nullable<int> MemberID { get; set; }
    
        public virtual Tbl_Cart Tbl_Cart { get; set; }
        public virtual Tbl_Members Tbl_Members { get; set; }
        public virtual Tbl_Product Tbl_Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Order> Tbl_Order { get; set; }
    }
}