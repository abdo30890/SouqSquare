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
    public class Tbl_ProductController : ApiController
    {
        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Tbl_Product
        public IQueryable<Tbl_Product> GetTbl_Product()
        {
            return db.Tbl_Product;
        }

        // GET: api/Tbl_Product/5
        [ResponseType(typeof(Tbl_Product))]
        public IHttpActionResult GetTbl_Product(int id)
        {
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return NotFound();
            }

            return Ok(tbl_Product);
        }

        [HttpGet]
        public IHttpActionResult GetProductName(string search)
        {
            var result = db.Tbl_Product.Where(n => n.ProductName.StartsWith(search) || search == null).ToList();
            return Ok(result);
        }


        // PUT: api/Tbl_Product/5
        [ResponseType(typeof(void))]
        public void PutTbl_Product(int id, Tbl_Product product)
        {
            Tbl_Product product1 = db.Tbl_Product.FirstOrDefault(d => d.ProductId == id);
            product1.ProductName = product.ProductName;
            product1.IsActive = product.IsActive;
            product1.IsDelete = product.IsDelete;
            product1.ProductImage = product.ProductImage;
            product1.ModifiedDate = product.ModifiedDate;
            product1.Quantity = product.Quantity;
            product.Price = product1.Price;
            product.CreatedDate = product1.CreatedDate;
            product.IsFeatured = product1.IsFeatured;
            product.CategoryId = product1.CategoryId;
            product.Description = product1.Description;
            //name , price, Desc , Quantity , img , Category Id

            db.SaveChanges();
        }

        // POST: api/Tbl_Product
        [ResponseType(typeof(Tbl_Product))]
        public IHttpActionResult PostTbl_Product(Tbl_Product tbl_Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Product.Add(tbl_Product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Product.ProductId }, tbl_Product);
        }

        // DELETE: api/Tbl_Product/5
        [ResponseType(typeof(Tbl_Product))]
        public IHttpActionResult DeleteTbl_Product(int id)
        {
            Tbl_Product tbl_Product = db.Tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return NotFound();
            }

            db.Tbl_Product.Remove(tbl_Product);
            db.SaveChanges();

            return Ok(tbl_Product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_ProductExists(int id)
        {
            return db.Tbl_Product.Count(e => e.ProductId == id) > 0;
        }

        //get product By Category Id

  [HttpGet]
  public IHttpActionResult GetProdByCatId(int id)
        {
            return Ok(db.Tbl_Product.Where(p => p.CategoryId == id).ToList());
        }


    }
}