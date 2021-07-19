using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace api.models
{
    public class AddEvents : IAddEvent
    {
        public void AddEvent(Event value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO events(eventName, startDate, endDate, location, eventDeets, orgId) VALUES(@eventName, @startDate, @endDate, @location, @eventDeets, @orgId)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@eventName", value.EventName);
            cmd.Parameters.AddWithValue("@startDate", value.StartDate);
            cmd.Parameters.AddWithValue("@endDate", value.EndDate);
            cmd.Parameters.AddWithValue("@location", value.Location);
            cmd.Parameters.AddWithValue("@eventDeets", value.EventDeets);
            cmd.Parameters.AddWithValue("@orgId", value.OrgId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}