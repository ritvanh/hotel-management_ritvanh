using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Models;

namespace HotelManager.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new PersonLoginRequest());
        }
        [HttpPost]
        public ActionResult Login(PersonLoginRequest model)
        {
            var loggedUser = Person.Login(model);
            if (loggedUser != null)
            {
                Session["email"] = loggedUser.Email;
                Session["name"] = loggedUser.Name + " " + loggedUser.Surname;
                Session["role"] = (Role)loggedUser.Role;
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new PersonAddRequest());
        }
        [HttpPost]
        public ActionResult Register(PersonAddRequest model)
        {
            if (Person.Register(model))
            {
                return RedirectToAction("Login", "Identity");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Signout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Identity");
        }
    }
}