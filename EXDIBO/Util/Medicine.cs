namespace EXDIBO.Util
{
    public class Medicine
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int? IdKind { get; set; } 

        public string? Kind { get; set; }

        public string? Apply { get; set; } // Administration: Subcutanea, Intravenosa, Intramuscular

        public string? Via { get; set; } // Use/Way: , injectable , Tópic , External, .... 

        public int? Dose { get; set; } // CC or ML 

        public int? Often { get; set; } // Frecuency: Every 6/H 8/H 12/H

        public int? Times { get; set; } // For: 3 Times 

        public int? Withdrawal { get; set; } // For: 30 Days 

        public string? Contraindication { get; set; } // No Compatible 

        public DateTime Register { get; set; }

        public string? Note { get; set; }

        public bool Status { get; set; }
    }
}
