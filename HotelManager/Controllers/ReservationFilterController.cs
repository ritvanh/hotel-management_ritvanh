using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Controllers
{
    public class ReservationFilterController : Controller
    {
        // GET: ReservationFilter
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationFilter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationFilter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationFilter/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationFilter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationFilter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationFilter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationFilter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
