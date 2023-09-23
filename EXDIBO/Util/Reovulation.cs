namespace EXDIBO.Util
{
    public class Reovulation
    {

        public int? Id { get; set; }

        public int? MotherId { get; set; }

        public int? MotherNumber { get; set; }

        public string? MotherEarring { get; set; }

        public string? MotherName { get; set; }

        public int? FatherId { get; set; }

        public int? FatherNumber { get; set; }

        public string? FatherEarring { get; set; }

        public string? FatherName { get; set; }

        public int? IdBreed { get; set; }

        public string? Breed { get; set; }

        public int? IdFarm { get; set; }

        public string? Farm { get; set; }

        public int? IdGroup { get; set; }

        public string? Group { get; set; }

        public DateTime Register { get; set; }

        public DateTime Ovulation { get; set; }

        public bool? Status { get; set; }
    }
}
