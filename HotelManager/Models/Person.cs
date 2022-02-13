using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using HotelManagement;
using HotelManager;
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
        public static bool Edit(Person model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Persons SET Password='{model.Password}' WHERE Email={model.Email}", con))
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
        public static List<Person> GetPersons()
        {
            try
            {
                List<Person> persons = new List<Person>();
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Persons", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            persons.Add(new Person()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Surname = (string)reader["Surname"],
                                Email = (string)reader["Email"],
                                Password = (string)reader["Password"],
                                Role = (Role)reader["Role"]
                            });
                        }
                        return persons;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static bool DeletePerson(int id)
        {
            try
            {
                    using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand($"DELETE FROM Persons WHERE Id={id}",con))
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
        public static Person GetPersonById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Persons WHERE Id={id}", con))
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
        public static bool UpdatePerson(Person model)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand($"UPDATE Persons SET Name='{model.Name}',Surname='{model.Surname}',Email='{model.Email}',Role={(int)model.Role},Password='{model.Password}' WHERE Id={model.Id}", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        if (cmd.ExecuteNonQuery() == 1) { return true; }
                        con.Close();
                    }
                }
            }catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}