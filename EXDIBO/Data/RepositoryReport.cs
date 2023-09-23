using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;
namespace EXDIBO.Data
{
    public class RepositoryReport
    {

        private static PregnantReport FillPregnantReport(SqlDataReader dr)
        {
            PregnantReport pregnantReport = new ()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                IdMother = Convert.ToInt32(dr["IdMother"]),
                MotherName = dr["MotherName"].ToString(),
                IdFather = Convert.ToInt32(dr["IdFather"]),
                FatherName = dr["FatherName"].ToString(),
                IdBreed = Convert.ToInt32(dr["IdBreed"]),
                BreedName = dr["BreedName"].ToString(),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                FarmName = dr["FarmName"].ToString(),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                GroupName = dr["GroupName"].ToString(),
                Register = Convert.ToDateTime(dr["Register"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return pregnantReport;
        }

        private static BovineReport FillBovineReport(SqlDataReader dr)
        {
            BovineReport animal = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                IdMother = Convert.ToInt32(dr["IdMother"]),
                Mother = dr["Mother"].ToString(),
                IdFather = Convert.ToInt32(dr["IdFather"]),
                Father = dr["Father"].ToString(),
                IdBreed = Convert.ToInt32(dr["IdBreed"]),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                Brand = dr["Brand"].ToString(),
                Name = dr["Name"].ToString(),
                Gender = dr["Gender"].ToString(),
                Born = Convert.ToDateTime(dr["Born"]),
                ProductionMilk = Convert.ToInt32(dr["ProductionMilk"]),
                Birth = Convert.ToInt32(dr["Birth"]),
                Pregnant = Convert.ToBoolean(dr["Pregnant"]),
                Ovulation = Convert.ToDateTime(dr["Ovulation"]),
                OvulationTimes = Convert.ToInt32(dr["OvulationTimes"]),
                StartWeight = Convert.ToDouble(dr["StartWeight"]),
                Weight = Convert.ToDouble(dr["Weight"]),
                FinalWeight = Convert.ToDouble(dr["FinalWeight"]),
                AdmissionDate = Convert.ToDateTime(dr["AdmissionDate"]),
                DischargeDate = Convert.ToDateTime(dr["DischargeDate"]),
                Price = Convert.ToDouble(dr["Price"]),
                Notes = dr["Notes"].ToString(),
                Discards = Convert.ToBoolean(dr["Discards"]),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return animal;
        }

        private static WithdrawalReport FillWithdrawal(SqlDataReader dr)
        {
            WithdrawalReport withdrawal = new()
            {
                Number = Convert.ToInt32(dr["Number"]),
                Bovine = dr["Bovine"].ToString(),
                Farm = dr["Farm"].ToString(),
                Group = dr["Group"].ToString(),
                Name = dr["Name"].ToString(),
                Kind = dr["Kind"].ToString(),
                Apply = dr["Apply"].ToString(),
                Times = Convert.ToInt32(dr["Times"]),
                Withdrawal = Convert.ToInt32(dr["Withdrawal"]),
                Register = Convert.ToDateTime(dr["Register"]),
                EndWithdrawal = new DateTime()
            };
            DateTime end = withdrawal.Register;
            withdrawal.EndWithdrawal = end.AddDays(Convert.ToDouble(withdrawal.Withdrawal));
            return withdrawal;
        }

        private static Born FillBorn(SqlDataReader dr)
        {
            Born born = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                Bovine = dr["Bovine"].ToString(),
                ProductionMilk = Convert.ToInt32(dr["ProductionMilk"]),
                Breed = dr["Breed"].ToString(),
                Farm = dr["Farm"].ToString(),
                Group = dr["Group"].ToString(),
                Ovulation = Convert.ToDateTime(dr["Ovulation"]),
                Originate = Convert.ToDateTime(dr["originate"])
            };
            return born;
        }

        public List<PregnantReport> PregnantReport(DateTime From, DateTime To)
        {
            List<PregnantReport> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 00:00:00.000";
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_ovulation_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(FillPregnantReport(dr));
                }
            }
            return report;
        }

        public List<BovineReport> BornReport(DateTime From, DateTime To)
        {
            List<BovineReport> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " " + To.Hour + ":" + To.Minute + ":00.000";
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_born_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(FillBovineReport(dr));
                }
            }
            return report;
        }

        public List<Bovine> DiscardReport(DateTime From, DateTime To)
        {
            List<Bovine> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " " + To.Hour + ":" + To.Minute + ":00.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_discard_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(repository.FillBovine(dr));
                }
            }
            return report;
        }

        public List<SeriePastel> BornByMonthReport(DateTime From, DateTime To)
        {
            List<SeriePastel> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_born_by_month_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SeriePastel serie = new()
                    {
                        name = dr["Month"].ToString(),
                        y = Convert.ToDouble(dr["Born"])
                    };
                    report.Add(serie);
                }
            }
            return report;
        }

        public List<WithdrawalReport> WithdrawalReport(DateTime From, DateTime To)
        {
            List<WithdrawalReport> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_withdrawal_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(FillWithdrawal(dr));
                }
            }
            return report;
        }

        public List<WithdrawalReport> ImplantReport(DateTime From, DateTime To)
        {
            List<WithdrawalReport> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_implant_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(FillWithdrawal(dr));
                }
            }
            return report;
        }

        public Serie GetPregnancy(DateTime From, DateTime To)
        {
            Serie serie = new(new List<string>(), new List<int>(), new List<int>(), new List<int>());
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_pregnant_report_from_to", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    serie.Months.Add(Convert.ToString(dr["Months"]));
                    serie.Pregnants.Add(Convert.ToInt32(dr["Pregnants"]));
                    serie.Emptys.Add(Convert.ToInt32(dr["Emptys"]));
                    serie.Total.Add(Convert.ToInt32(dr["Total"]));
                }
            }
            return serie;
        }

        public List<Born> GetBornByMonth(DateTime From, DateTime To)
        {
            List<Born> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            RepositoryAnimal repository = new();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_gonna_born_by_month", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report.Add(FillBorn(dr));
                }
            }
            return report;
        }

        public List<ProductionReport> GetDealyProductionFromTo(DateTime From, DateTime To)
        {
            List<ProductionReport> report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_report_production", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   report.Add( new () {
                       Id = Convert.ToInt32(dr["Id"]),
                       Codigo = dr["Codigo"].ToString(),
                       Production = Convert.ToInt32(dr["Production"]),
                       IdBovine = Convert.ToInt32(dr["IdBovine"]),
                       Number = Convert.ToInt32(dr["Number"]), 
                       Earring = Convert.ToString(dr["Earring"]),
                       Name = Convert.ToString(dr["Name"]),
                       Pregnant = Convert.ToBoolean(dr["Pregnant"]),
                       Register = Convert.ToDateTime(dr["Register"]),
                       Status = Convert.ToBoolean(dr["Status"])
                    });
                }
            }
            return report;
        }

        public Production GetReportProductionAverage(DateTime From, DateTime To)
        {
            Production report = new();
            string from = From.Year + "-" + From.Month + "-" + From.Day + " 00:00:00.000";
            string to = To.Year + "-" + To.Month + "-" + To.Day + " 23:59:50.000";
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_report_production_average", connection);
                cmd.Parameters.AddWithValue("Desde", from);
                cmd.Parameters.AddWithValue("Hasta", to);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report = new Production()
                    {
                        Id = Convert.ToInt32(dr["Cows"]),
                        IdBovine = Convert.ToInt32(dr["Production"]),
                        Output = Convert.ToDouble(dr["Average"]),
                        Register = Convert.ToDateTime(dr["From"]),
                        Name = Convert.ToString(dr["To"]),
                        IdFarm = 0,
                        IdGroup = 0,
                        Status = true
                    };
                }
            }
            return report;
        }


    }
}
 