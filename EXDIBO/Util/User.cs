using System.ComponentModel.DataAnnotations;

namespace EXDIBO.Util
{
   
    public class User
    {

        public int? Id { get; set; }

        [Required]
        [Range(1000, 999999)]
        public int? Code { get; set; }

        [Required(ErrorMessage ="Documento de Identidad Nacional es Requerido")]
        [DataType(DataType.Text) ]
        [StringLength(27, ErrorMessage ="El formato recomendado es 801230456" , MinimumLength = 8)]
        public string? DNI { get; set; }

        [StringLength(50, MinimumLength =2)]
        [Required(ErrorMessage = "Nombre de Usuario Requerido")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }
       
        [Required (ErrorMessage = "I Apellido de Usuario Requerido")]
        [StringLength(50, MinimumLength =2, ErrorMessage = "Apellido de Usuario Requerido")]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }
        
        [Required(ErrorMessage = "II Apellido de Usuario Requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "II Apellido de Usuario Requerido")]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [StringLength(150, ErrorMessage ="El texto no corresponde a una direccion de correo electrónico", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "La dirección proporcionada no corresponde a un correo electrónico")]
        [Required(ErrorMessage ="La dirección de correo electrónico es requerida")]
        public string? Email { get; set; }

        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$%\\^&\\*])(?=.{8,})")]

        //[StringLength(50, ErrorMessage = "La Contraseña debe contener de 8 - 50 caracteres y caracteres como - * ? ! @ # $ / () {} = . , ; :", MinimumLength=7)]
        [Required(ErrorMessage = "La Contraseña es requerida, mínimo 8 caracteres alfanuméricos mayúscula y minúscula")]
        [StringLength(60, ErrorMessage = "La Contraseña es requiere de mínimo 8 caracteres alfanuméricos mayúsculas y minúsculas ", MinimumLength = 7)]
        public string? Password { get; set; }

        [Required (ErrorMessage = "El Nacimiento del usuario es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime Birth { get; set; }

        [DataType(DataType.Text)]
        public string? Gender { get; set; }

        [DataType(DataType.Text)]
        public string? Job { get; set; }

        [Phone(ErrorMessage = "El número debe ser válido mínimo 8 dígitos")]
        [Required (ErrorMessage = "El móvil del usuario es requerido")]
        public string? Mobile { get; set; }

        [Phone(ErrorMessage = "El número debe ser válido mínimo 8 dígitos")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "El rol de usuario es requerido")]
        public string? Role { get; set; }

        [Required]
        public List<Farm>? Finca { get; set; }

        public string? Token { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }
        
        public bool? Status { get; set; }
    }
}
