using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCarAPI.Context;
using ReservasCarAPI.Models;
using ReservasCarAPI.Models.Gets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservasCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class ReservasController : ControllerBase
    {
        private readonly AppDBContext _db;

        public ReservasController(AppDBContext db)
        {
            _db = db;
        }

        // GET: api/<ReservasController>
        [HttpGet]
        public async Task<ActionResult<List<GetReservas>>> GetAll()
        {
            var reserva = await _db.reservas
            //.Include(r => r.usuarios)
            //.Include(r => r.Vehiculos)
                            .ToListAsync();
            List<GetReservas> listReservas = new List<GetReservas>();

            foreach (var item in reserva)
            {
                GetReservas x = new GetReservas();
                x.Reservas = item;
                x.usuarios = await _db.usuarios.FirstOrDefaultAsync(xx => xx.Id == x.Reservas.Id_usuario);
                x.Vehiculos = await _db.vehiculos.FirstOrDefaultAsync(xx => xx.Id == x.Reservas.Id_vechiculo);
                listReservas.Add(x);
            }

            return listReservas;
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReservas>> Get(int id)
        {
            var reserva = await _db.reservas
                                   //.Include(r => r.usuarios)
                                   //.Include(r => r.Vehiculos)
                                   .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound("No se encontró la reserva con el ID especificado.");
            }

            GetReservas reservation = new GetReservas();
            reservation.Reservas = reserva;
            reservation.usuarios = await _db.usuarios.FirstOrDefaultAsync(xx => xx.Id == reservation.Reservas.Id_usuario);
            reservation.Vehiculos = await _db.vehiculos.FirstOrDefaultAsync(xx => xx.Id == reservation.Reservas.Id_vechiculo);

            return reservation;
        }

        [HttpGet("ReservasUsuario")]
        public async Task<ActionResult<List<GetReservas>>> ReservasUsuario(int id)
        {
            var reserva = await _db.reservas.Where(x => x.Id_usuario == id).ToListAsync();
            List<GetReservas> listReservas = new List<GetReservas>();

            foreach (var item in reserva)
            {
                GetReservas x = new GetReservas();
                x.Reservas = item;
                x.usuarios = await _db.usuarios.FirstOrDefaultAsync(xx => xx.Id == x.Reservas.Id_usuario);
                x.Vehiculos = await _db.vehiculos.FirstOrDefaultAsync(xx => xx.Id == x.Reservas.Id_vechiculo);
                listReservas.Add(x);
            }

            return listReservas;
        }

        // POST api/<ReservasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Reservas reserva)
        {
            // Verificar si el ID del usuario existe
            var usuario = await _db.usuarios.FindAsync(reserva.Id_usuario);
            if (usuario == null)
            {
                return BadRequest("El ID del usuario especificado no existe.");
            }

            // Verificar si el ID del vehículo existe
            var vehiculo = await _db.vehiculos.FindAsync(reserva.Id_vechiculo);
            if (vehiculo == null)
            {
                return BadRequest("El ID del vehículo especificado no existe.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            vehiculo.Disponibilidad--;

            _db.reservas.Add(reserva);
            await _db.SaveChangesAsync();
            return Ok("La reserva se ha agregado correctamente.");
        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Reservas reserva, int id)
        {
            var existingReserva = await _db.reservas.FirstOrDefaultAsync(x => x.Id == id);
            if (existingReserva == null)
            {
                return NotFound("No se encontró la reserva con el ID especificado.");
            }

            // Verificar si el nuevo ID del usuario existe
            var usuario = await _db.usuarios.FindAsync(reserva.Id_usuario);
            if (usuario == null)
            {
                return BadRequest("El ID del usuario especificado no existe.");
            }

            // Verificar si el nuevo ID del vehículo existe
            var vehiculo = await _db.vehiculos.FindAsync(reserva.Id_vechiculo);
            if (vehiculo == null)
            {
                return BadRequest("El ID del vehículo especificado no existe.");
            }

            // Actualizar las propiedades de la reserva
            existingReserva.FechaInicio = reserva.FechaInicio;
            existingReserva.FechaFin = reserva.FechaFin;
            existingReserva.Estado = reserva.Estado;
            existingReserva.Monto = reserva.Monto;
            existingReserva.NroTarjeta = reserva.NroTarjeta;
            existingReserva.VencimientoTarjeta = reserva.VencimientoTarjeta;
            existingReserva.Id_usuario = reserva.Id_usuario;
            existingReserva.Id_vechiculo = reserva.Id_vechiculo;

            await _db.SaveChangesAsync();
            return Ok("La reserva ha sido actualizada correctamente.");
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reserva = await _db.reservas.FirstOrDefaultAsync(x => x.Id == id);
            if (reserva == null)
            {
                return NotFound("No se encontró la reserva con el ID especificado.");
            }

            _db.reservas.Remove(reserva);
            await _db.SaveChangesAsync();
            return Ok("La reserva ha sido eliminada correctamente.");
        }
    }
}
