using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;
namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            return View(Room.GetRooms());
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            return View(Room.GetRoomByNumber(id));
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View("Create", new Room());
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room room)
        {
            try
            {
                // TODO: Add insert logic here
                var fileName = "~/Content/images/room/" + Guid.NewGuid() + "_" + room.UploadImage.FileName;
                room.photoPath = fileName;
                Room.InsertRoom(room);
                room.UploadImage.SaveAs(Server.MapPath(fileName));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Room.GetRoomByNumber(id));
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                // TODO: Add update logic here
                Room.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Room.GetRoomByNumber(id));
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Room room)
        {
            try
            {
                // TODO: Add delete logic here
                Room.DeleteRoom(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
