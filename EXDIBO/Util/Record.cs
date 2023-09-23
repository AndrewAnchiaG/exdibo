namespace EXDIBO.Util
{
    public class Record
    {

        public int? IdRecord { get; set; }

        public DateTime? RegisterRecord { get; set; }

        public string? Comment { get; set; } 

        // Bovine

        public int? IdBovine { get; set; }

        public int? Number { get; set; }

        public string? Earring { get; set; }

        public int? IdMother { get; set; } // Mother

        public string? Mother { get; set; } // Mother

        public int? IdFather { get; set; } // Father

        public string? Father { get; set; }

        public int? IdBreed { get; set; } // Race

        public string? Breed { get; set; } // Race

        public int? IdFarm { get; set; }

        public string? Farm { get; set; }

        public int? IdGroup { get; set; }

        public string? Group { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; } //Genero

        public DateTime Born { get; set; } //  Nacio

        public int? ProductionMilk { get; set; }  // Prodduccion Lactea

        public int? Birth { get; set; } //Hijos

        public bool? Pregnant { get; set; }

        public DateTime Ovulation { get; set; }

        public int? OvulationTimes { get; set; }

        public Double? StartWeight { get; set; }

        public Double? Weight { get; set; }
   
        public Double? FinalWeight { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime DischargeDate { get; set; }      

        public Double? Price { get; set; }

        public string? Notes { get; set; }

        public bool Discards { get; set; }

        public bool Status { get; set; }

        // Medicine

        public int? IdMedicine { get; set; }

        public string? Medicine { get; set; }

        public int? IdKind { get; set; }

        public string? Kind { get; set; }        

        public string? Apply { get; set; } // Administration: Subcutanea, Intravenosa, Intramuscular

        public string? Via { get; set; } // Use/Way: , injectable , Tópic , External, .... 

        public int? Dose { get; set; } // CC or ML 

        public int? Often { get; set; } // Frecuency: Every 6/H 8/H 12/H

        public int? Times { get; set; } // For: 3 Times 

        public int? Withdrawal { get; set; } // For: 30 Days 

        public string? Contraindication { get; set; } // No Compatible 

        public string? Indication { get; set; }

        // User

        public int? IdUser { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
