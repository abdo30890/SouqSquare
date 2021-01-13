using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Final.Project.DAL;
using Final.Project.Repository;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;


namespace Final.Project.Controllers
{
    public class AdminApiController : ApiController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        [System.Web.Http.HttpGet]
        public List<Tbl_Category> GetCategories()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return allcategories.ToList();
        }

        [System.Web.Http.HttpGet]
        public List<Tbl_Product> GetProducts()
        {
            return (List<Tbl_Product>)_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct();

        }
        [System.Web.Http.HttpPost]
        public void ProductEdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(tbl);
            
        }

    }
}
