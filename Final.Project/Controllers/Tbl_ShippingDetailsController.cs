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
    public class Tbl_ShippingDetailsController : ApiController
    {
        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Tbl_ShippingDetails
        public IQueryable<Tbl_ShippingDetails> GetTbl_ShippingDetails()
        {
            return db.Tbl_ShippingDetails;
        }

        // Get : shippingdetailsByMemberId/5
        public IHttpActionResult GetShippingByMemberId(int id)
        {

            return Ok(db.Tbl_ShippingDetails.Where(C => C.MemberId == id).ToList());

        }
        // GET: api/Tbl_ShippingDetails/5
        [ResponseType(typeof(Tbl_ShippingDetails))]
        public IHttpActionResult GetTbl_ShippingDetails(int id)
        {
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            if (tbl_ShippingDetails == null)
            {
                return NotFound();
            }

            return Ok(tbl_ShippingDetails);
        }

        // PUT: api/Tbl_ShippingDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_ShippingDetails(int id, Tbl_ShippingDetails tbl_ShippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_ShippingDetails.ShippingDetailId)
            {
                return BadRequest();
            }

            db.Entry(tbl_ShippingDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_ShippingDetailsExists(id))
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

        // POST: api/Tbl_ShippingDetails
        [ResponseType(typeof(Tbl_ShippingDetails))]
        public IHttpActionResult PostTbl_ShippingDetails(Tbl_ShippingDetails tbl_ShippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_ShippingDetails.Add(tbl_ShippingDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_ShippingDetails.ShippingDetailId }, tbl_ShippingDetails);
        }

        // DELETE: api/Tbl_ShippingDetails/5
        [ResponseType(typeof(Tbl_ShippingDetails))]
        public IHttpActionResult DeleteTbl_ShippingDetails(int id)
        {
            Tbl_ShippingDetails tbl_ShippingDetails = db.Tbl_ShippingDetails.Find(id);
            if (tbl_ShippingDetails == null)
            {
                return NotFound();
            }

            db.Tbl_ShippingDetails.Remove(tbl_ShippingDetails);
            db.SaveChanges();

            return Ok(tbl_ShippingDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_ShippingDetailsExists(int id)
        {
            return db.Tbl_ShippingDetails.Count(e => e.ShippingDetailId == id) > 0;
        }
    }
}