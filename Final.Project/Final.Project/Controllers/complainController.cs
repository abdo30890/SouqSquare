using Final.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Final.Project.DAL;

namespace Final.Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComplainController : ApiController
    {

        dbMyOnlineShoppingEntities3 db = new dbMyOnlineShoppingEntities3();
        // get Complains
        [HttpGet]
        public List<Complain> GetComplains()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Complains.ToList();
        }
        //get one Complain 
        public Complain GetComplain(int id)
        {
            Complain complain = db.Complains.FirstOrDefault(c => c.ComplainNum == id);
            return complain;
        }

        //post Complain
        [HttpPost]
        // user create Complain
        public void PostComplain(Complain complain)
        {
            db.Complains.Add(complain);
            db.SaveChanges();

        }
        [HttpDelete]
        //Delete Complain
        public void DeleteComplain(int id)
        {
            Complain complain = db.Complains.FirstOrDefault(c => c.ComplainNum == id);
            db.Complains.Remove(complain);
            db.SaveChanges();
        }
    }
}
