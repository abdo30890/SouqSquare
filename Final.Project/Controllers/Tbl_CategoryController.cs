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
    public class Tbl_CategoryController : ApiController
    {
        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();
        
        // GET: api/Tbl_Category
        public IQueryable<Tbl_Category> GetTbl_Category()
        {
            return db.Tbl_Category;
        }

        // GET: api/Tbl_Category/5
        [ResponseType(typeof(Tbl_Category))]
        public IHttpActionResult GetTbl_Category(int id)
        { 
            Tbl_Category tblCategory = db.Tbl_Category.Find(id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            return Ok(tblCategory);
        }

        // PUT: api/Tbl_Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Category(int id, Tbl_Category tbl_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_CategoryExists(id))
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

        // POST: api/Tbl_Category
        [ResponseType(typeof(Tbl_Category))]
        public IHttpActionResult PostTbl_Category(Tbl_Category tbl_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Category.Add(tbl_Category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Category.CategoryId }, tbl_Category);
        }

        // DELETE: api/Tbl_Category/5
        [ResponseType(typeof(Tbl_Category))]
        public void DeleteCategory(int id)
        {
            Tbl_Category category = db.Tbl_Category.FirstOrDefault(c => c.CategoryId == id);
            db.Tbl_Category.Remove(category);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_CategoryExists(int id)
        {
            return db.Tbl_Category.Count(e => e.CategoryId == id) > 0;
        }
    }
}