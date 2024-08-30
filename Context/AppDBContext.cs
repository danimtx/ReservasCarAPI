using Microsoft.EntityFrameworkCore;
using ReservasCarAPI.Models;

namespace ReservasCarAPI.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Reservas> reservas { get; set; }
    }
}
