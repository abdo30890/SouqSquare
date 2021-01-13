using Final.Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Project.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Cart_Status { get; set; }
       public List<int> SelectedProducts { get; set; }// هتحط هنا ال ids بتاعت اى منتج يختاره
       
       // public virtual ICollection<Cart_Product> Cart_Product { get; set; }
    }
}