using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class ProductServices : IProductServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public ProductServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<Product> GetProduct()
        {
            try
            {
                List<Product> ProductList = new List<Product>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_Product", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        product.ProductTypes= productTypes;

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

        public string IsExistProduct(Product objProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_IsExists_Product", con);

                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
                    cmd.Parameters["@Name"].Value = objProduct.Name;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[1].Value.ToString();
                    return strApplicationIDout;                   
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public string InsertProduct(Product objProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    cmd.Parameters["@Name"].Value = objProduct.Name;
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal));
                    cmd.Parameters["@Price"].Value = objProduct.Price;
                    cmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarChar));
                    cmd.Parameters["@Image"].Value = objProduct.Image; 
                    cmd.Parameters.Add(new SqlParameter("@ProductColor", SqlDbType.VarChar));
                    cmd.Parameters["@ProductColor"].Value = objProduct.ProductColor;
                    cmd.Parameters.Add(new SqlParameter("@IsAvailable", SqlDbType.Bit));
                    cmd.Parameters["@IsAvailable"].Value = objProduct.IsAvailable;
                    cmd.Parameters.Add(new SqlParameter("@ProductTypeId", SqlDbType.Int));
                    cmd.Parameters["@ProductTypeId"].Value = objProduct.ProductTypeId;
                    cmd.Parameters.Add(new SqlParameter("@SpecialTagId", SqlDbType.Int));
                    cmd.Parameters["@SpecialTagId"].Value = objProduct.SpecialTagId;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_Product";
                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[7].Value.ToString();
                    return "Success";
                    //if (Convert.ToInt32(strApplicationIDout) > 0)
                    //{
                    //    sqltran.Commit();
                    //    return "Success";
                    //}
                    //else
                    //{
                    //    sqltran.Rollback();
                    //    return "Failed";
                    //}
                    //}
                }

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
                //ProductTypes productTypes = new ProductTypes();
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
                    //productTypes.ProductType = reader["ProductType"].ToString();
                    //product.ProductTypes = productTypes;
                    //specialTags.SpecialTag = 

                }
                return product;
            }
        }

        public string UpdateProduct(Product objProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_UPDATE_Product", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objProduct.Id;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    cmd.Parameters["@Name"].Value = objProduct.Name;
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal));
                    cmd.Parameters["@Price"].Value = objProduct.Price;
                    cmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarChar));
                    cmd.Parameters["@Image"].Value = objProduct.Image;
                    cmd.Parameters.Add(new SqlParameter("@ProductColor", SqlDbType.VarChar));
                    cmd.Parameters["@ProductColor"].Value = objProduct.ProductColor;
                    cmd.Parameters.Add(new SqlParameter("@IsAvailable", SqlDbType.Bit));
                    cmd.Parameters["@IsAvailable"].Value = objProduct.IsAvailable;
                    cmd.Parameters.Add(new SqlParameter("@ProductTypeId", SqlDbType.Int));
                    cmd.Parameters["@ProductTypeId"].Value = objProduct.ProductTypeId;
                    cmd.Parameters.Add(new SqlParameter("@SpecialTagId", SqlDbType.Int));
                    cmd.Parameters["@SpecialTagId"].Value = objProduct.SpecialTagId;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[8].Value.ToString();
                    return "Success";
                    //if (Convert.ToInt32(strApplicationIDout) > 0)
                    //{
                    //    sqltran.Commit();
                    //    return "Success";
                    //}
                    //else
                    //{
                    //    sqltran.Rollback();
                    //    return "Failed";
                    //}
                    //}
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteProduct(Product objProduct)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_DELETE_Product", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objProduct.Id;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[1].Value.ToString();
                    return "Success";
                    //if (Convert.ToInt32(strApplicationIDout) > 0)
                    //{
                    //    sqltran.Commit();
                    //    return "Success";
                    //}
                    //else
                    //{
                    //    sqltran.Rollback();
                    //    return "Failed";
                    //}
                    //}
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Product> SearchProduct(decimal? lowAmount, decimal? largeAmount)
        {
            try
            {
                List<Product> ProductList = new List<Product>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_SEARCH_Product", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@lowAmount", SqlDbType.Decimal));
                    cmd.Parameters["@lowAmount"].Value = lowAmount;
                    cmd.Parameters.Add(new SqlParameter("@largeAmount", SqlDbType.Decimal));
                    cmd.Parameters["@largeAmount"].Value = largeAmount;

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
    }

    public interface IProductServices
    {
        public List<Product> GetProduct();
        public string IsExistProduct(Product objProduct);
        public string InsertProduct(Product objProduct);
        public Product GetProduct(int? id);
        public string UpdateProduct(Product objProduct);
        public string DeleteProduct(Product objProduct);
        public List<Product> SearchProduct(decimal? lowAmount, decimal? largeAmount);
    }
}
