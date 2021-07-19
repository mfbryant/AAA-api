using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api.models.interfaces;

namespace api.models
{
    public class ReadEvents : IGetAllEvents, IGetEvent
    {
        public List<Event> GetAllEvents()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from events";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Event> events = new List<Event>();
            while (rdr.Read())
            {
                Event e = new Event()
                {
                    EventId = int.Parse(rdr["eventId"].ToString()),
                    EventName = rdr["eventName"].ToString(),
                    StartDate = DateTime.Parse(rdr["startDate"].ToString()),
                    EndDate = DateTime.Parse(rdr["endDate"].ToString()),
                    Location = rdr["location"].ToString(),
                    EventDeets = rdr["eventDeets"].ToString(),
                    OrgId = int.Parse(rdr["orgId"].ToString()),
                };
                events.Add(e);
            }
            return events;
        }

        public Event GetEvent(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM events WHERE eventId=@eventId";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@eventId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Event()
            {
                EventId = int.Parse(rdr["eventId"].ToString()),
                EventName = rdr["eventName"].ToString(),
                StartDate = DateTime.Parse(rdr["startDate"].ToString()),
                EndDate = DateTime.Parse(rdr["endDate"].ToString()),
                Location = rdr["location"].ToString(),
                EventDeets = rdr["eventDeets"].ToString(),
                OrgId = int.Parse(rdr["orgId"].ToString()),
            };
        }
    }
}