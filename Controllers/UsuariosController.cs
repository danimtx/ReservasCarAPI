﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservasCarAPI.Context;
using ReservasCarAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservasCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDBContext _db;

        public UsuariosController(AppDBContext db)
        {
            _db = db;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetAll()
        {
            return await _db.usuarios
                            .Include(u => u.roles)
                            .ToListAsync();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> Get(int id)
        {
            var usuario = await _db.usuarios
                                   .Include(u => u.roles)
                                   .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound("No se encontró el usuario con el ID especificado.");
            }
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuarios usuario)
        {
            // Verificar si el ID del rol existe
            var rol = await _db.roles.FindAsync(usuario.Id_roles);
            if (rol == null)
            {
                return BadRequest("El ID del rol especificado no existe.");
            }

            // Validar la contraseña
            if (!ValidarContrasena(usuario.Password))
            {
                return BadRequest("La contraseña debe tener al menos una mayúscula, un número, un símbolo y debe tener entre 8 y 16 caracteres.");
            }

            if (!ValidarUser(usuario.User))
            {
                return BadRequest("Este User ya esta en uso");
            }

            if (!ValidarCorreo(usuario.Email))
            {
                return BadRequest("El Correo ya esta en uso");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return Ok("El usuario se ha agregado correctamente.");
        }
        private bool ValidarUser(string user)
        {
            if (string.IsNullOrEmpty(user))
                return false;
            var u = _db.usuarios.FirstOrDefaultAsync(u => u.User == user);
            if(u == null)
                return true;
            return false;
        }
        private bool ValidarCorreo(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            var c = _db.usuarios.FirstOrDefaultAsync(u => u.User == email);
            if (c == null)
                return true;
            return false;
        }
        // Método para validar la contraseña
        private bool ValidarContrasena(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            // Expresión regular para:
            // - Al menos una letra mayúscula
            // - Al menos un número
            // - Al menos un símbolo especial
            // - Entre 8 y 16 caracteres
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$");
            return regex.IsMatch(password);
        }


        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Usuarios usuario, int id)
        {
            var existingUsuario = await _db.usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUsuario == null)
            {
                return NotFound("No se encontró el usuario con el ID especificado.");
            }

            // Verificar si el nuevo ID del rol existe
            var rol = await _db.roles.FindAsync(usuario.Id_roles);
            if (rol == null)
            {
                return BadRequest("El ID del rol especificado no existe.");
            }

            // Actualizar las propiedades del usuario
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.Apellido = usuario.Apellido;
            existingUsuario.User = usuario.User;
            existingUsuario.Password = usuario.Password;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Telefono = usuario.Telefono;
            existingUsuario.Direccion = usuario.Direccion;
            existingUsuario.Id_roles = usuario.Id_roles;

            await _db.SaveChangesAsync();
            return Ok("El usuario ha sido actualizado correctamente.");
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _db.usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound("No se encontró el usuario con el ID especificado.");
            }

            _db.usuarios.Remove(usuario);
            await _db.SaveChangesAsync();
            return Ok("El usuario ha sido eliminado correctamente.");
        }
    }
}
