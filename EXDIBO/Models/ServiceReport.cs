using EXDIBO.Util;
using EXDIBO.Data;


namespace EXDIBO.Models
{
    public class ServiceReport
    {
        public List<PregnantReport> PregnantReport (DateTime From, DateTime To)
        {
            return new RepositoryReport().PregnantReport(From, To);
        }

        public List<BovineReport> BornReport(DateTime From, DateTime To) {
            return new RepositoryReport().BornReport(From, To);
        }

        public List<Bovine> DiscardReport(DateTime From, DateTime To)
        {
            return new RepositoryReport().DiscardReport(From, To);
        }

        public List<SeriePastel> BornByMonthReport(DateTime From, DateTime To)
        {
            return new RepositoryReport().BornByMonthReport(From, To);
        }
    
        public List<WithdrawalReport> WithdrawalReport(DateTime From, DateTime To)
        {
            return new RepositoryReport().WithdrawalReport(From, To);
        }

        public List<WithdrawalReport> ImplantReport(DateTime From, DateTime To)
        {
            return new RepositoryReport().ImplantReport(From, To);
        }

        public Serie GetPregnancy(DateTime From, DateTime To) 
        {
            return new RepositoryReport().GetPregnancy(From, To);
        }

        public List<Born> GetBornByMonth(DateTime From, DateTime To)
        {
            return new RepositoryReport().GetBornByMonth(From, To);
        }


        public List<ProductionReport> GetDealyProductionFromTo (DateTime From, DateTime To)
        {
            return new RepositoryReport().GetDealyProductionFromTo(From, To);
        }

        public Production GetReportProductionAverage(DateTime From, DateTime To)
        {
            return new RepositoryReport().GetReportProductionAverage(From, To);
        }
    }
}
