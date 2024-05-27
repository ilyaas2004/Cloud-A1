using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;


using System.Collections.Generic;

namespace Cloud_A1.Models
{
    public class userTable2
    {
        public static string con_string = "Server=tcp:ilyaas-sql-server.database.windows.net,1433;Initial Catalog=ilyaas-DB;Persist Security Info=False;User ID=ilyaaskamish;Password=deadpool123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public userTable2 () { }    

        public string Name { get; set; }
        //public int ID { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        

        public List<userTable2> GetAllUsers()
        {
            List<userTable2> users = new List<userTable2>();
            string sql = "SELECT * FROM userTable1";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userTable2 user = new userTable2();
                user.Name = reader["user_Name"].ToString();
                user.Surname = reader["user_Surname"].ToString();
                user.Email = reader["user_Email"].ToString();
                user.Password = reader["user_Password"].ToString();
                users.Add(user);
            }
            con.Close();
            return users;
        }

        public int insert_User(userTable2 m)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO userTable2 (user_Name, user_Surname, user_Email, user_Password) VALUES (@Name, @Surname, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                cmd.Parameters.AddWithValue("@Password", m.Password);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return 0; // Return 0 indicating failure
            }
            finally
            {
                con.Close();
            }


        }
    }
}

//declaring string with object name "sql" where we will write the insert statements
//string sql = @"insert into userTable([[userName], [userSurname], [userEmail]) values(" + m.Name + ", " + m.Surname + ", " + m.Email + ")";


//SqlCommand cmd = new SqlCommand(sql, con);


//return cmd.ExecuteNonQuery();


//same methods below, but as you can see.. much longer to complete
