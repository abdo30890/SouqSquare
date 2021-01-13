using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using Final.Project.DAL;
using Microsoft.Ajax.Utilities;

namespace Final.Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Tbl_ProductController : ApiController
    {
        
        

        private dbMyOnlineShoppingEntities3 db = new dbMyOnlineShoppingEntities3();
        
        // GET: api/Products
        [HttpGet]
        public List<Tbl_Product> GetProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Tbl_Product.ToList();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Tbl_Product))]
        public Tbl_Product GetProduct(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Tbl_Product product = db.Tbl_Product.FirstOrDefault(d => d.ProductId == id);
            return product;
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public void PutProduct(int id, Tbl_Product product)
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

        // POST: api/Products
        [ResponseType(typeof(Tbl_Product))]
        public void PostProduct(Tbl_Product product)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            db.Tbl_Product.Add(product);
            db.SaveChanges();
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Tbl_Product))]
        public void DeleteProduct(int id)
        {
            Tbl_Product product = db.Tbl_Product.FirstOrDefault(p => p.ProductId == id);
            db.Tbl_Product.Remove(product);
        }
        [HttpGet]
        public IQueryable<Tbl_Product> GetProdByCatId(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IQueryable<Tbl_Product> productsByCategory = db.Tbl_Product.Where(p => p.CategoryId.Equals(id));
            return productsByCategory.AsQueryable();

        }



    }
}