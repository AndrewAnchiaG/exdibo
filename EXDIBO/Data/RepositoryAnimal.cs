using EXDIBO.Util;
using System.Data.SqlClient;
using System.Data;

namespace EXDIBO.Data
{
    public class RepositoryAnimal
    {
        private Breed FillBreed(SqlDataReader dr)
        {
            Breed raza = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Purpose = dr["Purpose"].ToString(),
                Genetics = dr["Genetics"].ToString(),
                Status = Convert.ToBoolean(dr["Status"].ToString())
            };
            return raza;
        }

        public Bovine FillBovine(SqlDataReader dr)
        {
            Bovine animal = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                IdMother = Convert.ToInt32(dr["IdMother"]),
                IdFather = Convert.ToInt32(dr["IdFather"]),
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

        public Detail FillDetail(SqlDataReader dr)
        {
            Detail bovinaDetail = new()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Number = Convert.ToInt32(dr["Number"]),
                Earring = dr["Earring"].ToString(),
                IdMother = Convert.ToInt32(dr["IdMother"]),
                MotherNumber = Convert.ToInt32(dr["MotherNumber"]),
                Mother = dr["Mother"].ToString(),
                MotherGender = dr["MotherGender"].ToString(),
                MotherBreed = dr["MotherBreed"].ToString(),
                IdFather = Convert.ToInt32(dr["IdFather"]),
                FatherNumber = Convert.ToInt32(dr["FatherNumber"]),
                Father = dr["Father"].ToString(),
                FatherGender = dr["FatherGender"].ToString(),
                FatherBreed = dr["FatherBreed"].ToString(),
                IdBreed = Convert.ToInt32(dr["IdBreed"]),
                Breed = dr["Breed"].ToString(),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                Farm = dr["Farm"].ToString(),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                Group = dr["Group"].ToString(),
                Name = dr["Name"].ToString(),
                Gender = dr["Gender"].ToString(),
                Brand = dr["Brand"].ToString(),
                Born = Convert.ToDateTime(dr["Born"]),
                ProductionMilk = Convert.ToInt32(dr["ProductionMilk"]),
                Birth = Convert.ToInt32(dr["Birth"]),
                Pregnant = Convert.ToBoolean(dr["Pregnant"].ToString()),
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
            return bovinaDetail;
        }

        public List<Breed> GetBreeds()
        {
            var breedlist = new List<Breed>();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_breed_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    breedlist.Add(FillBreed(dr));
                }
            }
            return breedlist;
        }

        public bool SaveBovine(Bovine Animal)
        {
            bool result;
            try
            {

                DateTime time = DateTime.Now;
                string Born = Animal.Born.Year + "-" + Animal.Born.Month + "-" + Animal.Born.Day + " " + time.Hour + ":" + time.Minute + ":" + time.Second + ".000";
                string Admision = Animal.AdmissionDate.Year + "-" + Animal.AdmissionDate.Month + "-" + Animal.AdmissionDate.Day + " " + time.Hour + ":" + time.Minute + ":" + time.Second + ".000";
                string Discharge = Animal.DischargeDate.Year + "-" + Animal.DischargeDate.Month + "-" + Animal.DischargeDate.Day + " " + time.Hour + ":" + time.Minute + ":" + time.Second + ".000";
                string Ovulation = Animal.Ovulation.Year + "-" + Animal.Ovulation.Month + "-" + Animal.Ovulation.Day + " " + time.Hour + ":" + time.Minute + ":" + time.Second + ".000";

                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_bovine", sqlconn);

                    cmd.Parameters.AddWithValue("Number", Animal.Number);
                    cmd.Parameters.AddWithValue("Earring", Animal.Earring);
                    cmd.Parameters.AddWithValue("IdMother", Animal.IdMother);
                    cmd.Parameters.AddWithValue("IdFather", Animal.IdFather);
                    cmd.Parameters.AddWithValue("IdBreed", Animal.IdBreed);
                    cmd.Parameters.AddWithValue("IdFarm", Animal.IdFarm);
                    cmd.Parameters.AddWithValue("IdGroup", Animal.IdGroup);
                    cmd.Parameters.AddWithValue("Brand", Animal.Brand);
                    cmd.Parameters.AddWithValue("Name", Animal.Name);
                    cmd.Parameters.AddWithValue("Gender", Animal.Gender);
                    cmd.Parameters.AddWithValue("Born", Born);
                    cmd.Parameters.AddWithValue("ProductionMilk", Animal.ProductionMilk);
                    cmd.Parameters.AddWithValue("Pregnant", Animal.Pregnant);
                    cmd.Parameters.AddWithValue("Birth", Animal.Birth);
                    cmd.Parameters.AddWithValue("Ovulation", Ovulation);
                    cmd.Parameters.AddWithValue("OvulationTimes", Animal.OvulationTimes);
                    cmd.Parameters.AddWithValue("StartWeight", Animal.StartWeight);
                    cmd.Parameters.AddWithValue("Weight", Animal.Weight);
                    cmd.Parameters.AddWithValue("FinalWeight", Animal.FinalWeight);
                    cmd.Parameters.AddWithValue("AdmissionDate", Admision);
                    cmd.Parameters.AddWithValue("DischargeDate", Discharge);
                    cmd.Parameters.AddWithValue("Price", Animal.Price);
                    cmd.Parameters.AddWithValue("Notes", Animal.Notes);
                    cmd.Parameters.AddWithValue("Discards", Animal.Discards);
                    cmd.Parameters.AddWithValue("Status", Animal.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public bool SaveOvulation(Ovulation Ovulation)
        {
            string register = Ovulation.Register.Year + "-" + Ovulation.Register.Month + "-" + Ovulation.Register.Day + " " + Ovulation.Register.Hour + ":" + Ovulation.Register.Minute + ":" + Ovulation.Register.Second + ".000";

            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_ovulation", sqlconn);
                    cmd.Parameters.AddWithValue("IdMother", Ovulation.IdMother);
                    cmd.Parameters.AddWithValue("IdFather", Ovulation.IdFather);
                    cmd.Parameters.AddWithValue("IdBreed", Ovulation.IdBreed);
                    cmd.Parameters.AddWithValue("IdFarm", Ovulation.IdFarm);
                    cmd.Parameters.AddWithValue("IdGroup", Ovulation.IdGroup);
                    cmd.Parameters.AddWithValue("Register", Ovulation.Register);
                    cmd.Parameters.AddWithValue("Status", Ovulation.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public bool SaveProduction(Production MilkProduction)  // TODO : SAVE PRODUCCTION CORRECT
        {
            bool result;
            string register = MilkProduction.Register.Year + "-" + MilkProduction.Register.Month + "-" + MilkProduction.Register.Day + " " + MilkProduction.Register.Hour + ":" + MilkProduction.Register.Minute + ":" + MilkProduction.Register.Second + ".000";
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_production", sqlconn);
                    cmd.Parameters.AddWithValue("Name", MilkProduction.Name);
                    cmd.Parameters.AddWithValue("IdBovine", MilkProduction.IdBovine);
                    cmd.Parameters.AddWithValue("IdFarm", MilkProduction.IdFarm);
                    cmd.Parameters.AddWithValue("IdGroup", MilkProduction.IdGroup);
                    cmd.Parameters.AddWithValue("Output", MilkProduction.Output);
                    cmd.Parameters.AddWithValue("Register", register);
                    cmd.Parameters.AddWithValue("Status", MilkProduction.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public List<Bovine> GetAllBovine()
        {
            var Animallist = new List<Bovine>();
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_bovine_list", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Animallist.Add(FillBovine(dr));
                }
            }
            return Animallist;
        }

        public List<Bovine> GetBovineByErringOrName(string Clave)
        {
            List<Bovine> animals = new List<Bovine>();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_search_bovine_by_earring_or_name", connection);
                cmd.Parameters.AddWithValue("Clave", Clave);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    animals.Add(FillBovine(dr));
                }
            }
            if (animals.Count < 1) { animals = null; }
            return animals;
        }



        public Bovine GetByAnimalId(int IdBovine)
        {
            Bovine animal = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_bovine_by_id", connection);
                cmd.Parameters.AddWithValue("Id", IdBovine);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    animal = FillBovine(dr);
                }
            }
            return animal;
        }

        public bool EditarAnimal(Bovine Animal)
        {
            bool result;
            try
            {

                string Born = Animal.Born.Year + "-" + Animal.Born.Month + "-" + Animal.Born.Day + " 00:00:00.000";
                string Admision = Animal.AdmissionDate.Year + "-" + Animal.AdmissionDate.Month + "-" + Animal.AdmissionDate.Day + " 00:00:00.000";
                string Discharge = Animal.DischargeDate.Year + "-" + Animal.DischargeDate.Month + "-" + Animal.DischargeDate.Day + " 00:00:00.000";
                string Ovulation = Animal.Ovulation.Year + "-" + Animal.Ovulation.Month + "-" + Animal.Ovulation.Day + " 00:00:00.000";

                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_bovine", sqlconn);
                    cmd.Parameters.AddWithValue("Id", Animal.Id);
                    cmd.Parameters.AddWithValue("Number", Animal.Number);
                    cmd.Parameters.AddWithValue("Earring", Animal.Earring);
                    cmd.Parameters.AddWithValue("IdMother", Animal.IdMother);
                    cmd.Parameters.AddWithValue("IdFather", Animal.IdFather);
                    cmd.Parameters.AddWithValue("IdBreed", Animal.IdBreed);
                    cmd.Parameters.AddWithValue("IdFarm", Animal.IdFarm);
                    cmd.Parameters.AddWithValue("IdGroup", Animal.IdGroup);
                    cmd.Parameters.AddWithValue("Brand", Animal.Brand);
                    cmd.Parameters.AddWithValue("Name", Animal.Name);
                    cmd.Parameters.AddWithValue("Gender", Animal.Gender);
                    cmd.Parameters.AddWithValue("Born", Born);
                    cmd.Parameters.AddWithValue("ProductionMilk", Animal.ProductionMilk);
                    cmd.Parameters.AddWithValue("Pregnant", Animal.Pregnant);
                    cmd.Parameters.AddWithValue("Birth", Animal.Birth);
                    cmd.Parameters.AddWithValue("Ovulation", Ovulation);
                    cmd.Parameters.AddWithValue("OvulationTimes", Animal.OvulationTimes);
                    cmd.Parameters.AddWithValue("StartWeight", Animal.StartWeight);
                    cmd.Parameters.AddWithValue("Weight", Animal.Weight);
                    cmd.Parameters.AddWithValue("FinalWeight", Animal.FinalWeight);
                    cmd.Parameters.AddWithValue("AdmissionDate", Admision);
                    cmd.Parameters.AddWithValue("DischargeDate", Discharge);
                    cmd.Parameters.AddWithValue("Price", Animal.Price);
                    cmd.Parameters.AddWithValue("Notes", Animal.Notes);
                    cmd.Parameters.AddWithValue("Discards", Animal.Discards);
                    cmd.Parameters.AddWithValue("Status", Animal.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public Bovine GetBovineByNumber(int Number)
        {
            Bovine animal = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_bovine_by_number", connection);
                cmd.Parameters.AddWithValue("num", Number);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    animal = FillBovine(dr);
                }
            }
            return animal;
        }

        public Detail GetBovineDetails(int IdNumber)
        {
            Detail animalDetail = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_details_of_bovine_by_id", connection);
                cmd.Parameters.AddWithValue("bovine", IdNumber);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    animalDetail = FillDetail(dr);
                }
            }
            return animalDetail;
        }

        public bool StatusAnimal(int Id, bool Status)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_status_bovine", sqlconn);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.Parameters.AddWithValue("Status", Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public bool UpdateBovineProduction(Production MilkProduction)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_bovine_production", sqlconn);
                    cmd.Parameters.AddWithValue("Production", MilkProduction.Output);
                    cmd.Parameters.AddWithValue("IdBovine", MilkProduction.IdBovine);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private Reovulation FillGestacion(SqlDataReader dr)
        {
            Reovulation ovulation = new Reovulation()
            {
                Id = Convert.ToInt32(dr["Id"]),
                MotherId = Convert.ToInt32(dr["MotherId"]),
                MotherNumber = Convert.ToInt32(dr["MotherNumber"]),
                MotherEarring = Convert.ToString(dr["MotherEarring"]),
                MotherName = Convert.ToString(dr["MotherName"]),
                FatherId = Convert.ToInt32(dr["FatherId"]),
                FatherNumber = Convert.ToInt32(dr["FatherNumber"]),
                FatherEarring = Convert.ToString(dr["FatherEarring"]),
                FatherName = Convert.ToString(dr["FatherName"]),
                IdBreed = Convert.ToInt32(dr["IdBreed"]),
                Breed = Convert.ToString(dr["BreedName"]),
                IdFarm = Convert.ToInt32(dr["IdFarm"]),
                Farm = Convert.ToString(dr["FarmName"]),
                IdGroup = Convert.ToInt32(dr["IdGroup"]),
                Group = Convert.ToString(dr["GroupName"]),
                Register = Convert.ToDateTime(dr["Register"]),
                Ovulation = Convert.ToDateTime(dr["Ovulation"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return ovulation;
        }

        public List<Reovulation> GetGestation(DateTime Desde, DateTime Hasta)
        {
            List<Reovulation> gestacion = new();
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_monthly_gestation", connection);
                cmd.Parameters.AddWithValue("Desde", Desde);
                cmd.Parameters.AddWithValue("Hasta", Hasta);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gestacion.Add(FillGestacion(dr));
                }
            }
            if (gestacion.Count <= 0) { gestacion = null; }
            return gestacion;
        }


        public bool UpdateOvulationStatus(int id, bool status)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_ovulation_status", sqlconn);
                    cmd.Parameters.AddWithValue("IdOvulation", id);
                    cmd.Parameters.AddWithValue("Gestation", status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool UpdateBovinePregnant(int id, bool status)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_bovine_pregnant", sqlconn);
                    cmd.Parameters.AddWithValue("IdBovine", id);
                    cmd.Parameters.AddWithValue("Gestation", status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }



        public bool UpdateBovineOvulation(bool gestation, DateTime ovulation, int idBovine)
        {
            bool result;
            string register = ovulation.Year + "-" + ovulation.Month + "-" + ovulation.Day + " " + ovulation.Hour + ":" + ovulation.Minute + ":" + ovulation.Second + ".000";

            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_bovine_ovulation", sqlconn);
                    cmd.Parameters.AddWithValue("Gestation", gestation);
                    cmd.Parameters.AddWithValue("Ovulation", ovulation);
                    cmd.Parameters.AddWithValue("IdBovine", idBovine);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public int SuggestedNumber()
        {
            var number = 0;
            var conn = new DBContext();
            using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
            {
                sqlconn.Open();
                SqlCommand cmd = new("sp_suggested_number", sqlconn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    number = Convert.ToInt32(dr["Number"]);
                }
            }
            return number + 1;
        }

        public bool UpdateBovineBirth(int id)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_bovine_births", sqlconn);
                    cmd.Parameters.AddWithValue("IdAnimal", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        public ProductionReport GetDealyProductionById(int Id)
        {
            ProductionReport report = null;
            var conn = new DBContext();
            using (var connection = new SqlConnection(conn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new("sp_production_by_id", connection);
                cmd.Parameters.AddWithValue("IdProduction", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    report = new ProductionReport()
                    {
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
                    };
                }
            }
            return report;
        }


        public bool EstadoProduccion(int Id, bool Status)
        {
            bool result;
            try
            {
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_status_production", sqlconn);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.Parameters.AddWithValue("Status", Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }

        public bool UpdateBovineProduction(ProductionReport production)
        { 
            bool result;
            try
            {
                string register = production.Register.Year + "-" + production.Register.Month + "-" + production.Register.Day + " " + production.Register.Hour + ":" + production.Register.Minute + ":" + production.Register.Second + ".000";
                var conn = new DBContext();
                using (var sqlconn = new SqlConnection(conn.GetConnectionString()))
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_production", sqlconn);
                    cmd.Parameters.AddWithValue("Id", production.Id);
                    cmd.Parameters.AddWithValue("Name", production.Codigo);
                    cmd.Parameters.AddWithValue("IdBovine", production.IdBovine);
                    cmd.Parameters.AddWithValue("Output", production.Production);
                    cmd.Parameters.AddWithValue("Register", register);
                    cmd.Parameters.AddWithValue("Status", production.Status);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
