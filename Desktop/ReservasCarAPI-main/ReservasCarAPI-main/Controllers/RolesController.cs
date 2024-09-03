using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCarAPI.Context;
using ReservasCarAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservasCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Cors")]
    public class RolesController : ControllerBase
    {
        private readonly AppDBContext _db;
        public RolesController(AppDBContext db)
        {
            _db = db;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<ActionResult<List<Roles>>> GetAll()
        {
            return await _db.roles.ToListAsync();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> Get(int id)
        {
            var rol = await _db.roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Roles rol)
        {
            _db.roles.Add(rol);
            await _db.SaveChangesAsync();
            return Ok("El rol se agrego correctamente");
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Roles rol, int id)
        {
            var mRol = await _db.roles.FirstOrDefaultAsync(x => x.Id == id);
            if (mRol == null)
            {
                return BadRequest("No existe ese rol");
            }
            mRol.Rol = rol.Rol;
            //mRol = rol; no funciona
            await _db.SaveChangesAsync();
            return Ok("Rol actualizada");
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rol = await _db.roles.FirstOrDefaultAsync(x => x.Id == id);
            if (rol == null)
            {
                return BadRequest("No existe el rol");
            }
            _db.roles.Remove(rol);
            await _db.SaveChangesAsync();
            return Ok("Rol eliminada");
        }
    }
}
