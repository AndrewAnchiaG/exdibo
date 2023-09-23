using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;

namespace EXDIBO.Data
{
    public class RepositoryFarm
    {
        private Farm FillFarm(SqlDataReader dr)
        {
            Farm farm = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Code = Convert.ToInt32(dr["Code"]),
                Name = dr["Name"].ToString(),
                Email = dr["Email"].ToString(),
                Address = dr["Address"].ToString(),
                Register = Convert.ToDateTime(dr["Register"].ToString()),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return farm;
        }
       
        private Group FillGroup(SqlDataReader dr)
        {
            Group group = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                Number = dr["Number"].ToString(),
                Name = dr["Name"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return group;
        }

        public List<Farm> GetAllFarm()
        {
            var farmlist = new List<Farm>();
            var conn = new DBContext();

            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_farm_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    farmlist.Add(FillFarm(dr));
                }
            }
            return farmlist;
        }

        public List<Group> GetAllGroup()
        {
            var grouplist = new List<Group>();

            var conn = new DBContext();

            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_group_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    grouplist.Add(FillGroup(dr));
                }
            }
            return grouplist;
        }
    }
}
