using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Final.Project.DAL;

namespace Final.Project.Controllers
{
    public class Tbl_OrderController : ApiController
    {
        private dbMyOnlineShoppingEntities6 db = new dbMyOnlineShoppingEntities6();

        // GET: api/Tbl_Order
        public IQueryable<Tbl_Order> GetTbl_Order()
        {
            return db.Tbl_Order;
        }

        // GET: api/Tbl_Order/5
        [ResponseType(typeof(Tbl_Order))]
        public IHttpActionResult GetTbl_Order(int id)
        {
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return NotFound();
            }

            return Ok(tbl_Order);
        }

        // PUT: api/Tbl_Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Order(int id, Tbl_Order tbl_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Order.OerderId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_OrderExists(id))
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

        // POST: api/Tbl_Order
        [ResponseType(typeof(Tbl_Order))]
        public IHttpActionResult PostTbl_Order(Tbl_Order tbl_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Order.Add(tbl_Order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Order.OerderId }, tbl_Order);
        }

        // DELETE: api/Tbl_Order/5
        [ResponseType(typeof(Tbl_Order))]
        public IHttpActionResult DeleteTbl_Order(int id)
        {
            Tbl_Order tbl_Order = db.Tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return NotFound();
            }

            db.Tbl_Order.Remove(tbl_Order);
            db.SaveChanges();

            return Ok(tbl_Order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_OrderExists(int id)
        {
            return db.Tbl_Order.Count(e => e.OerderId == id) > 0;
        }
    }
}