using System.ComponentModel.DataAnnotations;

namespace EXDIBO.Util
{

    public class MedicineRecord
    {
        public int? Id { get; set; }
        [Required]
        public int? IdUser { get; set; }
        [Required]
        public int? IdMedicine { get; set; }
        [Required]
        public int? IdBovine { get; set; }
        [Required]
        public int? IdFarm { get; set; }
        [Required]
        public int? IdGroup { get; set; }
        [Required]
        public int? IdKind { get; set; }
        [Required]
        public string? Ilness { get; set; }
        [Required]
        public string? Symptom { get; set; }

        [Required]
        public DateTime? Register { get; set; }
        [Required]
        public string? Notes { get; set; }
        [Required]
        public bool? Status { get; set; }
    }
}
