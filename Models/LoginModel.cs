using System.Data.SqlClient;

namespace Cloud_A1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:ilyaas-sql-server.database.windows.net,1433;Initial Catalog = ilyaas - DB; Persist Security Info=False;User ID = ilyaaskamish; Password=deadpool123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";


        public int SelectUser(string email, string name)
        {
            int userId = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT user_ID FROM userTable2 WHERE user_Email = @Email AND user_Name = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw ex;
                }
            }
            return userId;
        }

    }
}
    

