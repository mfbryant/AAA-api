using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api.models.interfaces;

namespace api.models
{
    public class ReadAttendance : IGetAllAttendance, IGetAttendance
    {
        public List<Attendance> GetAllAttendance()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from attendance";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Attendance> attendances = new List<Attendance>();
            while (rdr.Read())
            {
                Attendance x = new Attendance()
                {
                    AttendanceId = int.Parse(rdr["attendanceId"].ToString()),
                    EventId = int.Parse(rdr["eventId"].ToString()),
                    UserId = int.Parse(rdr["userId"].ToString())
                };
                attendances.Add(x);
            }
            return attendances;
        }

        public Attendance GetAttendance(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM attendance WHERE attendanceId=@attendanceId";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@attendanceId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Attendance()
            {
                AttendanceId = int.Parse(rdr["attendanceId"].ToString()),
                EventId = int.Parse(rdr["eventId"].ToString()),
                UserId = int.Parse(rdr["userId"].ToString())
            };
        }
    }
}