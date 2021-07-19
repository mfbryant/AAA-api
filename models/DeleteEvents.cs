using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace api.models
{
    public class DeleteEvents : IDeleteEvent
    {
        public void DeleteEvent(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM events WHERE eventId='" + id + "'";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}