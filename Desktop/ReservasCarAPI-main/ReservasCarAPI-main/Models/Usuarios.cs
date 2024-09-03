using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasCarAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El Apellido no puede exceder los 50 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El User es requerido.")]
        [StringLength(20, ErrorMessage = "El nombre de usuario no puede exceder los 20 caracteres.")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;    

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono electrónico es requerido.")]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string Direccion { get; set; } = string.Empty;

        public string Foto {  get; set; } = string.Empty;

        //claves FK
        public int Id_roles { get; set; }
        //[ForeignKey(nameof(Id_roles))]
        //public Roles roles { get; set; }
    }
}
