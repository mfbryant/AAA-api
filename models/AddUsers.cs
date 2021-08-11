using MySql.Data.MySqlClient;
using api.models.interfaces;

namespace api.models
{
    public class AddUsers : IAddUser
    {
        public void AddUser(User value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(userName, userEmail, executive, officer, orgId) VALUES(@userName, @userEmail, @executive, @officer, @orgId)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userName", value.UserName);
            cmd.Parameters.AddWithValue("@userEmail", value.UserEmail);
            cmd.Parameters.AddWithValue("@executive", value.Executive);
            cmd.Parameters.AddWithValue("@officer", value.Officer);
            cmd.Parameters.AddWithValue("@orgId", value.OrgId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}