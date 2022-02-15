using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;
using HotelManager.Models;
namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            if (TempData["rooms"] == null)
            {
                return View(Room.GetRooms());
            }
            else if(TempData["rooms"] != null)
            {
                return View(TempData["rooms"]);
            }
            else if(TempData["rooms"] == null)
            {
                return View(new { message = "Nuk ka asnje dhome sipas specifikimeve" });
            }
            else
            {
                return View();
            }
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
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    while (room.UploadImage == null)
                    {
                        ViewBag.ErrorMessage = "Ju lutem jepni imazhin!";
                        return View(room);
                    }
                    var fileName = "~/Content/images/room/" + Guid.NewGuid() + "_" + room.UploadImage.FileName;
                    room.photoPath = fileName;
                    if (Room.InsertRoom(room))
                    {
                        try
                        {
                            room.UploadImage.SaveAs(Server.MapPath(fileName));
                        }
                        catch { }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Me shume mundesi dhoma ekziston.Kontrolloni fushat!";
                        return View(room);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Keni lene fusha bosh!";
                    return View(room);
                }
            }
            catch
            {
                return View();
            }
            return View(room);
        }
        
        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(Room.GetRoomByNumber(id));
            }catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (room.UploadImage != null)
                    {
                        var fileName = "~/Content/images/room/" + Guid.NewGuid() + "_" + room.UploadImage.FileName;
                        room.photoPath = fileName;
                        try
                        {
                            room.UploadImage.SaveAs(Server.MapPath(fileName));
                        }
                        catch { }
                    }
                    else
                    {
                        String path = Room.GetRoomByNumber(room.roomNumber).photoPath;
                        room.photoPath = path;
                    }
                    // TODO: Add update logic here
                    Room.UpdateRoom(room);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Keni lene fusha bosh!";
                    return View(room);
                }
            }
            catch
            {
                return RedirectToAction("Index");
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
        public ActionResult AddReservation(int id)
        {
            Reservation reservation = new Reservation();
            reservation.roomNumber = id;
            return View(reservation);
        }
        [HttpPost]
        public ActionResult AddReservation(Reservation model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if(model.arrivalDate > model.departionDate)
                    {
                        ViewBag.ErrorMessage = "Data e largimit nuk mund te jete me e vogel se data e mberritjes!";
                        return View(model);
                    }
                    else
                    {
                        if (Reservation.Add(model))
                        {
                            return RedirectToAction("PayReservation", new { reference = model.reservationReference });
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Datat e dhena jante te zena";
                            return View(model);
                        }
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Keni lene fusha bosh";
                    return View(model);
                } 
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PayReservation(String reference)
        {
            var payment = new Payment();
            payment.reservationReference = reference;
            return View(payment);
        }

        [HttpPost]
        public ActionResult PayReservation(Payment model)
        {
            try {
                if (ModelState.IsValid)
                {
                    if (Payment.Add(model))
                    {
                        Reservation.UpdateStatus(model.reservationReference);
                        return RedirectToAction("RoomPaymentConfirmed", model);
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Keni lene fusha bosh!";
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RoomPaymentConfirmed(Payment model)
        {
            return View(model);
        }

    }
}
