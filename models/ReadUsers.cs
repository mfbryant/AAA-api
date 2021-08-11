using System.Reflection.Metadata;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api.models.interfaces;

namespace api.models
{
    public class ReadUsers : IGetAllUsers, IGetUser
    {
        public List<User> GetAllUsers()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from users";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<User> users = new List<User>();
            while (rdr.Read())
            {
                User x = new User()
                {
                    UserId = int.Parse(rdr["userId"].ToString()),
                    UserName = rdr["userName"].ToString(),
                    UserEmail = rdr["userEmail"].ToString(),
                    Executive = Boolean.Parse(rdr["executive"].ToString()),
                    Officer = Boolean.Parse(rdr["officer"].ToString()),
                    OrgId = int.Parse(rdr["orgId"].ToString())
                };
                users.Add(x);
            }
            return users;

        }

        public User GetUser(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM users WHERE userId=@userId";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new User()
            {
                UserId = int.Parse(rdr["userId"].ToString()),
                UserName = rdr["userName"].ToString(),
                UserEmail = rdr["userEmail"].ToString(),
                Executive = Boolean.Parse(rdr["executive"].ToString()),
                Officer = Boolean.Parse(rdr["officer"].ToString()),
                OrgId = int.Parse(rdr["orgId"].ToString())
            };
        }
    }
}