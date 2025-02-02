using Microsoft.AspNetCore.Identity;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class RoleServices : IRoleServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public RoleServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<Role> GetRole()
        {
            try
            {
                List<Role> RoleList = new List<Role>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_Role", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.Id = reader["Id"].ToString();
                        role.UserName = reader["UserName"].ToString();

                        RoleList.Add(role);
                    }
                }
                return RoleList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UserRoleMaping> GetAllUser()
        {
            List<UserRoleMaping> UserRoleMapingList = new List<UserRoleMaping>();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_AllUSER", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                
               
                while (reader.Read())
                {
                    UserRoleMaping userRoleMaping = new UserRoleMaping();
                    userRoleMaping.UserId = reader["UserId"].ToString();
                    userRoleMaping.RoleId = reader["RoleId"].ToString();
                    userRoleMaping.UserName = Convert.ToString(reader["UserName"]);
                    userRoleMaping.RoleName = Convert.ToString(reader["RoleName"]);

                    UserRoleMapingList.Add(userRoleMaping);
                }
                return UserRoleMapingList;
            }
        }

        public IdentityUser GetUser(string? id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_UserIdRole", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                IdentityUser identityUser = new IdentityUser();
                //ProductTypes productTypes = new ProductTypes();
                //SpecialTags specialTags = new SpecialTags();
                while (reader.Read())
                {
                    identityUser.UserName = reader["UserName"].ToString();
                    identityUser.Id = reader["Id"].ToString();                                    

                }
                return identityUser;
            }
        }
        public string UpdateRole(string UserId, string RoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_UPDATE_UserRole", con);

                    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
                    cmd.Parameters["@UserId"].Value = UserId;
                    cmd.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.NVarChar));
                    cmd.Parameters["@RoleId"].Value = RoleId;
                    
                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    string strApplicationIDout = cmd.Parameters[2].Value.ToString();
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
        public SessionUserVm GetUserRoleInfo(string? EmailId)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_UserRoleInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                cmd.Parameters["@EmailId"].Value = EmailId;

                SqlDataReader reader = cmd.ExecuteReader();

                SessionUserVm objSessionUserVm = new SessionUserVm();                
                while (reader.Read())
                {
                    objSessionUserVm.UserName = reader["UserName"].ToString();
                    objSessionUserVm.RoleName = reader["RoleName"].ToString();

                }
                return objSessionUserVm;
            }
        }
    }

    public interface IRoleServices
    {
        public List<Role> GetRole();
        public List<UserRoleMaping> GetAllUser();
        public IdentityUser GetUser(string? id);
        public string UpdateRole(string UserId, string RoleId);
        public SessionUserVm GetUserRoleInfo(string? EmailId);
    }
}
