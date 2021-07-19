using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace api.models
{
    public class EditEvents : IEditEvent
    {
        public void EditEvent(Event value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE events SET eventName=@eventName, startDate=@startDate, endDate=@endDate, location=@location, eventDeets=@eventDeets, orgId=@orgId WHERE eventId='" + value.EventId + "'";

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