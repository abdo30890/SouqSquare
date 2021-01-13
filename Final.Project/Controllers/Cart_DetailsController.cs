using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Final.Project.DAL;
namespace Final.Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Cart_DetailsController : ApiController
    {

        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Cart_Details
        public IQueryable<Cart_Details> GetCart_Details(int id)
        {
            return db.Cart_Details.Where(c => c.MemberID == id/* && c.Tbl_Cart.Cart_Status == "open"*/);

        }

        // GET: api/Cart_Details/5
        [ResponseType(typeof(Cart_Details))]
        public IHttpActionResult GetCart_DetailsById(int id)
        {
            Cart_Details cart_Details = db.Cart_Details.Find(id);
            if (cart_Details == null)
            {
                return NotFound();
            }

            return Ok(cart_Details);
        }

        //get cardid by cartdetails
        public IHttpActionResult GetDetailsByCartId(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Ok(db.Cart_Details.Where(p => p.CartId == id).ToList());

        }

        // PUT: api/Cart_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart_Details(int id, Cart_Details cart_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart_Details.CartDetailsID)
            {
                return BadRequest();
            }

            db.Entry(cart_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cart_DetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cart_Details
        [ResponseType(typeof(Cart_Details))]
    

        public IHttpActionResult PostCart_Details(Cart_Details cart_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var Product = db.Cart_Details.FirstOrDefault(c => c.ProductId == cart_Details.ProductId && c.MemberID == cart_Details.MemberID && c.Tbl_Cart.Cart_Status=="open");
            var productm = db.Tbl_Product.FirstOrDefault(async => async.ProductId == cart_Details.ProductId);

   

            if (productm.Quantity > 0)
            {
                if (Product == null)
                {
                    cart_Details.CreateDate = DateTime.Now;
                    db.Cart_Details.Add(cart_Details);
                }

                else
                {
                    cart_Details.CreateDate = DateTime.Now;
                    Product.product_Quantity++;
                   
                }

                productm.Quantity -= cart_Details.product_Quantity;

                db.SaveChanges();
            }
            return CreatedAtRoute("DefaultApi", new { id = cart_Details.CartDetailsID }, cart_Details);

        }

        // DELETE: api/Cart_Details/5
        [ResponseType(typeof(Cart_Details))]
        public IHttpActionResult DeleteCart_Details(int id)
        {
            Cart_Details cart_Details = db.Cart_Details.Find(id);
            if (cart_Details == null)
            {
                return NotFound();
            }

            db.Cart_Details.Remove(cart_Details);
            db.SaveChanges();

            return Ok(cart_Details);
        }



        private bool Cart_DetailsExists(int id)
        {
            return db.Cart_Details.Count(e => e.CartDetailsID == id) > 0;
        }
        public IQueryable<Cart_Details> GetOrderByMemberId(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Cart_Details.Where(c => c.MemberID == id );

            //return Ok(db.Cart_Details.Where(C => C.MemberID == id).ToList());

        }
    }
}