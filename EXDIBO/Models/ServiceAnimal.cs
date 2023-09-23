using EXDIBO.Util;
using EXDIBO.Data;

namespace EXDIBO.Models
{
    public class ServiceAnimal
    {
        public List<Bovine> GetAllBovine()
        {
            return new RepositoryAnimal().GetAllBovine();
        }

        public List<Bovine> GetBovineByErringOrName(string Clave)
        {
            return new RepositoryAnimal().GetBovineByErringOrName(Clave);
        }

        public Bovine GetByAnimalId(int IdBovine)
        {
            return new RepositoryAnimal().GetByAnimalId(IdBovine);
        }

        public Bovine GetBovineByNumber(int Number)
        {
            return new RepositoryAnimal().GetBovineByNumber(Number);
        }

        public bool SaveBovine(Bovine Animal)
        {
            return new RepositoryAnimal().SaveBovine(Animal);
        }


        public List<Breed> GetBreeds()
        {
            return new RepositoryAnimal().GetBreeds();
        }


        public bool SaveOvulation(Ovulation ovulation)
        {
            return new RepositoryAnimal().SaveOvulation(ovulation);
        }


        public bool SaveProduction(Production MilkProduction)
        {
            return new RepositoryAnimal().SaveProduction(MilkProduction);
        }

        public bool EditarAnimal(Bovine animal)
        {
            return new RepositoryAnimal().EditarAnimal(animal);
        }

        public Detail GetBovineDetails(int IdNumber)
        {
            return new RepositoryAnimal().GetBovineDetails(IdNumber);
        }

        public bool StatusAnimal(int id, bool Status)
        {
            return new RepositoryAnimal().StatusAnimal(id, Status);
        }

        public bool UpdateBovineProduction(Production MilkProduction)
        {
            return new RepositoryAnimal().UpdateBovineProduction(MilkProduction);
        }


        public List<Reovulation> GetGestation(DateTime Desde, DateTime Hasta)
        {
            return new RepositoryAnimal().GetGestation(Desde, Hasta);
        }


        public bool UpdateOvulationStatus(int id, bool status)
        {
            return new RepositoryAnimal().UpdateOvulationStatus(id, status);
        }

        public bool UpdateBovineOvulation(bool gestation, DateTime ovulation, int idBovine)
        {
            return new RepositoryAnimal().UpdateBovineOvulation(gestation, ovulation, idBovine);
        }

        public bool UpdateBovinePregnant(int id, bool status)
        {
            return new RepositoryAnimal().UpdateBovinePregnant(id, status);
        }

        public int SuggestedNumber()
        {
            return new RepositoryAnimal().SuggestedNumber();
        }

        public bool UpdateBovineBirth(int id)
        {
            return new RepositoryAnimal().UpdateBovineBirth(id);
        }

        public ProductionReport GetDealyProductionById(int Id) 
        {
            return new RepositoryAnimal().GetDealyProductionById(Id);
        }

        public bool EstadoProduccion(int Id, bool Status) 
        {
            return new RepositoryAnimal().EstadoProduccion(Id, Status);
        }

        public bool UpdateBovineProduction(ProductionReport production) 
        {
            return new RepositoryAnimal().UpdateBovineProduction(production);
        }
    }
}

