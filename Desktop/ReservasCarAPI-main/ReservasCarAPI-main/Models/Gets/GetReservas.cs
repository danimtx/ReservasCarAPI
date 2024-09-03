namespace ReservasCarAPI.Models.Gets
{
    public class GetReservas
    {
        public Reservas Reservas { get; set; }

        // Claves foráneas
        //public int Id_usuario { get; set; }

        public Usuarios usuarios { get; set; } // No marcado como [Required]

        //public int Id_vechiculo { get; set; }

        public Vehiculos Vehiculos { get; set; } // No marcado como [Required]
    }
}
