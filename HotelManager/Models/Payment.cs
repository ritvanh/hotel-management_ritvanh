using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelManagement;

namespace HotelManager.Models
{
    public class Payment
    {
        public String reservationReference { get; set; }
        public String cardHolder { get; set; }
        public String cardNumber { get; set; }
        public String expirationDate { get; set; }
        public static bool Add(Payment model)
        {
                try
                {

                    using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Payments VALUES('{model.reservationReference}','{model.cardHolder}','{model.cardNumber}','{model.expirationDate}')", con))
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
        public static List<Payment> GetPayments()
        {
            try
            {
                List<Payment> pays = new List<Payment>();
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payments", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            pays.Add(new Payment()
                            {
                                reservationReference = (String)reader["reservationReference"],
                                cardHolder = (String)reader["cardHolder"],
                                cardNumber = (String)reader["cardNumber"],
                                expirationDate = (String)reader["expirationDate"]
                            });
                        }
                        return pays;
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
