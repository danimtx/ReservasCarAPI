using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservasCarAPI.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Monto para la reserva es requerido")]
        public float Monto { get; set; }

        [Required(ErrorMessage = "El Numero de tarjeta es requerido")]
        public string NroTarjeta { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de vencimiento de la tarjeta es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime VencimientoTarjeta { get; set; }

        //Claves FK
        public int Id_usuario { get; set; }
        //[ForeignKey(nameof(Id_usuario))]
        //public Usuarios usuarios { get; set; }

        public int Id_vechiculo { get; set; }
        //[ForeignKey(nameof(Id_vechiculo))]
        //public Vehiculos Vehiculos { get; set; }
    }
}
