using System.ComponentModel.DataAnnotations;

namespace EXDIBO.Util
{
    public class Bovine
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "El campo de número es requerido")]
        public int? Number { get; set; }

        [Required(ErrorMessage = "El campo de arete es requerido")]
        public string? Earring { get; set; }

        [Required(ErrorMessage = "El campo numero de madre es requerido")]
        public int? IdMother { get; set; } // Mother

        [Required(ErrorMessage = "El campo numero de padre es requerido")]
        public int? IdFather { get; set; } // Father

        [Required(ErrorMessage = "El campo de raza es requerido")]
        public int? IdBreed { get; set; } // Race

        [Required(ErrorMessage = "El campo de Finca es requerido")]
        public int? IdFarm { get; set; }

        [Required(ErrorMessage = "El campo de grupo es requerido")]
        public int? IdGroup { get; set; }

        [Required(ErrorMessage = "El campo de marca es requerido")]
        public string? Brand { get; set; } // Fierro - Marca

        [Required(ErrorMessage = "El campo de nombre es requerido")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El campo de genero es requerido")]
        public string? Gender { get; set; } //Genero

        [Required(ErrorMessage = "El campo de nacimiento es requerido")]
        public DateTime Born { get; set; } //  Nacio

        [Required(ErrorMessage = "El campo de producción lactea es requerido")]
        public int? ProductionMilk { get; set; }  // Prodduccion Lactea

        [Required(ErrorMessage = "El campo N°. de hijo es requerido")]
        public int? Birth { get; set; } //Hijos

        [Required(ErrorMessage = "El campo de gestación es requerido")]
        public bool? Pregnant { get; set; }

        [Required(ErrorMessage = "El campo de ovulación es requerido")]
        public DateTime Ovulation { get; set; }

        [Required(ErrorMessage = "El campo de ovulación es requerido")]
        public int? OvulationTimes { get; set; }

        [Required(ErrorMessage = "El campo de peso inicial es requerido")]
        public Double? StartWeight { get; set; }

        [Required(ErrorMessage = "El campo peso actual es requerido")]
        public Double? Weight { get; set; }

        [Required(ErrorMessage = "El campo peso final es requerido")]
        public Double? FinalWeight { get; set; }

        [Required(ErrorMessage = "El campo día de ingreso es requerido")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "El campo día de salida es requerido")]
        public DateTime DischargeDate { get; set; }

        [Required(ErrorMessage = "El campo precio es requerido")]
        public Double? Price { get; set; }

        public string? Notes { get; set; }

        public bool Discards { get; set; }

        public bool Status { get; set; }

    }
}
