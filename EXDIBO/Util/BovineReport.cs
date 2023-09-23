namespace EXDIBO.Util
{
    public class BovineReport
    {
        public int? Id { get; set; }

        public int? Number { get; set; }

        public string? Earring { get; set; }

        public int? IdMother { get; set; } // Mother

        public string? Mother { get; set; }

        public int? IdFather { get; set; } // Father

        public string? Father { get; set; }

        public int? IdBreed { get; set; } // Race

        public int? IdFarm { get; set; }

        public int? IdGroup { get; set; }

        public string? Brand { get; set; } // Fierro - Marca

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
    }
}
