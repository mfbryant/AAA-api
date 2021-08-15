using MySql.Data.MySqlClient;
using api.models.interfaces;

namespace api.models
{
    public class AddAttendances : IAddAttendance
    {
        public void AddAttendance(Attendance value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO attendance(eventId, userId) VALUES(@eventId, @userId)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@eventId", value.EventId);
            cmd.Parameters.AddWithValue("@userId", value.UserId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}