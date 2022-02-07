using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Models;
namespace HotelManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ReservationFilter());
        }
        [HttpPost]
        public ActionResult Index(ReservationFilter filter)
        {
            var rooms = ReservationFilter.FilterRooms(filter);
            TempData["rooms"] = rooms;
            return RedirectToAction("Index", "Room");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}