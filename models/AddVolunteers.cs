using MySql.Data.MySqlClient;
using api.models.interfaces;

namespace api.models
{
    public class AddVolunteers : IAddVolunteer
    {
        public void AddVolunteer(Volunteer value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO volunteers(volunteerOrg, volunteerDeets) VALUES(@volunteerOrg, @volunteerDeets)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@volunteerOrg", value.VolunteerOrg);
            cmd.Parameters.AddWithValue("@volunteerDeets", value.VolunteerDeets);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}