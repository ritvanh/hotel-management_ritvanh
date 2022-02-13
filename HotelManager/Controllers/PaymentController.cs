using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Models;
namespace HotelManager.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Clients()
        {
            try
            {
                if (Payment.GetPayments() != null)
                {
                    return View(Payment.GetPayments());
                }
                else
                {
                    return View(new { message = "Nuk keni asnje klient" });
                }
            }catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
