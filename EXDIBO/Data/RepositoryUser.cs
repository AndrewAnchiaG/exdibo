using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;

namespace EXDIBO.Data
{
    public class RepositoryUser : IRepositoryUser
    {
        public User FillUser(SqlDataReader dr)
        {
            DateTime DateTimeClass = Convert.ToDateTime(dr["Birth"].ToString());
            User user = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Code = Convert.ToInt32(dr["Code"]),
                DNI = dr["DNI"].ToString(),
                Name = dr["Name"].ToString(),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                Password = dr["Password"].ToString(),
                Birth = DateTimeClass,
                Gender = dr["Gender"].ToString(),
                Job = dr["Job"].ToString(),
                Mobile = dr["Mobile"].ToString(),
                Phone = dr["Phone"].ToString(),
                Role = dr["Role"].ToString(),
                Token = Convert.ToString(dr["Token"]),

                // Finca
                Finca = new List<Farm>(),


                RegisterDate = Convert.ToDateTime(dr["RegisterDate"]),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return user;
        }

        public List<User> GetAllUsers()
        {
            var listUser = new List<User>();
            var conn = new DBContext();

            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_userlist", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listUser.Add(FillUser(dr));
                }
            }
            return listUser;
        }

        public User GetUserById(int IdUser)
        {
            User oUser = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_user_by_id", connection);
                cmd.Parameters.AddWithValue("Id", IdUser);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oUser = FillUser(dr);
                }
            }
            return oUser;
        }

        public User GetValidateUser(string email, string password)
        {
            User oUser = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_validateuser", connection);
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oUser = FillUser(dr);
                }
                else
                {
                    oUser = null;
                }
            }
            return oUser;
        }

        public bool SaveUser(User oUser)
        {
            string RegisterDate = oUser.RegisterDate.Year + "-" + oUser.RegisterDate.Month + "-" + oUser.RegisterDate.Day + " " + oUser.RegisterDate.Hour + ":" + oUser.RegisterDate.Minute + ":" + oUser.RegisterDate.Second + ".000";
            string BirthDate = oUser.Birth.Year + "-" + oUser.Birth.Month + "-" + oUser.Birth.Day;
            bool resolution;
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_user", connection);
                    cmd.Parameters.AddWithValue("Code", oUser.Code);
                    cmd.Parameters.AddWithValue("DNI", oUser.DNI);
                    cmd.Parameters.AddWithValue("Name", oUser.Name);
                    cmd.Parameters.AddWithValue("FirstName", oUser.FirstName);
                    cmd.Parameters.AddWithValue("LastName", oUser.LastName);
                    cmd.Parameters.AddWithValue("Email", oUser.Email);
                    cmd.Parameters.AddWithValue("Password", oUser.Password);
                    cmd.Parameters.AddWithValue("Birth", BirthDate);
                    cmd.Parameters.AddWithValue("Gender", oUser.Gender);
                    cmd.Parameters.AddWithValue("Job", oUser.Job);
                    cmd.Parameters.AddWithValue("Mobile", oUser.Mobile);
                    cmd.Parameters.AddWithValue("Phone", oUser.Phone);
                    cmd.Parameters.AddWithValue("Role", oUser.Role);
                    cmd.Parameters.AddWithValue("Token", oUser.Token);
                    cmd.Parameters.AddWithValue("RegisterDate", RegisterDate);
                    cmd.Parameters.AddWithValue("Status", oUser.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resolution = true;
            }
            catch (Exception)
            {
                resolution = false;
            }
            return resolution;
        }

        public bool EditUser(User oUser)
        {
            string RegisterDate = oUser.RegisterDate.Year + "-" + oUser.RegisterDate.Month + "-" + oUser.RegisterDate.Day + " " + oUser.RegisterDate.Hour + ":" + oUser.RegisterDate.Minute + ":" + oUser.RegisterDate.Second + ".000";
            string BirthDate = oUser.Birth.Year + "-" + oUser.Birth.Month + "-" + oUser.Birth.Day;
            bool resolution;
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_user", connection);
                    cmd.Parameters.AddWithValue("Id", oUser.Id);
                    cmd.Parameters.AddWithValue("Code", oUser.Code);
                    cmd.Parameters.AddWithValue("DNI", oUser.DNI);
                    cmd.Parameters.AddWithValue("Name", oUser.Name);
                    cmd.Parameters.AddWithValue("FirstName", oUser.FirstName);
                    cmd.Parameters.AddWithValue("LastName", oUser.LastName);
                    cmd.Parameters.AddWithValue("Email", oUser.Email);
                    cmd.Parameters.AddWithValue("Password", oUser.Password);
                    cmd.Parameters.AddWithValue("Birth", BirthDate);
                    cmd.Parameters.AddWithValue("Gender", oUser.Gender);
                    cmd.Parameters.AddWithValue("Job", oUser.Job);
                    cmd.Parameters.AddWithValue("Mobile", oUser.Mobile);
                    cmd.Parameters.AddWithValue("Phone", oUser.Phone);
                    cmd.Parameters.AddWithValue("Role", oUser.Role);
                    cmd.Parameters.AddWithValue("Token", oUser.Token);
                    cmd.Parameters.AddWithValue("RegisterDate", RegisterDate);
                    cmd.Parameters.AddWithValue("Status", oUser.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resolution = true;
            }
            catch (Exception)
            {
                resolution = false;
            }
            return resolution;
        }

        public bool ChangeStatusUser(int Id, bool Status)
        {
            bool resolution;
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new("sp_change_status_user", connection);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.Parameters.AddWithValue("Status", Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resolution = true;
            }
            catch (Exception)
            {
                resolution = false;
            }
            return resolution;
        }
    }
}
