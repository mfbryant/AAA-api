using MySql.Data.MySqlClient;
using api.models.interfaces;

namespace api.models
{
    public class DeleteFavorites : IDeleteFavorite
    {
        public void DeleteFavorite(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"DELETE FROM favorites WHERE favoriteId = {id};";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}