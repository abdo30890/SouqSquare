using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Final.Project.DAL;
using Final.Project.Models;
using Microsoft.Ajax.Utilities;

namespace Final.Project.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        dbMyOnlineShoppingEntities1 db = new dbMyOnlineShoppingEntities1();

        public IHttpActionResult Register(Tbl_Members member)
        {

            if (ModelState.IsValid)
            {
                var cart = db.Tbl_Cart.FirstOrDefault(c => c.MemberId == member.MemberId && c.Cart_Status == "open");
                if (cart == null)
                {
                    db.Tbl_Cart.Add(new Tbl_Cart
                    {
                        Cart_Status = "open",
                        MemberId = member.MemberId
                    });
        

                }
                db.Tbl_Members.Add(member);
                db.SaveChanges();

                var memberIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, member.Email),
                    new Claim(ClaimTypes.Name, member.Name)


                }, "AppCookie");

                var authManager = Request.GetOwinContext().Authentication;
                authManager.SignIn(memberIdentity);
                db.SaveChanges();
                return Ok(new { Name = member.Name, UserID = member.MemberId ,cartId= member.Tbl_Cart });

            }
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Email Or Password");
            return ResponseMessage(response);
        }

        public IHttpActionResult Login(Tbl_Members members)
        {


            Tbl_Members newMember = db.Tbl_Members.FirstOrDefault(u => u.Email == members.Email && u.Password == members.Password);
            var cart = db.Tbl_Cart.FirstOrDefault(c => c.MemberId == newMember.MemberId && c.Cart_Status == "open");
            if (cart == null)
            {
                db.Tbl_Cart.Add(new Tbl_Cart
                {
                    Cart_Status = "open",
                    MemberId = newMember.MemberId
                });
                db.SaveChanges();

            }

            if (newMember != null)
            {
                var userIdentity =
                    new ClaimsIdentity(new List<Claim>()
                        {

                            new Claim(ClaimTypes.Email, members.Email),
                            new Claim("Password", members.Password)
                        },
                        "AppCookie");

                var authManager = Request.GetOwinContext().Authentication;
                authManager.SignIn(userIdentity);
                var tblMembers = newMember;
                return Ok(new { Name=newMember.Name,UserID=newMember.MemberId, cartId = cart.CartId });
            }

            else
            {

                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Email Or Password");
                return ResponseMessage(response);

            }
        }

            public void Logout()
        {
            var authManager = Request.GetOwinContext().Authentication;
            authManager.SignOut("AppCookie");
           
        }
    }
}
