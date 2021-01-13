using Final.Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Project.Controllers
{
    public class CategoryController : ApiController
    {
        private dbMyOnlineShoppingEntities3 db = new dbMyOnlineShoppingEntities3();
        
        public List<Tbl_Category> GetCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Tbl_Category.ToList();
        }

        public Tbl_Category GetCategory(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Tbl_Category category = db.Tbl_Category.FirstOrDefault(c=> c.CategoryId==id);
            return category;
        }

        public void PostCategory(Tbl_Category category)
        {
            db.Tbl_Category.Add(category);
            db.SaveChanges();
        }
        public void DeleteCategory (int id)
        {
            Tbl_Category category = db.Tbl_Category.FirstOrDefault(c=>c.CategoryId==id);
            db.Tbl_Category.Remove(category);
            db.SaveChanges();
        }
    }
}
