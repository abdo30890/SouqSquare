using Final.Project.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Final.Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComplainController : ApiController
    {

        dbMyOnlineShoppingEntities6 db = new dbMyOnlineShoppingEntities6();
        // get Complains
        [HttpGet]
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
