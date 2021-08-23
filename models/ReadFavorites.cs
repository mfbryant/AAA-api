using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api.models.interfaces;

namespace api.models
{
    public class ReadFavorites : IGetAllFavorites, IGetFavorite
    {
        public List<Favorite> GetAllFavorites()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from favorites";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Favorite> favorites = new List<Favorite>();
            while (rdr.Read())
            {
                Favorite x = new Favorite()
                {
                    FavoriteId = int.Parse(rdr["favoriteId"].ToString()),
                    EventId = int.Parse(rdr["favoriteId"].ToString()),
                    UserId = int.Parse(rdr["favoriteId"].ToString())

                };
                favorites.Add(x);
            }
            return favorites;
        }

        public Favorite GetFavorite(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM favorites WHERE favoriteId=@favoriteId";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@favoriteId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Favorite()
            {
                FavoriteId = int.Parse(rdr["favoriteId"].ToString()),
                EventId = int.Parse(rdr["favoriteId"].ToString()),
                UserId = int.Parse(rdr["favoriteId"].ToString())
            };
        }
    }
}