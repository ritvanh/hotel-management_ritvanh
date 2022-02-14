using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Models;
using HotelManagement.Models;
namespace HotelManager.Models
{
    public class Stats
    {
        public int TotalRoomNumber { get; set; }
        public int BusyRoomNumber { get; set; }
        public int LiveClients { get; set; }
        public int TotalClients { get; set; }
        public decimal MoneyEarned { get; set; }
        public int Reservations { get; set; }
        public static Stats ReturnStats()
        {
            Stats stats = new Stats();
            //totalrooms
            stats.TotalRoomNumber = Room.GetRooms().Count;
            //busy rooms&live clients
            stats.BusyRoomNumber = 0;
            stats.LiveClients = 0;
            var rooms = Room.GetRooms();
            foreach (var room in rooms)
            {
                if (!Room.IsRoomAvailable(room.roomNumber))
                {
                    stats.BusyRoomNumber++;
                    stats.LiveClients += (room.childrenCap + room.adultCap);
                }
            }
            //TotalClients
            stats.TotalClients = Payment.GetPayments().Count;
            //Reservations and money earned;
            var res = Reservation.GetReservations();
            stats.Reservations = res.Count;
            stats.MoneyEarned = 0;
            foreach (var reservation in res)
            {
                stats.MoneyEarned += reservation.moneyPaid;
            }
            //return
            return stats;
        }

    }
}