using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Models;

namespace HotelManager.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View(ReservationDetails.GetFullReservations());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Add()
        {
            return View("Add",new Reservation());
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Add(Reservation model)
        {
            try
            {
                // TODO: Add insert logic here
                if (Reservation.Add(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
