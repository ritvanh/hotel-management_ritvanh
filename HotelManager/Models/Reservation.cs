using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelManagement;
using HotelManagement.Models;
namespace HotelManager.Models
{
    public class Reservation
    {
        public String reservationReference { get; set; }
        public int status { get; set; }
        public int roomNumber { get; set; }
        [Required]
        public DateTime arrivalDate { get; set; }
        [Required]
        public DateTime departionDate { get; set; }
        public decimal moneyPaid { get; set; }

        public static bool Add(Reservation model)
        {
            if (IsRoomFree(model))
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                    {
                        var room = Room.GetRoomByNumber(model.roomNumber);
                        double money;
                        if (model.arrivalDate.Month >= 6 && model.arrivalDate.Month <= 9 || model.arrivalDate.Month == 12)
                        {
                            money = room.specialPrice * ((model.departionDate - model.arrivalDate).TotalDays);

                        }
                        else
                        {
                            money = room.basePrice * ((model.departionDate - model.arrivalDate).TotalDays);
                        }
                        var reference = Guid.NewGuid().ToString();
                        model.reservationReference = reference;
                        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Reservations VALUES({model.roomNumber},'{model.arrivalDate}','{model.departionDate}',{money},'{model.reservationReference}',{0})", con))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;
                            con.Open();
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                return true;
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
        public static List<Reservation> GetReservations()
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reservations", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            reservations.Add(new Reservation()
                            {
                                roomNumber = (int)reader["roomNumber"],
                                arrivalDate = ((DateTime)reader["arrivalDate"]).Date,
                                departionDate = (DateTime)reader["departionDate"],
                                moneyPaid = (decimal)reader["moneyPaid"],
                                reservationReference = (string)reader["reservationReference"],
                                status = (int)reader["status"]
                            });
                        }
                        return reservations;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static bool IsRoomFree(Reservation res)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Reservations WHERE roomNumber={res.roomNumber}", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DateTime arrival = (DateTime)reader["arrivalDate"];
                            DateTime departion = (DateTime)reader["departionDate"];
                            if (arrival <= res.departionDate && res.arrivalDate <= departion)
                            {
                                return false;
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public static bool UpdateStatus(String reference)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Reservations SET status=1 WHERE reservationReference='{reference}'", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public static Reservation GetReservationByReference(String reference)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Reservations WHERE reservationReference='{reference}'", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            return new Reservation()
                            {
                                roomNumber = (int)reader["roomNumber"],
                                arrivalDate = (DateTime)reader["arrivalDate"],
                                departionDate = (DateTime)reader["departionDate"],
                                moneyPaid = (decimal)reader["moneyPaid"],
                                reservationReference = (string)reader["reservationReference"],
                                status = (int)reader["status"]
                            };
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}