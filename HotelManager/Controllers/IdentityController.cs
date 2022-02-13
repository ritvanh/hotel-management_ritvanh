using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Models;
using static HotelManager.Models.Person;
namespace HotelManager.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Index()
        {
            return View(Person.GetPersons());
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
        [HttpGet]
        public ActionResult ChangePassword()
        {
            string email = Session["email"].ToString();
            return View(Person.GetPersonByEmail(email));
        }
        [HttpPost]
        public ActionResult ChangePassword(Person model)
        {
            if (Person.Edit(model))
            {
                return RedirectToAction("Index", "Room");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            var person = Person.GetPersonById(id);
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (Person.UpdatePerson(person))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }
        public ActionResult Signout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Identity");
        }
        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Person.GetPersonById(id));
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Person person)
        {
            try
            {
                // TODO: Add delete logic here
                Person.DeletePerson(person.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}