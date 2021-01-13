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
    public class Tbl_MembersController : ApiController
    {
        dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Tbl_Members
        public IQueryable<Tbl_Members> GetTbl_Members()
        {
            return db.Tbl_Members;
        }

        // GET: api/Tbl_Members/5
        [ResponseType(typeof(Tbl_Members))]
        public IHttpActionResult GetTbl_Members(int id)
        {
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            if (tbl_Members == null)
            {
                return NotFound();
            }

            return Ok(tbl_Members);
        }

        // PUT: api/Tbl_Members/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Members(int id, Tbl_Members tbl_Members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Members.MemberId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Members).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_MembersExists(id))
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

        // POST: api/Tbl_Members
        [ResponseType(typeof(Tbl_Members))]
        public IHttpActionResult PostTbl_Members(Tbl_Members tbl_Members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Members.Add(tbl_Members);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Members.MemberId }, tbl_Members);
        }

        // DELETE: api/Tbl_Members/5
        [ResponseType(typeof(Tbl_Members))]
        public IHttpActionResult DeleteTbl_Members(int id)
        {
            Tbl_Members tbl_Members = db.Tbl_Members.Find(id);
            if (tbl_Members == null)
            {
                return NotFound();
            }

            db.Tbl_Members.Remove(tbl_Members);
            db.SaveChanges();

            return Ok(tbl_Members);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_MembersExists(int id)
        {
            return db.Tbl_Members.Count(e => e.MemberId == id) > 0;
        }
    }
}