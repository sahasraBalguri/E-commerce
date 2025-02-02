using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class HomeServices : IHomeServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public HomeServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<Product> GetProduct(string? ProductType)
        {
            try
            {
                List<Product> ProductList = new List<Product>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_Product", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductType", SqlDbType.NVarChar));
                    cmd.Parameters["@ProductType"].Value = ProductType;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        ProductTypes productTypes = new ProductTypes();
                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = reader["Name"].ToString();
                        product.Price = Convert.ToDecimal(reader["Price"]);
                        product.ProductColor = reader["ProductColor"].ToString();
                        product.IsAvailable = Convert.ToBoolean(reader["IsAvailable"]);
                        productTypes.ProductType = reader["ProductType"].ToString();
                        product.ProductTypes = productTypes;
                        product.Image = reader["Image"].ToString();
                        ProductList.Add(product);
                    }
                }
                return ProductList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Product GetProduct(int? id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_ProductIdWise", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                Product product = new Product();
                ProductTypes productTypes = new ProductTypes();
                //SpecialTags specialTags = new SpecialTags();
                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.Image = Convert.ToString(reader["Image"]);
                    product.ProductColor = reader["ProductColor"].ToString();
                    product.IsAvailable = Convert.ToBoolean(reader["IsAvailable"]);
                    product.ProductTypeId = Convert.ToInt32(reader["ProductTypeId"]);
                    product.SpecialTagId = Convert.ToInt32(reader["SpecialTagId"]);
                    productTypes.ProductType = reader["ProductType"].ToString();
                    product.ProductTypes = productTypes;
                    //specialTags.SpecialTag = 

                }
                return product;
            }
        }
    }

    public interface IHomeServices
    {
        public List<Product> GetProduct(string? ProductType);
        public Product GetProduct(int? id);
    }
}
