using System.ComponentModel.DataAnnotations;

namespace ReservasCarAPI.Models
{
    public class Vehiculos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Marca es requerida.")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Modelo es requerido.")]
        public int Modelo { get; set; }

        [Required(ErrorMessage = "La Categoría es requerida.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Gama es requerida.")]
        public string Gama {  get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de Puertas es requerido.")]
        public int Puertas { get; set; }

        [Required(ErrorMessage = "La Tracción es requerida.")]
        public string Traccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Capacidad de carga es requerida.")]
        public string CapacidadCarga { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Cilindrada es requerida.")]
        public string Cilindrada { get; set; } = string.Empty;

        [Required(ErrorMessage = "La procedencia es requerida.")]
        public string Procedencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es requerida.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerida.")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "El color es requerida.")]
        public string color {  get; set; } = string.Empty;

        [Required(ErrorMessage = "La Disponibilidad es requerida.")]
        public int Disponibilidad { get; set; }

        public string Foto { get; set; } = string.Empty;
    }
}
