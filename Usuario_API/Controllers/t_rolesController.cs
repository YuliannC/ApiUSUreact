using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usuario_API;
using Usuario_API.Models;

namespace Usuario_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_rolesController : ControllerBase
    {
        private readonly usuarioDbContext _context;

        public t_rolesController(usuarioDbContext context)
        {
            _context = context;
        }

        // GET: api/t_rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_rol>>> Gett_rol()
        {
          if (_context.t_rol == null)
          {
              return NotFound();
          }
            return await _context.t_rol.ToListAsync();
        }

        // GET: api/t_rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<t_rol>> Gett_rol(int id)
        {
          if (_context.t_rol == null)
          {
              return NotFound();
          }
            var t_rol = await _context.t_rol.FindAsync(id);

            if (t_rol == null)
            {
                return NotFound();
            }

            return t_rol;
        }

        // PUT: api/t_rol/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putt_rol(int id, t_rol t_rol)
        {
            if (id != t_rol.Rolid)
            {
                return BadRequest();
            }

            _context.Entry(t_rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_rolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/t_rol
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<t_rol>> Postt_rol(t_rol t_rol)
        {
          if (_context.t_rol == null)
          {
              return Problem("Entity set 'usuarioDbContext.t_rol'  is null.");
          }
            _context.t_rol.Add(t_rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gett_rol", new { id = t_rol.Rolid }, t_rol);
        }

        // DELETE: api/t_rol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet_rol(int id)
        {
            if (_context.t_rol == null)
            {
                return NotFound();
            }
            var t_rol = await _context.t_rol.FindAsync(id);
            if (t_rol == null)
            {
                return NotFound();
            }

            _context.t_rol.Remove(t_rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool t_rolExists(int id)
        {
            return (_context.t_rol?.Any(e => e.Rolid == id)).GetValueOrDefault();
        }
    }
}
