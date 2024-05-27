using System.Data.SqlClient;
using System.Data;

using System.Reflection.Metadata.Ecma335;

namespace Cloud_A1.Models
{
    public class productTable1
    {
        //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string con_string = "Server=tcp:ilyaas-sql-server.database.windows.net,1433;Initial Catalog = ilyaas - DB; Persist Security Info=False;User ID = ilyaaskamish; Password=deadpool123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        public static SqlConnection con = new SqlConnection(con_string);




        public int ProductID { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }



        public int insert_product(productTable1 p)
        {

            
                string sql = "INSERT INTO productTable1 (product_name, product_price, product_category, product_availability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            


        }


        // Method to retrieve all products from the database
        public static List<productTable1> GetAllProducts()
        {
            List<productTable1> products = new List<productTable1>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable1";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable1 product = new productTable1();
                    product.ProductID = Convert.ToInt32(rdr["product_ID"]);
                    product.Name = rdr["product_name"].ToString();
                    product.Price = rdr["product_price"].ToString();
                    product.Category = rdr["product_category"].ToString();
                    product.Availability = rdr["product_availability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }

    }
}
