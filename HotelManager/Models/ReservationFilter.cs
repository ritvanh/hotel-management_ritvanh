using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Models;
using HotelManagement.Models;
namespace HotelManager.Models
{
    public class ReservationFilter:Reservation
    {
        public int adultNum { get; set; }
        public int childNum { get; set; }
        public static List<Room> FilterRooms(ReservationFilter filter)
        {
            var rooms = Room.GetRooms();
            List<Room> filteredRooms = new List<Room>();
            foreach(Room room in rooms)
            {
                Reservation res = new Reservation()
                {
                    roomNumber = room.roomNumber,
                    arrivalDate = filter.arrivalDate,
                    departionDate = filter.departionDate,
                    moneyPaid = 0
                };
                if (room.adultCap >= filter.adultNum && room.childrenCap >= filter.childNum && Reservation.IsRoomFree(res))
                {
                    filteredRooms.Add(room);
                }
            }
            return filteredRooms;
        }
    }
}