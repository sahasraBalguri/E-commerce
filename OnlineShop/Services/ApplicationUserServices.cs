using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public ApplicationUserServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }
        public List<ApplicationUser> GetApplicationUsers()
        {
            try
            {
                List<ApplicationUser> ApplicationUserList = new List<ApplicationUser>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_ApplicationUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ApplicationUser applicationUser = new ApplicationUser();
                        applicationUser.Id = reader["ID"].ToString();
                        applicationUser.UserName = reader["UserName"].ToString();
                        applicationUser.NormalizedUserName = reader["NormalizedUserName"].ToString();
                        //applicationUser.Email = reader["Email"].ToString();
                        //applicationUser.NormalizedEmail = reader["NormalizedEmail"].ToString();
                        applicationUser.EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]);
                        applicationUser.PasswordHash = reader["PasswordHash"].ToString();
                        applicationUser.SecurityStamp = reader["SecurityStamp"].ToString();
                        applicationUser.ConcurrencyStamp = reader["ConcurrencyStamp"].ToString();
                        //applicationUser.PhoneNumber = reader["PhoneNumber"].ToString(); 
                        //applicationUser.PhoneNumberConfirmed = Convert.ToBoolean(reader["PhoneNumberConfirmed"]); 
                        applicationUser.TwoFactorEnabled = Convert.ToBoolean(reader["TwoFactorEnabled"]);
                        //if (reader["LockoutEnd"] == System.DBNull)
                        //{
                        //    applicationUser.LockoutEnd = new DateTime();
                        //}
                        //else
                        //{
                            applicationUser.LockoutEnd = (DateTimeOffset?)reader["LockoutEnd"];
                        //}                        
                        applicationUser.LockoutEnabled = Convert.ToBoolean(reader["LockoutEnabled"]);
                        applicationUser.AccessFailedCount = Convert.ToInt32(reader["AccessFailedCount"]);
                        //applicationUser.Discriminator = produreader["NormalizedEmail"].ToString(); 
                        applicationUser.FirstName = reader["FirstName"].ToString();
                        applicationUser.LastName = reader["LastName"].ToString();

                        ApplicationUserList.Add(applicationUser);
                    }
                }
                return ApplicationUserList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ApplicationUser GetUser(string? id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_UserIdWise", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                ApplicationUser applicationUser = new ApplicationUser();
                //ProductTypes productTypes = new ProductTypes();
                //SpecialTags specialTags = new SpecialTags();
                while (reader.Read())
                {
                    applicationUser.Id = reader["ID"].ToString();
                    applicationUser.UserName = reader["UserName"].ToString();
                    applicationUser.NormalizedUserName = reader["NormalizedUserName"].ToString();
                    //applicationUser.Email = reader["Email"].ToString();
                    //applicationUser.NormalizedEmail = reader["NormalizedEmail"].ToString();
                    applicationUser.EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]);
                    applicationUser.PasswordHash = reader["PasswordHash"].ToString();
                    applicationUser.SecurityStamp = reader["SecurityStamp"].ToString();
                    applicationUser.ConcurrencyStamp = reader["ConcurrencyStamp"].ToString();
                    //applicationUser.PhoneNumber = reader["PhoneNumber"].ToString(); 
                    //applicationUser.PhoneNumberConfirmed = Convert.ToBoolean(reader["PhoneNumberConfirmed"]); 
                    applicationUser.TwoFactorEnabled = Convert.ToBoolean(reader["TwoFactorEnabled"]);
                    //applicationUser.LockoutEnd = Convert.ToDateTime(reader["LockoutEnd"]); 
                    applicationUser.LockoutEnabled = Convert.ToBoolean(reader["LockoutEnabled"]);
                    applicationUser.AccessFailedCount = Convert.ToInt32(reader["AccessFailedCount"]);
                    //applicationUser.Discriminator = produreader["NormalizedEmail"].ToString(); 
                    applicationUser.FirstName = reader["FirstName"].ToString();
                    applicationUser.LastName = reader["LastName"].ToString();

                }
                return applicationUser;
            }
        }
        public string InsertUser(ApplicationUser objApplicationUser)
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
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar));
                    cmd.Parameters["@Id"].Value = objApplicationUser.Id;
                    cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar));
                    cmd.Parameters["@UserName"].Value = objApplicationUser.UserName;
                    cmd.Parameters.Add(new SqlParameter("@NormalizedUserName", SqlDbType.NVarChar));
                    cmd.Parameters["@NormalizedUserName"].Value = objApplicationUser.UserName.ToUpper();
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    cmd.Parameters["@Email"].Value = objApplicationUser.Email == null ? "" : objApplicationUser.Email;
                    cmd.Parameters.Add(new SqlParameter("@NormalizedEmail", SqlDbType.NVarChar));
                    cmd.Parameters["@NormalizedEmail"].Value = objApplicationUser.Email == null ? "" : objApplicationUser.Email.ToUpper();
                    cmd.Parameters.Add(new SqlParameter("@EmailConfirmed", SqlDbType.Bit));
                    cmd.Parameters["@EmailConfirmed"].Value = objApplicationUser.EmailConfirmed;
                    cmd.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar));
                    cmd.Parameters["@PasswordHash"].Value = objApplicationUser.PasswordHash;
                    cmd.Parameters.Add(new SqlParameter("@SecurityStamp", SqlDbType.NVarChar));
                    cmd.Parameters["@SecurityStamp"].Value = objApplicationUser.SecurityStamp;
                    cmd.Parameters.Add(new SqlParameter("@ConcurrencyStamp", SqlDbType.NVarChar));
                    cmd.Parameters["@ConcurrencyStamp"].Value = objApplicationUser.ConcurrencyStamp;
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar));
                    cmd.Parameters["@PhoneNumber"].Value = objApplicationUser.PhoneNumber == null ? "" : objApplicationUser.PhoneNumber;
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumberConfirmed", SqlDbType.Bit));
                    cmd.Parameters["@PhoneNumberConfirmed"].Value = objApplicationUser.PhoneNumberConfirmed;
                    cmd.Parameters.Add(new SqlParameter("@TwoFactorEnabled", SqlDbType.Bit));
                    cmd.Parameters["@TwoFactorEnabled"].Value = objApplicationUser.TwoFactorEnabled;
                    cmd.Parameters.Add(new SqlParameter("@LockoutEnd", SqlDbType.DateTimeOffset));
                    cmd.Parameters["@LockoutEnd"].Value = objApplicationUser.LockoutEnd == null ? DateTimeOffset.Now : objApplicationUser.LockoutEnd;
                    cmd.Parameters.Add(new SqlParameter("@LockoutEnabled", SqlDbType.Bit));
                    cmd.Parameters["@LockoutEnabled"].Value = objApplicationUser.LockoutEnabled;
                    cmd.Parameters.Add(new SqlParameter("@AccessFailedCount", SqlDbType.Int));
                    cmd.Parameters["@AccessFailedCount"].Value = objApplicationUser.AccessFailedCount;
                    cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                    cmd.Parameters["@FirstName"].Value = objApplicationUser.FirstName;
                    cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                    cmd.Parameters["@LastName"].Value = objApplicationUser.LastName;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_User";
                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[17].Value.ToString();
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
        public string InsertUserRole(ApplicationUser objApplicationUser, string Role)
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
                    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
                    cmd.Parameters["@UserId"].Value = objApplicationUser.Id;
                    cmd.Parameters.Add(new SqlParameter("@Role", SqlDbType.NVarChar));
                    cmd.Parameters["@Role"].Value = Role;
                    cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                    cmd.Parameters["@FirstName"].Value = objApplicationUser.FirstName;
                    cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                    cmd.Parameters["@LastName"].Value = objApplicationUser.LastName;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_UserRole";
                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[4].Value.ToString();
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
        public string UpdateUser(ApplicationUser objApplicationUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_UPDATE_User", con);

                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar));
                    cmd.Parameters["@Id"].Value = objApplicationUser.Id;
                    cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar));
                    cmd.Parameters["@UserName"].Value = objApplicationUser.UserName;
                    cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                    cmd.Parameters["@FirstName"].Value = objApplicationUser.FirstName;
                    cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                    cmd.Parameters["@LastName"].Value = objApplicationUser.LastName;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[4].Value.ToString();
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
        public string DeleteUser(ApplicationUser objApplicationUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_DELETE_User", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                    cmd.Parameters["@id"].Value = objApplicationUser.Id;

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
        public string LockOutUser(ApplicationUser objApplicationUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_LockOut_User", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                    cmd.Parameters["@id"].Value = objApplicationUser.Id;

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
        public string ActivateUser(ApplicationUser objApplicationUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_Activate_User", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                    cmd.Parameters["@id"].Value = objApplicationUser.Id;

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
    public interface IApplicationUserServices
    {
        public List<ApplicationUser> GetApplicationUsers();
        public ApplicationUser GetUser(string? id);
        public string InsertUser(ApplicationUser objApplicationUser);
        public string InsertUserRole(ApplicationUser objApplicationUser, string Role);
        public string UpdateUser(ApplicationUser objApplicationUser);
        public string DeleteUser(ApplicationUser objApplicationUser);
        public string LockOutUser(ApplicationUser objApplicationUser);
        public string ActivateUser(ApplicationUser objApplicationUser);
    }
}
