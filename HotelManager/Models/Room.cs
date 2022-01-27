using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HotelManagement;
namespace HotelManagement.Models
{
    public class Room
    {
        public int roomNumber { get; set; }
        public string roomName { get; set; }
        public int adultCap { get; set; }
        public int childrenCap { get; set; }
        public double basePrice { get; set; }
        public double specialPrice { get; set; }
        public int luxuryIndex { get; set; }
        public static List<Room> GetRooms()
        {
            try
            {
                List<Room> rooms = new List<Room>();
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Rooms", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            rooms.Add(new Room()
                            {
                                roomNumber = (int)reader["roomNumber"],
                                roomName = (string)reader["roomName"],
                                adultCap = (int)reader["adultCap"],
                                childrenCap = (int)reader["childrenCap"],
                                luxuryIndex = (int)reader["luxuryIndex"],
                                basePrice = Convert.ToDouble(reader["basePrice"]),
                                specialPrice = Convert.ToDouble(reader["specialPrice"])
                            });
                        }
                        return rooms;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public static bool InsertRoom(Room room)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand($"INSERT INTO Rooms VALUES({room.roomNumber},'{room.roomName}',{room.adultCap},{room.childrenCap},{(room.luxuryIndex * 5) * ((room.childrenCap * 0.5) + room.adultCap)},{((room.luxuryIndex+1) * 5) * ((room.childrenCap * 0.5) + room.adultCap)},{room.luxuryIndex})", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                            return true;
                        con.Close();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return false;
        }
        public static bool DeleteRoom(int number)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand($"DELETE FROM Rooms WHERE roomNumber={number}", con))
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
        public static Room GetRoomByNumber(int number)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using(SqlCommand cmd = new SqlCommand($"SELECT * FROM Rooms WHERE roomNumber={number}", con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        var room = new Room();
                        while (reader.Read())
                        {
                            room.roomNumber = (int)reader["roomNumber"];
                            room.roomName = (string)reader["roomName"];
                            room.adultCap = (int)reader["adultCap"];
                            room.childrenCap = (int)reader["childrenCap"];
                            room.luxuryIndex = (int)reader["luxuryIndex"];
                            room.basePrice = Convert.ToDouble(reader["basePrice"]);
                            room.specialPrice = Convert.ToDouble(reader["specialPrice"]);
                        }
                        con.Close();
                        return room;
                    }
                }
            }catch(Exception ex)
            {

            }
            return null;
        }
        public static bool UpdateRoom(Room room)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Tools.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand($"UPDATE Rooms SET roomNumber={room.roomNumber}, roomName='{room.roomName}', adultCap={room.adultCap}, childrenCap={room.childrenCap}, " +
                        $"basePrice={room.basePrice}, specialPrice={room.specialPrice}, luxuryIndex={room.luxuryIndex} WHERE roomNumber={room.roomNumber}", con))
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
            catch(Exception ex){

            }
            return false;
        }
    }
}