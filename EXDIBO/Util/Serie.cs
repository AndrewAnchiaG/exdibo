namespace EXDIBO.Util
{
    public class Serie
    {
        public List<string> Months { get; set; }

        public List<int> Pregnants { get; set; }

        public List<int> Emptys { get; set; }

        public List<int> Total { get; set; }

        public Serie(List<string> months, List<int> pregnants, List<int> emptys, List<int> total)
        {
            Months = months;
            Pregnants = pregnants;
            Emptys = emptys;
            Total = total;
        }

       

    }
}
