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
            if (Person.GetPersons() != null) {
                return View(Person.GetPersons());
            }
            else
            {
                ViewBag.ErrorMessage = "Nuk ka asnje perdorues te regjistruar, kontaktoni pergjegjesin e IT.";
                return View(ViewBag.ErrorMessage);
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new PersonLoginRequest());
        }
        [HttpPost]
        public ActionResult Login(PersonLoginRequest model)
        {
            if (model.Email != null && model.Password!=null)
            {
                var loggedUser = Person.Login(model);
                if (loggedUser != null)
                {
                    Session["email"] = loggedUser.Email;
                    Session["name"] = loggedUser.Name + " " + loggedUser.Surname;
                    Session["role"] = (Role)loggedUser.Role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Te dhena te gabuara";
                    return View(model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Futni te dhenat";
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
            if (Person.GetPersonByEmail(model.Email) == null)
            {
                if (Person.Register(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Ekziston nje tjeter perdorues me kete email.";
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(new PersonResetPasswordRequest());
        }
        [HttpPost]
        public ActionResult ChangePassword(PersonResetPasswordRequest model)
        {
            try
            {
                var email = Session["email"].ToString();
                var user = Person.GetPersonByEmail(email);
                if(model.Password != user.Password)
                {
                    ViewBag.ErrorMessage = "Fjalekalim aktual i gabuar!";
                    return View(model);
                }else if(model.Password == user.Password && model.NewPassword != model.ConfirmPassword)
                {
                    ViewBag.ErrorMessage = "Fjalkalimet nuk perputhen!";
                    return View(model);
                }
                else
                {
                    Person.Edit(email, model.NewPassword);
                    return RedirectToAction("Index", "Home");
                }
            }catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
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
            if (Person.GetPersonById(id) != null && id!=null)
            {
                return View(Person.GetPersonById(id));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Person person)
        {
            try
            {
                // TODO: Add delete logic hereif
                if (person != null && id !=null)
                {
                    Person.DeletePerson(person.Id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}