using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final.Project.DAL;
using Final.Project.Repository;

namespace Final.Project.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        // GET api/values
        public IEnumerable<string> Get()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return (IEnumerable<string>)allcategories.ToList();


        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
