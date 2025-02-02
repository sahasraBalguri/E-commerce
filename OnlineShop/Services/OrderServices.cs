using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class OrderServices : IOrderServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public OrderServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public string InsertOrder(Order objOrder)
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
                    cmd.Parameters.Add(new SqlParameter("@OrderNo", SqlDbType.VarChar));
                    cmd.Parameters["@OrderNo"].Value = objOrder.OrderNo;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    cmd.Parameters["@Name"].Value = objOrder.Name;
                    cmd.Parameters.Add(new SqlParameter("@PhoneNo", SqlDbType.VarChar));
                    cmd.Parameters["@PhoneNo"].Value = objOrder.PhoneNo;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                    cmd.Parameters["@Email"].Value = objOrder.Email;
                    cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                    cmd.Parameters["@Address"].Value = objOrder.Address;
                    //cmd.Parameters.Add(new SqlParameter("@OrderDetails", SqlDbType.Udt));
                    //cmd.Parameters["@OrderDate"].Value = objOrder.OrderDetails;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_Order";
                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[5].Value.ToString();
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
        public int GetOrderCount(Order objOrder)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_OrderCount", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objOrder.rowCount = Convert.ToInt32(reader["rowCount"]);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objOrder.rowCount;
        }
        public string InsertOrderDetails(DataTable table)
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
                    cmd.Parameters.Add(new SqlParameter("@TempTable", SqlDbType.Structured));
                    cmd.Parameters["@TempTable"].Value = table;
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_OrderDetails";
                    cmd.ExecuteNonQuery();
                    return "Success";
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public interface IOrderServices
    {
        public string InsertOrder(Order objOrder);
        public int GetOrderCount(Order objOrder);
        public string InsertOrderDetails(DataTable table);
    }
}
