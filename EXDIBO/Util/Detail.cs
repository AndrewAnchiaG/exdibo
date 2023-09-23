namespace EXDIBO.Util
{
    public class Detail
    {
        public int? Id { get; set; }

        public int? Number { get; set; }

        public string? Earring { get; set; }

        public int? IdMother { get; set; } // IdMother

        public int? MotherNumber { get; set; } // MotherNumber

        public string? Mother { get; set; } // Mother

        public string? MotherGender { get; set; } // MotherGender

        public string? MotherBreed { get; set; } // MotherBreed

        public int? IdFather { get; set; } // IdFather

        public int? FatherNumber { get; set; } // FatherNumber

        public string? Father { get; set; } // Father

        public string? FatherGender { get; set; } // FatherGender

        public string? FatherBreed { get; set; } // FatherBreed
        
        public int? IdBreed { get; set; } // Race

        public string? Breed { get; set; } // Race

        public int? IdFarm { get; set; } // IDFarm

        public string? Farm { get; set; } // Farm

        public int? IdGroup { get; set; } // IdGroup

        public string? Group { get; set; } // Group

        public string? Brand { get; set; } // Fierro - Marca
    
        public string? Name { get; set; } // NameBovine
 
        public string? Gender { get; set; } //Gender
      
        public DateTime Born { get; set; } // 

        public int? ProductionMilk { get; set; }  // Prodduccion Lactea

        public int? Birth { get; set; } //Hijos

        public bool? Pregnant { get; set; } // Yes OR No - True || False

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
    }
}
