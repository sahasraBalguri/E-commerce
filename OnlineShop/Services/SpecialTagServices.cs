using OnlineShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShop.Services
{
    public class SpecialTagServices : ISpecialTagServices
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;

        public SpecialTagServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
        }

        public List<SpecialTags> GetSpecialTag()
        {
            try
            {
                List<SpecialTags> SpecialTagList = new List<SpecialTags>();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("USP_GET_SpecialTags", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SpecialTags specialTag = new SpecialTags();
                        specialTag.Id = Convert.ToInt32(reader["Id"]);
                        specialTag.SpecialTag = reader["SpecialTag"].ToString();

                        SpecialTagList.Add(specialTag);
                    }
                }
                return SpecialTagList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string InsertSpecialTag(SpecialTags objSpecialTag)
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
                    cmd.Parameters.Add(new SqlParameter("@SpecialTag", SqlDbType.VarChar));
                    cmd.Parameters["@SpecialTag"].Value = objSpecialTag.SpecialTag;

                    cmd.Parameters.Add(new SqlParameter("@ApplicationIDout", SqlDbType.VarChar, 100, ParameterDirection.Output, true, 0, 0, "ApplicationIDout", DataRowVersion.Current, ""));


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_INSERT_SpecialTags";
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

        public SpecialTags GetSpecialTag(int? id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                var cmd = new SqlCommand("USP_GET_SpecialTagsIdWise", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                SpecialTags specialTag = new SpecialTags();
                while (reader.Read())
                {
                    specialTag.Id = Convert.ToInt32(reader["Id"]);
                    specialTag.SpecialTag = reader["SpecialTag"].ToString();
                }
                return specialTag;
            }
        }

        public string UpdateSpecialTag(SpecialTags objSpecialTag)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_UPDATE_SpecialTags", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objSpecialTag.Id;
                    cmd.Parameters.Add(new SqlParameter("@SpecialTag", SqlDbType.NVarChar));
                    cmd.Parameters["@SpecialTag"].Value = objSpecialTag.SpecialTag;

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

        public string DeleteSpecialTag(SpecialTags objSpecialTag)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    //using (SqlTransaction sqltran = con.BeginTransaction())
                    //{
                    con.Open();
                    var cmd = new SqlCommand("USP_DELETE_SpecialTags", con);

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = objSpecialTag.Id;

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

    public interface ISpecialTagServices
    {
        public List<SpecialTags> GetSpecialTag();
        public string InsertSpecialTag(SpecialTags objSpecialTag);
        public SpecialTags GetSpecialTag(int? id);
        public string UpdateSpecialTag(SpecialTags objSpecialTag);
        public string DeleteSpecialTag(SpecialTags objSpecialTag);
    }
}
