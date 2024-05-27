using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cloud_A1.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public ProductDisplayModel() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public ProductDisplayModel(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:ilyaas-sql-server.database.windows.net,1433;Initial Catalog = ilyaas - DB; Persist Security Info=False;User ID = ilyaaskamish; Password=deadpool123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT product_ID, product_name, product_price, product_category, product_availability FROM productTable1";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.ProductID = Convert.ToInt32(reader["productID"]);
                    product.ProductName = Convert.ToString(reader["product_name"]);
                    product.ProductPrice = Convert.ToDecimal(reader["product_price"]);
                    product.ProductCategory = Convert.ToString(reader["product_category"]);
                    product.ProductAvailability = Convert.ToBoolean(reader["product_availability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}

