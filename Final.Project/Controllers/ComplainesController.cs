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
    public class ComplainesController : ApiController
    {
        private dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        // GET: api/Complaines
        public List<Complaine> GetComplains()
        {
            
            return db.Complaines.ToList();
        }
        //get one Complain 
        public Complaine GetComplain(int id)
        {
            Complaine complain = db.Complaines.FirstOrDefault(c => c.ComplainId == id);
            return complain;
        }

        //post Complain
        [HttpPost]
        // user create Complain
        //api/Complaines/PostComplain
        public void PostComplain(Complaine complain)
        {
            db.Complaines.Add(complain);
            db.SaveChanges();

        }
        [HttpDelete]
        //Delete Complain
        public void DeleteComplain(int id)
        {
            Complaine complain = db.Complaines.FirstOrDefault(c => c.ComplainId == id);
            db.Complaines.Remove(complain);
            db.SaveChanges();
        }
    }
}