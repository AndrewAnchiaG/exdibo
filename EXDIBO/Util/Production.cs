using System.ComponentModel.DataAnnotations;

namespace EXDIBO.Util
{

    public class Production
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "Número de animal es requerido")]
        public int? IdBovine { get; set; }

        public int? IdFarm { get; set; }

        public int? IdGroup { get; set; }

        [Required(ErrorMessage = "El peso de la Producción en mililitros es requerido")]
        public double? Output { get; set; }

        [Required(ErrorMessage = "La Fecha del Registro de Producción es requerida")]
        public DateTime Register { get; set; }

        [Required(ErrorMessage = "El Estado de la Producción es requerido")]
        public bool? Status { get; set; }
    }
}
