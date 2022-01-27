using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using HotelManagement;
namespace HotelManager.Models
{
    public enum Role : byte
    {
        None = 0,
        Manager = 1,
        Supervisor = 2
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public static Person Login(PersonLoginRequest model)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Persons WHERE Email='{model.Email}' AND Password='{model.Password}'", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            return new Person()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Surname = (string)reader["Surname"],
                                Email = (string)reader["Email"],
                                Role = (Role)reader["Role"],
                                Password = (string)reader["Password"]
                            };
                        }
                        con.Close();
                    }
                }
            }catch(Exception ex)
            {

            }
            return null;
        }
        public static Person GetPersonByEmail(string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Persons WHERE Email='{email}'", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            return new Person()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Surname = (string)reader["Surname"],
                                Email = (string)reader["Email"],
                                Role = (Role)reader["Role"],
                                Password = (string)reader["Password"]
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
        public static bool Register(PersonAddRequest model)
        {
            try
            {
                if (GetPersonByEmail(model.Email)!=null){ 
                }else
                {
                    using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand($"INSERT INTO Persons(Name,Surname,Email,Role,Password) VALUES('{model.Name}','{model.Surname}','{model.Email}',{(int)model.Role},'{model.Password}')", con))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;
                            con.Open();
                            if(cmd.ExecuteNonQuery() == 1)
                            {
                                return true;
                            }
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

    }
}