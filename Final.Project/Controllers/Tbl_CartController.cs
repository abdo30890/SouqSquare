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
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Tbl_CartController : ApiController
    {
        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Tbl_Cart
        public IQueryable<Tbl_Cart> GetTbl_Cart()
        {
            return db.Tbl_Cart;
        }

        // GET: api/Tbl_Cart/5
        [ResponseType(typeof(Tbl_Cart))]
        public IHttpActionResult GetTbl_Cart(int id)
        {
            Tbl_Cart tbl_Cart = db.Tbl_Cart.Find(id);
            if (tbl_Cart == null)
            {
                return NotFound();
            }

            return Ok(tbl_Cart);
        }

        // PUT: api/Tbl_Cart/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Cart(int id, Tbl_Cart tbl_Cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Cart.CartId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_CartExists(id))
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

        // POST: api/Tbl_Cart
        [ResponseType(typeof(Tbl_Cart))]
        public IHttpActionResult PostTbl_Cart(int id)
        {
            Tbl_Cart cart = db.Tbl_Cart.Find(id);

            if (cart != null && cart.Cart_Status == "open")
            {
                cart.Cart_Status = "close";
                db.Entry<Tbl_Cart>(cart).State = EntityState.Modified;
            }

            var newcart = new Tbl_Cart()
            {
                Cart_Status = "open",
                MemberId = cart.MemberId
            };


            db.Tbl_Cart.Add(newcart);
            db.SaveChanges();

            return Ok( new {id = newcart.CartId });
        }

        // DELETE: api/Tbl_Cart/5
        [ResponseType(typeof(Tbl_Cart))]
        public IHttpActionResult DeleteTbl_Cart(int id)
        {
            Tbl_Cart tbl_Cart = db.Tbl_Cart.Find(id);
            if (tbl_Cart == null)
            {
                return NotFound();
            }

            db.Tbl_Cart.Remove(tbl_Cart);
            db.SaveChanges();

            return Ok(tbl_Cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_CartExists(int id)
        {
            return db.Tbl_Cart.Count(e => e.CartId == id) > 0;
        }
    }
}