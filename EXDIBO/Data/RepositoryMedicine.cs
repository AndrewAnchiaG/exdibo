using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;



namespace EXDIBO.Data
{
    public class RepositoryMedicine
    {

        private Kind FillKind(SqlDataReader dr)
        {
            Kind kind = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return kind;
        }

        private Kind FillIlness(SqlDataReader dr)
        {
            Kind kind = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Enfermedad"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return kind;
        }

        private Medicine FillMedicine(SqlDataReader dr)
        {
            Medicine medicament = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                IdKind = Convert.ToInt32(dr["IdKind"]),
                Kind = dr["Kind"].ToString(),
                Apply = dr["Apply"].ToString(),
                Via = dr["Via"].ToString(),
                Dose = Convert.ToInt32(dr["Dose"]),
                Often = Convert.ToInt32(dr["Often"]),
                Times = Convert.ToInt32(dr["Times"]),
                Withdrawal = Convert.ToInt32(dr["Withdrawal"]),
                Contraindication = dr["Contraindication"].ToString(),
                Register = Convert.ToDateTime(dr["Register"]),
                Note = dr["Note"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return medicament;
        }

        private MedicineRecord FillMedicineRecord(SqlDataReader dr)
        {
            MedicineRecord medicament = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                IdUser = Convert.ToInt32(dr["IdUser"]),
                IdKind = Convert.ToInt32(dr["IdKind"]),
                IdBovine = Convert.ToInt32(dr["IdBovine"]),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                IdMedicine = Convert.ToInt32(dr["IdMedicine"]),
                Register = Convert.ToDateTime(dr["Register"]),
                Notes = dr["Notes"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return medicament;
        }

        private Record FillRecord(SqlDataReader dr)
        {
            Record medicineRecord = new()
            {
                IdRecord = Convert.ToInt32(dr["IdMRecord"]),
                RegisterRecord = Convert.ToDateTime(dr["RegMRecord"]),
                Comment = dr["Comment"].ToString(),
                IdBovine = Convert.ToInt32(dr["IdBovine"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                IdMother = Convert.ToInt32(dr["IdMother"]),
                Mother = dr["Mother"].ToString(),
                IdFather = Convert.ToInt32(dr["IdFather"]),
                Father = dr["Father"].ToString(),
                IdBreed = Convert.ToInt32(dr["IdBreed"]),
                Breed = dr["Breed"].ToString(),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                Farm = dr["Farm"].ToString(),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                Group = dr["Group"].ToString(),
                Gender = dr["Gender"].ToString(),
                Name = dr["Name"].ToString(),
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
                Discards = Convert.ToBoolean(dr["Discards"]),
                Status = Convert.ToBoolean(dr["Status"].ToString()),
                Notes = dr["Notes"].ToString(),
                IdMedicine = Convert.ToInt32(dr["IdMedicine"]),
                Medicine = dr["Medicine"].ToString(),
                IdKind = Convert.ToInt32(dr["IdKind"]),
                Kind = dr["Kind"].ToString(),
                Apply = dr["Apply"].ToString(),
                Via = dr["Via"].ToString(),
                Dose = Convert.ToInt32(dr["Dose"]),
                Often = Convert.ToInt32(dr["Often"]),
                Times = Convert.ToInt32(dr["Times"]),
                Withdrawal = Convert.ToInt32(dr["Withdrawal"]),
                Contraindication = dr["Contraindication"].ToString(),
                Indication = dr["Indication"].ToString(),
                IdUser = Convert.ToInt32(dr["IdUser"]),
                Username = dr["Username"].ToString(),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString()
            };
            return medicineRecord;
        }

        public List<Kind> GetKindMedicine()
        {
            var breedlist = new List<Kind>();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_kind_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    breedlist.Add(FillKind(dr));
                }
            }
            return breedlist;
        }

        public bool SaveMedicine(Medicine medicine)
        {
            bool resolution;
            DateTime now = DateTime.Now;
            string registro = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Second + ".000";
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_insert_medicine", connection);
                    cmd.Parameters.AddWithValue("Name", medicine.Name);
                    cmd.Parameters.AddWithValue("IdKind", medicine.IdKind);
                    cmd.Parameters.AddWithValue("Apply", medicine.Apply);
                    cmd.Parameters.AddWithValue("Via", medicine.Via);
                    cmd.Parameters.AddWithValue("Dose", medicine.Dose);
                    cmd.Parameters.AddWithValue("Often", medicine.Often);
                    cmd.Parameters.AddWithValue("Times", medicine.Times);
                    cmd.Parameters.AddWithValue("Withdrawal", medicine.Withdrawal);
                    cmd.Parameters.AddWithValue("Contraindication", medicine.Contraindication);
                    cmd.Parameters.AddWithValue("Register", registro);
                    cmd.Parameters.AddWithValue("Note", medicine.Note);
                    cmd.Parameters.AddWithValue("Status", medicine.Status);
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

        public bool EditMedicine(Medicine medicine)
        {
            bool resolution;

            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    DateTime now = medicine.Register;
                    string registro = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Second + ".000";
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_update_medicine", connection);
                    cmd.Parameters.AddWithValue("Id", medicine.Id);
                    cmd.Parameters.AddWithValue("Name", medicine.Name);
                    cmd.Parameters.AddWithValue("IdKind", medicine.IdKind);
                    cmd.Parameters.AddWithValue("Apply", medicine.Apply);
                    cmd.Parameters.AddWithValue("Via", medicine.Via);
                    cmd.Parameters.AddWithValue("Dose", medicine.Dose);
                    cmd.Parameters.AddWithValue("Often", medicine.Often);
                    cmd.Parameters.AddWithValue("Times", medicine.Times);
                    cmd.Parameters.AddWithValue("Withdrawal", medicine.Withdrawal);
                    cmd.Parameters.AddWithValue("Contraindication", medicine.Contraindication);
                    cmd.Parameters.AddWithValue("Register", registro);
                    cmd.Parameters.AddWithValue("Note", medicine.Note);
                    cmd.Parameters.AddWithValue("Status", medicine.Status);
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

        public bool StatusMedicine(int Id, bool Status)
        {
            bool resolution;
            try
            {
                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_status_medicine", connection);
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


        public List<Medicine> GetAllMedicine()
        {
            List<Medicine> medicaments = new();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_medicine_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medicaments.Add(FillMedicine(dr));
                }
            }
            return medicaments;
        }

        public List<Medicine> GetAllActiveMedicine()
        {
            List<Medicine> medicaments = new();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_medicine_active_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medicaments.Add(FillMedicine(dr));
                }
            }
            return medicaments;
        }


        public List<MedicineRecord> GetRecords()
        {
            List<MedicineRecord> records = new();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_records_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    records.Add(FillMedicineRecord(dr));
                }
            }
            return records;
        }

        public Medicine GetMedicineById(int id)
        {
            Medicine medicament = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_medicine_by_id", connection);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medicament = FillMedicine(dr);
                }
            }
            return medicament;
        }

        public List<Record> GetRecordByBovine(int IdBovine)
        {
            List<Record> records = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_medicine_record_by_bovine", connection);
                cmd.Parameters.AddWithValue("NumberBovine", IdBovine);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    records.Add(FillRecord(dr));
                }
            }
            return records;
        }

        public List<Record> GetRecordByUser(int IDUser) /// TODO: SEARC By Id   
        {
            List<Record> records = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_medicine_record_by_user", connection);
                cmd.Parameters.AddWithValue("IDUser", IDUser);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    records.Add(FillRecord(dr));
                }
            }
            return records;
        }

        public List<Record> GetRecordByDate(DateTime Desde, DateTime Hasta) /// TODO: SEARC By Id   
        {
            List<Record> records = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_medicine_record_by_date", connection);
                cmd.Parameters.AddWithValue("Desde", Desde);
                cmd.Parameters.AddWithValue("Hasta", Hasta);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    records.Add(FillRecord(dr));
                }
            }
            return records;
        }

        public Record GetRecordById(int IdRecord)
        {
            Record record = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_medicine_record_by_id", connection);
                cmd.Parameters.AddWithValue("IdRecord", IdRecord);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    record = FillRecord(dr);
                }
            }
            return record;
        }

        public List<Kind> GetAllIllness()
        {
            List<Kind> medicaments = new();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_Ilness_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medicaments.Add(FillIlness(dr));
                }
            }
            return medicaments;
        }

        public bool SaveMedicineRecord(MedicineRecord medicineRecord)
        {
            bool resolution;
            try
            {
                DateTime now = DateTime.Now;
                string registro = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Second + ".000";

                var conn = new DBContext();
                using (var connection = new SqlConnection(conn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("sp_insert_medicine_record", connection);
                    cmd.Parameters.AddWithValue("IdUser", medicineRecord.IdUser);
                    cmd.Parameters.AddWithValue("IdMedicine", medicineRecord.IdMedicine);
                    cmd.Parameters.AddWithValue("IdBovine", medicineRecord.IdBovine);
                    cmd.Parameters.AddWithValue("IdFarm", medicineRecord.IdFarm);
                    cmd.Parameters.AddWithValue("IdGroup", medicineRecord.IdGroup);
                    cmd.Parameters.AddWithValue("IdKind", medicineRecord.IdKind);
                    cmd.Parameters.AddWithValue("Ilness", medicineRecord.Ilness);
                    cmd.Parameters.AddWithValue("Symptom", medicineRecord.Symptom);
                    cmd.Parameters.AddWithValue("Register", registro);
                    cmd.Parameters.AddWithValue("Notes", medicineRecord.Notes);
                    cmd.Parameters.AddWithValue("Status", medicineRecord.Status);
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