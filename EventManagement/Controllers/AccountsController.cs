using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EventManagement.Models;
using EventManagement.Context;
namespace EventManagement.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        LoginContext entity = new LoginContext();
        public AccountsController()
        {
        }
        public AccountsController(LoginContext _entity)
        {
            entity = _entity;
        }
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            

            if (ModelState.IsValid)
            {
               
                using (LoginContext db = new LoginContext())
                {
                    var obj = db.Users.Where(u => u.Email.Equals(credentials.Email) && u.password.Equals(credentials.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        FormsAuthentication.SetAuthCookie(obj.FullName, false);
                        Session["Username"] = obj.FullName;
                        Session["UserID"] = obj.Id.ToString();
                        Session["Email"] = obj.Email;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }


            ModelState.AddModelError("", "Email or Password is wrong");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserModel userInfo)
        {
            bool userExist = entity.Users.Any(u => u.Email == userInfo.Email);
            if(userExist)
            {
                ModelState.AddModelError("", "Email already exist");
            }
            else if(ModelState.IsValid)
            {
                entity.Users.Add(userInfo);
                entity.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured");
            }
            return View(userInfo);
        }
        public ActionResult Signout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}