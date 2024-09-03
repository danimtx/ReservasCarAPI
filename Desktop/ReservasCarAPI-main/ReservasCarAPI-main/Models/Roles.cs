using System.ComponentModel.DataAnnotations;

namespace ReservasCarAPI.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "El Rol es requerido")]
        [StringLength(50, ErrorMessage = "El Rol no puede exceder los 50 caracteres.")]
        public string Rol {  get; set; } = string.Empty;
    }
}
