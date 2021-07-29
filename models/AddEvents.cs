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

            string stm = @"INSERT INTO events(eventName, startDate, endDate, location, eventDeets, orgId, eventDraft, eventPending, eventApproved, userId) VALUES(@eventName, @startDate, @endDate, @location, @eventDeets, @orgId, @eventDraft, @eventPending, @eventApproved, @userId)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@eventName", value.EventName);
            cmd.Parameters.AddWithValue("@startDate", value.StartDate);
            cmd.Parameters.AddWithValue("@endDate", value.EndDate);
            cmd.Parameters.AddWithValue("@location", value.Location);
            cmd.Parameters.AddWithValue("@eventDeets", value.EventDeets);
            cmd.Parameters.AddWithValue("@orgId", value.OrgId);
            cmd.Parameters.AddWithValue("@eventDraft", value.EventDraft);
            cmd.Parameters.AddWithValue("@eventPending", value.EventPending);
            cmd.Parameters.AddWithValue("@eventApproved", value.EventApproved);
            cmd.Parameters.AddWithValue("@userId", value.UserId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}