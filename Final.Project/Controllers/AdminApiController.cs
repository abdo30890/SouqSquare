using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final.Project.DAL;
using Final.Project.Repository;
using System.Data.Entity;


namespace Final.Project.Controllers
{
    public class AdminApiController : ApiController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        [HttpGet]
        public List<Tbl_Category> GetCategories()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return allcategories.ToList();
        }

        [HttpGet]
        public List<Tbl_Product> GetProducts()
        {
            return (List<Tbl_Product>)_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct();

        }

    }
}
