namespace EXDIBO.Util
{
    public class WithdrawalReport
    {
        public int? Number { get; set; } // N cow

        public string? Bovine { get; set; } // Name Caw

        public string? Farm { get; set; }

        public string? Group { get; set; }

        public string? Name { get; set; }

        public string? Kind { get; set; }

        public string? Apply { get; set; } // Administration: Subcutanea, Intravenosa, Intramuscular

        public int? Times { get; set; } // For: 3 Times 

        public int? Withdrawal { get; set; } // For: 30 Days 

        public DateTime Register { get; set; }

        public DateTime EndWithdrawal { get; set; }
    }
}
