using EXDIBO.Util;
using EXDIBO.Data;

namespace EXDIBO.Models
{
    public class ServiceMedicine
    {
        public List<Kind> GetKindMedicine()
        {
            return new RepositoryMedicine().GetKindMedicine();
        }

        public bool SaveMedicine(Medicine medicine) {
            return new RepositoryMedicine().SaveMedicine(medicine);
        }

        public bool SaveMedicineRecord(MedicineRecord medicineRecord)
        {
            return new RepositoryMedicine().SaveMedicineRecord(medicineRecord);
        }

        public List<Medicine> GetAllMedicine()
        {
            return new RepositoryMedicine().GetAllMedicine();
        }

        public List<Medicine> GetAllActiveMedicine()
        {
            return new RepositoryMedicine().GetAllActiveMedicine();
        }

        public List<MedicineRecord> GetRecords()
        {
            return new RepositoryMedicine().GetRecords();
        }

        public Medicine GetMedicineById(int id)
        {
            return new RepositoryMedicine().GetMedicineById(id);
        }

        public bool StatusMedicine(int Id, bool Status)
        {
            return new RepositoryMedicine().StatusMedicine(Id, Status);
        }

        public bool EditMedicine(Medicine medicine) 
        {
            return new RepositoryMedicine().EditMedicine(medicine);
        }

        public List<Record> GetRecordByBovine(int IdBovine) 
        {
            return new RepositoryMedicine().GetRecordByBovine(IdBovine);
        }

        public List<Record> GetRecordByDate(DateTime Desde, DateTime Hasta) 
        {
            return new RepositoryMedicine().GetRecordByDate(Desde, Hasta);
        }
        
        public List<Record> GetRecordByUser(int IdUser)
        {
            return new RepositoryMedicine().GetRecordByUser(IdUser);
        }

        public Record GetRecordById(int IdRecord)
        {
            return new RepositoryMedicine().GetRecordById(IdRecord);
        }

        public List<Kind> GetAllIllness() 
        {
            return new RepositoryMedicine().GetAllIllness();
        }
    }

}

