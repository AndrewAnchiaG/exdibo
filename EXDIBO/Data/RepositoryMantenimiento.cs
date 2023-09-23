using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;


namespace EXDIBO.Data
{
    public class RepositoryMantenimiento
    {

        public bool StatusIlness(int Id, bool Status)
        {
            bool resolution;
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_status_ilness", connection);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.Parameters.AddWithValue("Status", Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resolution = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                resolution = false;
            }
            return resolution;
        }
    }
}
