using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api.models.interfaces;

namespace api.models
{
    public class ReadVolunteers : IGetAllVolunteers, IGetVolunteer
    {
        public List<Volunteer> GetAllVolunteers()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from volunteers";
            using var cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Volunteer> volunteers = new List<Volunteer>();
            while (rdr.Read())
            {
                Volunteer x = new Volunteer()
                {
                    VolunteerId = int.Parse(rdr["volunteerId"].ToString()),
                    VolunteerOrg = rdr["volunteerOrg"].ToString(),
                    VolunteerDeets = rdr["volunteerDeets"].ToString(),

                };
                volunteers.Add(x);
            }
            return volunteers;
        }

        public Volunteer GetVolunteer(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM volunteers WHERE volunteerId=@volunteerId";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@volunteerId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Volunteer()
            {
                VolunteerId = int.Parse(rdr["volunteerId"].ToString()),
                VolunteerOrg = rdr["volunteerOrg"].ToString(),
                VolunteerDeets = rdr["volunteerDeets"].ToString(),
            };
        }
    }
}