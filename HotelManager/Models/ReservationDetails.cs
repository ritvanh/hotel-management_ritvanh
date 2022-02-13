using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HotelManagement;
using HotelManagement.Models;
namespace HotelManager.Models
{
    public class ReservationDetails
    {
        public String reservationReference { get; set; }
        public int roomNumber { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime departionDate { get; set; } 

        public decimal moneyPaid { get; set; }  
        public String cardHolder { get; set; }
        public String cardNumber { get; set; }
        public static List<ReservationDetails> GetFullReservations()
        {
            List<ReservationDetails> result = new List<ReservationDetails>();
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand($"SELECT Reservations.reservationReference, Reservations.roomNumber, Reservations.arrivalDate, Reservations.departionDate, Reservations.moneyPaid, Payments.cardHolder, Payments.cardNumber FROM Reservations JOIN Payments ON Reservations.reservationReference=Payments.reservationReference", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new ReservationDetails()
                            {
                                reservationReference = (String)reader["reservationReference"],
                                roomNumber = (int)reader["roomNumber"],
                                arrivalDate = (DateTime)reader["arrivalDate"],
                                departionDate = (DateTime)reader["departionDate"],
                                moneyPaid = (decimal)reader["moneyPaid"],
                                cardHolder = (String)reader["cardHolder"],
                                cardNumber = (String)reader["cardNumber"]
                                
                            });
                        }
                        con.Close();
                    }
                }
            }catch(Exception ex)
            {

            }
            return result;
        }
    }
}