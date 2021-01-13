using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Final.Project.DAL;
using Final.Project.Models;
using Microsoft.Ajax.Utilities;

namespace Final.Project.Controllers
{
    public class UserController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UserReg(RegisterInfo RegInfo)
        {
            dbMyOnlineShoppingEntities3 db = new dbMyOnlineShoppingEntities3();
            db.Tbl_Members.Add(new Tbl_Members()

            {
                FristName = RegInfo.Name,
                EmailId = RegInfo.Email,
                Password = RegInfo.Password,
                //RePassword = RegInfo.password_confirm

            });
           
            db.SaveChanges();
            return Ok();

        }
    }
}
