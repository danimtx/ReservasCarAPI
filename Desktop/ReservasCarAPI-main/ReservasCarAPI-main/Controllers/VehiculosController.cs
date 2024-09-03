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
    public class VehiculosController : ControllerBase
    {
        private readonly AppDBContext _db;

        public VehiculosController(AppDBContext db)
        {
            _db = db;
        }

        // GET: api/<VehiculosController>
        [HttpGet]
        public async Task<ActionResult<List<Vehiculos>>> GetAll()
        {
            return await _db.vehiculos.ToListAsync();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculos>> Get(int id)
        {
            var vehiculo = await _db.vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound("No se encontró el vehículo con el ID especificado.");
            }
            return vehiculo;
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Vehiculos vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.vehiculos.Add(vehiculo);
            await _db.SaveChangesAsync();
            return Ok("El vehículo se ha agregado correctamente.");
        }

        [HttpPost("GuardarImagen")]
        public async Task<string> GuardarImagen([FromForm] SubirImagenApi fichero)
        {
            var ruta = string.Empty;
            if (fichero.Archivo.Length > 0)
            {
                var nombreArchivo = Guid.NewGuid().ToString() + ".jpg";
                ruta = $"wwwroot/Uploads/Vehiculos/{nombreArchivo}";
                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await fichero.Archivo.CopyToAsync(stream);
                }
            }

            //var v = await _db.vehiculos.FirstOrDefaultAsync(x => x.Id == id);
            //v.Foto = ruta;
            ruta = ruta.Replace("wwwroot/", "");
            return ruta;
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Vehiculos vehiculo, int id)
        {
            var existingVehiculo = await _db.vehiculos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVehiculo == null)
            {
                return NotFound("No se encontró el vehículo con el ID especificado.");
            }

            // Actualizar las propiedades del vehículo
            existingVehiculo.Marca = vehiculo.Marca;
            existingVehiculo.Modelo = vehiculo.Modelo;
            existingVehiculo.Categoria = vehiculo.Categoria;
            existingVehiculo.Gama = vehiculo.Gama;
            existingVehiculo.Puertas = vehiculo.Puertas;
            existingVehiculo.Traccion = vehiculo.Traccion;
            existingVehiculo.CapacidadCarga = vehiculo.CapacidadCarga;
            existingVehiculo.Cilindrada = vehiculo.Cilindrada;
            existingVehiculo.Procedencia = vehiculo.Procedencia;
            existingVehiculo.Descripcion = vehiculo.Descripcion;
            existingVehiculo.Precio = vehiculo.Precio;
            existingVehiculo.color = vehiculo.color;
            existingVehiculo.Disponibilidad = vehiculo.Disponibilidad;

            await _db.SaveChangesAsync();
            return Ok("El vehículo ha sido actualizado correctamente.");
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var vehiculo = await _db.vehiculos.FirstOrDefaultAsync(x => x.Id == id);
            if (vehiculo == null)
            {
                return NotFound("No se encontró el vehículo con el ID especificado.");
            }

            _db.vehiculos.Remove(vehiculo);
            await _db.SaveChangesAsync();
            return Ok("El vehículo ha sido eliminado correctamente.");
        }
    }
}
