using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class ProductTypesServices : IProductTypesServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public ProductTypesServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<ProductTypes> GetProductTypes()
        {
            try
            {
                List<ProductTypes> ProductTypesList = new List<ProductTypes>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_ProductTypes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductTypes productTypes = new ProductTypes();
                        productTypes.Id = Convert.ToInt32(reader["Id"]);
                        productTypes.ProductType = reader["ProductType"].ToString();

                        ProductTypesList.Add(productTypes);
                    }
                }
                return ProductTypesList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string InsertProductTypes(ProductTypes objProductTypes)
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
                    cmd.Parameters.Add(new SqlParameter("@ProductType", SqlDbType.VarChar));
                    cmd.Parameters["@ProductType"].Value = objProductTypes.ProductType;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_ProductTypes";
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

        public ProductTypes GetProductTypes(int? id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_ProductTypesIdWise", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                ProductTypes productTypes = new ProductTypes();
                while (reader.Read())
                {
                    productTypes.Id = Convert.ToInt32(reader["Id"]);
                    productTypes.ProductType = reader["ProductType"].ToString();
                }
                return productTypes;
            }
        }

        public string UpdateProductTypes(ProductTypes objProductTypes)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_UPDATE_ProductTypes", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objProductTypes.Id;
                    cmd.Parameters.Add(new SqlParameter("@ProductTypes", SqlDbType.NVarChar));
                    cmd.Parameters["@ProductTypes"].Value = objProductTypes.ProductType;

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

        public string DeleteProductTypes(ProductTypes objProductTypes)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_DELETE_ProductTypes", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objProductTypes.Id;
                    
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
    }

    public interface IProductTypesServices
    {
        public List<ProductTypes> GetProductTypes();
        public string InsertProductTypes(ProductTypes objProductTypes);
        public ProductTypes GetProductTypes(int? id);
        public string UpdateProductTypes(ProductTypes objProductTypes);
        public string DeleteProductTypes(ProductTypes objProductTypes);
    }
}
